using Shared;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Zero5.Data.Layer;

namespace ScambioDati
{
    class ImportaCampiAggiuntiviOrdini
    {
        public void EseguiImportazioneCampiAggiuntiviOrdini()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_ODP", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_CampiAggiuntiviOrdini);

            PHA_ODP ordiniERP = new PHA_ODP(query);

            if (ordiniERP == null || ordiniERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + ordiniERP.RowCount.ToString() + " " + ordiniERP.TableName);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            OrdiniProduzione ordiniPhase = new OrdiniProduzione();
            ordiniPhase.LoadNone();

            Dictionary<string, string> campiDaVariareOrdiniDefault = new Dictionary<string, string> {
                            { ordiniPhase.Fields.DataOrdine.FieldName,ordiniERP.Fields.Dataregistrazione.FieldName},
                            { ordiniPhase.Fields.RevisioneArticolo.FieldName,ordiniERP.Fields.Varianteart.FieldName},
                            { ordiniPhase.Fields.Articolo.FieldName, ordiniERP.Fields.Codart.FieldName},
                            { ordiniPhase.Fields.Note.FieldName, ordiniERP.Fields.Notaartcli.FieldName},
                        };

            Dictionary<string, string> dicCampiDaAggiornare = Common.GetMappingDictionaryFromJson("AggiornaCampi_Ordini_Da_PHAODP", campiDaVariareOrdiniDefault);

            if (dicCampiDaAggiornare.Count == 0)
                return;

            List<int> lstIDOrdiniAggiornati = new List<int>();

            while (!ordiniERP.EOF)
            {
                try
                {
                    string codiceOrdineERP = ordiniERP.Rifodp;
                    string codiceEsternoOrdineERP = ordiniERP.Iddocumento.ToString() + ";" + ordiniERP.Idriga.ToString();

                    if (ordiniPhase.CodiceEsterno != codiceEsternoOrdineERP)
                    {
                        System.Threading.Thread.Sleep(10);
                        ordiniPhase.Load(ordiniPhase.Fields.CodiceEsterno == codiceEsternoOrdineERP);
                    }

                    if (!ordiniPhase.EOF)
                    {
                        Common.AllineaCampiDaOggettoDati(ordiniPhase, ordiniERP, dicCampiDaAggiornare);
                        if (ordiniPhase.RowChangedCount > 0)
                            ordiniPhase.Save();

                        if (!lstIDOrdiniAggiornati.Contains(ordiniPhase.IDOrdineProduzione))
                            lstIDOrdiniAggiornati.Add(ordiniPhase.IDOrdineProduzione);

                        if (ordiniERP.RowIndex % 100 == 0)
                            Zero5.Util.Log.WriteLog("Righe analizzate " + ordiniERP.RowIndex.ToString() + ".");
                    }
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Riga " + ordiniERP.RowIndex.ToString() + ": Errore non gestito ordine " + ordiniERP.Rifodp + Environment.NewLine + ex.Message);
                }
                ordiniERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Campi Aggiunto Ordini. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
