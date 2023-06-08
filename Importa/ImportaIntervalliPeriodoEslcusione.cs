using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaIntervalliPeriodoEslcusione
    {
        public void EseguiImportazione()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_GGCHIUSURA WHERE [data] >= convert(date, GETDATE())", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_GiorniChiusura);

            PHA_GGCHIUSURA esclusioniERP = new PHA_GGCHIUSURA(query);

            if (esclusioniERP == null || esclusioniERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + esclusioniERP.RowCount.ToString() + " PHA_GGCHIUSURA");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            IntervalliPeriodoEsclusione esclusioniPhase = new IntervalliPeriodoEsclusione();
            esclusioniPhase.LoadAll();

            Periodi periodiPhase = new Periodi();
            periodiPhase.LoadAll();

            HashSet<int> lstIDEsclusioniVerificate = new HashSet<int>();

            while (!periodiPhase.EOF)
            {
                esclusioniERP.MoveFirst();
                while (!esclusioniERP.EOF)
                {
                    esclusioniPhase.MoveFirst();
                    while (!esclusioniPhase.EOF)
                    {
                        if (esclusioniPhase.IDPeriodo == periodiPhase.IDPeriodo &&
                            esclusioniPhase.DataInizio == esclusioniERP.Data &&
                            esclusioniPhase.DataFine == esclusioniERP.Data)
                            break;
                        esclusioniPhase.MoveNext();
                    }

                    if (esclusioniPhase.EOF)
                    {
                        esclusioniPhase.AddNewAndNewID();
                        esclusioniPhase.IDPeriodo = periodiPhase.IDPeriodo;
                        esclusioniPhase.DataInizio = esclusioniERP.Data;
                        esclusioniPhase.DataFine = esclusioniERP.Data;
                    }

                    lstIDEsclusioniVerificate.Add(esclusioniPhase.IDIntervalloPeriodo);

                    esclusioniERP.MoveNext();
                }

                if (esclusioniPhase.RowChangedCount > 0)
                    esclusioniPhase.Save();

                periodiPhase.MoveNext();
            }

            esclusioniPhase.MoveFirst();
            while (!esclusioniPhase.EOF)
            {
                if (esclusioniPhase.DataInizio >= DateTime.Now.Date)
                    if (!lstIDEsclusioniVerificate.Contains(esclusioniPhase.IDIntervalloPeriodo))
                        esclusioniPhase.DeleteRow();
                esclusioniPhase.MoveNext();
            }

            if (esclusioniPhase.RowChangedCount > 0)
                esclusioniPhase.Save();

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Intervalli Periodo Esclusione. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
