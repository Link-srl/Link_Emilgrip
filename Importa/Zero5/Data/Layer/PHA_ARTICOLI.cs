using System;
using System.Collections.Generic;
using Zero5.Data.Layer.Properties.BaseProperties;
using System.Text;
using Zero5.Data.Filter;

namespace Zero5.Data.Layer
{
    internal partial class PHA_ARTICOLI : ESolverDataObject
    {
        public PHA_ARTICOLI(string selectQuery) : base("PHA_ARTICOLI", selectQuery)
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
            public Zero5.Data.Filter.DoubleField Altezza = new Filter.DoubleField("PHA_ARTICOLI", "Altezza", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codart = new Filter.StringField("PHA_ARTICOLI", "CodArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codcategpianifica = new Filter.StringField("PHA_ARTICOLI", "CodCategPianifica", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codfamiglia = new Filter.StringField("PHA_ARTICOLI", "CodFamiglia", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Codmacrofamiglia = new Filter.StringField("PHA_ARTICOLI", "CodMacroFamiglia", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Coeffum2magden = new Filter.DoubleField("PHA_ARTICOLI", "CoeffUm2MagDen", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Coeffum2magnum = new Filter.DoubleField("PHA_ARTICOLI", "CoeffUm2MagNum", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Colliperstrato = new Filter.IntegerField("PHA_ARTICOLI", "ColliPerStrato", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Colliperunitacarico = new Filter.DoubleField("PHA_ARTICOLI", "ColliPerUnitaCarico", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datafinevalidita = new Filter.DateTimeField("PHA_ARTICOLI", "DataFineValidita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DateTimeField Datainiziovalidita = new Filter.DateTimeField("PHA_ARTICOLI", "DataInizioValidita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Dbgruppo = new Filter.StringField("PHA_ARTICOLI", "DBGruppo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desart = new Filter.StringField("PHA_ARTICOLI", "DesArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Descategpianifica = new Filter.StringField("PHA_ARTICOLI", "DesCategPianifica", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desestesaart = new Filter.StringField("PHA_ARTICOLI", "DesEstesaArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desestesavariante = new Filter.StringField("PHA_ARTICOLI", "DesEstesaVariante", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desfamiglia = new Filter.StringField("PHA_ARTICOLI", "DesFamiglia", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Desmacrofamiglia = new Filter.StringField("PHA_ARTICOLI", "DesMacroFamiglia", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Giacperlotti = new Filter.IntegerField("PHA_ARTICOLI", "GiacPerLotti", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Larghezza = new Filter.DoubleField("PHA_ARTICOLI", "Larghezza", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Nomefileimmagine = new Filter.StringField("PHA_ARTICOLI", "NomeFileImmagine", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Percorsoimmagine = new Filter.StringField("PHA_ARTICOLI", "PercorsoImmagine", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Pesolordounit = new Filter.DoubleField("PHA_ARTICOLI", "PesoLordoUnit", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Pesonettounit = new Filter.DoubleField("PHA_ARTICOLI", "PesoNettoUnit", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Profondita = new Filter.DoubleField("PHA_ARTICOLI", "Profondita", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Statoart = new Filter.IntegerField("PHA_ARTICOLI", "StatoArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Stratiperunitacarico = new Filter.IntegerField("PHA_ARTICOLI", "StratiPerUnitaCarico", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.IntegerField Tipoart = new Filter.IntegerField("PHA_ARTICOLI", "TipoArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Umdimensioni = new Filter.StringField("PHA_ARTICOLI", "UmDimensioni", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Ummag = new Filter.StringField("PHA_ARTICOLI", "UmMag", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Ummag2 = new Filter.StringField("PHA_ARTICOLI", "UmMag2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Umpesolordounit = new Filter.StringField("PHA_ARTICOLI", "UmPesoLordoUnit", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Umpesonettounit = new Filter.StringField("PHA_ARTICOLI", "UmPesoNettoUnit", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Umvolumeunit = new Filter.StringField("PHA_ARTICOLI", "UmVolumeUnit", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Unitapercollo = new Filter.DoubleField("PHA_ARTICOLI", "UnitaPerCollo", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo1 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo1", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo10 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo10", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo11 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo11", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo12 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo12", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo13 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo13", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo14 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo14", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo15 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo15", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo16 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo16", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo17 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo17", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo18 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo18", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo19 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo19", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo2 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo2", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo20 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo20", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo21 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo21", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo22 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo22", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo23 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo23", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo24 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo24", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo25 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo25", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo26 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo26", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo27 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo27", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo28 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo28", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo29 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo29", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo3 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo3", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo30 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo30", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo31 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo31", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo32 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo32", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo33 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo33", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo34 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo34", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo35 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo35", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo36 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo36", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo37 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo37", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo38 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo38", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo39 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo39", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo4 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo4", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo40 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo40", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo41 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo41", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo42 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo42", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo43 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo43", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo44 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo44", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo45 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo45", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo46 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo46", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo47 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo47", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo48 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo48", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo49 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo49", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo5 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo5", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo50 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo50", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo51 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo51", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo52 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo52", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo53 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo53", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo54 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo54", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo55 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo55", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo56 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo56", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo57 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo57", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo58 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo58", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo59 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo59", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo6 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo6", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo60 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo60", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo7 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo7", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo8 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo8", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Valorecampo9 = new Filter.StringField("PHA_ARTICOLI", "ValoreCampo9", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.StringField Varianteart = new Filter.StringField("PHA_ARTICOLI", "VarianteArt", "", eFieldVisibility.ReadOnly, null);
            public Zero5.Data.Filter.DoubleField Volumeunit = new Filter.DoubleField("PHA_ARTICOLI", "VolumeUnit", "", eFieldVisibility.ReadOnly, null);

            private Zero5.Data.Filter.Field[] fieldList = null;
            public override Zero5.Data.Filter.Field[] Items
            {
                get
                {
                    if (fieldList == null)
                    {
                        fieldList = new Zero5.Data.Filter.Field[]{
                            PHA_ARTICOLI.ClassFields.Altezza,
                            PHA_ARTICOLI.ClassFields.Codart,
                            PHA_ARTICOLI.ClassFields.Codcategpianifica,
                            PHA_ARTICOLI.ClassFields.Codfamiglia,
                            PHA_ARTICOLI.ClassFields.Codmacrofamiglia,
                            PHA_ARTICOLI.ClassFields.Coeffum2magden,
                            PHA_ARTICOLI.ClassFields.Coeffum2magnum,
                            PHA_ARTICOLI.ClassFields.Colliperstrato,
                            PHA_ARTICOLI.ClassFields.Colliperunitacarico,
                            PHA_ARTICOLI.ClassFields.Datafinevalidita,
                            PHA_ARTICOLI.ClassFields.Datainiziovalidita,
                            PHA_ARTICOLI.ClassFields.Dbgruppo,
                            PHA_ARTICOLI.ClassFields.Desart,
                            PHA_ARTICOLI.ClassFields.Descategpianifica,
                            PHA_ARTICOLI.ClassFields.Desestesaart,
                            PHA_ARTICOLI.ClassFields.Desestesavariante,
                            PHA_ARTICOLI.ClassFields.Desfamiglia,
                            PHA_ARTICOLI.ClassFields.Desmacrofamiglia,
                            PHA_ARTICOLI.ClassFields.Giacperlotti,
                            PHA_ARTICOLI.ClassFields.Larghezza,
                            PHA_ARTICOLI.ClassFields.Nomefileimmagine,
                            PHA_ARTICOLI.ClassFields.Percorsoimmagine,
                            PHA_ARTICOLI.ClassFields.Pesolordounit,
                            PHA_ARTICOLI.ClassFields.Pesonettounit,
                            PHA_ARTICOLI.ClassFields.Profondita,
                            PHA_ARTICOLI.ClassFields.Statoart,
                            PHA_ARTICOLI.ClassFields.Stratiperunitacarico,
                            PHA_ARTICOLI.ClassFields.Tipoart,
                            PHA_ARTICOLI.ClassFields.Umdimensioni,
                            PHA_ARTICOLI.ClassFields.Ummag,
                            PHA_ARTICOLI.ClassFields.Ummag2,
                            PHA_ARTICOLI.ClassFields.Umpesolordounit,
                            PHA_ARTICOLI.ClassFields.Umpesonettounit,
                            PHA_ARTICOLI.ClassFields.Umvolumeunit,
                            PHA_ARTICOLI.ClassFields.Unitapercollo,
                            PHA_ARTICOLI.ClassFields.Valorecampo1,
                            PHA_ARTICOLI.ClassFields.Valorecampo10,
                            PHA_ARTICOLI.ClassFields.Valorecampo11,
                            PHA_ARTICOLI.ClassFields.Valorecampo12,
                            PHA_ARTICOLI.ClassFields.Valorecampo13,
                            PHA_ARTICOLI.ClassFields.Valorecampo14,
                            PHA_ARTICOLI.ClassFields.Valorecampo15,
                            PHA_ARTICOLI.ClassFields.Valorecampo16,
                            PHA_ARTICOLI.ClassFields.Valorecampo17,
                            PHA_ARTICOLI.ClassFields.Valorecampo18,
                            PHA_ARTICOLI.ClassFields.Valorecampo19,
                            PHA_ARTICOLI.ClassFields.Valorecampo2,
                            PHA_ARTICOLI.ClassFields.Valorecampo20,
                            PHA_ARTICOLI.ClassFields.Valorecampo21,
                            PHA_ARTICOLI.ClassFields.Valorecampo22,
                            PHA_ARTICOLI.ClassFields.Valorecampo23,
                            PHA_ARTICOLI.ClassFields.Valorecampo24,
                            PHA_ARTICOLI.ClassFields.Valorecampo25,
                            PHA_ARTICOLI.ClassFields.Valorecampo26,
                            PHA_ARTICOLI.ClassFields.Valorecampo27,
                            PHA_ARTICOLI.ClassFields.Valorecampo28,
                            PHA_ARTICOLI.ClassFields.Valorecampo29,
                            PHA_ARTICOLI.ClassFields.Valorecampo3,
                            PHA_ARTICOLI.ClassFields.Valorecampo30,
                            PHA_ARTICOLI.ClassFields.Valorecampo31,
                            PHA_ARTICOLI.ClassFields.Valorecampo32,
                            PHA_ARTICOLI.ClassFields.Valorecampo33,
                            PHA_ARTICOLI.ClassFields.Valorecampo34,
                            PHA_ARTICOLI.ClassFields.Valorecampo35,
                            PHA_ARTICOLI.ClassFields.Valorecampo36,
                            PHA_ARTICOLI.ClassFields.Valorecampo37,
                            PHA_ARTICOLI.ClassFields.Valorecampo38,
                            PHA_ARTICOLI.ClassFields.Valorecampo39,
                            PHA_ARTICOLI.ClassFields.Valorecampo4,
                            PHA_ARTICOLI.ClassFields.Valorecampo40,
                            PHA_ARTICOLI.ClassFields.Valorecampo41,
                            PHA_ARTICOLI.ClassFields.Valorecampo42,
                            PHA_ARTICOLI.ClassFields.Valorecampo43,
                            PHA_ARTICOLI.ClassFields.Valorecampo44,
                            PHA_ARTICOLI.ClassFields.Valorecampo45,
                            PHA_ARTICOLI.ClassFields.Valorecampo46,
                            PHA_ARTICOLI.ClassFields.Valorecampo47,
                            PHA_ARTICOLI.ClassFields.Valorecampo48,
                            PHA_ARTICOLI.ClassFields.Valorecampo49,
                            PHA_ARTICOLI.ClassFields.Valorecampo5,
                            PHA_ARTICOLI.ClassFields.Valorecampo50,
                            PHA_ARTICOLI.ClassFields.Valorecampo51,
                            PHA_ARTICOLI.ClassFields.Valorecampo52,
                            PHA_ARTICOLI.ClassFields.Valorecampo53,
                            PHA_ARTICOLI.ClassFields.Valorecampo54,
                            PHA_ARTICOLI.ClassFields.Valorecampo55,
                            PHA_ARTICOLI.ClassFields.Valorecampo56,
                            PHA_ARTICOLI.ClassFields.Valorecampo57,
                            PHA_ARTICOLI.ClassFields.Valorecampo58,
                            PHA_ARTICOLI.ClassFields.Valorecampo59,
                            PHA_ARTICOLI.ClassFields.Valorecampo6,
                            PHA_ARTICOLI.ClassFields.Valorecampo60,
                            PHA_ARTICOLI.ClassFields.Valorecampo7,
                            PHA_ARTICOLI.ClassFields.Valorecampo8,
                            PHA_ARTICOLI.ClassFields.Valorecampo9,
                            PHA_ARTICOLI.ClassFields.Varianteart,
                            PHA_ARTICOLI.ClassFields.Volumeunit
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
    internal partial class PHA_ARTICOLI : ESolverDataObject
    {
        #region Properties
        public double Altezza
        {
            get
            {
                return base.get_DoubleField("Altezza");
            }
            set
            {
                base.set_DoubleField("Altezza", value);
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
        public string Codcategpianifica
        {
            get
            {
                return base.get_StringField("CodCategPianifica");
            }
            set
            {
                base.set_StringField("CodCategPianifica", value);
            }
        }
        public string Codfamiglia
        {
            get
            {
                return base.get_StringField("CodFamiglia");
            }
            set
            {
                base.set_StringField("CodFamiglia", value);
            }
        }
        public string Codmacrofamiglia
        {
            get
            {
                return base.get_StringField("CodMacroFamiglia");
            }
            set
            {
                base.set_StringField("CodMacroFamiglia", value);
            }
        }
        public double Coeffum2magden
        {
            get
            {
                return base.get_DoubleField("CoeffUm2MagDen");
            }
            set
            {
                base.set_DoubleField("CoeffUm2MagDen", value);
            }
        }
        public double Coeffum2magnum
        {
            get
            {
                return base.get_DoubleField("CoeffUm2MagNum");
            }
            set
            {
                base.set_DoubleField("CoeffUm2MagNum", value);
            }
        }
        public int Colliperstrato
        {
            get
            {
                return base.get_IntegerField("ColliPerStrato");
            }
            set
            {
                base.set_IntegerField("ColliPerStrato", value);
            }
        }
        public double Colliperunitacarico
        {
            get
            {
                return base.get_DoubleField("ColliPerUnitaCarico");
            }
            set
            {
                base.set_DoubleField("ColliPerUnitaCarico", value);
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
        public string Desart
        {
            get
            {
                return base.get_StringField("DesArt");
            }
            set
            {
                base.set_StringField("DesArt", value);
            }
        }
        public string Descategpianifica
        {
            get
            {
                return base.get_StringField("DesCategPianifica");
            }
            set
            {
                base.set_StringField("DesCategPianifica", value);
            }
        }
        public string Desestesaart
        {
            get
            {
                return base.get_StringField("DesEstesaArt");
            }
            set
            {
                base.set_StringField("DesEstesaArt", value);
            }
        }
        public string Desestesavariante
        {
            get
            {
                return base.get_StringField("DesEstesaVariante");
            }
            set
            {
                base.set_StringField("DesEstesaVariante", value);
            }
        }
        public string Desfamiglia
        {
            get
            {
                return base.get_StringField("DesFamiglia");
            }
            set
            {
                base.set_StringField("DesFamiglia", value);
            }
        }
        public string Desmacrofamiglia
        {
            get
            {
                return base.get_StringField("DesMacroFamiglia");
            }
            set
            {
                base.set_StringField("DesMacroFamiglia", value);
            }
        }
        public int Giacperlotti
        {
            get
            {
                return base.get_IntegerField("GiacPerLotti");
            }
            set
            {
                base.set_IntegerField("GiacPerLotti", value);
            }
        }
        public double Larghezza
        {
            get
            {
                return base.get_DoubleField("Larghezza");
            }
            set
            {
                base.set_DoubleField("Larghezza", value);
            }
        }
        public string Nomefileimmagine
        {
            get
            {
                return base.get_StringField("NomeFileImmagine");
            }
            set
            {
                base.set_StringField("NomeFileImmagine", value);
            }
        }
        public string Percorsoimmagine
        {
            get
            {
                return base.get_StringField("PercorsoImmagine");
            }
            set
            {
                base.set_StringField("PercorsoImmagine", value);
            }
        }
        public double Pesolordounit
        {
            get
            {
                return base.get_DoubleField("PesoLordoUnit");
            }
            set
            {
                base.set_DoubleField("PesoLordoUnit", value);
            }
        }
        public double Pesonettounit
        {
            get
            {
                return base.get_DoubleField("PesoNettoUnit");
            }
            set
            {
                base.set_DoubleField("PesoNettoUnit", value);
            }
        }
        public double Profondita
        {
            get
            {
                return base.get_DoubleField("Profondita");
            }
            set
            {
                base.set_DoubleField("Profondita", value);
            }
        }
        public int Statoart
        {
            get
            {
                return base.get_IntegerField("StatoArt");
            }
            set
            {
                base.set_IntegerField("StatoArt", value);
            }
        }
        public int Stratiperunitacarico
        {
            get
            {
                return base.get_IntegerField("StratiPerUnitaCarico");
            }
            set
            {
                base.set_IntegerField("StratiPerUnitaCarico", value);
            }
        }
        public int Tipoart
        {
            get
            {
                return base.get_IntegerField("TipoArt");
            }
            set
            {
                base.set_IntegerField("TipoArt", value);
            }
        }
        public string Umdimensioni
        {
            get
            {
                return base.get_StringField("UmDimensioni");
            }
            set
            {
                base.set_StringField("UmDimensioni", value);
            }
        }
        public string Ummag
        {
            get
            {
                return base.get_StringField("UmMag");
            }
            set
            {
                base.set_StringField("UmMag", value);
            }
        }
        public string Ummag2
        {
            get
            {
                return base.get_StringField("UmMag2");
            }
            set
            {
                base.set_StringField("UmMag2", value);
            }
        }
        public string Umpesolordounit
        {
            get
            {
                return base.get_StringField("UmPesoLordoUnit");
            }
            set
            {
                base.set_StringField("UmPesoLordoUnit", value);
            }
        }
        public string Umpesonettounit
        {
            get
            {
                return base.get_StringField("UmPesoNettoUnit");
            }
            set
            {
                base.set_StringField("UmPesoNettoUnit", value);
            }
        }
        public string Umvolumeunit
        {
            get
            {
                return base.get_StringField("UmVolumeUnit");
            }
            set
            {
                base.set_StringField("UmVolumeUnit", value);
            }
        }
        public double Unitapercollo
        {
            get
            {
                return base.get_DoubleField("UnitaPerCollo");
            }
            set
            {
                base.set_DoubleField("UnitaPerCollo", value);
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
        public double Volumeunit
        {
            get
            {
                return base.get_DoubleField("VolumeUnit");
            }
            set
            {
                base.set_DoubleField("VolumeUnit", value);
            }
        }
        #endregion
    }
}

