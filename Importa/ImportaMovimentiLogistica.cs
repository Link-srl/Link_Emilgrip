using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaMovimentiLogistica
    {
        public void EseguiImportazione()
        {
            if (!Configurazioni.Comune_Importazione_ImportaGiacenzeEMovimenti)
                return;

            Zero5.Server.Licenza srvLicenza = new Zero5.Server.Licenza();
            if (!srvLicenza.IsProdottoAttivo(Zero5.License.ProductModules.Phase5_MES_ServerLogistica))
                return;

            string nomeTabella = Configurazioni.GetConfigFromOpzioniWithDefaultValue("PHA_MOVMAG", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_NomeTabellaImportazione_MovimentiMagazzino);

            PHA_MOVMAG movimentiERP = new PHA_MOVMAG("SELECT * FROM " + nomeTabella + " WHERE DataRegistrazione > '" + Configurazioni.Comune_Importazione_DataUltimoMovimentoImportato.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' ORDER BY DataRegistrazione ASC");
            //TODO: passare-combinare iddocumento-idriga alla query per assicurarsi di non prendere movimenti doppi

            if (movimentiERP == null || movimentiERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + movimentiERP.RowCount.ToString() + " Movimenti da PHA_MOVMAG.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Data.Layer.Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            Zero5.Data.Layer.Ubicazioni ubicazioniPhase = new Ubicazioni();
            ubicazioniPhase.LoadNone();

            Zero5.Server.Logistica2 srvLog = new Zero5.Server.Logistica2();

            while (!movimentiERP.EOF)
            {
                System.Threading.Thread.Sleep(10);

                try
                {
                    string codiceArticoloERP = Common.GetCodiceArticoloFromEsolver(movimentiERP.Codart, movimentiERP.Varianteart);

                    if (articoliPhase.CodiceArticolo != codiceArticoloERP)
                        articoliPhase.Load(articoliPhase.Fields.CodiceArticolo == codiceArticoloERP);

                    if (articoliPhase.EOF)
                    {
                        articoliPhase.AddNewAndNewID();

                        articoliPhase.CodiceArticolo = codiceArticoloERP;
                        articoliPhase.CodiceEsterno = movimentiERP.Codart;
                        articoliPhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreato articolo " + articoliPhase.CodiceEsterno);
                    }

                    string CodiceAreaMagazzinoEsolver = "ESMAG_" + movimentiERP.Magarea;

                    if (ubicazioniPhase.CodiceEsterno != CodiceAreaMagazzinoEsolver)
                        ubicazioniPhase.Load(articoliPhase.Fields.CodiceEsterno == CodiceAreaMagazzinoEsolver);

                    if (ubicazioniPhase.EOF)
                    {
                        ubicazioniPhase.AddNewAndNewID();
                        ubicazioniPhase.CodiceEsterno = CodiceAreaMagazzinoEsolver;
                        ubicazioniPhase.Codice = movimentiERP.Magarea;
                        ubicazioniPhase.Magazzino = movimentiERP.Magarea;
                        ubicazioniPhase.Save();
                    }

                    Zero5.Data.Layer.UnitaLogistiche udc = new UnitaLogistiche();
                    {
                        Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                        fil.Add(udc.Fields.Lotto == movimentiERP.Lotto);
                        fil.Add(udc.Fields.IDArticolo == articoliPhase.IDArticolo);
                        fil.Add(udc.Fields.IDUbicazione == ubicazioniPhase.IDUbicazione);
                        udc.Load(fil);
                    }

                    int idCausaleCaricoDaEsolver = Common.IDCausaleMovimentoCaricoERP;
                    int idCausaleScaricoDaEsolver = Common.IDCausaleMovimentoScaricoERP;

                    if (udc.EOF)
                    {
                        int idUdc = srvLog.UnitaLogistiche_Crea(articoliPhase.IDArticolo, ubicazioniPhase.IDUbicazione, movimentiERP.Lotto, Articoli.enumArticoliGestione.UnitaDiCarico, "", UnitaLogistiche.enumUnitaLogisticheStato.Normale, movimentiERP.Dataregistrazione, DateTime.MinValue, 0, 0, 0, 0, 0, 0, 0, 0);
                        udc.Load(udc.Fields.IDUnita == idUdc);
                    }

                    if (movimentiERP.Tipomovimento == (int)eTipoMovimento_eSOLVER.Carico)
                    {
                        srvLog.UnitaLogistiche_Carico(udc.IDUnita, movimentiERP.Qta, movimentiERP.Udm, 0, ubicazioniPhase.IDUbicazione, idCausaleCaricoDaEsolver, movimentiERP.Dataregistrazione, udc.Stato, 0, 0, 0, 0, 0, 0, 0, false, false, 0, 0);
                    }
                    else if (movimentiERP.Tipomovimento == (int)eTipoMovimento_eSOLVER.Scarico)
                    {
                        try
                        {
                            srvLog.UnitaLogistiche_Scarico(udc.IDUnita, movimentiERP.Qta, movimentiERP.Udm, idCausaleScaricoDaEsolver, movimentiERP.Dataregistrazione, 0, 0, 0, 0, 0, 0, 0, 0, 0, true, false, false, true, false, true);
                        }
                        catch (Exception ex)
                        {
                            srvLog.UnitaLogistiche_Scarico(udc.IDUnita, udc.Quantita, movimentiERP.Udm, idCausaleScaricoDaEsolver, movimentiERP.Dataregistrazione, 0, 0, 0, 0, 0, 0, 0, 0, 0, true, false, false, true, false, true);
                            Zero5.Util.Log.WriteLog("UDC " + udc.IDUnita + ": scarico anomalo superiore a qta giacente su UDC. Convertito in scarico totale. Qta movimento eSOLVER: " + movimentiERP.Qta + " qta movimento Phase " + udc.Quantita);
                            Zero5.Util.Log.WriteLog("Exc. " + ex.Message);
                        }
                    }

                    Configurazioni.Comune_Importazione_DataUltimoMovimentoImportato = movimentiERP.Dataregistrazione;
                    //TODO: utilizzare una chiave del movimento per escludere i movimenti già importati invece di utilizzare la data (potrebbero creare movimenti nel passato)

                    Zero5.Util.Log.WriteLog("Importato movimento " + movimentiERP.Codart + " " + movimentiERP.Varianteart + " " + movimentiERP.Lotto + " " + movimentiERP.Magarea + " TIPO: " + movimentiERP.Tipomovimento + " QTA: " + movimentiERP.Qta + " " + movimentiERP.Udm);
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Errore importazione " + movimentiERP.Codart + " " + movimentiERP.Varianteart + " " + movimentiERP.Lotto + " " + movimentiERP.Magarea + " TIPO: " + movimentiERP.Tipomovimento + " QTA: " + movimentiERP.Qta + " " + movimentiERP.Udm + " - " + ex.Message);
                }
                movimentiERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Movimenti Logistica. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
