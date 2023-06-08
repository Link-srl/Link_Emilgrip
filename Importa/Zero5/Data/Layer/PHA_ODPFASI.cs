using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_ODPFASI : ESolverDataObject
    {
        public PHA_ODPFASI(string selectQuery) : base("PHA_ODPFASI", selectQuery)
        {
        }

        #region Fields
        private static FieldsObject fields = new FieldsObject();
        public FieldsObject Fields
        {
            get { return fields; }
        }

        public static FieldsObject ClassFields
        {
            get { return fields; }
        }

        public override Zero5.Data.Layer.Fields.BaseFields FieldsList
        {
            get { return fields; }
        }
        internal class FieldsObject : Zero5.Data.Layer.Fields.BaseFields
        {
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_ODPFASI", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codcliente = new Filter.IntegerField("PHA_ODPFASI", "CodCliente", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codlavorazione = new Filter.StringField("PHA_ODPFASI", "CodLavorazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codrisorsaprod = new Filter.StringField("PHA_ODPFASI", "CodRisorsaProd", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codterzista = new Filter.IntegerField("PHA_ODPFASI", "CodTerzista", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codtipodoc = new Filter.IntegerField("PHA_ODPFASI", "CodTipoDoc", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Commessa = new Filter.StringField("PHA_ODPFASI", "Commessa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datafinepianif = new Filter.DateTimeField("PHA_ODPFASI", "DataFinePianif", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datafinesched = new Filter.DateTimeField("PHA_ODPFASI", "DataFineSched", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datainiziopianif = new Filter.DateTimeField("PHA_ODPFASI", "DataInizioPianif", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datainiziosched = new Filter.DateTimeField("PHA_ODPFASI", "DataInizioSched", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Dataregistrazione = new Filter.DateTimeField("PHA_ODPFASI", "DataRegistrazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_ODPFASI", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desarticolo = new Filter.StringField("PHA_ODPFASI", "DesArticolo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desestesarigaodp = new Filter.StringField("PHA_ODPFASI", "DesEstesaRigaOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Deslavorazione = new Filter.StringField("PHA_ODPFASI", "DesLavorazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desrisorsa = new Filter.StringField("PHA_ODPFASI", "DesRisorsa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Destipodoc = new Filter.StringField("PHA_ODPFASI", "DesTipoDoc", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Fasecontolavoro = new Filter.IntegerField("PHA_ODPFASI", "FaseContoLavoro", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Gruppodoc = new Filter.StringField("PHA_ODPFASI", "GruppoDoc", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Id = new Filter.StringField("PHA_ODPFASI", "Id", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Iddocumento = new Filter.IntegerField("PHA_ODPFASI", "IdDocumento", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idriga = new Filter.IntegerField("PHA_ODPFASI", "IdRiga", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idrigalavorazione = new Filter.IntegerField("PHA_ODPFASI", "IdRigaLavorazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Leadtimefase = new Filter.DoubleField("PHA_ODPFASI", "LeadTimeFase", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Notainterna = new Filter.StringField("PHA_ODPFASI", "NotaInterna", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numfase = new Filter.DoubleField("PHA_ODPFASI", "NumFase", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numoreimpegnoprod = new Filter.DoubleField("PHA_ODPFASI", "NumOreImpegnoProd", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numunitaoperative = new Filter.DoubleField("PHA_ODPFASI", "NumUnitaOperative", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Quantitaavanzata = new Filter.DoubleField("PHA_ODPFASI", "QuantitaAvanzata", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Quantitaordinata = new Filter.DoubleField("PHA_ODPFASI", "QuantitaOrdinata", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Quantitaordinataudm2 = new Filter.DoubleField("PHA_ODPFASI", "QuantitaOrdinataUdM2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Ragsocialecliente = new Filter.StringField("PHA_ODPFASI", "RagSocialeCliente", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Ragsocialeterzista = new Filter.StringField("PHA_ODPFASI", "RagSocialeTerzista", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Riflottoalfanum = new Filter.StringField("PHA_ODPFASI", "RifLottoAlfanum", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Riflottodata = new Filter.DateTimeField("PHA_ODPFASI", "RifLottoData", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Riflottonumero = new Filter.IntegerField("PHA_ODPFASI", "RifLottoNumero", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodp = new Filter.StringField("PHA_ODPFASI", "RifOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Statofaseodp = new Filter.IntegerField("PHA_ODPFASI", "StatoFaseOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Tempoattr = new Filter.DoubleField("PHA_ODPFASI", "TempoAttr", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Tempociclo = new Filter.DoubleField("PHA_ODPFASI", "TempoCiclo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Temposmont = new Filter.DoubleField("PHA_ODPFASI", "TempoSmont", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Udm = new Filter.StringField("PHA_ODPFASI", "UdM", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Udm2 = new Filter.StringField("PHA_ODPFASI", "UdM2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Udmattrsmont = new Filter.IntegerField("PHA_ODPFASI", "UdMAttrSmont", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Udmlavorazione = new Filter.IntegerField("PHA_ODPFASI", "UdMLavorazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_ODPFASI", "VarianteArt", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_ODPFASI.ClassFields.Codart,
                            PHA_ODPFASI.ClassFields.Codcliente,
                            PHA_ODPFASI.ClassFields.Codlavorazione,
                            PHA_ODPFASI.ClassFields.Codrisorsaprod,
                            PHA_ODPFASI.ClassFields.Codterzista,
                            PHA_ODPFASI.ClassFields.Codtipodoc,
                            PHA_ODPFASI.ClassFields.Commessa,
                            PHA_ODPFASI.ClassFields.Datafinepianif,
                            PHA_ODPFASI.ClassFields.Datafinesched,
                            PHA_ODPFASI.ClassFields.Datainiziopianif,
                            PHA_ODPFASI.ClassFields.Datainiziosched,
                            PHA_ODPFASI.ClassFields.Dataregistrazione,
                            PHA_ODPFASI.ClassFields.Dbgruppo,
                            PHA_ODPFASI.ClassFields.Desarticolo,
                            PHA_ODPFASI.ClassFields.Desestesarigaodp,
                            PHA_ODPFASI.ClassFields.Deslavorazione,
                            PHA_ODPFASI.ClassFields.Desrisorsa,
                            PHA_ODPFASI.ClassFields.Destipodoc,
                            PHA_ODPFASI.ClassFields.Fasecontolavoro,
                            PHA_ODPFASI.ClassFields.Gruppodoc,
                            PHA_ODPFASI.ClassFields.Id,
                            PHA_ODPFASI.ClassFields.Iddocumento,
                            PHA_ODPFASI.ClassFields.Idriga,
                            PHA_ODPFASI.ClassFields.Idrigalavorazione,
                            PHA_ODPFASI.ClassFields.Leadtimefase,
                            PHA_ODPFASI.ClassFields.Notainterna,
                            PHA_ODPFASI.ClassFields.Numfase,
                            PHA_ODPFASI.ClassFields.Numoreimpegnoprod,
                            PHA_ODPFASI.ClassFields.Numunitaoperative,
                            PHA_ODPFASI.ClassFields.Quantitaavanzata,
                            PHA_ODPFASI.ClassFields.Quantitaordinata,
                            PHA_ODPFASI.ClassFields.Quantitaordinataudm2,
                            PHA_ODPFASI.ClassFields.Ragsocialecliente,
                            PHA_ODPFASI.ClassFields.Ragsocialeterzista,
                            PHA_ODPFASI.ClassFields.Riflottoalfanum,
                            PHA_ODPFASI.ClassFields.Riflottodata,
                            PHA_ODPFASI.ClassFields.Riflottonumero,
                            PHA_ODPFASI.ClassFields.Rifodp,
                            PHA_ODPFASI.ClassFields.Statofaseodp,
                            PHA_ODPFASI.ClassFields.Tempoattr,
                            PHA_ODPFASI.ClassFields.Tempociclo,
                            PHA_ODPFASI.ClassFields.Temposmont,
                            PHA_ODPFASI.ClassFields.Udm,
                            PHA_ODPFASI.ClassFields.Udm2,
                            PHA_ODPFASI.ClassFields.Udmattrsmont,
                            PHA_ODPFASI.ClassFields.Udmlavorazione,
                            PHA_ODPFASI.ClassFields.Varianteart
                        };
                    }
                    return fieldList;
                }
            }

            public new Zero5.Data.Filter.Field ByFieldName(string fieldName)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].FieldName == fieldName) return Items[i];
                }
                return null;
            }
        }

        #endregion
    }
}
namespace Zero5.Data.Layer
{
    internal partial class PHA_ODPFASI : ESolverDataObject
    {
        #region Properties
        public string Codart
        {
            get
            {
                return base.get_StringField("CodArt");
            }
            set
            {
                base.set_StringField("CodArt", value);
            }
        }
        public int Codcliente
        {
            get
            {
                return base.get_IntegerField("CodCliente");
            }
            set
            {
                base.set_IntegerField("CodCliente", value);
            }
        }
        public string Codlavorazione
        {
            get
            {
                return base.get_StringField("CodLavorazione");
            }
            set
            {
                base.set_StringField("CodLavorazione", value);
            }
        }
        public string Codrisorsaprod
        {
            get
            {
                return base.get_StringField("CodRisorsaProd");
            }
            set
            {
                base.set_StringField("CodRisorsaProd", value);
            }
        }
        public int Codterzista
        {
            get
            {
                return base.get_IntegerField("CodTerzista");
            }
            set
            {
                base.set_IntegerField("CodTerzista", value);
            }
        }
        public int Codtipodoc
        {
            get
            {
                return base.get_IntegerField("CodTipoDoc");
            }
            set
            {
                base.set_IntegerField("CodTipoDoc", value);
            }
        }
        public string Commessa
        {
            get
            {
                return base.get_StringField("Commessa");
            }
            set
            {
                base.set_StringField("Commessa", value);
            }
        }
        public DateTime Datafinepianif
        {
            get
            {
                return base.get_DateTimeField("DataFinePianif");
            }
            set
            {
                base.set_DateTimeField("DataFinePianif", value);
            }
        }
        public DateTime Datafinesched
        {
            get
            {
                return base.get_DateTimeField("DataFineSched");
            }
            set
            {
                base.set_DateTimeField("DataFineSched", value);
            }
        }
        public DateTime Datainiziopianif
        {
            get
            {
                return base.get_DateTimeField("DataInizioPianif");
            }
            set
            {
                base.set_DateTimeField("DataInizioPianif", value);
            }
        }
        public DateTime Datainiziosched
        {
            get
            {
                return base.get_DateTimeField("DataInizioSched");
            }
            set
            {
                base.set_DateTimeField("DataInizioSched", value);
            }
        }
        public DateTime Dataregistrazione
        {
            get
            {
                return base.get_DateTimeField("DataRegistrazione");
            }
            set
            {
                base.set_DateTimeField("DataRegistrazione", value);
            }
        }
        public string Dbgruppo
        {
            get
            {
                return base.get_StringField("DBGruppo");
            }
            set
            {
                base.set_StringField("DBGruppo", value);
            }
        }
        public string Desarticolo
        {
            get
            {
                return base.get_StringField("DesArticolo");
            }
            set
            {
                base.set_StringField("DesArticolo", value);
            }
        }
        public string Desestesarigaodp
        {
            get
            {
                return base.get_StringField("DesEstesaRigaOdP");
            }
            set
            {
                base.set_StringField("DesEstesaRigaOdP", value);
            }
        }
        public string Deslavorazione
        {
            get
            {
                return base.get_StringField("DesLavorazione");
            }
            set
            {
                base.set_StringField("DesLavorazione", value);
            }
        }
        public string Desrisorsa
        {
            get
            {
                return base.get_StringField("DesRisorsa");
            }
            set
            {
                base.set_StringField("DesRisorsa", value);
            }
        }
        public string Destipodoc
        {
            get
            {
                return base.get_StringField("DesTipoDoc");
            }
            set
            {
                base.set_StringField("DesTipoDoc", value);
            }
        }
        public int Fasecontolavoro
        {
            get
            {
                return base.get_IntegerField("FaseContoLavoro");
            }
            set
            {
                base.set_IntegerField("FaseContoLavoro", value);
            }
        }
        public string Gruppodoc
        {
            get
            {
                return base.get_StringField("GruppoDoc");
            }
            set
            {
                base.set_StringField("GruppoDoc", value);
            }
        }
        public string Id
        {
            get
            {
                return base.get_StringField("Id");
            }
            set
            {
                base.set_StringField("Id", value);
            }
        }
        public int Iddocumento
        {
            get
            {
                return base.get_IntegerField("IdDocumento");
            }
            set
            {
                base.set_IntegerField("IdDocumento", value);
            }
        }
        public int Idriga
        {
            get
            {
                return base.get_IntegerField("IdRiga");
            }
            set
            {
                base.set_IntegerField("IdRiga", value);
            }
        }
        public int Idrigalavorazione
        {
            get
            {
                return base.get_IntegerField("IdRigaLavorazione");
            }
            set
            {
                base.set_IntegerField("IdRigaLavorazione", value);
            }
        }
        public double Leadtimefase
        {
            get
            {
                return base.get_DoubleField("LeadTimeFase");
            }
            set
            {
                base.set_DoubleField("LeadTimeFase", value);
            }
        }
        public string Notainterna
        {
            get
            {
                return base.get_StringField("NotaInterna");
            }
            set
            {
                base.set_StringField("NotaInterna", value);
            }
        }
        public double Numfase
        {
            get
            {
                return base.get_DoubleField("NumFase");
            }
            set
            {
                base.set_DoubleField("NumFase", value);
            }
        }
        public double Numoreimpegnoprod
        {
            get
            {
                return base.get_DoubleField("NumOreImpegnoProd");
            }
            set
            {
                base.set_DoubleField("NumOreImpegnoProd", value);
            }
        }
        public double Numunitaoperative
        {
            get
            {
                return base.get_DoubleField("NumUnitaOperative");
            }
            set
            {
                base.set_DoubleField("NumUnitaOperative", value);
            }
        }
        public double Quantitaavanzata
        {
            get
            {
                return base.get_DoubleField("QuantitaAvanzata");
            }
            set
            {
                base.set_DoubleField("QuantitaAvanzata", value);
            }
        }
        public double Quantitaordinata
        {
            get
            {
                return base.get_DoubleField("QuantitaOrdinata");
            }
            set
            {
                base.set_DoubleField("QuantitaOrdinata", value);
            }
        }
        public double Quantitaordinataudm2
        {
            get
            {
                return base.get_DoubleField("QuantitaOrdinataUdM2");
            }
            set
            {
                base.set_DoubleField("QuantitaOrdinataUdM2", value);
            }
        }
        public string Ragsocialecliente
        {
            get
            {
                return base.get_StringField("RagSocialeCliente");
            }
            set
            {
                base.set_StringField("RagSocialeCliente", value);
            }
        }
        public string Ragsocialeterzista
        {
            get
            {
                return base.get_StringField("RagSocialeTerzista");
            }
            set
            {
                base.set_StringField("RagSocialeTerzista", value);
            }
        }
        public string Riflottoalfanum
        {
            get
            {
                return base.get_StringField("RifLottoAlfanum");
            }
            set
            {
                base.set_StringField("RifLottoAlfanum", value);
            }
        }
        public DateTime Riflottodata
        {
            get
            {
                return base.get_DateTimeField("RifLottoData");
            }
            set
            {
                base.set_DateTimeField("RifLottoData", value);
            }
        }
        public int Riflottonumero
        {
            get
            {
                return base.get_IntegerField("RifLottoNumero");
            }
            set
            {
                base.set_IntegerField("RifLottoNumero", value);
            }
        }
        public string Rifodp
        {
            get
            {
                return base.get_StringField("RifOdP");
            }
            set
            {
                base.set_StringField("RifOdP", value);
            }
        }
        public int Statofaseodp
        {
            get
            {
                return base.get_IntegerField("StatoFaseOdP");
            }
            set
            {
                base.set_IntegerField("StatoFaseOdP", value);
            }
        }
        public double Tempoattr
        {
            get
            {
                return base.get_DoubleField("TempoAttr");
            }
            set
            {
                base.set_DoubleField("TempoAttr", value);
            }
        }
        public double Tempociclo
        {
            get
            {
                return base.get_DoubleField("TempoCiclo");
            }
            set
            {
                base.set_DoubleField("TempoCiclo", value);
            }
        }
        public double Temposmont
        {
            get
            {
                return base.get_DoubleField("TempoSmont");
            }
            set
            {
                base.set_DoubleField("TempoSmont", value);
            }
        }
        public string Udm
        {
            get
            {
                return base.get_StringField("UdM");
            }
            set
            {
                base.set_StringField("UdM", value);
            }
        }
        public string Udm2
        {
            get
            {
                return base.get_StringField("UdM2");
            }
            set
            {
                base.set_StringField("UdM2", value);
            }
        }
        public int Udmattrsmont
        {
            get
            {
                return base.get_IntegerField("UdMAttrSmont");
            }
            set
            {
                base.set_IntegerField("UdMAttrSmont", value);
            }
        }
        public int Udmlavorazione
        {
            get
            {
                return base.get_IntegerField("UdMLavorazione");
            }
            set
            {
                base.set_IntegerField("UdMLavorazione", value);
            }
        }
        public string Varianteart
        {
            get
            {
                return base.get_StringField("VarianteArt");
            }
            set
            {
                base.set_StringField("VarianteArt", value);
            }
        }
        #endregion
    }
}

