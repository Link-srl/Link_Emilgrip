using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_MATERIALIODP : ESolverDataObject
    {
        public PHA_MATERIALIODP(string selectQuery) : base("PHA_MATERIALIODP", selectQuery)
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
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_MATERIALIODP", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codlottoalfa = new Filter.StringField("PHA_MATERIALIODP", "CodLottoAlfa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Codlottodata = new Filter.DateTimeField("PHA_MATERIALIODP", "CodLottoData", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codlottonum = new Filter.IntegerField("PHA_MATERIALIODP", "CodLottoNum", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_MATERIALIODP", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desarticolo = new Filter.StringField("PHA_MATERIALIODP", "DesArticolo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Idpadrefase = new Filter.StringField("PHA_MATERIALIODP", "IdPadreFase", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Idpadremateriale = new Filter.StringField("PHA_MATERIALIODP", "IdPadreMateriale", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Lotto = new Filter.StringField("PHA_MATERIALIODP", "Lotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Nota = new Filter.StringField("PHA_MATERIALIODP", "Nota", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numfase = new Filter.DoubleField("PHA_MATERIALIODP", "NumFase", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numrigamateriale = new Filter.DoubleField("PHA_MATERIALIODP", "NumRigaMateriale", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Quantita = new Filter.DoubleField("PHA_MATERIALIODP", "Quantita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Quantitaconsumata = new Filter.DoubleField("PHA_MATERIALIODP", "QuantitaConsumata", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodp = new Filter.StringField("PHA_MATERIALIODP", "RifOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Statoimpegno = new Filter.IntegerField("PHA_MATERIALIODP", "StatoImpegno", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tipoconversione = new Filter.IntegerField("PHA_MATERIALIODP", "TipoConversione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tipogestione = new Filter.IntegerField("PHA_MATERIALIODP", "TipoGestione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Unitamisura = new Filter.StringField("PHA_MATERIALIODP", "UnitaMisura", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Variante = new Filter.StringField("PHA_MATERIALIODP", "Variante", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_MATERIALIODP.ClassFields.Codart,
                            PHA_MATERIALIODP.ClassFields.Codlottoalfa,
                            PHA_MATERIALIODP.ClassFields.Codlottodata,
                            PHA_MATERIALIODP.ClassFields.Codlottonum,
                            PHA_MATERIALIODP.ClassFields.Dbgruppo,
                            PHA_MATERIALIODP.ClassFields.Desarticolo,
                            PHA_MATERIALIODP.ClassFields.Idpadrefase,
                            PHA_MATERIALIODP.ClassFields.Idpadremateriale,
                            PHA_MATERIALIODP.ClassFields.Lotto,
                            PHA_MATERIALIODP.ClassFields.Nota,
                            PHA_MATERIALIODP.ClassFields.Numfase,
                            PHA_MATERIALIODP.ClassFields.Numrigamateriale,
                            PHA_MATERIALIODP.ClassFields.Quantita,
                            PHA_MATERIALIODP.ClassFields.Quantitaconsumata,
                            PHA_MATERIALIODP.ClassFields.Rifodp,
                            PHA_MATERIALIODP.ClassFields.Statoimpegno,
                            PHA_MATERIALIODP.ClassFields.Tipoconversione,
                            PHA_MATERIALIODP.ClassFields.Tipogestione,
                            PHA_MATERIALIODP.ClassFields.Unitamisura,
                            PHA_MATERIALIODP.ClassFields.Variante
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
    internal partial class PHA_MATERIALIODP : ESolverDataObject
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
        public string Codlottoalfa
        {
            get
            {
                return base.get_StringField("CodLottoAlfa");
            }
            set
            {
                base.set_StringField("CodLottoAlfa", value);
            }
        }
        public DateTime Codlottodata
        {
            get
            {
                return base.get_DateTimeField("CodLottoData");
            }
            set
            {
                base.set_DateTimeField("CodLottoData", value);
            }
        }
        public int Codlottonum
        {
            get
            {
                return base.get_IntegerField("CodLottoNum");
            }
            set
            {
                base.set_IntegerField("CodLottoNum", value);
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
        public string Idpadrefase
        {
            get
            {
                return base.get_StringField("IdPadreFase");
            }
            set
            {
                base.set_StringField("IdPadreFase", value);
            }
        }
        public string Idpadremateriale
        {
            get
            {
                return base.get_StringField("IdPadreMateriale");
            }
            set
            {
                base.set_StringField("IdPadreMateriale", value);
            }
        }
        public string Lotto
        {
            get
            {
                return base.get_StringField("Lotto");
            }
            set
            {
                base.set_StringField("Lotto", value);
            }
        }
        public string Nota
        {
            get
            {
                return base.get_StringField("Nota");
            }
            set
            {
                base.set_StringField("Nota", value);
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
        public double Numrigamateriale
        {
            get
            {
                return base.get_DoubleField("NumRigaMateriale");
            }
            set
            {
                base.set_DoubleField("NumRigaMateriale", value);
            }
        }
        public double Quantita
        {
            get
            {
                return base.get_DoubleField("Quantita");
            }
            set
            {
                base.set_DoubleField("Quantita", value);
            }
        }
        public double Quantitaconsumata
        {
            get
            {
                return base.get_DoubleField("QuantitaConsumata");
            }
            set
            {
                base.set_DoubleField("QuantitaConsumata", value);
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
        public int Statoimpegno
        {
            get
            {
                return base.get_IntegerField("StatoImpegno");
            }
            set
            {
                base.set_IntegerField("StatoImpegno", value);
            }
        }
        public int Tipoconversione
        {
            get
            {
                return base.get_IntegerField("TipoConversione");
            }
            set
            {
                base.set_IntegerField("TipoConversione", value);
            }
        }
        public int Tipogestione
        {
            get
            {
                return base.get_IntegerField("TipoGestione");
            }
            set
            {
                base.set_IntegerField("TipoGestione", value);
            }
        }
        public string Unitamisura
        {
            get
            {
                return base.get_StringField("UnitaMisura");
            }
            set
            {
                base.set_StringField("UnitaMisura", value);
            }
        }
        public string Variante
        {
            get
            {
                return base.get_StringField("Variante");
            }
            set
            {
                base.set_StringField("Variante", value);
            }
        }
        #endregion
    }
}

