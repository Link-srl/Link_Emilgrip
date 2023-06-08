using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaArticoli
    {
        public int nrArticoliUltimaLetturaERP = 0;

        public void EseguiImportazione()
        {
            if (!Configurazioni.Comune_Importazione_ImportaAnagraficaArticoli)
                return;

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_ARTICOLI", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Articoli);

            nrArticoliUltimaLetturaERP = 0;
            PHA_ARTICOLI articoliERP = new PHA_ARTICOLI(query);

            if (articoliERP == null || articoliERP.RowCount == 0)
                return;

            nrArticoliUltimaLetturaERP = articoliERP.RowCount;

            Zero5.Util.Log.WriteLog("Importazione " + articoliERP.RowCount.ToString() + " PHA_ARTICOLI.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Articoli articoliPhase = new Articoli();
            articoliPhase.LoadAll();

            if (articoliERP.DataTable.Columns.Contains("DesArticolo"))
            {
                if (!articoliERP.DataTable.Columns.Contains("DesArt"))
                    articoliERP.DataTable.Columns["DesArticolo"].ColumnName = "DesArt";
            }

            Dictionary<string, string> campiDaAggiornareDefault = new Dictionary<string, string> {
                        {  articoliPhase.Fields.Descrizione.FieldName, articoliERP.Fields.Desart.FieldName},
                        {  articoliPhase.Fields.UnitaDiMisura.FieldName, articoliERP.Fields.Ummag.FieldName},
                    };

            Dictionary<string, string> dicCampiDaAggiornare = Common.GetMappingDictionaryFromJson("AggiornaCampi_Articoli_Da_PHAARTICOLI", campiDaAggiornareDefault);

            while (!articoliERP.EOF)
            {
                string codArticoloERP = Common.GetCodiceArticoloFromEsolver(articoliERP.Codart, articoliERP.Varianteart);

                if (articoliPhase.CodiceArticolo != codArticoloERP)
                    articoliPhase.MoveToNextFieldValue(articoliPhase.Fields.CodiceArticolo, codArticoloERP, true);

                if (articoliPhase.EOF)
                {
                    articoliPhase.AddNewAndNewID();

                    articoliPhase.CodiceArticolo = codArticoloERP;
                    articoliPhase.CodiceEsterno = articoliERP.Codart;
                    articoliPhase.DataOraCreazione = DateTime.Now;
                    articoliPhase.Save();

                    Zero5.Util.Log.WriteLog("\tCreato articolo " + articoliPhase.CodiceEsterno);
                }

                Common.AllineaCampiDaOggettoDati(articoliPhase, articoliERP, dicCampiDaAggiornare);

                Zero5.Data.Layer.Articoli.eTipoArticolo tipoArticoloERP = Articoli.eTipoArticolo.Default;
                switch (articoliERP.Tipoart)
                {
                    case 0:
                        tipoArticoloERP = Articoli.eTipoArticolo.MateriaPrima;
                        break;
                    case 1:
                        tipoArticoloERP = Articoli.eTipoArticolo.Semilavorato;
                        break;
                    case 2:
                        tipoArticoloERP = Articoli.eTipoArticolo.Kit;
                        break;
                    case 3:
                        tipoArticoloERP = Articoli.eTipoArticolo.ProdottoFinito;
                        break;
                    case 4:
                        tipoArticoloERP = Articoli.eTipoArticolo.ContenitoreARendere;
                        break;
                    case 5:
                        tipoArticoloERP = Articoli.eTipoArticolo.ImballoAPerdere;
                        break;
                    case 6:
                        tipoArticoloERP = Articoli.eTipoArticolo.MaterialeAusiliario;
                        break;
                    case 7:
                        tipoArticoloERP = Articoli.eTipoArticolo.Impianto;
                        break;
                    case 8:
                        tipoArticoloERP = Articoli.eTipoArticolo.ComponenteFittizio;
                        break;
                    default:
                        tipoArticoloERP = Articoli.eTipoArticolo.Default;
                        break;
                };

                bool obsoletoERP = false;
                if (articoliERP.Datafinevalidita > new DateTime(1990, 1, 1) && articoliERP.Datafinevalidita < DateTime.Now)
                    obsoletoERP = true;

                //TODO: importare um peso netto così da gestire oltre KG e GR
                double pesoNettoUnitarioERP = 0;
                if (articoliERP.Umpesonettounit == "KG")
                    pesoNettoUnitarioERP = articoliERP.Pesonettounit;
                else if (articoliERP.Umpesonettounit == "GR")
                    pesoNettoUnitarioERP = articoliERP.Pesonettounit * 1000;

                //TODO: controllare il significato dell'oggetto sopra

                Common.AllineaCampiDaValori(articoliPhase, new Dictionary<Zero5.Data.Filter.Field, object> {
                    { articoliPhase.Fields.TipoArticolo, tipoArticoloERP},
                    { articoliPhase.Fields.Obsoleto, obsoletoERP},
                    { articoliPhase.Fields.PesoNetto, pesoNettoUnitarioERP},
                //TODO: aggiungere l'extstring01 al DB e poi inserire al suo interno l'unità per collo
                    { articoliPhase.Fields.extDouble01, articoliERP.Unitapercollo}
                });

                //TODO: UnitàPerCollo ColliPerStrato StratoPerUnitaCarico

                if (articoliPhase.RowChangedCount > 0)
                    articoliPhase.Save();

                articoliERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Articoli. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
