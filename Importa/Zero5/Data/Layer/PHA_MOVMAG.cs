using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_MOVMAG : ESolverDataObject
    {
        public PHA_MOVMAG(string selectQuery) : base("PHA_MOVMAG", selectQuery)
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
            public Zero5.Data.Filter.StringField Appendice = new Filter.StringField("PHA_MOVMAG", "Appendice", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codareamag = new Filter.StringField("PHA_MOVMAG", "CodAreaMag", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_MOVMAG", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codlottoalfa = new Filter.StringField("PHA_MOVMAG", "CodLottoAlfa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Codlottodata = new Filter.DateTimeField("PHA_MOVMAG", "CodLottoData", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codlottonum = new Filter.IntegerField("PHA_MOVMAG", "CodLottoNum", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codmag = new Filter.StringField("PHA_MOVMAG", "CodMag", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Dataregistrazione = new Filter.DateTimeField("PHA_MOVMAG", "DataRegistrazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_MOVMAG", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idd = new Filter.IntegerField("PHA_MOVMAG", "IdD", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idr = new Filter.IntegerField("PHA_MOVMAG", "IdR", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Lotto = new Filter.StringField("PHA_MOVMAG", "Lotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Magarea = new Filter.StringField("PHA_MOVMAG", "MagArea", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Qta = new Filter.DoubleField("PHA_MOVMAG", "Qta", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Qtaudm2 = new Filter.DoubleField("PHA_MOVMAG", "QtaUdM2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tipomovimento = new Filter.IntegerField("PHA_MOVMAG", "TipoMovimento", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Udm = new Filter.StringField("PHA_MOVMAG", "UdM", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Udm2 = new Filter.StringField("PHA_MOVMAG", "UdM2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_MOVMAG", "VarianteArt", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_MOVMAG.ClassFields.Appendice,
                            PHA_MOVMAG.ClassFields.Codareamag,
                            PHA_MOVMAG.ClassFields.Codart,
                            PHA_MOVMAG.ClassFields.Codlottoalfa,
                            PHA_MOVMAG.ClassFields.Codlottodata,
                            PHA_MOVMAG.ClassFields.Codlottonum,
                            PHA_MOVMAG.ClassFields.Codmag,
                            PHA_MOVMAG.ClassFields.Dataregistrazione,
                            PHA_MOVMAG.ClassFields.Dbgruppo,
                            PHA_MOVMAG.ClassFields.Idd,
                            PHA_MOVMAG.ClassFields.Idr,
                            PHA_MOVMAG.ClassFields.Lotto,
                            PHA_MOVMAG.ClassFields.Magarea,
                            PHA_MOVMAG.ClassFields.Qta,
                            PHA_MOVMAG.ClassFields.Qtaudm2,
                            PHA_MOVMAG.ClassFields.Tipomovimento,
                            PHA_MOVMAG.ClassFields.Udm,
                            PHA_MOVMAG.ClassFields.Udm2,
                            PHA_MOVMAG.ClassFields.Varianteart
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
    internal partial class PHA_MOVMAG : ESolverDataObject
    {
        #region Properties
        public string Appendice
        {
            get
            {
                return base.get_StringField("Appendice");
            }
            set
            {
                base.set_StringField("Appendice", value);
            }
        }
        public string Codareamag
        {
            get
            {
                return base.get_StringField("CodAreaMag");
            }
            set
            {
                base.set_StringField("CodAreaMag", value);
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
        public string Codmag
        {
            get
            {
                return base.get_StringField("CodMag");
            }
            set
            {
                base.set_StringField("CodMag", value);
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
        public int Idd
        {
            get
            {
                return base.get_IntegerField("IdD");
            }
            set
            {
                base.set_IntegerField("IdD", value);
            }
        }
        public int Idr
        {
            get
            {
                return base.get_IntegerField("IdR");
            }
            set
            {
                base.set_IntegerField("IdR", value);
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
        public string Magarea
        {
            get
            {
                return base.get_StringField("MagArea");
            }
            set
            {
                base.set_StringField("MagArea", value);
            }
        }
        public double Qta
        {
            get
            {
                return base.get_DoubleField("Qta");
            }
            set
            {
                base.set_DoubleField("Qta", value);
            }
        }
        public double Qtaudm2
        {
            get
            {
                return base.get_DoubleField("QtaUdM2");
            }
            set
            {
                base.set_DoubleField("QtaUdM2", value);
            }
        }
        public int Tipomovimento
        {
            get
            {
                return base.get_IntegerField("TipoMovimento");
            }
            set
            {
                base.set_IntegerField("TipoMovimento", value);
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

