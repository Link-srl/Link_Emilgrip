using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_ODP : ESolverDataObject
    {
        public PHA_ODP(string selectQuery) : base("PHA_ODP", selectQuery)
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
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_ODP", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Dataregistrazione = new Filter.DateTimeField("PHA_ODP", "DataRegistrazione", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_ODP", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desestesa = new Filter.StringField("PHA_ODP", "DesEstesa", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Iddocumento = new Filter.IntegerField("PHA_ODP", "IdDocumento", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Idodp = new Filter.StringField("PHA_ODP", "IdOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Idriga = new Filter.IntegerField("PHA_ODP", "IdRiga", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Notaartcli = new Filter.StringField("PHA_ODP", "NotaArtCli", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Notainterna = new Filter.StringField("PHA_ODP", "NotaInterna", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Rifodp = new Filter.StringField("PHA_ODP", "RifOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Riftestataodp = new Filter.StringField("PHA_ODP", "RifTestataOdP", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo1 = new Filter.StringField("PHA_ODP", "ValoreCampo1", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo10 = new Filter.StringField("PHA_ODP", "ValoreCampo10", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo11 = new Filter.StringField("PHA_ODP", "ValoreCampo11", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo12 = new Filter.StringField("PHA_ODP", "ValoreCampo12", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo13 = new Filter.StringField("PHA_ODP", "ValoreCampo13", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo14 = new Filter.StringField("PHA_ODP", "ValoreCampo14", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo15 = new Filter.StringField("PHA_ODP", "ValoreCampo15", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo16 = new Filter.StringField("PHA_ODP", "ValoreCampo16", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo17 = new Filter.StringField("PHA_ODP", "ValoreCampo17", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo18 = new Filter.StringField("PHA_ODP", "ValoreCampo18", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo19 = new Filter.StringField("PHA_ODP", "ValoreCampo19", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo2 = new Filter.StringField("PHA_ODP", "ValoreCampo2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo20 = new Filter.StringField("PHA_ODP", "ValoreCampo20", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo21 = new Filter.StringField("PHA_ODP", "ValoreCampo21", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo22 = new Filter.StringField("PHA_ODP", "ValoreCampo22", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo23 = new Filter.StringField("PHA_ODP", "ValoreCampo23", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo24 = new Filter.StringField("PHA_ODP", "ValoreCampo24", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo25 = new Filter.StringField("PHA_ODP", "ValoreCampo25", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo26 = new Filter.StringField("PHA_ODP", "ValoreCampo26", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo27 = new Filter.StringField("PHA_ODP", "ValoreCampo27", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo28 = new Filter.StringField("PHA_ODP", "ValoreCampo28", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo29 = new Filter.StringField("PHA_ODP", "ValoreCampo29", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo3 = new Filter.StringField("PHA_ODP", "ValoreCampo3", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo30 = new Filter.StringField("PHA_ODP", "ValoreCampo30", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo31 = new Filter.StringField("PHA_ODP", "ValoreCampo31", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo32 = new Filter.StringField("PHA_ODP", "ValoreCampo32", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo33 = new Filter.StringField("PHA_ODP", "ValoreCampo33", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo34 = new Filter.StringField("PHA_ODP", "ValoreCampo34", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo35 = new Filter.StringField("PHA_ODP", "ValoreCampo35", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo36 = new Filter.StringField("PHA_ODP", "ValoreCampo36", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo37 = new Filter.StringField("PHA_ODP", "ValoreCampo37", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo38 = new Filter.StringField("PHA_ODP", "ValoreCampo38", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo39 = new Filter.StringField("PHA_ODP", "ValoreCampo39", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo4 = new Filter.StringField("PHA_ODP", "ValoreCampo4", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo40 = new Filter.StringField("PHA_ODP", "ValoreCampo40", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo41 = new Filter.StringField("PHA_ODP", "ValoreCampo41", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo42 = new Filter.StringField("PHA_ODP", "ValoreCampo42", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo43 = new Filter.StringField("PHA_ODP", "ValoreCampo43", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo44 = new Filter.StringField("PHA_ODP", "ValoreCampo44", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo45 = new Filter.StringField("PHA_ODP", "ValoreCampo45", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo46 = new Filter.StringField("PHA_ODP", "ValoreCampo46", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo47 = new Filter.StringField("PHA_ODP", "ValoreCampo47", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo48 = new Filter.StringField("PHA_ODP", "ValoreCampo48", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo49 = new Filter.StringField("PHA_ODP", "ValoreCampo49", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo5 = new Filter.StringField("PHA_ODP", "ValoreCampo5", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo50 = new Filter.StringField("PHA_ODP", "ValoreCampo50", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo51 = new Filter.StringField("PHA_ODP", "ValoreCampo51", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo52 = new Filter.StringField("PHA_ODP", "ValoreCampo52", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo53 = new Filter.StringField("PHA_ODP", "ValoreCampo53", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo54 = new Filter.StringField("PHA_ODP", "ValoreCampo54", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo55 = new Filter.StringField("PHA_ODP", "ValoreCampo55", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo56 = new Filter.StringField("PHA_ODP", "ValoreCampo56", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo57 = new Filter.StringField("PHA_ODP", "ValoreCampo57", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo58 = new Filter.StringField("PHA_ODP", "ValoreCampo58", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo59 = new Filter.StringField("PHA_ODP", "ValoreCampo59", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo6 = new Filter.StringField("PHA_ODP", "ValoreCampo6", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo60 = new Filter.StringField("PHA_ODP", "ValoreCampo60", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo7 = new Filter.StringField("PHA_ODP", "ValoreCampo7", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo8 = new Filter.StringField("PHA_ODP", "ValoreCampo8", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo9 = new Filter.StringField("PHA_ODP", "ValoreCampo9", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_ODP", "VarianteArt", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_ODP.ClassFields.Codart,
                            PHA_ODP.ClassFields.Dataregistrazione,
                            PHA_ODP.ClassFields.Dbgruppo,
                            PHA_ODP.ClassFields.Desestesa,
                            PHA_ODP.ClassFields.Iddocumento,
                            PHA_ODP.ClassFields.Idodp,
                            PHA_ODP.ClassFields.Idriga,
                            PHA_ODP.ClassFields.Notaartcli,
                            PHA_ODP.ClassFields.Notainterna,
                            PHA_ODP.ClassFields.Rifodp,
                            PHA_ODP.ClassFields.Riftestataodp,
                            PHA_ODP.ClassFields.Valorecampo1,
                            PHA_ODP.ClassFields.Valorecampo10,
                            PHA_ODP.ClassFields.Valorecampo11,
                            PHA_ODP.ClassFields.Valorecampo12,
                            PHA_ODP.ClassFields.Valorecampo13,
                            PHA_ODP.ClassFields.Valorecampo14,
                            PHA_ODP.ClassFields.Valorecampo15,
                            PHA_ODP.ClassFields.Valorecampo16,
                            PHA_ODP.ClassFields.Valorecampo17,
                            PHA_ODP.ClassFields.Valorecampo18,
                            PHA_ODP.ClassFields.Valorecampo19,
                            PHA_ODP.ClassFields.Valorecampo2,
                            PHA_ODP.ClassFields.Valorecampo20,
                            PHA_ODP.ClassFields.Valorecampo21,
                            PHA_ODP.ClassFields.Valorecampo22,
                            PHA_ODP.ClassFields.Valorecampo23,
                            PHA_ODP.ClassFields.Valorecampo24,
                            PHA_ODP.ClassFields.Valorecampo25,
                            PHA_ODP.ClassFields.Valorecampo26,
                            PHA_ODP.ClassFields.Valorecampo27,
                            PHA_ODP.ClassFields.Valorecampo28,
                            PHA_ODP.ClassFields.Valorecampo29,
                            PHA_ODP.ClassFields.Valorecampo3,
                            PHA_ODP.ClassFields.Valorecampo30,
                            PHA_ODP.ClassFields.Valorecampo31,
                            PHA_ODP.ClassFields.Valorecampo32,
                            PHA_ODP.ClassFields.Valorecampo33,
                            PHA_ODP.ClassFields.Valorecampo34,
                            PHA_ODP.ClassFields.Valorecampo35,
                            PHA_ODP.ClassFields.Valorecampo36,
                            PHA_ODP.ClassFields.Valorecampo37,
                            PHA_ODP.ClassFields.Valorecampo38,
                            PHA_ODP.ClassFields.Valorecampo39,
                            PHA_ODP.ClassFields.Valorecampo4,
                            PHA_ODP.ClassFields.Valorecampo40,
                            PHA_ODP.ClassFields.Valorecampo41,
                            PHA_ODP.ClassFields.Valorecampo42,
                            PHA_ODP.ClassFields.Valorecampo43,
                            PHA_ODP.ClassFields.Valorecampo44,
                            PHA_ODP.ClassFields.Valorecampo45,
                            PHA_ODP.ClassFields.Valorecampo46,
                            PHA_ODP.ClassFields.Valorecampo47,
                            PHA_ODP.ClassFields.Valorecampo48,
                            PHA_ODP.ClassFields.Valorecampo49,
                            PHA_ODP.ClassFields.Valorecampo5,
                            PHA_ODP.ClassFields.Valorecampo50,
                            PHA_ODP.ClassFields.Valorecampo51,
                            PHA_ODP.ClassFields.Valorecampo52,
                            PHA_ODP.ClassFields.Valorecampo53,
                            PHA_ODP.ClassFields.Valorecampo54,
                            PHA_ODP.ClassFields.Valorecampo55,
                            PHA_ODP.ClassFields.Valorecampo56,
                            PHA_ODP.ClassFields.Valorecampo57,
                            PHA_ODP.ClassFields.Valorecampo58,
                            PHA_ODP.ClassFields.Valorecampo59,
                            PHA_ODP.ClassFields.Valorecampo6,
                            PHA_ODP.ClassFields.Valorecampo60,
                            PHA_ODP.ClassFields.Valorecampo7,
                            PHA_ODP.ClassFields.Valorecampo8,
                            PHA_ODP.ClassFields.Valorecampo9,
                            PHA_ODP.ClassFields.Varianteart
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
    internal partial class PHA_ODP : ESolverDataObject
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
        public string Desestesa
        {
            get
            {
                return base.get_StringField("DesEstesa");
            }
            set
            {
                base.set_StringField("DesEstesa", value);
            }
        }
        public int Iddocumento
        {
            get
            {
                return base.get_IntegerField("IdDocumento");
            }
            set
            {
                base.set_IntegerField("IdDocumento", value);
            }
        }
        public string Idodp
        {
            get
            {
                return base.get_StringField("IdOdP");
            }
            set
            {
                base.set_StringField("IdOdP", value);
            }
        }
        public int Idriga
        {
            get
            {
                return base.get_IntegerField("IdRiga");
            }
            set
            {
                base.set_IntegerField("IdRiga", value);
            }
        }
        public string Notaartcli
        {
            get
            {
                return base.get_StringField("NotaArtCli");
            }
            set
            {
                base.set_StringField("NotaArtCli", value);
            }
        }
        public string Notainterna
        {
            get
            {
                return base.get_StringField("NotaInterna");
            }
            set
            {
                base.set_StringField("NotaInterna", value);
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
        public string Riftestataodp
        {
            get
            {
                return base.get_StringField("RifTestataOdP");
            }
            set
            {
                base.set_StringField("RifTestataOdP", value);
            }
        }
        public string Valorecampo1
        {
            get
            {
                return base.get_StringField("ValoreCampo1");
            }
            set
            {
                base.set_StringField("ValoreCampo1", value);
            }
        }
        public string Valorecampo10
        {
            get
            {
                return base.get_StringField("ValoreCampo10");
            }
            set
            {
                base.set_StringField("ValoreCampo10", value);
            }
        }
        public string Valorecampo11
        {
            get
            {
                return base.get_StringField("ValoreCampo11");
            }
            set
            {
                base.set_StringField("ValoreCampo11", value);
            }
        }
        public string Valorecampo12
        {
            get
            {
                return base.get_StringField("ValoreCampo12");
            }
            set
            {
                base.set_StringField("ValoreCampo12", value);
            }
        }
        public string Valorecampo13
        {
            get
            {
                return base.get_StringField("ValoreCampo13");
            }
            set
            {
                base.set_StringField("ValoreCampo13", value);
            }
        }
        public string Valorecampo14
        {
            get
            {
                return base.get_StringField("ValoreCampo14");
            }
            set
            {
                base.set_StringField("ValoreCampo14", value);
            }
        }
        public string Valorecampo15
        {
            get
            {
                return base.get_StringField("ValoreCampo15");
            }
            set
            {
                base.set_StringField("ValoreCampo15", value);
            }
        }
        public string Valorecampo16
        {
            get
            {
                return base.get_StringField("ValoreCampo16");
            }
            set
            {
                base.set_StringField("ValoreCampo16", value);
            }
        }
        public string Valorecampo17
        {
            get
            {
                return base.get_StringField("ValoreCampo17");
            }
            set
            {
                base.set_StringField("ValoreCampo17", value);
            }
        }
        public string Valorecampo18
        {
            get
            {
                return base.get_StringField("ValoreCampo18");
            }
            set
            {
                base.set_StringField("ValoreCampo18", value);
            }
        }
        public string Valorecampo19
        {
            get
            {
                return base.get_StringField("ValoreCampo19");
            }
            set
            {
                base.set_StringField("ValoreCampo19", value);
            }
        }
        public string Valorecampo2
        {
            get
            {
                return base.get_StringField("ValoreCampo2");
            }
            set
            {
                base.set_StringField("ValoreCampo2", value);
            }
        }
        public string Valorecampo20
        {
            get
            {
                return base.get_StringField("ValoreCampo20");
            }
            set
            {
                base.set_StringField("ValoreCampo20", value);
            }
        }
        public string Valorecampo21
        {
            get
            {
                return base.get_StringField("ValoreCampo21");
            }
            set
            {
                base.set_StringField("ValoreCampo21", value);
            }
        }
        public string Valorecampo22
        {
            get
            {
                return base.get_StringField("ValoreCampo22");
            }
            set
            {
                base.set_StringField("ValoreCampo22", value);
            }
        }
        public string Valorecampo23
        {
            get
            {
                return base.get_StringField("ValoreCampo23");
            }
            set
            {
                base.set_StringField("ValoreCampo23", value);
            }
        }
        public string Valorecampo24
        {
            get
            {
                return base.get_StringField("ValoreCampo24");
            }
            set
            {
                base.set_StringField("ValoreCampo24", value);
            }
        }
        public string Valorecampo25
        {
            get
            {
                return base.get_StringField("ValoreCampo25");
            }
            set
            {
                base.set_StringField("ValoreCampo25", value);
            }
        }
        public string Valorecampo26
        {
            get
            {
                return base.get_StringField("ValoreCampo26");
            }
            set
            {
                base.set_StringField("ValoreCampo26", value);
            }
        }
        public string Valorecampo27
        {
            get
            {
                return base.get_StringField("ValoreCampo27");
            }
            set
            {
                base.set_StringField("ValoreCampo27", value);
            }
        }
        public string Valorecampo28
        {
            get
            {
                return base.get_StringField("ValoreCampo28");
            }
            set
            {
                base.set_StringField("ValoreCampo28", value);
            }
        }
        public string Valorecampo29
        {
            get
            {
                return base.get_StringField("ValoreCampo29");
            }
            set
            {
                base.set_StringField("ValoreCampo29", value);
            }
        }
        public string Valorecampo3
        {
            get
            {
                return base.get_StringField("ValoreCampo3");
            }
            set
            {
                base.set_StringField("ValoreCampo3", value);
            }
        }
        public string Valorecampo30
        {
            get
            {
                return base.get_StringField("ValoreCampo30");
            }
            set
            {
                base.set_StringField("ValoreCampo30", value);
            }
        }
        public string Valorecampo31
        {
            get
            {
                return base.get_StringField("ValoreCampo31");
            }
            set
            {
                base.set_StringField("ValoreCampo31", value);
            }
        }
        public string Valorecampo32
        {
            get
            {
                return base.get_StringField("ValoreCampo32");
            }
            set
            {
                base.set_StringField("ValoreCampo32", value);
            }
        }
        public string Valorecampo33
        {
            get
            {
                return base.get_StringField("ValoreCampo33");
            }
            set
            {
                base.set_StringField("ValoreCampo33", value);
            }
        }
        public string Valorecampo34
        {
            get
            {
                return base.get_StringField("ValoreCampo34");
            }
            set
            {
                base.set_StringField("ValoreCampo34", value);
            }
        }
        public string Valorecampo35
        {
            get
            {
                return base.get_StringField("ValoreCampo35");
            }
            set
            {
                base.set_StringField("ValoreCampo35", value);
            }
        }
        public string Valorecampo36
        {
            get
            {
                return base.get_StringField("ValoreCampo36");
            }
            set
            {
                base.set_StringField("ValoreCampo36", value);
            }
        }
        public string Valorecampo37
        {
            get
            {
                return base.get_StringField("ValoreCampo37");
            }
            set
            {
                base.set_StringField("ValoreCampo37", value);
            }
        }
        public string Valorecampo38
        {
            get
            {
                return base.get_StringField("ValoreCampo38");
            }
            set
            {
                base.set_StringField("ValoreCampo38", value);
            }
        }
        public string Valorecampo39
        {
            get
            {
                return base.get_StringField("ValoreCampo39");
            }
            set
            {
                base.set_StringField("ValoreCampo39", value);
            }
        }
        public string Valorecampo4
        {
            get
            {
                return base.get_StringField("ValoreCampo4");
            }
            set
            {
                base.set_StringField("ValoreCampo4", value);
            }
        }
        public string Valorecampo40
        {
            get
            {
                return base.get_StringField("ValoreCampo40");
            }
            set
            {
                base.set_StringField("ValoreCampo40", value);
            }
        }
        public string Valorecampo41
        {
            get
            {
                return base.get_StringField("ValoreCampo41");
            }
            set
            {
                base.set_StringField("ValoreCampo41", value);
            }
        }
        public string Valorecampo42
        {
            get
            {
                return base.get_StringField("ValoreCampo42");
            }
            set
            {
                base.set_StringField("ValoreCampo42", value);
            }
        }
        public string Valorecampo43
        {
            get
            {
                return base.get_StringField("ValoreCampo43");
            }
            set
            {
                base.set_StringField("ValoreCampo43", value);
            }
        }
        public string Valorecampo44
        {
            get
            {
                return base.get_StringField("ValoreCampo44");
            }
            set
            {
                base.set_StringField("ValoreCampo44", value);
            }
        }
        public string Valorecampo45
        {
            get
            {
                return base.get_StringField("ValoreCampo45");
            }
            set
            {
                base.set_StringField("ValoreCampo45", value);
            }
        }
        public string Valorecampo46
        {
            get
            {
                return base.get_StringField("ValoreCampo46");
            }
            set
            {
                base.set_StringField("ValoreCampo46", value);
            }
        }
        public string Valorecampo47
        {
            get
            {
                return base.get_StringField("ValoreCampo47");
            }
            set
            {
                base.set_StringField("ValoreCampo47", value);
            }
        }
        public string Valorecampo48
        {
            get
            {
                return base.get_StringField("ValoreCampo48");
            }
            set
            {
                base.set_StringField("ValoreCampo48", value);
            }
        }
        public string Valorecampo49
        {
            get
            {
                return base.get_StringField("ValoreCampo49");
            }
            set
            {
                base.set_StringField("ValoreCampo49", value);
            }
        }
        public string Valorecampo5
        {
            get
            {
                return base.get_StringField("ValoreCampo5");
            }
            set
            {
                base.set_StringField("ValoreCampo5", value);
            }
        }
        public string Valorecampo50
        {
            get
            {
                return base.get_StringField("ValoreCampo50");
            }
            set
            {
                base.set_StringField("ValoreCampo50", value);
            }
        }
        public string Valorecampo51
        {
            get
            {
                return base.get_StringField("ValoreCampo51");
            }
            set
            {
                base.set_StringField("ValoreCampo51", value);
            }
        }
        public string Valorecampo52
        {
            get
            {
                return base.get_StringField("ValoreCampo52");
            }
            set
            {
                base.set_StringField("ValoreCampo52", value);
            }
        }
        public string Valorecampo53
        {
            get
            {
                return base.get_StringField("ValoreCampo53");
            }
            set
            {
                base.set_StringField("ValoreCampo53", value);
            }
        }
        public string Valorecampo54
        {
            get
            {
                return base.get_StringField("ValoreCampo54");
            }
            set
            {
                base.set_StringField("ValoreCampo54", value);
            }
        }
        public string Valorecampo55
        {
            get
            {
                return base.get_StringField("ValoreCampo55");
            }
            set
            {
                base.set_StringField("ValoreCampo55", value);
            }
        }
        public string Valorecampo56
        {
            get
            {
                return base.get_StringField("ValoreCampo56");
            }
            set
            {
                base.set_StringField("ValoreCampo56", value);
            }
        }
        public string Valorecampo57
        {
            get
            {
                return base.get_StringField("ValoreCampo57");
            }
            set
            {
                base.set_StringField("ValoreCampo57", value);
            }
        }
        public string Valorecampo58
        {
            get
            {
                return base.get_StringField("ValoreCampo58");
            }
            set
            {
                base.set_StringField("ValoreCampo58", value);
            }
        }
        public string Valorecampo59
        {
            get
            {
                return base.get_StringField("ValoreCampo59");
            }
            set
            {
                base.set_StringField("ValoreCampo59", value);
            }
        }
        public string Valorecampo6
        {
            get
            {
                return base.get_StringField("ValoreCampo6");
            }
            set
            {
                base.set_StringField("ValoreCampo6", value);
            }
        }
        public string Valorecampo60
        {
            get
            {
                return base.get_StringField("ValoreCampo60");
            }
            set
            {
                base.set_StringField("ValoreCampo60", value);
            }
        }
        public string Valorecampo7
        {
            get
            {
                return base.get_StringField("ValoreCampo7");
            }
            set
            {
                base.set_StringField("ValoreCampo7", value);
            }
        }
        public string Valorecampo8
        {
            get
            {
                return base.get_StringField("ValoreCampo8");
            }
            set
            {
                base.set_StringField("ValoreCampo8", value);
            }
        }
        public string Valorecampo9
        {
            get
            {
                return base.get_StringField("ValoreCampo9");
            }
            set
            {
                base.set_StringField("ValoreCampo9", value);
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

