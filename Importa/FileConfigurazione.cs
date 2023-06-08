using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace ScambioDati
{
    class FileConfigurazione : Zero5.Util.FileParametri
    {
        public FileConfigurazione()
            : base(Zero5.IO.Util.LocalPathFile("Importa.cfg"))
        {
        }

        public void MigraParametriDaFileAOpzioni()
        {
            if (!System.IO.File.Exists(Zero5.IO.Util.LocalPathFile("Importa.cfg")))
                return;

            Zero5.Util.Log.WriteLog("Migrazione configurazioni da file a opzioni...");

            {
                string databaseScambio = GetParametro("DatabaseScambio");
                if (databaseScambio == "")
                    databaseScambio = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ES_PHASE;Data Source=.\\";

                Zero5.Data.Layer.Opzioni.helper.SaveStringValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_Importazione_DatabaseDiScambio, databaseScambio);
            }

            {
                bool abilitaProgrammazioneAutomatica = false;
                string configOnFile = GetParametro("AbilitaProgrammazioneAutomatica");
                if (configOnFile != "")
                    abilitaProgrammazioneAutomatica = configOnFile == "1";

                Zero5.Data.Layer.Opzioni.helper.SaveBoolValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_AbilitaProgrammazioneAutomatica, abilitaProgrammazioneAutomatica);
            }

            {
                bool OrdiniForzaChiusura = false;
                string configOnFile = GetParametro("OrdiniForzaChiusura");
                if (configOnFile != "")
                    OrdiniForzaChiusura = configOnFile == "1";

                Zero5.Data.Layer.Opzioni.helper.SaveBoolValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_ForzaChiusuraOrdini, OrdiniForzaChiusura);
            }

            {
                bool Logistica_EseguiImportazioneGiacenzeIniziale = true;
                string configOnFile = GetParametro("Logistica_EseguiImportazioneGiacenzeIniziale");
                if (configOnFile != "")
                    Logistica_EseguiImportazioneGiacenzeIniziale = configOnFile == "1";

                Zero5.Data.Layer.Opzioni.helper.SaveBoolValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_ImportaGiacenzeIniziali, Logistica_EseguiImportazioneGiacenzeIniziale);
            }

            {
                bool ImportaArticoliMassivoDaAnagrafica = true;
                string configOnFile = GetParametro("ImportaArticoliMassivoDaAnagrafica");
                if (configOnFile != "")
                    ImportaArticoliMassivoDaAnagrafica = configOnFile == "1";

                Zero5.Data.Layer.Opzioni.helper.SaveBoolValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_ImportaAnagraficaArticoli, ImportaArticoliMassivoDaAnagrafica);
            }

            {
                bool ImportaGiacenzeEMovimenti = true;
                string configOnFile = GetParametro("ImportaGiacenzeEMovimenti");
                if (configOnFile != "")
                    ImportaGiacenzeEMovimenti = configOnFile == "1";

                Zero5.Data.Layer.Opzioni.helper.SaveBoolValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_ImportaGiacenzeEMovimenti, ImportaGiacenzeEMovimenti);
            }

            {
                string configOnFile = GetParametro("Logistica_DataRegistrazioneUltimoMovimentoImportato");
                if (configOnFile != "")
                          Zero5.Data.Layer.Opzioni.helper.SaveStringValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_Importazione_DataUltimoMovimentoImportato, configOnFile);
            }

            Configurazioni.RicaricaConfigurazioni();
            Zero5.Util.Log.WriteLog("Migrazione configurazioni da file a opzioni conclusa.");

            System.IO.File.Delete(Zero5.IO.Util.LocalPathFile("Importa.cfg"));
            Zero5.Util.Log.WriteLog("Eliminato il file Importa.cfg");
        }
    }
}
