using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaDistintaBase
    {
        public void EseguiImportazione()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_MATERIALIODP where RifOdP in (select RifOdP from PHA_ODPFASI)", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_DistintaBase);

            PHA_MATERIALIODP impegniERP = new PHA_MATERIALIODP(query);

            if (impegniERP == null || impegniERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + impegniERP.RowCount.ToString() + " PHA_MATERIALIODP.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            OrdiniProduzione ordiniPhase = new OrdiniProduzione();
            ordiniPhase.LoadNone();

            Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            DistintaBase distintaPadrePhase = new DistintaBase();
            distintaPadrePhase.LoadNone();

            DistintaBase distintaPhase = new DistintaBase();
            distintaPhase.LoadNone();

            HashSet<string> lstCodiceEsternoImportatiEsolver = new HashSet<string>();

            while (!impegniERP.EOF)
            {
                lstCodiceEsternoImportatiEsolver.Add(impegniERP.Idpadremateriale);
                try
                {
                    string op_CodiceEsterno = Shared.Common.GetCodiceEsternoOrdineFromCodiceEsternoFase(impegniERP.Idpadrefase);
                    if (op_CodiceEsterno != "")
                    {
                        if (ordiniPhase.CodiceEsterno != op_CodiceEsterno)
                            ordiniPhase.Load(ordiniPhase.Fields.CodiceEsterno == op_CodiceEsterno);

                        if (!ordiniPhase.EOF)
                        {
                            if (distintaPadrePhase.IDDistintaBase != ordiniPhase.IDDistintaBase || ordiniPhase.IDDistintaBase == 0)
                            {
                                if (ordiniPhase.IDDistintaBase == 0)
                                    distintaPadrePhase.LoadNone();
                                else
                                    distintaPadrePhase.Load(distintaPadrePhase.Fields.IDDistintaBase == ordiniPhase.IDDistintaBase);

                                if (distintaPadrePhase.EOF)
                                {
                                    distintaPadrePhase.AddNewAndNewID();
                                    distintaPadrePhase.IDArticolo = ordiniPhase.IDArticolo;
                                    distintaPadrePhase.CodiceArticolo = ordiniPhase.Articolo;
                                    distintaPadrePhase.Descrizione = ordiniPhase.ArticoloDescrizione;
                                    distintaPadrePhase.RiferimentoEsterno = impegniERP.Rifodp;
                                    distintaPadrePhase.DataCreazione = DateTime.Now;
                                    distintaPadrePhase.Save();

                                    ordiniPhase.IDDistintaBase = distintaPadrePhase.IDDistintaBase;
                                    ordiniPhase.Save();
                                    Zero5.Util.Log.WriteLog("\tCreata distinta base IDDistintaBase:'" + ordiniPhase.IDDistintaBase + "'");
                                }
                            }
                            string codArtConVersione = impegniERP.Codart;
                            if (!string.IsNullOrEmpty(impegniERP.Variante))
                                codArtConVersione += "_" + impegniERP.Variante;

                            articoliPhase.Load(articoliPhase.Fields.CodiceArticolo == codArtConVersione);
                            if (articoliPhase.EOF)
                            {
                                articoliPhase.AddNewAndNewID();
                                articoliPhase.CodiceArticolo = codArtConVersione;
                                articoliPhase.CodiceEsterno = impegniERP.Codart;
                                articoliPhase.Descrizione = impegniERP.Desarticolo;
                                articoliPhase.Save();
                            }

                            distintaPhase.Load(distintaPhase.Fields.IDDistintaBasePadre == distintaPadrePhase.IDDistintaBase
                                              , distintaPhase.Fields.RiferimentoEsterno == impegniERP.Idpadremateriale);

                            if (distintaPhase.EOF)
                            {
                                distintaPhase.AddNewAndNewID();
                                distintaPhase.IDArticolo = articoliPhase.IDArticolo;
                                distintaPhase.CodiceArticolo = articoliPhase.CodiceArticolo;
                                distintaPhase.IDDistintaBasePadre = distintaPadrePhase.IDDistintaBase;
                                distintaPhase.RiferimentoEsterno = impegniERP.Idpadremateriale;
                                distintaPhase.DataCreazione = DateTime.Now;
                                distintaPhase.Save();
                            }

                            distintaPhase.Descrizione = impegniERP.Desarticolo;
                            distintaPhase.NumeroFase = (int)(impegniERP.Numfase * 10);
                            distintaPhase.NumeroRigaDistintaBase = (int)impegniERP.Numrigamateriale;
                            distintaPhase.UnitaMisura = impegniERP.Unitamisura;

                            if (ordiniPhase.QuantitaRichiesta != 0)
                            {
                                distintaPhase.Quantita = impegniERP.Quantita / ordiniPhase.QuantitaRichiesta;
                                distintaPhase.Gestione = DistintaBase.eGestione.ConsumoDichiarato;
                                distintaPhase.TipoConversione = DistintaBase.eTipoConversione.Unitario;
                            }
                            else
                            {
                                distintaPhase.Quantita = impegniERP.Quantita;
                                distintaPhase.Gestione = DistintaBase.eGestione.ConsumoDichiarato;
                                distintaPhase.TipoConversione = DistintaBase.eTipoConversione.Fisso;
                            }
                            distintaPhase.Save();
                        }
                        else
                            Zero5.Util.Log.WriteLog("Importa distinta base, ordine con codice esterno:'" + op_CodiceEsterno + "' non trovato");
                    }
                }
                catch (ArgumentException ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Riga " + impegniERP.RowIndex.ToString() + ": Errore non gestito diba ex:" + ex.Message + Environment.NewLine + ex.Message);
                }
                impegniERP.MoveNext();
            }


            //Pulizia righe distinta non presenti in esolver
            List<List<int>> idDistinteDaControllare = new List<List<int>>();
            {
                Zero5.Data.Layer.OrdiniProduzione opPhaseAperti = new OrdiniProduzione();
                opPhaseAperti.Load(
                    opPhaseAperti.Fields.CodiceEsterno != "",
                    opPhaseAperti.Fields.Stato != OrdiniProduzione.enumOrdiniProduzioneStati.Chiuso,
                    opPhaseAperti.Fields.IDDistintaBase != 0);

                idDistinteDaControllare = Zero5.Util.Common.SplitList(opPhaseAperti.GetIntListFromField(opPhaseAperti.Fields.IDDistintaBase), 1000);
            }

            foreach (List<int> lstDistinteDaVerificare in idDistinteDaControllare)
            {
                Zero5.Data.Layer.DistintaBase righeDistinteBase = new DistintaBase();
                Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                fil.Add(righeDistinteBase.Fields.IDDistintaBasePadre.FilterIn(lstDistinteDaVerificare));
                fil.Add(righeDistinteBase.Fields.RiferimentoEsterno != "");
                fil.Add(righeDistinteBase.Fields.IDDistintaBasePadre != 0);

                righeDistinteBase.Load(fil);

                while (!righeDistinteBase.EOF)
                {
                    if (!lstCodiceEsternoImportatiEsolver.Contains(righeDistinteBase.RiferimentoEsterno))
                    {
                        Zero5.Util.Log.WriteLog("Eliminata riga distinta rif esterno " + righeDistinteBase.RiferimentoEsterno + " idDistintaPadre " + righeDistinteBase.IDDistintaBasePadre);
                        righeDistinteBase.DeleteRow();
                    }
                    righeDistinteBase.MoveNext();
                }

                //Lasciamo aperta la riga padre anche se abbiamo eliminato le figlie perchè pensiamo che in un secondo momento vengano ricreate

                righeDistinteBase.Save();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Distinta Base. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
