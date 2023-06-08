using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ScambioDati
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (!Zero5.Threading.SingleInstance.ImAloneWithinSystem())
                {
                    Zero5.Util.Log.WriteLog("...double istance, closing.");
                    return;
                }

                foreach(string arg in args)
                    switch (arg) {
                        case "-LogWSData":
                            Shared.Configurazioni.LogWSData = true;
                            break;
                    }


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //Gestione configurazioni obsolete su files
                FileConfigurazione Parametri = new FileConfigurazione();
                Parametri.MigraParametriDaFileAOpzioni();

                ImportaArticoli importatoreArticoli = new ImportaArticoli();
                ImportaAlias importatoreAlias = new ImportaAlias();
                ImportaUnitaLogisticheDaGiacenze importatoreUnitaLogisticheDaGiacenza = new ImportaUnitaLogisticheDaGiacenze();
                ImportaMovimentiLogistica importatoreMovimenti = new ImportaMovimentiLogistica();
                ImportaOrdiniFasi importatoreOrdini = new ImportaOrdiniFasi();
                ImportaCampiAggiuntiviOrdini importatoreCampiOrdini = new ImportaCampiAggiuntiviOrdini();
                ImportaRisorse importatoreRisorse = new ImportaRisorse();
                ImportaDistintaBase importatoreDistintaBase = new ImportaDistintaBase();
                ImportaCausali importatoreCausali = new ImportaCausali();
                ImportaIntervalliPeriodo importatoreIntervalliPeriodi = new ImportaIntervalliPeriodo();
                ImportaIntervalliPeriodoEslcusione importatoreIntervalliPeriodiEsclusione = new ImportaIntervalliPeriodoEslcusione();
                ImportaAllegati importatoreAllegati = new ImportaAllegati();

                Zero5.Util.Log.WriteLog("START");
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreIntervalliPeriodi.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreIntervalliPeriodiEsclusione.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreCausali.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreRisorse.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreArticoli.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreAlias.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    bool aggiornaArticoli = importatoreArticoli.nrArticoliUltimaLetturaERP == 0;
                    importatoreOrdini.EseguiImportazioneOrdiniFasi(aggiornaArticoli);
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreCampiOrdini.EseguiImportazioneCampiAggiuntiviOrdini();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                }


                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreDistintaBase.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreUnitaLogisticheDaGiacenza.EseguiImportazione();
                    importatoreMovimenti.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);

                }

                try
                {
                    System.Threading.Thread.Sleep(1500);
                    importatoreAllegati.EseguiImportazione();
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                    Zero5.Util.Log.WriteLog(ex.StackTrace);

                }

                sw.Stop();
                Zero5.Util.Log.WriteLog("DONE. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));

            }
            catch (Exception ex)
            {
                Zero5.Util.Log.WriteLog("Errore Generico: " + ex.Message);
                Zero5.Util.Log.WriteLog(ex.StackTrace);

            }
        }
    }
}
