using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;

namespace ScambioDati
{
    class ImportaAlias
    {
        public int nrAliasUltimaLetturaERP = 0;

        public void EseguiImportazione()
        {
            if (!Configurazioni.Comune_Importazione_ImportaAnagraficaArticoli)
                return;

            nrAliasUltimaLetturaERP = 0;

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_ARTICOLI WHERE UmMag <> UmMag2 and UmMag2 <> ''", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Alias);
            PHA_ARTICOLI aliasERP = new PHA_ARTICOLI(query);

            if (aliasERP == null || aliasERP.RowCount == 0)
                return;

            nrAliasUltimaLetturaERP = aliasERP.RowCount;

            Zero5.Util.Log.WriteLog("Importazione " + aliasERP.RowCount.ToString() + " ALIAS da PHA_ARTICOLI.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Data.Layer.Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            Zero5.Data.Layer.AliasArticoliClientiFornitori aliasPhase = new AliasArticoliClientiFornitori();
            aliasPhase.LoadAll();

            while (!aliasERP.EOF)
            {
                if (aliasERP.Ummag != aliasERP.Ummag2 && aliasERP.Ummag2 != "")
                {

                    string codArticoloERP = Common.GetCodiceArticoloFromEsolver(aliasERP.Codart, aliasERP.Varianteart);
                    string codAliasERP = codArticoloERP + "_" + aliasERP.Ummag + "_" + aliasERP.Ummag2;

                    if (aliasPhase.CodiceAlias != codAliasERP)
                        aliasPhase.MoveToNextFieldValue(aliasPhase.Fields.CodiceAlias, codAliasERP, true);

                    if (aliasPhase.EOF)
                    {
                        aliasPhase.AddNewAndNewID();

                        if (articoliPhase.CodiceArticolo != aliasERP.Codart)
                            articoliPhase.Load(articoliPhase.Fields.CodiceArticolo == codArticoloERP);

                        aliasPhase.IDArticolo = articoliPhase.IDArticolo;
                        aliasPhase.CodiceAlias = codAliasERP;
                        aliasPhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreato alias " + aliasPhase.CodiceAlias);
                    }

                    Common.AllineaCampiDaOggettoDati(aliasPhase, aliasERP, new Dictionary<string, string> {
                        {  aliasPhase.Fields.Descrizione.FieldName, aliasERP.Fields.Desart.FieldName},
                        {  aliasPhase.Fields.UnitaDiMisura.FieldName, aliasERP.Fields.Ummag2.FieldName},
                    });

                    Zero5.Data.Layer.AliasArticoliClientiFornitori.eTipoConversione tipoConversioneERP = AliasArticoliClientiFornitori.eTipoConversione.Moltiplica;
                    double fattoreConversioneERP = 0;

                    if (aliasERP.Coeffum2magnum == 1 && aliasERP.Coeffum2magden != 1)
                    {
                        tipoConversioneERP = AliasArticoliClientiFornitori.eTipoConversione.Dividi;
                        fattoreConversioneERP = aliasERP.Coeffum2magden;
                    }
                    else
                    {
                        tipoConversioneERP = AliasArticoliClientiFornitori.eTipoConversione.Moltiplica;
                        fattoreConversioneERP = aliasERP.Coeffum2magnum / aliasERP.Coeffum2magden;
                    }

                    Common.AllineaCampiDaValori(aliasPhase, new Dictionary<Zero5.Data.Filter.Field, object> {
                    { aliasPhase.Fields.TipoConversione, tipoConversioneERP},
                    { aliasPhase.Fields.FattoreDiConversione, fattoreConversioneERP}
                });

                    if (aliasPhase.RowChangedCount > 0)
                        aliasPhase.Save();
                }

                aliasERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Alias. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
