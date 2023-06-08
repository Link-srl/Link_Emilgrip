using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_TURNI : ESolverDataObject
    {
        public PHA_TURNI(string selectQuery) : base("PHA_TURNI", selectQuery)
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
            public Zero5.Data.Filter.StringField Codproforariosett = new Filter.StringField("PHA_TURNI", "CodProfOrarioSett", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datafinevalidita = new Filter.DateTimeField("PHA_TURNI", "DataFineValidita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datainiziovalidita = new Filter.DateTimeField("PHA_TURNI", "DataInizioValidita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Descrizione = new Filter.StringField("PHA_TURNI", "Descrizione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Giornosettimana = new Filter.IntegerField("PHA_TURNI", "GiornoSettimana", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Oraa = new Filter.IntegerField("PHA_TURNI", "OraA", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Orada = new Filter.IntegerField("PHA_TURNI", "OraDa", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_TURNI.ClassFields.Codproforariosett,
                            PHA_TURNI.ClassFields.Datafinevalidita,
                            PHA_TURNI.ClassFields.Datainiziovalidita,
                            PHA_TURNI.ClassFields.Descrizione,
                            PHA_TURNI.ClassFields.Giornosettimana,
                            PHA_TURNI.ClassFields.Oraa,
                            PHA_TURNI.ClassFields.Orada
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
    internal partial class PHA_TURNI : ESolverDataObject
    {
        #region Properties
        public string Codproforariosett
        {
            get
            {
                return base.get_StringField("CodProfOrarioSett");
            }
            set
            {
                base.set_StringField("CodProfOrarioSett", value);
            }
        }
        public DateTime Datafinevalidita
        {
            get
            {
                return base.get_DateTimeField("DataFineValidita");
            }
            set
            {
                base.set_DateTimeField("DataFineValidita", value);
            }
        }
        public DateTime Datainiziovalidita
        {
            get
            {
                return base.get_DateTimeField("DataInizioValidita");
            }
            set
            {
                base.set_DateTimeField("DataInizioValidita", value);
            }
        }
        public string Descrizione
        {
            get
            {
                return base.get_StringField("Descrizione");
            }
            set
            {
                base.set_StringField("Descrizione", value);
            }
        }
        public int Giornosettimana
        {
            get
            {
                return base.get_IntegerField("GiornoSettimana");
            }
            set
            {
                base.set_IntegerField("GiornoSettimana", value);
            }
        }
        public int Oraa
        {
            get
            {
                return base.get_IntegerField("OraA");
            }
            set
            {
                base.set_IntegerField("OraA", value);
            }
        }
        public int Orada
        {
            get
            {
                return base.get_IntegerField("OraDa");
            }
            set
            {
                base.set_IntegerField("OraDa", value);
            }
        }
        #endregion
    }
}

