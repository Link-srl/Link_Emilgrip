using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_GIACENZA : ESolverDataObject
    {
        public PHA_GIACENZA(string selectQuery) : base("PHA_GIACENZA", selectQuery)
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
            public Zero5.Data.Filter.StringField Annotazionelotto = new Filter.StringField("PHA_GIACENZA", "AnnotazioneLotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codareamag = new Filter.StringField("PHA_GIACENZA", "CodAreaMag", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_GIACENZA", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codlottoalfa = new Filter.StringField("PHA_GIACENZA", "CodLottoAlfa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Codlottodata = new Filter.DateTimeField("PHA_GIACENZA", "CodLottoData", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Codlottonum = new Filter.IntegerField("PHA_GIACENZA", "CodLottoNum", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codmag = new Filter.StringField("PHA_GIACENZA", "CodMag", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Dataaperturalotto = new Filter.DateTimeField("PHA_GIACENZA", "DataAperturaLotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datascadenzalotto = new Filter.DateTimeField("PHA_GIACENZA", "DataScadenzaLotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_GIACENZA", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Giacenza = new Filter.DoubleField("PHA_GIACENZA", "Giacenza", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Giacenzaudm2 = new Filter.DoubleField("PHA_GIACENZA", "GiacenzaUdM2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Lotto = new Filter.StringField("PHA_GIACENZA", "Lotto", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Lottobloccato = new Filter.IntegerField("PHA_GIACENZA", "LottoBloccato", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Magarea = new Filter.StringField("PHA_GIACENZA", "MagArea", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Magum = new Filter.StringField("PHA_GIACENZA", "MagUm", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Magum2 = new Filter.StringField("PHA_GIACENZA", "MagUm2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_GIACENZA", "VarianteArt", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_GIACENZA.ClassFields.Annotazionelotto,
                            PHA_GIACENZA.ClassFields.Codareamag,
                            PHA_GIACENZA.ClassFields.Codart,
                            PHA_GIACENZA.ClassFields.Codlottoalfa,
                            PHA_GIACENZA.ClassFields.Codlottodata,
                            PHA_GIACENZA.ClassFields.Codlottonum,
                            PHA_GIACENZA.ClassFields.Codmag,
                            PHA_GIACENZA.ClassFields.Dataaperturalotto,
                            PHA_GIACENZA.ClassFields.Datascadenzalotto,
                            PHA_GIACENZA.ClassFields.Dbgruppo,
                            PHA_GIACENZA.ClassFields.Giacenza,
                            PHA_GIACENZA.ClassFields.Giacenzaudm2,
                            PHA_GIACENZA.ClassFields.Lotto,
                            PHA_GIACENZA.ClassFields.Lottobloccato,
                            PHA_GIACENZA.ClassFields.Magarea,
                            PHA_GIACENZA.ClassFields.Magum,
                            PHA_GIACENZA.ClassFields.Magum2,
                            PHA_GIACENZA.ClassFields.Varianteart
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
    internal partial class PHA_GIACENZA : ESolverDataObject
    {
        #region Properties
        public string Annotazionelotto
        {
            get
            {
                return base.get_StringField("AnnotazioneLotto");
            }
            set
            {
                base.set_StringField("AnnotazioneLotto", value);
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
        public DateTime Dataaperturalotto
        {
            get
            {
                return base.get_DateTimeField("DataAperturaLotto");
            }
            set
            {
                base.set_DateTimeField("DataAperturaLotto", value);
            }
        }
        public DateTime Datascadenzalotto
        {
            get
            {
                return base.get_DateTimeField("DataScadenzaLotto");
            }
            set
            {
                base.set_DateTimeField("DataScadenzaLotto", value);
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
        public double Giacenza
        {
            get
            {
                return base.get_DoubleField("Giacenza");
            }
            set
            {
                base.set_DoubleField("Giacenza", value);
            }
        }
        public double Giacenzaudm2
        {
            get
            {
                return base.get_DoubleField("GiacenzaUdM2");
            }
            set
            {
                base.set_DoubleField("GiacenzaUdM2", value);
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
        public int Lottobloccato
        {
            get
            {
                return base.get_IntegerField("LottoBloccato");
            }
            set
            {
                base.set_IntegerField("LottoBloccato", value);
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
        public string Magum
        {
            get
            {
                return base.get_StringField("MagUm");
            }
            set
            {
                base.set_StringField("MagUm", value);
            }
        }
        public string Magum2
        {
            get
            {
                return base.get_StringField("MagUm2");
            }
            set
            {
                base.set_StringField("MagUm2", value);
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
