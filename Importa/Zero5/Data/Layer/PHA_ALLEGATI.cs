using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_ALLEGATI : ESolverDataObject
    {
        public PHA_ALLEGATI(string selectQuery) : base("PHA_ALLEGATI", selectQuery)
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
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_ALLEGATI", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_ALLEGATI", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Firmaultvardata = new Filter.DateTimeField("PHA_ALLEGATI", "FirmaUltVarData", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idallegato = new Filter.IntegerField("PHA_ALLEGATI", "IdAllegato", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Iddoc = new Filter.StringField("PHA_ALLEGATI", "IDDoc", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Nomefile = new Filter.StringField("PHA_ALLEGATI", "NomeFile", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Percorso = new Filter.StringField("PHA_ALLEGATI", "Percorso", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodp = new Filter.StringField("PHA_ALLEGATI", "RifOdP", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_ALLEGATI.ClassFields.Codart,
                            PHA_ALLEGATI.ClassFields.Dbgruppo,
                            PHA_ALLEGATI.ClassFields.Firmaultvardata,
                            PHA_ALLEGATI.ClassFields.Idallegato,
                            PHA_ALLEGATI.ClassFields.Iddoc,
                            PHA_ALLEGATI.ClassFields.Nomefile,
                            PHA_ALLEGATI.ClassFields.Percorso,
                            PHA_ALLEGATI.ClassFields.Rifodp
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
    internal partial class PHA_ALLEGATI : ESolverDataObject
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
        public DateTime Firmaultvardata
        {
            get
            {
                return base.get_DateTimeField("FirmaUltVarData");
            }
            set
            {
                base.set_DateTimeField("FirmaUltVarData", value);
            }
        }
        public int Idallegato
        {
            get
            {
                return base.get_IntegerField("IdAllegato");
            }
            set
            {
                base.set_IntegerField("IdAllegato", value);
            }
        }
        public string Iddoc
        {
            get
            {
                return base.get_StringField("IDDoc");
            }
            set
            {
                base.set_StringField("IDDoc", value);
            }
        }
        public string Nomefile
        {
            get
            {
                return base.get_StringField("NomeFile");
            }
            set
            {
                base.set_StringField("NomeFile", value);
            }
        }
        public string Percorso
        {
            get
            {
                return base.get_StringField("Percorso");
            }
            set
            {
                base.set_StringField("Percorso", value);
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
        #endregion
    }
}

