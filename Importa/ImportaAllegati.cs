using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    public class ImportaAllegati
    {

        public void EseguiImportazione()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_Allegati", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Allegati);

            PHA_ALLEGATI allegatiERP = new PHA_ALLEGATI(query);

            if (allegatiERP == null || allegatiERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + allegatiERP.RowCount.ToString() + " PHA_Allegati.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Data.Layer.Allegati allegatiPhase = new Zero5.Data.Layer.Allegati();
            allegatiPhase.LoadAll();

            List<int> lstIdAllegatiPapabili = new List<int>();

            while (!allegatiPhase.EOF)
            {
                try
                {
                    if (!File.Exists(allegatiPhase.PercorsoCompleto))
                    {
                        allegatiPhase.IDRaggruppamento = 0;
                        allegatiPhase.IDTipoAllegato = 0;
                        allegatiPhase.Attivo = false;
                        allegatiPhase.DataInserimento = DateTime.MinValue;
                        allegatiPhase.DataAggiornamento = DateTime.MinValue;
                        allegatiPhase.IDUtenteInserimento = 0;
                        allegatiPhase.IDUtenteAggiornamento = 0;
                        allegatiPhase.NomeFile = string.Empty;
                        allegatiPhase.Descrizione = string.Empty;
                        allegatiPhase.PercorsoCompleto = string.Empty;
                        allegatiPhase.IDArticolo = 0;
                        allegatiPhase.IDRisorsaMacchina = 0;
                        allegatiPhase.NumeroFase = 0;
                        allegatiPhase.OperazioneFase = string.Empty;
                        allegatiPhase.DescrizioneFase = string.Empty;
                        allegatiPhase.IDOrdineProduzione = 0;
                        allegatiPhase.CodiceEsterno = string.Empty;
                        allegatiPhase.DimensioneAllegato = 0;
                        allegatiPhase.IDNCSegnalazione = 0;
                        allegatiPhase.IDCRMAttivita = 0;
                        allegatiPhase.IDContestoSicurezza = 0;
                        allegatiPhase.IDCaratteristica = 0;
                        allegatiPhase.IDModelliControllo = 0;
                        allegatiPhase.IDTipoImballo = 0;

                        lstIdAllegatiPapabili.Add(allegatiPhase.IDAllegato);
                    }
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Errore per IDAllegato:'" + allegatiPhase.IDAllegato + "' messaggio:" + ex.Message);
                }

                allegatiPhase.MoveNext();
            }
            allegatiPhase.Save();

            Zero5.Data.Layer.TipiAllegato tipoAllegato = new Zero5.Data.Layer.TipiAllegato();
            // controllo il tipo allegato deve esistere quello esolver
            tipoAllegato.Load(tipoAllegato.Fields.Descrizione == "eSolver");
            if (tipoAllegato.EOF)
            {
                tipoAllegato.AddNewAndNewID();
                tipoAllegato.Descrizione = "eSolver";
                tipoAllegato.ModalitaSalvataggioFile = Zero5.Data.Layer.TipiAllegato.enumModalitaSalvataggioFile.CollegamentoFile;
                tipoAllegato.Save();
                Zero5.Util.Log.WriteLog("Creazione del tipo allegato eSolver");
            }

            Articoli articoliPhase = new Articoli();
            articoliPhase.LoadNone();

            OrdiniProduzione ordiniPhase = new OrdiniProduzione();
            ordiniPhase.LoadNone();

            while (!allegatiERP.EOF)
            {
                string percorsoFile = allegatiERP.Percorso + allegatiERP.Nomefile;
                try
                {
                    FileInfo fileInfo = new FileInfo(percorsoFile);
                    if (!fileInfo.Exists)
                        throw new ArgumentException("Allegato ERP file: '" + percorsoFile + "' non esiste, non verrà quindi importato");

                    if (!allegatiPhase.PercorsoCompleto.Equals(percorsoFile, StringComparison.OrdinalIgnoreCase))
                    {
                        allegatiPhase.Load(allegatiPhase.Fields.PercorsoCompleto == percorsoFile);
                        // se non esiste verifico se ci sono id da recuperare

                        if (allegatiPhase.EOF) // creazione o riutilizzo di record
                        {
                            if (lstIdAllegatiPapabili.Count > 0)
                            {
                                int idAllegato = lstIdAllegatiPapabili.First();
                                allegatiPhase.Load(allegatiPhase.Fields.IDAllegato == idAllegato);
                                lstIdAllegatiPapabili.Remove(idAllegato);
                                //   Zero5.Util.Log.WriteLog("Riutilizzato record id : '" + idAllegato + "'");
                            }
                            else // se non ci sono id da recuperare allora lo creo 
                            {
                                allegatiPhase.AddNewAndNewID();
                                // Zero5.Util.Log.WriteLog("Inserimento di un nuovo record : '" + allegatiPhase.IDAllegato+ "'");
                            }
                            allegatiPhase.PercorsoCompleto = fileInfo.FullName;
                            allegatiPhase.DataInserimento = DateTime.Now;
                        }
                        // campi che vengono aggiornati 
                        allegatiPhase.Attivo = true;
                        allegatiPhase.IDTipoAllegato = tipoAllegato.IDTipoAllegato;
                        allegatiPhase.IDArticolo = 0;
                        allegatiPhase.IDRisorsaMacchina = 0;
                        allegatiPhase.NumeroFase = 0;
                        allegatiPhase.OperazioneFase = string.Empty;
                        allegatiPhase.DescrizioneFase = string.Empty;
                        allegatiPhase.IDOrdineProduzione = 0;
                        allegatiPhase.CodiceEsterno = allegatiERP.Idallegato.ToString();
                        allegatiPhase.DimensioneAllegato = (int)fileInfo.Length;
                        allegatiPhase.IDNCSegnalazione = 0;
                        allegatiPhase.IDCRMAttivita = 0;
                        allegatiPhase.IDContestoSicurezza = 0;
                        allegatiPhase.IDCaratteristica = 0;
                        allegatiPhase.IDModelliControllo = 0;
                        allegatiPhase.IDTipoImballo = 0;

                        allegatiPhase.NomeFile = string.IsNullOrEmpty(allegatiERP.Nomefile) ? fileInfo.Name : allegatiERP.Nomefile;
                        allegatiPhase.IDRaggruppamento = 0;// TODO ??
                        allegatiPhase.DataAggiornamento = DateTime.Now;
                        allegatiPhase.IDUtenteInserimento = 0;
                        allegatiPhase.IDUtenteAggiornamento = 0;

                        allegatiPhase.Save();
                        //Zero5.Util.Log.WriteLog("Aggiornamento del record record : '" + allegatiPhase.IDAllegato + "'");
                    }

                    #region Associazione ARTICOLI
                    if (!string.IsNullOrEmpty(allegatiERP.Codart))
                    {
                        articoliPhase.Load(articoliPhase.Fields.CodiceEsterno == allegatiERP.Codart);
                        if (!articoliPhase.EOF)
                        {
                            allegatiPhase.IDArticolo = articoliPhase.IDArticolo;
                            allegatiPhase.Save();
                        }

                    }
                    #endregion
                    #region Associazione ORDINI
                    // associo ordine

                    string codiceEsternoOrdine = Shared.Common.GetCodiceEsternoOrdineFromCodiceEsternoFase(allegatiERP.Iddoc);

                    if (!string.IsNullOrEmpty(codiceEsternoOrdine))
                    {
                        ordiniPhase.Load(ordiniPhase.Fields.CodiceEsterno == codiceEsternoOrdine);
                        if (!ordiniPhase.EOF)
                        {
                            allegatiPhase.IDOrdineProduzione = ordiniPhase.IDOrdineProduzione;
                            allegatiPhase.Save();
                        }
                    }
                    #endregion
                }
                catch (ArgumentException ex)
                {
                    Zero5.Util.Log.WriteLog(ex.Message);
                }
                catch (Exception ex)
                {
                    Zero5.Util.Log.WriteLog("Errore importazione allegato idAllegatoERP:'" + allegatiERP.Idallegato + "' " + ex.Message);
                }
                allegatiERP.MoveNext();
            }

            // eliminazione degli allegati papabili non usati
            Allegati AllegatiDaEliminare;
            List<List<int>> righeAllegatiDaEliminare = new List<List<int>>();
            righeAllegatiDaEliminare.AddRange(Zero5.Util.Common.SplitList(lstIdAllegatiPapabili, 2000));

            foreach (List<int> lst in righeAllegatiDaEliminare)
            {
                AllegatiDaEliminare = new Allegati();
                Zero5.Data.Filter.Filter filtro = new Zero5.Data.Filter.Filter();
                filtro.Add(AllegatiDaEliminare.Fields.IDAllegato.FilterIn(lst));
                AllegatiDaEliminare.Load(filtro);
                AllegatiDaEliminare.DeleteAll();
                AllegatiDaEliminare.Save();
                System.Threading.Thread.Sleep(10);
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Allegati. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}