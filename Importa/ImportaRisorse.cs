using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;

namespace ScambioDati
{
    class ImportaRisorse
    {
        private enum eTipoRisorsa_eSolver
        {
            Reparto = 0,
            Macchina = 1,
            UomoManodopera = 2,
            Terzista = 3,
            UomoServizi = 4,
        }

        public void EseguiImportazione()
        {
            #region Livelli
            Zero5.Data.Layer.Livelli liv = new Livelli();
            liv.LoadAll(liv.Fields.IDLivello.FieldName);

            int IDLivelloMacchina = -1;
            int IDLivelloIsola = -1;
            int IDLivelloUomo = -1;
            int IDLivelloSquadra = -1;

            while (!liv.EOF)
            {
                if (liv.Tipo == Livelli.eTipo.Macchina)
                {
                    if (IDLivelloMacchina == -1)
                        IDLivelloMacchina = liv.IDLivello;
                    else if (IDLivelloIsola == -1)
                        IDLivelloIsola = liv.IDLivello;
                }
                else if (liv.Tipo == Livelli.eTipo.Uomo)
                {
                    if (IDLivelloUomo == -1)
                        IDLivelloUomo = liv.IDLivello;
                    if (IDLivelloSquadra == -1)
                        IDLivelloSquadra = liv.IDLivello;
                }
                liv.MoveNext();
            }
            #endregion

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_RISORSEPROD", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Risorse);

            PHA_RISORSEPROD risorseERP = new PHA_RISORSEPROD(query);

            if (risorseERP == null || risorseERP.RowCount == 0)
                return;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            Zero5.Util.Log.WriteLog("Importazione " + risorseERP.RowCount.ToString() + " PHA_RISORSEPROD.");

            Risorse risorsePhase = new Risorse();
            risorsePhase.LoadAll();

            while (!risorseERP.EOF)
            {
                List<int> lstValoriConsentiti = new List<int>() {
                    (int) eTipoRisorsa_eSolver.Macchina,
                    (int) eTipoRisorsa_eSolver.Reparto,
                    (int) eTipoRisorsa_eSolver.Terzista,
                    (int) eTipoRisorsa_eSolver.UomoManodopera,
                    (int) eTipoRisorsa_eSolver.UomoServizi
                };

                if (lstValoriConsentiti.Contains(risorseERP.Tiporisorsaprod))
                {
                    Zero5.Data.Layer.Risorse.eTipo tipoRisorsa = Risorse.eTipo.Macchina;
                    if ((eTipoRisorsa_eSolver)risorseERP.Tiporisorsaprod == eTipoRisorsa_eSolver.UomoManodopera ||
                          (eTipoRisorsa_eSolver)risorseERP.Tiporisorsaprod == eTipoRisorsa_eSolver.UomoServizi)
                        tipoRisorsa = Risorse.eTipo.Uomo;
                    else
                        tipoRisorsa = Risorse.eTipo.Macchina;

                    #region RISORSA PADRE
                    int idRisorsaPadre = 0;
                    if (!string.IsNullOrEmpty(risorseERP.Risorsapadre))
                    {
                        if (risorsePhase.CodiceEsterno != risorseERP.Risorsapadre ||
                            risorsePhase.Tipo != tipoRisorsa)
                        {
                            risorsePhase.MoveFirst();
                            while (!risorsePhase.EOF)
                            {
                                if (risorsePhase.CodiceEsterno == risorseERP.Risorsapadre &&
                                    risorsePhase.Tipo == tipoRisorsa)
                                    break;
                                risorsePhase.MoveNext();
                            }
                        }

                        if (risorsePhase.EOF)
                        {
                            risorsePhase.AddNewAndNewID();

                            risorsePhase.Codice = risorseERP.Risorsapadre;
                            risorsePhase.CodiceEsterno = risorseERP.Risorsapadre;
                            risorsePhase.Tipo = tipoRisorsa;
                            if (risorsePhase.Tipo == Risorse.eTipo.Uomo)
                                risorsePhase.IDLivello = IDLivelloSquadra;
                            else
                                risorsePhase.IDLivello = IDLivelloIsola;

                            risorsePhase.Save();

                            Zero5.Util.Log.WriteLog("\tCreata risorsa " + risorsePhase.CodiceEsterno);
                        }

                        idRisorsaPadre = risorsePhase.IDRisorsa;
                    }
                    #endregion

                    #region RISORSA FIGLIA

                    if (risorsePhase.CodiceEsterno != risorseERP.Codrisorsaprod ||
                           risorsePhase.Tipo != tipoRisorsa)
                    {
                        risorsePhase.MoveFirst();
                        while (!risorsePhase.EOF)
                        {
                            if (risorsePhase.CodiceEsterno == risorseERP.Codrisorsaprod &&
                                risorsePhase.Tipo == tipoRisorsa)
                                break;
                            risorsePhase.MoveNext();
                        }
                    }

                    if (risorsePhase.EOF)
                    {
                        risorsePhase.AddNewAndNewID();

                        risorsePhase.Codice = risorseERP.Codrisorsaprod;
                        risorsePhase.CodiceEsterno = risorseERP.Codrisorsaprod;
                        risorsePhase.IDRisorsaPadre = idRisorsaPadre;
                        risorsePhase.Tipo = tipoRisorsa;
                        if (risorsePhase.Tipo == Risorse.eTipo.Uomo)
                            risorsePhase.IDLivello = IDLivelloUomo;
                        else
                        {
                            risorsePhase.IDLivello = IDLivelloMacchina;
                            risorsePhase.AbilitaProgrammazione = Risorse.eAbilitaProgrammazione.Si;
                            risorsePhase.AbilitaMonitoraggio = true;

                            risorsePhase.MinutiLimiteFermoGenerico = 5;

                            risorsePhase.InAperturaMacchinaConsideraDispositivoInStatoON = Zero5.Data.Layer.Risorse.eForzaStatoMacchinaInApertura.ReplicaElseForzaOFF;
                            risorsePhase.MinutiCuscinetto = 10;

                            risorsePhase.OttimizzaSetupConfigurazioneStampo = Zero5.Data.Layer.Risorse.eSistemaSiNo.Sistema;
                            risorsePhase.PercOttimizzazioneSetupConfigurazioneStampo = 100;

                            risorsePhase.OttimizzaSetupMaterialeCodice = Zero5.Data.Layer.Risorse.eSistemaSiNo.Sistema;
                            risorsePhase.PercOttimizzazioneSetupMaterialeCodice = 100;

                            risorsePhase.OttimizzaSetupNoteDistintaMateriale = Zero5.Data.Layer.Risorse.eSistemaSiNo.Sistema;
                            risorsePhase.PercOttimizzazioneSetupNoteDistintaMateriale = 100;

                            risorsePhase.OttimizzaSetupArticolo = Zero5.Data.Layer.Risorse.eSistemaSiNo.Sistema;
                            risorsePhase.PercOttimizzazioneSetupArticolo = 100;
                        }

                        risorsePhase.Save();

                        Zero5.Util.Log.WriteLog("\tCreata risorsa " + risorsePhase.CodiceEsterno);
                    }

                    Common.AllineaCampiDaOggettoDati(risorsePhase, risorseERP, new Dictionary<string, string> {
                        {  risorsePhase.Fields.Nome.FieldName, risorseERP.Fields.Des.FieldName},
                        {  risorsePhase.Fields.Descrizione.FieldName, risorseERP.Fields.Des.FieldName},
                    });

                    if (risorsePhase.RowChangedCount > 0)
                    {
                        risorsePhase.Save();
                    }
                    #endregion
                }
                risorseERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Risorse. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
