using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static ScambioDati.ImportaIntervalliPeriodo;
using static ScambioDati.Utility.Utility;
using Shared;

namespace ScambioDati
{
    public class ImportaIntervalliPeriodo
    {

        public void EseguiImportazione()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_TURNI", Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Turni);

            Zero5.Data.Layer.PHA_TURNI periodiIntervalliERP = new Zero5.Data.Layer.PHA_TURNI(query);

            if (periodiIntervalliERP == null || periodiIntervalliERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + periodiIntervalliERP.RowCount.ToString() + " PHA_TURNI.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Data.Layer.Periodi periodiPhase = new Zero5.Data.Layer.Periodi();
            periodiPhase.LoadAll();

            Zero5.Data.Layer.IntervalliPeriodo intervalliPhase = new Zero5.Data.Layer.IntervalliPeriodo();
            intervalliPhase.LoadAll(intervalliPhase.Fields.IDPeriodo.FieldName);

            //STEP1 Inserimento-Aggiornamento periodi
            while (!periodiIntervalliERP.EOF)
            {
                if (periodiPhase.Nome != periodiIntervalliERP.Codproforariosett)
                    periodiPhase.MoveToNextFieldValue(periodiPhase.Fields.Nome, periodiIntervalliERP.Codproforariosett, true);

                if (periodiPhase.EOF && periodiIntervalliERP.Datafinevalidita > DateTime.Now)
                {
                    periodiPhase.AddNewAndNewID();
                    periodiPhase.Nome = periodiIntervalliERP.Codproforariosett;
                    periodiPhase.Descrizione = periodiIntervalliERP.Descrizione;
                    periodiPhase.Tipo = (int)PeriodiTipo.Macchina;
                    periodiPhase.DataRiferimento = new DateTime(2020, 01, 06); //gli intervalli eSOLVER partono sempre dal lunedì
                    periodiPhase.Durata = 7; //gli intervalli eSOLVER hanno durata settimanale

                    Zero5.Util.Log.WriteLog("Creato periodo IDPeriodo:'" + periodiPhase.IDPeriodo + "' Nome:'" + periodiPhase.Nome + "' Descrizione:'" + periodiPhase.Descrizione + "' Tipo:'" + periodiPhase.Tipo + "' Durata:'" + periodiPhase.Durata + "'");
                }

                if (periodiPhase.Descrizione != periodiIntervalliERP.Descrizione)
                    periodiPhase.Descrizione = periodiIntervalliERP.Descrizione;

                periodiIntervalliERP.MoveNext();
            }

            if (periodiPhase.RowChangedCount > 0)
                periodiPhase.Save();

            //STEP2 Aggiunta intervalli mancanti

            periodiPhase.MoveFirst();
            while (!periodiPhase.EOF)
            {
                intervalliPhase.MoveToNextFieldValue(intervalliPhase.Fields.IDPeriodo, periodiPhase.IDPeriodo, true);
                if (intervalliPhase.EOF)
                {
                    periodiIntervalliERP.MoveFirst();
                    while (!periodiIntervalliERP.EOF)
                    {
                        if (periodiPhase.Nome == periodiIntervalliERP.Codproforariosett)
                        {
                            intervalliPhase.AddNewAndNewID();
                            intervalliPhase.IDPeriodo = periodiPhase.IDPeriodo;
                            intervalliPhase.GiornoInizio = periodiIntervalliERP.Giornosettimana;
                            intervalliPhase.GiornoFine = periodiIntervalliERP.Giornosettimana;
                            TimeSpan OraDA = new TimeSpan(periodiIntervalliERP.Orada / 100, periodiIntervalliERP.Orada % 100, 0);
                            TimeSpan OraA = new TimeSpan(periodiIntervalliERP.Oraa / 100, periodiIntervalliERP.Oraa % 100, 0);
                            intervalliPhase.OreInizio = periodiPhase.DataRiferimento.Add(OraDA);
                            intervalliPhase.OreFine = periodiPhase.DataRiferimento.Add(OraA);
                            intervalliPhase.Save();
                        }
                        periodiIntervalliERP.MoveNext();
                    }
                }

                periodiPhase.MoveNext();
            }

            //STEP3 Rimozione Intervalli obsoleti
            periodiIntervalliERP.MoveFirst();
            while (!periodiIntervalliERP.EOF)
            {
                periodiPhase.MoveToNextFieldValue(periodiPhase.Fields.Nome, periodiIntervalliERP.Codproforariosett, true);
                if (!periodiPhase.EOF)
                {
                    if (periodiIntervalliERP.Datafinevalidita < DateTime.Now)
                    {
                        intervalliPhase.MoveToNextFieldValue(intervalliPhase.Fields.IDPeriodo, periodiPhase.IDPeriodo, true);
                        if (!intervalliPhase.EOF)
                        {
                            intervalliPhase.DeleteAll();
                            intervalliPhase.Save();
                        }

                        periodiPhase.DeleteRow();
                        if (periodiPhase.RowChangedCount > 0)
                            periodiPhase.Save();
                    }
                }

                periodiIntervalliERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Intervalli Periodo. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
