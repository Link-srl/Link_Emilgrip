using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_CAUSALI : ESolverDataObject
    {
        public PHA_CAUSALI(string selectQuery) : base("PHA_CAUSALI", selectQuery)
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
            public Zero5.Data.Filter.StringField Categoriaattivita = new Filter.StringField("PHA_CAUSALI", "CategoriaAttivita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Causaleattivita = new Filter.IntegerField("PHA_CAUSALI", "CausaleAttivita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_CAUSALI", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Descategoriaattivita = new Filter.StringField("PHA_CAUSALI", "DesCategoriaAttivita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Des = new Filter.StringField("PHA_CAUSALI", "Des", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_CAUSALI.ClassFields.Categoriaattivita,
                            PHA_CAUSALI.ClassFields.Causaleattivita,
                            PHA_CAUSALI.ClassFields.Dbgruppo,
                            PHA_CAUSALI.ClassFields.Descategoriaattivita,
                            PHA_CAUSALI.ClassFields.Des
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
    internal partial class PHA_CAUSALI : ESolverDataObject
    {
        #region Properties
        public string Categoriaattivita
        {
            get
            {
                return base.get_StringField("CategoriaAttivita");
            }
            set
            {
                base.set_StringField("CategoriaAttivita", value);
            }
        }
        public int Causaleattivita
        {
            get
            {
                return base.get_IntegerField("CausaleAttivita");
            }
            set
            {
                base.set_IntegerField("CausaleAttivita", value);
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
        public string Descategoriaattivita
        {
            get
            {
                return base.get_StringField("DesCategoriaAttivita");
            }
            set
            {
                base.set_StringField("DesCategoriaAttivita", value);
            }
        }
        public string Des
        {
            get
            {
                return base.get_StringField("Des");
            }
            set
            {
                base.set_StringField("Des", value);
            }
        }
        #endregion
    }
}
