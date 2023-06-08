using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_GGCHIUSURA : ESolverDataObject
    {
        public PHA_GGCHIUSURA(string selectQuery) : base("PHA_GGCHIUSURA", selectQuery)
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
            public Zero5.Data.Filter.DateTimeField Data = new Filter.DateTimeField("PHA_GGCHIUSURA", "Data", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_GGCHIUSURA", "DBGruppo", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_GGCHIUSURA.ClassFields.Data,
                            PHA_GGCHIUSURA.ClassFields.Dbgruppo
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
    internal partial class PHA_GGCHIUSURA : ESolverDataObject
    {
        #region Properties
        public DateTime Data
        {
            get
            {
                return base.get_DateTimeField("Data");
            }
            set
            {
                base.set_DateTimeField("Data", value);
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
        #endregion
    }
}

