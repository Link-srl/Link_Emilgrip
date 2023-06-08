using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaSchedeTecniche
    {
        public void EseguiImportazione()
        {
            if (!Configurazioni.Comune_Importazione_ImportaSchedeTecniche)
                return;


            List<int> lstTipoContenutoNumericoEsolver = new List<int>() { 0, 3 };
            List<int> lstTipoContenutoAlfanumericoEsolver = new List<int>() { 1, 4, 5 };
            List<int> lstTipoContenutoDataEsolver = new List<int>() { 2 };

            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_ARTICOLI", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Articoli);

            Dictionary<string, string> dicNomeCampoPhasePerEtichettaEsolver = new Dictionary<string, string>();

            string queryCampi = "";
            if (query.Contains("FROM"))
            {
                queryCampi = "SELECT DISTINCT Etichetta, tipo contenuto " + query.Substring(query.IndexOf("FROM"));
                PHA_ARTSCHEDETEC etichetteSchedeTecnicheEsolver = new PHA_ARTSCHEDETEC(queryCampi);

                Zero5.Data.Layer.SchemaDBCampi campiSchedeTecnichePhase = new SchemaDBCampi();
                campiSchedeTecnichePhase.Load(campiSchedeTecnichePhase.Fields.IDTabella == (int)Zero5.Data.Layer.Contatori.enumContatoriTipoTabella.SchedeTecniche);

                while (!etichetteSchedeTecnicheEsolver.EOF)
                {
                    campiSchedeTecnichePhase.MoveToNextFieldValue(campiSchedeTecnichePhase.Fields.NomeCampoPersonalizzato, etichetteSchedeTecnicheEsolver.Etichetta, true);
                    if (!campiSchedeTecnichePhase.EOF)
                    {
                        if (campiSchedeTecnichePhase.Disabilitato)
                        {
                            campiSchedeTecnichePhase.StatoCampoAlProssimoAvvio = SchemaDBCampi.eStatoCampoAlProssimoAvvio.Abilitato;
                            campiSchedeTecnichePhase.NomeCampoPersonalizzato = etichetteSchedeTecnicheEsolver.Etichetta;
                            campiSchedeTecnichePhase.Save();
                            Zero5.Util.Log.WriteLog("Importazione schede tecniche, richiesta abilitazione al prossimo riavvio per il campo " + campiSchedeTecnichePhase.NomeCampo + " con nome " + campiSchedeTecnichePhase.NomeCampoPersonalizzato);
                        }
                        else
                        {
                            if (!dicNomeCampoPhasePerEtichettaEsolver.ContainsKey(etichetteSchedeTecnicheEsolver.Etichetta))
                                dicNomeCampoPhasePerEtichettaEsolver.Add(etichetteSchedeTecnicheEsolver.Etichetta, campiSchedeTecnichePhase.NomeCampo);
                        }
                    }
                    else
                    {
                        campiSchedeTecnichePhase.MoveFirst();
                        while (!campiSchedeTecnichePhase.EOF)
                        {
                            if (campiSchedeTecnichePhase.StatoCampoAlProssimoAvvio == SchemaDBCampi.eStatoCampoAlProssimoAvvio.Invariato &&
                                campiSchedeTecnichePhase.Disabilitato)
                            {


                                if (lstTipoContenutoNumericoEsolver.Contains(etichetteSchedeTecnicheEsolver.Tipocontenuto) && campiSchedeTecnichePhase.NomeCampo.StartsWith("extInt"))
                                    break;
                                else if (lstTipoContenutoAlfanumericoEsolver.Contains(etichetteSchedeTecnicheEsolver.Tipocontenuto) && campiSchedeTecnichePhase.NomeCampo.StartsWith("extString"))
                                    break;

                                //Double


                            }



                            campiSchedeTecnichePhase.MoveNext();
                        }

                    }

                    etichetteSchedeTecnicheEsolver.MoveNext();
                }



            }




            //nrArticoliUltimaLetturaERP = 0;
            //PHA_ARTICOLI articoliERP = new PHA_ARTICOLI(query);

            //if (articoliERP == null || articoliERP.RowCount == 0)
            //    return;

            //nrArticoliUltimaLetturaERP = articoliERP.RowCount;

            //Zero5.Util.Log.WriteLog("Importazione " + articoliERP.RowCount.ToString() + " PHA_ARTICOLI.");

            //Articoli articoliPhase = new Articoli();
            //articoliPhase.LoadAll();

            //if (articoliERP.DataTable.Columns.Contains("DesArticolo"))
            //{
            //    if (!articoliERP.DataTable.Columns.Contains("DesArt"))
            //        articoliERP.DataTable.Columns["DesArticolo"].ColumnName = "DesArt";
            //}

            //Dictionary<string, string> campiDaAggiornareDefault = new Dictionary<string, string> {
            //            {  articoliPhase.Fields.Descrizione.FieldName, articoliERP.Fields.Desart.FieldName},
            //            {  articoliPhase.Fields.UnitaDiMisura.FieldName, articoliERP.Fields.Ummag.FieldName},
            //        };

            //Dictionary<string, string> dicCampiDaAggiornare = Common.GetMappingDictionaryFromJson("AggiornaCampi_Articoli_Da_PHAARTICOLI", campiDaAggiornareDefault);

            //while (!articoliERP.EOF)
            //{
            //    string codArticoloERP = Common.GetCodiceArticoloFromEsolver(articoliERP.Codart, articoliERP.Varianteart);

            //    if (articoliPhase.CodiceArticolo != codArticoloERP)
            //        articoliPhase.MoveToNextFieldValue(articoliPhase.Fields.CodiceArticolo, codArticoloERP, true);

            //    if (articoliPhase.EOF)
            //    {
            //        articoliPhase.AddNewAndNewID();

            //        articoliPhase.CodiceArticolo = codArticoloERP;
            //        articoliPhase.CodiceEsterno = articoliERP.Codart;
            //        articoliPhase.DataOraCreazione = DateTime.Now;
            //        articoliPhase.Save();

            //        Zero5.Util.Log.WriteLog("\tCreato articolo " + articoliPhase.CodiceEsterno);
            //    }

            //    Common.AllineaCampiDaOggettoDati(articoliPhase, articoliERP, dicCampiDaAggiornare);

            //    Zero5.Data.Layer.Articoli.eTipoArticolo tipoArticoloERP = Articoli.eTipoArticolo.Default;
            //    switch (articoliERP.Tipoart)
            //    {
            //        case 0:
            //            tipoArticoloERP = Articoli.eTipoArticolo.MateriaPrima;
            //            break;
            //        case 1:
            //            tipoArticoloERP = Articoli.eTipoArticolo.Semilavorato;
            //            break;
            //        case 2:
            //            tipoArticoloERP = Articoli.eTipoArticolo.Kit;
            //            break;
            //        case 3:
            //            tipoArticoloERP = Articoli.eTipoArticolo.ProdottoFinito;
            //            break;
            //        case 4:
            //            tipoArticoloERP = Articoli.eTipoArticolo.ContenitoreARendere;
            //            break;
            //        case 5:
            //            tipoArticoloERP = Articoli.eTipoArticolo.ImballoAPerdere;
            //            break;
            //        case 6:
            //            tipoArticoloERP = Articoli.eTipoArticolo.MaterialeAusiliario;
            //            break;
            //        case 7:
            //            tipoArticoloERP = Articoli.eTipoArticolo.Impianto;
            //            break;
            //        case 8:
            //            tipoArticoloERP = Articoli.eTipoArticolo.ComponenteFittizio;
            //            break;
            //        default:
            //            tipoArticoloERP = Articoli.eTipoArticolo.Default;
            //            break;
            //    };

            //    bool obsoletoERP = false;
            //    if (articoliERP.Datafinevalidita > new DateTime(1990, 1, 1) && articoliERP.Datafinevalidita < DateTime.Now)
            //        obsoletoERP = true;

            //    //TODO: importare um peso netto così da gestire oltre KG e GR
            //    double pesoNettoUnitarioERP = 0;
            //    if (articoliERP.Umpesonettounit == "KG")
            //        pesoNettoUnitarioERP = articoliERP.Pesonettounit;
            //    else if (articoliERP.Umpesonettounit == "GR")
            //        pesoNettoUnitarioERP = articoliERP.Pesonettounit * 1000;

            //    //TODO: controllare il significato dell'oggetto sopra

            //    Common.AllineaCampiDaValori(articoliPhase, new Dictionary<Zero5.Data.Filter.Field, object> {
            //        { articoliPhase.Fields.TipoArticolo, tipoArticoloERP},
            //        { articoliPhase.Fields.Obsoleto, obsoletoERP},
            //        { articoliPhase.Fields.PesoNetto, pesoNettoUnitarioERP}
            //    });

            //    //TODO: UnitàPerCollo ColliPerStrato StratoPerUnitaCarico

            //    if (articoliPhase.RowChangedCount > 0)
            //        articoliPhase.Save();

            //    articoliERP.MoveNext();
            //}
        }
    }
}
