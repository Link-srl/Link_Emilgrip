using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaUnitaLogisticheDaGiacenze
    {
        public int nrGiacenzeUltimaLetturaERP = 0;

        public bool VerificaSeGiacenzaGiaImportataInPassato(int idArticolo, string lotto, int idUbicazione)
        {
            Zero5.Data.Layer.UnitaLogistiche udc = new UnitaLogistiche();
            {
                Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                fil.Add(udc.Fields.Lotto == lotto);
                fil.Add(udc.Fields.IDArticolo == idArticolo);
                fil.Add(udc.Fields.IDUbicazione == idUbicazione);
                udc.Load(fil);
            }

            if (udc.EOF)
            {
                Zero5.Data.Layer.Movimenti movimenti = new Movimenti();
                {
                    Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                    fil.Add(movimenti.Fields.Lotto == lotto);
                    fil.Add(movimenti.Fields.IDArticolo == idArticolo);
                    fil.Add(movimenti.Fields.IDUbicazione == idUbicazione);
                    movimenti.Load(fil);
                }

                if (movimenti.EOF)
                    return true;

            }
            return false;
        }

        public void EseguiImportazione()
        {
            if (!Configurazioni.Comune_Importazione_ImportaGiacenzeEMovimenti)
                return;

            Zero5.Server.Licenza srvLicenza = new Zero5.Server.Licenza();
            if (!srvLicenza.IsProdottoAttivo(Zero5.License.ProductModules.Phase5_MES_ServerLogistica))
                return;

            if (!Configurazioni.Comune_Importazione_ImportaGiacenzeIniziali)
                return;

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_GIACENZA WHERE Giacenza > 0", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Giacenze);

            nrGiacenzeUltimaLetturaERP = 0;
            PHA_GIACENZA giacenzeERP = new PHA_GIACENZA(query);

            if (giacenzeERP == null || giacenzeERP.RowCount == 0)
                return;

            nrGiacenzeUltimaLetturaERP = giacenzeERP.RowCount;

            Zero5.Util.Log.WriteLog("Importazione " + giacenzeERP.RowCount.ToString() + " UnitaLogistiche da PHA_GIACENZA.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Data.Layer.Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            Zero5.Data.Layer.Ubicazioni ubicazioniPhase = new Ubicazioni();
            ubicazioniPhase.LoadNone();

            Zero5.Server.Logistica2 srvLog = new Zero5.Server.Logistica2();

            while (!giacenzeERP.EOF)
            {
                System.Threading.Thread.Sleep(10);

                string noteUDc = "Articolo: " + giacenzeERP.Codart + " Variante: " + giacenzeERP.Varianteart + " Lotto: " + giacenzeERP.Lotto + " Ubicazione: " + giacenzeERP.Magarea;

                try
                {
                    string codiceArticoloERP = Common.GetCodiceArticoloFromEsolver(giacenzeERP.Codart, giacenzeERP.Varianteart);

                    if (articoliPhase.CodiceArticolo != codiceArticoloERP)
                        articoliPhase.Load(articoliPhase.Fields.CodiceArticolo == codiceArticoloERP);

                    if (articoliPhase.EOF)
                    {
                        articoliPhase.AddNewAndNewID();

                        articoliPhase.CodiceArticolo = codiceArticoloERP;
                        articoliPhase.CodiceEsterno = giacenzeERP.Codart;
                        articoliPhase.DataOraCreazione = DateTime.Now;
                        articoliPhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreato articolo " + articoliPhase.CodiceEsterno);
                    }

                    string CodiceAreaMagazzinoEsolver = "ESMAG_" + giacenzeERP.Magarea;

                    if (ubicazioniPhase.CodiceEsterno != CodiceAreaMagazzinoEsolver)
                        ubicazioniPhase.Load(articoliPhase.Fields.CodiceEsterno == CodiceAreaMagazzinoEsolver);

                    if (ubicazioniPhase.EOF)
                    {
                        ubicazioniPhase.AddNewAndNewID();
                        ubicazioniPhase.CodiceEsterno = CodiceAreaMagazzinoEsolver;
                        ubicazioniPhase.Codice = giacenzeERP.Magarea;
                        ubicazioniPhase.Magazzino = giacenzeERP.Magarea;
                        ubicazioniPhase.Save();
                    }

                    bool giacenzaDaImportare = VerificaSeGiacenzaGiaImportataInPassato(articoliPhase.IDArticolo, giacenzeERP.Lotto, ubicazioniPhase.IDUbicazione);

                    if (giacenzaDaImportare)
                    {
                        DateTime dtScadenza = giacenzeERP.Datascadenzalotto;
                        if (giacenzeERP.Datascadenzalotto == new DateTime(1800, 1, 1))
                            dtScadenza = DateTime.MinValue;

                        int idCausaleCaricoDaEsolver = Common.IDCausaleMovimentoCaricoInizialeERP;

                        int idMovimento = srvLog.UnitaLogistiche_CreaECarica(articoliPhase.IDArticolo, ubicazioniPhase.IDUbicazione, giacenzeERP.Lotto, giacenzeERP.Giacenza, articoliPhase.UnitaDiMisura, Articoli.enumArticoliGestione.UnitaDiCarico, "", 0, UnitaLogistiche.enumUnitaLogisticheStato.Normale, giacenzeERP.Dataaperturalotto, dtScadenza, 0, idCausaleCaricoDaEsolver, 0, 0, 0, 0, 0, 0, 0, false, false, 0, 0, 0);

                        Zero5.Util.Log.WriteLog("Caricata nuova UDC da Giacenza. " + noteUDc);
                        if (Configurazioni.Comune_Importazione_ImportaGiacenzeIniziali)
                            Configurazioni.Comune_Importazione_ImportaGiacenzeIniziali = false;
                    }

                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Errore carico nuova UDC da Giacenza. " + noteUDc + " - " + ex.Message);
                    throw ex;
                }
                giacenzeERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Giacenze Attuali. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
