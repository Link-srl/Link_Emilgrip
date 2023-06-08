using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_RISORSEPROD : ESolverDataObject
    {
        public PHA_RISORSEPROD(string selectQuery) : base("PHA_RISORSEPROD", selectQuery)
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
            public Zero5.Data.Filter.StringField Codrisorsaprod = new Filter.StringField("PHA_RISORSEPROD", "CodRisorsaProd", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_RISORSEPROD", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Des = new Filter.StringField("PHA_RISORSEPROD", "Des", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Risorsapadre = new Filter.StringField("PHA_RISORSEPROD", "RisorsaPadre", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tiporisorsaprod = new Filter.IntegerField("PHA_RISORSEPROD", "TipoRisorsaProd", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_RISORSEPROD.ClassFields.Codrisorsaprod,
                            PHA_RISORSEPROD.ClassFields.Dbgruppo,
                            PHA_RISORSEPROD.ClassFields.Des,
                            PHA_RISORSEPROD.ClassFields.Risorsapadre,
                            PHA_RISORSEPROD.ClassFields.Tiporisorsaprod
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
    internal partial class PHA_RISORSEPROD : ESolverDataObject
    {
        #region Properties
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
        public string Risorsapadre
        {
            get
            {
                return base.get_StringField("RisorsaPadre");
            }
            set
            {
                base.set_StringField("RisorsaPadre", value);
            }
        }
        public int Tiporisorsaprod
        {
            get
            {
                return base.get_IntegerField("TipoRisorsaProd");
            }
            set
            {
                base.set_IntegerField("TipoRisorsaProd", value);
            }
        }
        #endregion
    }
}