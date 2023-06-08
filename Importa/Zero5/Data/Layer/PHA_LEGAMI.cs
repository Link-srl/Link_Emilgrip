using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_LEGAMI : ESolverDataObject
    {
        public PHA_LEGAMI(string selectQuery) : base("PHA_LEGAMI", selectQuery)
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
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_LEGAMI", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codartprec = new Filter.StringField("PHA_LEGAMI", "CodArtPrec", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_LEGAMI", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Iddoc = new Filter.StringField("PHA_LEGAMI", "IdDoc", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Iddocprec = new Filter.StringField("PHA_LEGAMI", "IdDocPrec", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodp = new Filter.StringField("PHA_LEGAMI", "RifOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodpprec = new Filter.StringField("PHA_LEGAMI", "RifOdPPrec", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_LEGAMI", "VarianteArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteartprec = new Filter.StringField("PHA_LEGAMI", "VarianteArtPrec", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_LEGAMI.ClassFields.Codart,
                            PHA_LEGAMI.ClassFields.Codartprec,
                            PHA_LEGAMI.ClassFields.Dbgruppo,
                            PHA_LEGAMI.ClassFields.Iddoc,
                            PHA_LEGAMI.ClassFields.Iddocprec,
                            PHA_LEGAMI.ClassFields.Rifodp,
                            PHA_LEGAMI.ClassFields.Rifodpprec,
                            PHA_LEGAMI.ClassFields.Varianteart,
                            PHA_LEGAMI.ClassFields.Varianteartprec
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
    internal partial class PHA_LEGAMI :ESolverDataObject
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
        public string Codartprec
        {
            get
            {
                return base.get_StringField("CodArtPrec");
            }
            set
            {
                base.set_StringField("CodArtPrec", value);
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
        public string Iddoc
        {
            get
            {
                return base.get_StringField("IdDoc");
            }
            set
            {
                base.set_StringField("IdDoc", value);
            }
        }
        public string Iddocprec
        {
            get
            {
                return base.get_StringField("IdDocPrec");
            }
            set
            {
                base.set_StringField("IdDocPrec", value);
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
        public string Rifodpprec
        {
            get
            {
                return base.get_StringField("RifOdPPrec");
            }
            set
            {
                base.set_StringField("RifOdPPrec", value);
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
        public string Varianteartprec
        {
            get
            {
                return base.get_StringField("VarianteArtPrec");
            }
            set
            {
                base.set_StringField("VarianteArtPrec", value);
            }
        }
        #endregion
    }
}
