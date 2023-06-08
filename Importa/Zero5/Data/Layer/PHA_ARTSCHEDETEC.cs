using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_ARTSCHEDETEC : ESolverDataObject
    {
        public PHA_ARTSCHEDETEC(string selectQuery) : base("PHA_ARTSCHEDETEC", selectQuery)
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
            public Zero5.Data.Filter.StringField Annotazione = new Filter.StringField("PHA_ARTSCHEDETEC", "Annotazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_ARTSCHEDETEC", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_ARTSCHEDETEC", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Decrizione = new Filter.StringField("PHA_ARTSCHEDETEC", "Decrizione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Etichetta = new Filter.StringField("PHA_ARTSCHEDETEC", "Etichetta", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Numprogretichetta = new Filter.DoubleField("PHA_ARTSCHEDETEC", "NumProgrEtichetta", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tipocontenuto = new Filter.IntegerField("PHA_ARTSCHEDETEC", "TipoContenuto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valore = new Filter.StringField("PHA_ARTSCHEDETEC", "Valore", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_ARTSCHEDETEC", "VarianteArt", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_ARTSCHEDETEC.ClassFields.Annotazione,
                            PHA_ARTSCHEDETEC.ClassFields.Codart,
                            PHA_ARTSCHEDETEC.ClassFields.Dbgruppo,
                            PHA_ARTSCHEDETEC.ClassFields.Decrizione,
                            PHA_ARTSCHEDETEC.ClassFields.Etichetta,
                            PHA_ARTSCHEDETEC.ClassFields.Numprogretichetta,
                            PHA_ARTSCHEDETEC.ClassFields.Tipocontenuto,
                            PHA_ARTSCHEDETEC.ClassFields.Valore,
                            PHA_ARTSCHEDETEC.ClassFields.Varianteart
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
    internal partial class PHA_ARTSCHEDETEC : ESolverDataObject
    {
        #region Properties
        public string Annotazione
        {
            get
            {
                return base.get_StringField("Annotazione");
            }
            set
            {
                base.set_StringField("Annotazione", value);
            }
        }
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
        public string Decrizione
        {
            get
            {
                return base.get_StringField("Decrizione");
            }
            set
            {
                base.set_StringField("Decrizione", value);
            }
        }
        public string Etichetta
        {
            get
            {
                return base.get_StringField("Etichetta");
            }
            set
            {
                base.set_StringField("Etichetta", value);
            }
        }
        public double Numprogretichetta
        {
            get
            {
                return base.get_DoubleField("NumProgrEtichetta");
            }
            set
            {
                base.set_DoubleField("NumProgrEtichetta", value);
            }
        }
        public int Tipocontenuto
        {
            get
            {
                return base.get_IntegerField("TipoContenuto");
            }
            set
            {
                base.set_IntegerField("TipoContenuto", value);
            }
        }
        public string Valore
        {
            get
            {
                return base.get_StringField("Valore");
            }
            set
            {
                base.set_StringField("Valore", value);
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

