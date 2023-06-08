using Shared;
using System;
using System.Collections.Generic;
using Zero5.Data.Layer;

namespace ScambioDati
{
    class ImportaOrdiniFasi
    {
        public void EseguiImportazioneOrdiniFasi(bool aggiornaAnagraficaArticoliDaOrdiniProduzione)
        {
            ConvertiGestioneCodiceEsternoOrdiniSeNecessario();

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_ODPFASI", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_OrdiniFasi);

            PHA_ODPFASI ordiniFasiERP = new PHA_ODPFASI(query);

            if (ordiniFasiERP == null || ordiniFasiERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + ordiniFasiERP.RowCount.ToString() + " " + ordiniFasiERP.TableName);
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            ClientiFornitori clientiPhase = new ClientiFornitori();
            clientiPhase.LoadNone();

            OrdiniProduzione ordiniPhase = new OrdiniProduzione();
            ordiniPhase.LoadNone();

            FasiProduzione fasiPhase = new FasiProduzione();
            fasiPhase.LoadNone();

            TipiOrdine tipiOrdiniPhase = new TipiOrdine();
            tipiOrdiniPhase.LoadAll();

            Risorse macchinePhase = new Risorse();
            macchinePhase.LoadAll();

            Zero5.Server.Programmazione srvProg = new Zero5.Server.Programmazione();
            Zero5.Server.Produzione srvProd = new Zero5.Server.Produzione();

            List<int> lstArticoliDaVerificareAggiornamenti = new List<int>();
            List<int> lstClientiDaVerificareAggiornamenti = new List<int>();
            List<int> lstOrdiniDaRisequenziare = new List<int>();

            Dictionary<string, string> dicCampiDaAllineareArticoli = new Dictionary<string, string> {
                { Zero5.Data.Layer.Articoli.ClassFields.Descrizione.FieldName,ordiniFasiERP.Fields.Desarticolo.FieldName }
            };

            Dictionary<string, string> dicCampiDaAllineareClienti = new Dictionary<string, string>
            {
                   { Zero5.Data.Layer.ClientiFornitori.ClassFields.RagioneSociale.FieldName,ordiniFasiERP.Fields.Ragsocialecliente.FieldName }
            };


            Dictionary<string, string> campiDaAggiornareOrdiniDefault = new Dictionary<string, string> {
                        { ordiniPhase.Fields.DataOrdine.FieldName,ordiniFasiERP.Fields.Dataregistrazione.FieldName},
                        { ordiniPhase.Fields.Commessa.FieldName,ordiniFasiERP.Fields.Commessa.FieldName},
                        { ordiniPhase.Fields.QuantitaRichiesta.FieldName,ordiniFasiERP.Fields.Quantitaordinata.FieldName},
                        { ordiniPhase.Fields.ClienteDescrizione.FieldName,ordiniFasiERP.Fields.Ragsocialecliente.FieldName},
                        { ordiniPhase.Fields.RevisioneArticolo.FieldName,ordiniFasiERP.Fields.Varianteart.FieldName},
                        { ordiniPhase.Fields.ArticoloDescrizione.FieldName, ordiniFasiERP.Fields.Desarticolo.FieldName},
                        { ordiniPhase.Fields.Articolo.FieldName, ordiniFasiERP.Fields.Codart.FieldName},
                        { ordiniPhase.Fields.UnitaDiMisura.FieldName,ordiniFasiERP.Fields.Udm.FieldName},
                    };

            Dictionary<string, string> dicCampiDaAggiornareOrdini = Common.GetMappingDictionaryFromJson("AggiornaCampi_Ordini_Da_PHAODPFASI", campiDaAggiornareOrdiniDefault);

            Dictionary<string, string> campiDaAggiornareFasiDefault = new Dictionary<string, string> {
                            { fasiPhase.Fields.Sequenza.FieldName, ordiniFasiERP.Fields.Idrigalavorazione.FieldName},
                            { fasiPhase.Fields.Operazione.FieldName, ordiniFasiERP.Fields.Codlavorazione.FieldName },
                            { fasiPhase.Fields.Descrizione.FieldName, ordiniFasiERP.Fields.Deslavorazione.FieldName },
                            { fasiPhase.Fields.QtaPrevista.FieldName, ordiniFasiERP.Fields.Quantitaordinata.FieldName },
                            { fasiPhase.Fields.InizioPrevistoImportato.FieldName, ordiniFasiERP.Fields.Datainiziopianif.FieldName },
                            { fasiPhase.Fields.FinePrevistaImportata.FieldName, ordiniFasiERP.Fields.Datafinepianif.FieldName },
                    };

            Dictionary<string, string> dicCampiDaAggiornareFasi = Common.GetMappingDictionaryFromJson("AggiornaCampi_Fasi_Da_PHAODPFASI", campiDaAggiornareFasiDefault);


            List<int> lstIDOrdiniImportati = new List<int>();
            // List<int> lstIDFasiImportate = new List<int>();

            while (!ordiniFasiERP.EOF)
            {
                try
                {
                    #region ARTICOLI

                    string codArtERP = Common.GetCodiceArticoloFromEsolver(ordiniFasiERP.Codart, ordiniFasiERP.Varianteart);

                    if (articoliPhase.CodiceArticolo != codArtERP)
                    {
                        System.Threading.Thread.Sleep(10);
                        articoliPhase.Load(articoliPhase.Fields.CodiceArticolo == codArtERP);
                    }

                    //TODO: portare la creazione di un articolo in un metodo common
                    if (articoliPhase.EOF)
                    {
                        articoliPhase.AddNewAndNewID();

                        articoliPhase.CodiceArticolo = codArtERP;
                        articoliPhase.CodiceEsterno = ordiniFasiERP.Codart;
                        articoliPhase.DataOraCreazione = DateTime.Now;
                        articoliPhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreato articolo " + articoliPhase.CodiceArticolo);
                    }

                    if (aggiornaAnagraficaArticoliDaOrdiniProduzione)
                    {
                        if (Common.VerificaNecessitaAggiornamento(articoliPhase, ordiniFasiERP, dicCampiDaAllineareArticoli))
                        {
                            if (!lstArticoliDaVerificareAggiornamenti.Contains(articoliPhase.IDArticolo))
                            {
                                lstArticoliDaVerificareAggiornamenti.Add(articoliPhase.IDArticolo);
                            }
                        }
                    }

                    #endregion

                    #region CLIENTI

                    if (clientiPhase.CodiceEsterno != ordiniFasiERP.Codcliente.ToString())
                    {
                        System.Threading.Thread.Sleep(10);
                        clientiPhase.Load(clientiPhase.Fields.CodiceEsterno == ordiniFasiERP.Codcliente.ToString());
                    }

                    if (clientiPhase.EOF)
                    {
                        clientiPhase.AddNewAndNewID();

                        clientiPhase.CodiceEsterno = ordiniFasiERP.Codcliente.ToString();
                        clientiPhase.Codice = ordiniFasiERP.Codcliente.ToString();
                        clientiPhase.RagioneSociale = ordiniFasiERP.Ragsocialecliente;
                        clientiPhase.IsCliente = true;
                        clientiPhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreato il cliente " + clientiPhase.Codice);
                    }

                    if (Common.VerificaNecessitaAggiornamento(clientiPhase, ordiniFasiERP, dicCampiDaAllineareClienti))
                    {
                        if (!lstClientiDaVerificareAggiornamenti.Contains(clientiPhase.IDClienteFornitore))
                        {
                            lstClientiDaVerificareAggiornamenti.Add(clientiPhase.IDClienteFornitore);
                        }
                    }
                    #endregion

                    #region TIPI ORDINI
                    string tipoOrdineERP = ordiniFasiERP.Codtipodoc + " " + ordiniFasiERP.Destipodoc;
                    if (tipiOrdiniPhase.Descrizione != tipoOrdineERP)
                    {
                        tipiOrdiniPhase.MoveToNextFieldValue(tipiOrdiniPhase.Fields.Descrizione, tipoOrdineERP, true);
                        if (tipiOrdiniPhase.EOF)
                        {
                            tipiOrdiniPhase.AddNewAndNewID();
                            tipiOrdiniPhase.Descrizione = tipoOrdineERP;
                            tipiOrdiniPhase.ClasseOrdine = TipiOrdine.eClasseOrdine.Generico;
                            tipiOrdiniPhase.Save();
                        }
                    }

                    #endregion

                    #region ORDINI 


                    string codiceOrdineERP = ordiniFasiERP.Rifodp;
                    string codiceEsternoOrdineERP = ordiniFasiERP.Iddocumento.ToString() + ";" + ordiniFasiERP.Idriga.ToString();

                    if (ordiniPhase.CodiceEsterno != codiceEsternoOrdineERP)
                    {
                        System.Threading.Thread.Sleep(10);
                        ordiniPhase.Load(ordiniPhase.Fields.CodiceEsterno == codiceEsternoOrdineERP);

                        if (ordiniPhase.EOF)
                        {
                            //Verifica conversione vecchia codifica
                            ordiniPhase.Load(ordiniPhase.Fields.CodiceEsterno == codiceOrdineERP);
                            if (!ordiniPhase.EOF)
                            {
                                ordiniPhase.CodiceEsterno = codiceEsternoOrdineERP;
                                ordiniPhase.Save();
                            }
                        }
                    }


                    bool ordinePresenteNelleTabelleStoricizzate = false;
                    //{
                    //    Zero5.Data.Layer.zOrdiniProduzione zop = new zOrdiniProduzione();
                    //    Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                    //    fil.Add(zop.Fields.CodiceEsterno == codiceEsternoOrdineERP); //Nuova modalità
                    //    fil.AddOR();
                    //    fil.Add(zop.Fields.CodiceEsterno == codiceOrdineERP); //Vecchia modalità
                    //    zop.Load(fil);
                    //    if (!zop.EOF)
                    //        ordinePresenteNelleTabelleStoricizzate = true;
                    //}
                    //TODO: gestire il caso in cui l'ordine è presente ma storicizzato, da non reimportare


                    if (!ordinePresenteNelleTabelleStoricizzate)
                    {
                        if (ordiniPhase.EOF)
                        {
                            ordiniPhase.AddNewAndNewID();

                            ordiniPhase.Codice = codiceOrdineERP;
                            ordiniPhase.CodiceEsterno = codiceEsternoOrdineERP;

                            ordiniPhase.Save();

                            Zero5.Util.Log.WriteLog("\tCreato ordine " + ordiniPhase.Codice);
                        }

                        Common.AllineaCampiDaValori(ordiniPhase, new Dictionary<Zero5.Data.Filter.Field, object>() {
                        { ordiniPhase.Fields.IDArticolo, articoliPhase.IDArticolo},
                        { ordiniPhase.Fields.IDClienteFornitore, clientiPhase.IDClienteFornitore},
                        { ordiniPhase.Fields.IDTipoOrdine,tipiOrdiniPhase.IDTipoOrdine},
                        { ordiniPhase.Fields.Cliente,ordiniFasiERP.Codcliente.ToString()},
                        
                       
                    });


                        Common.AllineaCampiDaOggettoDati(ordiniPhase, ordiniFasiERP, dicCampiDaAggiornareOrdini);

                        if (ordiniPhase.Lotto == "")
                            if (ordiniFasiERP.Riflottoalfanum != "")
                                ordiniPhase.Lotto = ordiniFasiERP.Riflottoalfanum;

                        if (ordiniPhase.RowChangedCount > 0)
                            ordiniPhase.Save();
                        #endregion

                        //TODO: codice da capire?
                        //string dbGruppoForzato = Configurazioni.WsSistemi_GruppoForzato;
                        //if (dbGruppoForzato == "" && ordiniFasiERP.Dbgruppo != "")
                        //{
                        //    Zero5.Data.Layer.Opzioni.helper.SaveStringValue(Opzioni.enumOpzioniID.Esolver_ScambioDati_Comune_XbcGruppoForzato, ordiniFasiERP.Dbgruppo);
                        //}

                        #region FASI
                        eStatoFase_eSOLVER statoFaseEsolver = (eStatoFase_eSOLVER)ordiniFasiERP.Statofaseodp;

                        fasiPhase.Load(fasiPhase.Fields.CodiceEsterno == ordiniFasiERP.Id);

                        if (fasiPhase.EOF)
                        {
                            fasiPhase.AddNewAndNewID();
                            fasiPhase.IDOrdineProduzione = ordiniPhase.IDOrdineProduzione;
                            fasiPhase.Sequenza = ordiniFasiERP.Idrigalavorazione; //TODO: da riportare sotto
                            fasiPhase.NumeroFase = (int)(ordiniFasiERP.Numfase * 10); //TODO: da riportare sotto
                            fasiPhase.CodiceEsterno = ordiniFasiERP.Id;
                            fasiPhase.CodiceBolla = ordiniFasiERP.Id;

                            if (statoFaseEsolver == eStatoFase_eSOLVER.InAvanzamento && ordiniFasiERP.Quantitaavanzata != 0)
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Sospesa;
                            else if (statoFaseEsolver == eStatoFase_eSOLVER.Finito)
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Finita;
                            else
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Inserita;

                            fasiPhase.Save();

                            //TODO: chiamare l'aggiornamento dello stato fase tramite il metodo server


                            if (!lstOrdiniDaRisequenziare.Contains(ordiniPhase.IDOrdineProduzione))
                            {
                                lstOrdiniDaRisequenziare.Add(ordiniPhase.IDOrdineProduzione);
                            }

                            Zero5.Util.Log.WriteLog("      Creata fase " + ordiniPhase.Codice + " " + fasiPhase.NumeroFase);
                        }

                        Common.AllineaCampiDaOggettoDati(fasiPhase, ordiniFasiERP, dicCampiDaAggiornareFasi);

                        if (fasiPhase.Programmata == false)
                        {
                            Common.AllineaCampiDaOggettoDati(fasiPhase, ordiniFasiERP, new Dictionary<string, string> {
                            { fasiPhase.Fields.FinePrevista.FieldName, ordiniFasiERP.Fields.Datafinesched.FieldName }, //Datafinesched viene aggiornata di da Phase attraverso EsportaWS, basandosi sulla fine prevista
                            { fasiPhase.Fields.InizioPrevisto.FieldName, ordiniFasiERP.Fields.Datainiziosched.FieldName } //Datafinesched viene aggiornata di da Phase attraverso EsportaWS, basandosi sulla fine prevista
                        });
                        }

                        double TPrevMachTotSetup_ERP = Common.GetMinutiFromTempoESOLVER(ordiniFasiERP.Tempoattr, (eUMTempo_eSolver)ordiniFasiERP.Udmattrsmont) + Common.GetMinutiFromTempoESOLVER(ordiniFasiERP.Temposmont, (eUMTempo_eSolver)ordiniFasiERP.Udmattrsmont);

                        double TPrevMachUniCiclo_ERP = Common.GetMinutiFromTempoESOLVER(ordiniFasiERP.Tempociclo, (eUMTempo_eSolver)ordiniFasiERP.Udmlavorazione);

                        double TPrevMachTotCiclo_ERP = TPrevMachUniCiclo_ERP * ordiniFasiERP.Quantitaordinata;
                        double TPrevMachLeadTimeFasiEsterne_ERP = ordiniFasiERP.Leadtimefase * 24 * 60;
                        double TPrevMachUniLeadTimeFasiEsterne_ERP = TPrevMachLeadTimeFasiEsterne_ERP / ordiniFasiERP.Quantitaordinata;

                        macchinePhase.MoveToNextFieldValue(macchinePhase.Fields.CodiceEsterno, ordiniFasiERP.Codrisorsaprod, true);
                        if (macchinePhase.EOF)
                        {
                            macchinePhase.AddNewAndNewID();
                            macchinePhase.CodiceEsterno = ordiniFasiERP.Codrisorsaprod;
                            macchinePhase.Codice = ordiniFasiERP.Codrisorsaprod;
                            macchinePhase.Tipo = Risorse.eTipo.Macchina;
                            macchinePhase.IDLivello = 0;
                            macchinePhase.Descrizione = ordiniFasiERP.Desrisorsa;
                            macchinePhase.Nome = ordiniFasiERP.Desrisorsa;
                            macchinePhase.Save();
                        }

                        // Zero5.Util.Log.WriteLog("Ordine: " + codiceOrdineERP + " Macchina : " + ordiniFasiERP.Codrisorsaprod);


                        if (fasiPhase.NumeroFase != (int)ordiniFasiERP.Numfase * 10)
                        {
                            if (!lstOrdiniDaRisequenziare.Contains(ordiniPhase.IDOrdineProduzione))
                            {
                                lstOrdiniDaRisequenziare.Add(ordiniPhase.IDOrdineProduzione);
                            }
                        };

                        bool faseEsterna = Convert.ToBoolean(ordiniFasiERP.Fasecontolavoro);

                        if (faseEsterna)
                        {
                            Common.AllineaCampiDaValori(fasiPhase, new Dictionary<Zero5.Data.Filter.Field, object>()
                        {
                            { fasiPhase.Fields.TPrevMachTotCicloLavorazione, TPrevMachLeadTimeFasiEsterne_ERP },
                            { fasiPhase.Fields.TPrevMachTotCiclo, TPrevMachLeadTimeFasiEsterne_ERP },
                            { fasiPhase.Fields.TPrevMachUniCicloLavorazione, TPrevMachUniLeadTimeFasiEsterne_ERP },
                            { fasiPhase.Fields.TPrevMachUniCiclo, TPrevMachUniLeadTimeFasiEsterne_ERP },
                        });
                        }
                        else
                        {
                            Common.AllineaCampiDaValori(fasiPhase, new Dictionary<Zero5.Data.Filter.Field, object>()
                        {
                            { fasiPhase.Fields.TPrevMachUniCiclo, TPrevMachUniCiclo_ERP},
                            { fasiPhase.Fields.TPrevMachUniCicloLavorazione, TPrevMachUniCiclo_ERP},
                            { fasiPhase.Fields.TPrevMachTotCicloLavorazione, TPrevMachTotCiclo_ERP },
                            { fasiPhase.Fields.TPrevMachTotCiclo, TPrevMachTotCiclo_ERP },
                            { fasiPhase.Fields.TPrevMachTotSetup, TPrevMachTotSetup_ERP },
                            { fasiPhase.Fields.TPrevUomoTotSetup, TPrevMachTotSetup_ERP },
                        });
                        }

                        Common.AllineaCampiDaValori(fasiPhase, new Dictionary<Zero5.Data.Filter.Field, object>()
                    {
                        { fasiPhase.Fields.IDRisorsaMacchinaPrevista , macchinePhase.IDRisorsa},
                        { fasiPhase.Fields.LavorazioneEsterna, faseEsterna},
                        { fasiPhase.Fields.extDouble01, articoliPhase.extDouble01},
                        { fasiPhase.Fields.NumeroFase,(int)(ordiniFasiERP.Numfase * 10) },
                    });


                        if (fasiPhase.LavorazioneEsterna && ordiniFasiERP.Quantitaavanzata > fasiPhase.QtaBuonaTotale)
                        {
                            Zero5.Util.Log.WriteLog($"Aggiornamento della quantità per la fase esterna ID{fasiPhase.IDFaseProduzione} EST{fasiPhase.CodiceEsterno}");
                            System.Threading.Thread.Sleep(100);
                            double delta = ordiniFasiERP.Quantitaavanzata - fasiPhase.QtaBuonaTotale;
                            srvProd.DichiarazioneVersamento(fasiPhase.IDFaseProduzione, 0, 0, Common.TipoAttivitaVersamentoDaGestionale, Common.CausaleVersamentoDaGestionale, delta, 0, DateTime.Now, 0, 0);
                            fasiPhase.QtaBuonaLavorazione = ordiniFasiERP.Quantitaavanzata;
                            fasiPhase.QtaBuonaTotale = ordiniFasiERP.Quantitaavanzata;
                        }

                        if (fasiPhase.RowChangedCount > 0)
                        {
                            fasiPhase.Save();
                        }

                        if (statoFaseEsolver == eStatoFase_eSOLVER.InAvanzamento)
                        {
                            if (fasiPhase.Stato == FasiProduzione.enumFasiProduzioneStati.Inserita)
                            {
                                Zero5.Util.Log.WriteLog("Eseguo sospensione fase produzione " + fasiPhase.IDFaseProduzione + " rilevata da eSolver come InAvanzamento");
                                System.Threading.Thread.Sleep(10);
                                srvProd.FaseProduzione_UpdateStato(fasiPhase.IDFaseProduzione, (int)Zero5.Data.Layer.FasiProduzione.enumFasiProduzioneStati.Sospesa);
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Sospesa;
                            }
                        }
                        else if (statoFaseEsolver == eStatoFase_eSOLVER.Finito)
                        {
                            if (fasiPhase.Stato == FasiProduzione.enumFasiProduzioneStati.Inserita ||
                                fasiPhase.Stato == FasiProduzione.enumFasiProduzioneStati.Sospesa)
                            {
                                Zero5.Util.Log.WriteLog("Eseguo chiusura fase produzione " + fasiPhase.IDFaseProduzione);
                                System.Threading.Thread.Sleep(10);
                                srvProd.EseguiChiusuraFaseProduzione(fasiPhase.IDFaseProduzione);
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Finita;
                            }
                        }
                        else
                        {
                            if (fasiPhase.LavorazioneEsterna &&
                                fasiPhase.Stato == FasiProduzione.enumFasiProduzioneStati.Inserita &&
                                fasiPhase.QtaBuonaTotale > 0)
                            {
                                srvProd.FaseProduzione_UpdateStato(fasiPhase.IDFaseProduzione, (int)Zero5.Data.Layer.FasiProduzione.enumFasiProduzioneStati.Sospesa);
                                fasiPhase.Stato = FasiProduzione.enumFasiProduzioneStati.Sospesa;
                            }
                        }

                        #region PROGRAMMAZIONE AUTOMATICA
                        if (!macchinePhase.EOF && !macchinePhase.Disabilitata && Configurazioni.Comune_Importazione_AbilitaProgrammazioneAutomatica)
                            if (fasiPhase.Stato != FasiProduzione.enumFasiProduzioneStati.Finita)
                            {
                                //TODO: condizione da approfondire: quando non programma?
                                // condizione per la programmazione automatica
                                if (macchinePhase.AbilitaProgrammazioneAutomaticaInImportazione
                                  || (macchinePhase.AbilitaProgrammazione == Zero5.Data.Layer.Risorse.eAbilitaProgrammazione.Sistema && Zero5.Data.Layer.Opzioni.helper.LoadIntValue(Zero5.Data.Layer.Opzioni.enumOpzioniID.Programmazione_AbilitaProgrammazione) == 1)
                                  || (macchinePhase.AbilitaProgrammazione == Zero5.Data.Layer.Risorse.eAbilitaProgrammazione.Si))
                                {
                                    FasiProgrammate fasiProgrammate = new FasiProgrammate();
                                    fasiProgrammate.Load(fasiProgrammate.Fields.IDFaseProduzione == fasiPhase.IDFaseProduzione);
                                    //TODO: chiamare tramite metodo server

                                    if (fasiProgrammate.EOF) // accodo la fase in programmazione. se è gia stata programmata non faccio nulla
                                    {
                                        srvProg.AggiungiFaseProgrammataSuMacchinaInCoda(fasiPhase.IDFaseProduzione, macchinePhase.IDRisorsa, fasiPhase.QtaPrevista);

                                    }
                                }
                            }
                        #endregion


                        #endregion

                        if (!lstIDOrdiniImportati.Contains(ordiniPhase.IDOrdineProduzione))
                            lstIDOrdiniImportati.Add(ordiniPhase.IDOrdineProduzione);

                        if (ordiniFasiERP.RowIndex % 100 == 0)
                            Zero5.Util.Log.WriteLog("Righe analizzate " + ordiniFasiERP.RowIndex.ToString() + ".");
                    }
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Riga " + ordiniFasiERP.RowIndex.ToString() + ": Errore non gestito ordine " + ordiniFasiERP.Rifodp + Environment.NewLine + ex.Message);
                }
                ordiniFasiERP.MoveNext();
            }

            CalcolaNumeroFasePrecedentePerOrdine(lstOrdiniDaRisequenziare);

            VerificaAggiornamentoArticoli(lstArticoliDaVerificareAggiornamenti, ordiniFasiERP, dicCampiDaAllineareArticoli);
            VerificaAggiornamentoClienti(lstClientiDaVerificareAggiornamenti, ordiniFasiERP, dicCampiDaAllineareClienti);
            ChiusuraOrdiniMancantiERP(lstIDOrdiniImportati);

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Ordini Fasi. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }

        public void ConvertiGestioneCodiceEsternoOrdiniSeNecessario()
        {
            Zero5.Data.Layer.OrdiniProduzione op = new OrdiniProduzione();
            op.Load(op.Fields.CodiceEsterno.FilterLikeTo("%.%"));

            if (op.EOF)
                return;

            Zero5.Util.Log.WriteLog($"Trovati {op.RowCount} ordini di produzione con codice esterno gestito in modalità precedente, conversione in corso");

            while (!op.EOF)
            {
#if PHASE_STANDARD
                Zero5.Data.Layer.zFasiProduzione fp = new zFasiProduzione();
#else
                Zero5.Data.Layer.FasiProduzione fp = new FasiProduzione();
#endif
                Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                fil.Add(fp.Fields.IDOrdineProduzione == op.IDOrdineProduzione);
                fil.AddOrderBy(fp.Fields.CodiceEsterno, Zero5.Data.Filter.eSortOrder.DESC);
                fp.Load(fil);


                //00000793000010001
                //01234567890123456
                //doc______rig_lav_
                //fp.CodiceEsterno

                while (!fp.EOF)
                {
                    if (fp.CodiceEsterno.Length == 17)
                    {
                        string sidDoc = fp.CodiceEsterno.Substring(0, 9);
                        string sidRiga = fp.CodiceEsterno.Substring(9, 4);

                        int idDoc = 0;
                        int idRiga = 0;
                        int.TryParse(sidDoc, out idDoc);
                        int.TryParse(sidRiga, out idRiga);

                        op.CodiceEsterno = idDoc.ToString() + ";" + idRiga.ToString();
                        op.Save();

                        Zero5.Util.Log.WriteLog($"Codice esterno OP {op.Codice} -> {op.CodiceEsterno}");

                        break;
                    }
                    fp.MoveNext();
                }


                op.MoveNext();
            }

        }

        public void CalcolaNumeroFasePrecedentePerOrdine(List<int> lstOrdiniDaRisequenziare)
        {
            foreach (int idOrdine in lstOrdiniDaRisequenziare)
            {
                try
                {
                    System.Threading.Thread.Sleep(10);
                    Zero5.Data.Layer.FasiProduzione fp = new FasiProduzione();
                    Zero5.Data.Filter.Filter fil = new Zero5.Data.Filter.Filter();
                    fil.Add(fp.Fields.IDOrdineProduzione == idOrdine);
                    fil.AddOrderBy(fp.Fields.NumeroFase);
                    fil.AddOrderBy(fp.Fields.IDFaseProduzione);
                    fp.Load(fil);

                    if (fp.RowCount > 1)
                    {
                        int nrFasePrecedente = fp.NumeroFase;
                        fp.MoveNext();

                        while (!fp.EOF)
                        {
                            if (fp.NumeroFase != nrFasePrecedente)
                                fp.NumeroFasePrecedente = nrFasePrecedente;
                            nrFasePrecedente = fp.NumeroFase;
                            fp.MoveNext();
                        }

                        if (fp.RowChangedCount > 0)
                        {
                            Zero5.Util.Log.WriteLog("Ricalcolato numero fase precedente per ordine " + idOrdine);
                            fp.Save();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog($"Errore: CalcolaNumeroFasePrecedentePerOrdine {idOrdine} " + ex.Message);
                }
            }
        }

        public void VerificaAggiornamentoArticoli(List<int> lstArticoliDaVerificare, PHA_ODPFASI ordiniFasiERP, Dictionary<string, string> campiDaAllineare)
        {
            if (campiDaAllineare.Count == 0)
                return;

            if (lstArticoliDaVerificare.Count > 0)
            {
                Zero5.Util.Log.WriteLog("Verifica aggiornamento articoli");

                foreach (int idArticolo in lstArticoliDaVerificare)
                {
                    Articoli articolo = new Articoli();
                    articolo.Load(articolo.Fields.IDArticolo == idArticolo);

                    {
                        string ultimoOrdineConArticolo = "";
                        ordiniFasiERP.MoveFirst();
                        while (!ordiniFasiERP.EOF)
                        {
                            string codArtERP = Common.GetCodiceArticoloFromEsolver(ordiniFasiERP.Codart, ordiniFasiERP.Varianteart);

                            if (codArtERP == articolo.CodiceArticolo)
                            {
                                ultimoOrdineConArticolo = ordiniFasiERP.Id;
                            }
                            ordiniFasiERP.MoveNext();
                        }
                        ordiniFasiERP.MoveToNextFieldValue(ordiniFasiERP.Fields.Id, ultimoOrdineConArticolo, true);
                    }

                    Common.AllineaCampiDaOggettoDati(articolo, ordiniFasiERP, campiDaAllineare);

                    if (articolo.RowChangedCount > 0)
                    {
                        articolo.Save();
                        Zero5.Util.Log.WriteLog("Aggiornato articolo " + articolo.CodiceEsterno);
                    }
                }
            }
        }

        public void VerificaAggiornamentoClienti(List<int> lstClientiDaVerificare, PHA_ODPFASI ordiniFasiERP, Dictionary<string, string> campiDaAllineare)
        {
            if (campiDaAllineare.Count == 0)
                return;

            if (lstClientiDaVerificare.Count > 0)
            {
                Zero5.Util.Log.WriteLog("Verifica aggiornamento clienti");

                foreach (int idCliente in lstClientiDaVerificare)
                {
                    ClientiFornitori cliente = new ClientiFornitori();
                    cliente.Load(cliente.Fields.IDClienteFornitore == idCliente);

                    {
                        string ultimoOrdineConCliente = "";
                        ordiniFasiERP.MoveFirst();
                        while (!ordiniFasiERP.EOF)
                        {
                            if (ordiniFasiERP.Codcliente.ToString() == cliente.CodiceEsterno)
                            {
                                ultimoOrdineConCliente = ordiniFasiERP.Id;
                            }
                            ordiniFasiERP.MoveNext();
                        }
                        ordiniFasiERP.MoveToNextFieldValue(ordiniFasiERP.Fields.Id, ultimoOrdineConCliente, true);
                    }

                    Common.AllineaCampiDaOggettoDati(cliente, ordiniFasiERP, campiDaAllineare);

                    if (cliente.RowChangedCount > 0)
                    {
                        cliente.Save();
                        Zero5.Util.Log.WriteLog("Aggiornato cliente " + cliente.CodiceEsterno);
                    }
                }
            }
        }

        private void ChiusuraOrdiniMancantiERP(List<int> lstIDOrdiniImportati)
        {
            if (lstIDOrdiniImportati.Count > 0)
            {
                if (Zero5.Data.Layer.Opzioni.helper.LoadIntValue(Opzioni.enumOpzioniID.Engine_OpzioniSistema_ImpostaOrdineChiusoSeUltimaFaseChiusa) == 0)
                    Zero5.Data.Layer.Opzioni.helper.SaveIntValue(Opzioni.enumOpzioniID.Engine_OpzioniSistema_ImpostaOrdineChiusoSeUltimaFaseChiusa, 1);

                Zero5.Data.Layer.OrdiniProduzione ordiniNonChiusi = new Zero5.Data.Layer.OrdiniProduzione();
                ordiniNonChiusi.Load(ordiniNonChiusi.Fields.Stato != Zero5.Data.Layer.OrdiniProduzione.enumOrdiniProduzioneStati.Chiuso, ordiniNonChiusi.Fields.CodiceEsterno != ""); // solo gli ordini provenienti da esolver hanno codice estern popolato

                Zero5.Server.Produzione z5prod = new Zero5.Server.Produzione();

                List<int> idOrdiniDaChiudere = new List<int>();
                while (!ordiniNonChiusi.EOF)
                {
                    // chiude gli ordini di phase che non sono piu presenti nella tabella di scambio
                    if (!lstIDOrdiniImportati.Contains(ordiniNonChiusi.IDOrdineProduzione))
                        idOrdiniDaChiudere.Add(ordiniNonChiusi.IDOrdineProduzione);
                    ordiniNonChiusi.MoveNext();
                }

                List<List<int>> ordiniDaChiudereAux = new List<List<int>>();
                Zero5.Util.Log.WriteLog("\tTrovati " + idOrdiniDaChiudere.Count.ToString() + " ordini da chiudere automaticamente.");
                ordiniDaChiudereAux.AddRange(Zero5.Util.Common.SplitList(idOrdiniDaChiudere, 2000));

                System.Threading.Thread.Sleep(100);
                foreach (List<int> lst in ordiniDaChiudereAux)
                {
                    foreach (int idOrdine in lst)
                    {
                        try
                        {
                            Zero5.Util.Log.WriteLog("Chiusura automatica IDOrdineProduzione " + idOrdine + ".");
                            z5prod.OrdiniProduzione_ChiudiOrdine(idOrdine, false);
                        }
                        catch (Exception ex)
                        {
                            Zero5.Util.Log.WriteLog("\t" + ex.Message);
                        }
                    }
                }

                //TODO: rimuovere la divisione in porzioni

            }
        }
    }
}
