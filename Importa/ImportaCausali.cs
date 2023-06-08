using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zero5.Data.Layer;
using Shared;

namespace ScambioDati
{
    class ImportaCausali
    {
        public void EseguiImportazione()
        {
            string query = Configurazioni.GetConfigFromOpzioniWithDefaultValue("SELECT * FROM PHA_CAUSALI", Opzioni.enumOpzioniID.Esolver_ScambioDati_OnPremise_QueryImportazione_Causali);

            PHA_CAUSALI causaliERP = new PHA_CAUSALI(query);

            if (causaliERP == null || causaliERP.RowCount == 0)
                return;

            Zero5.Util.Log.WriteLog("Importazione " + causaliERP.RowCount.ToString() + " PHA_CAUSALI.");
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            CausaliAttivita causaliAttivita = new CausaliAttivita();
            causaliAttivita.LoadAll();

            TipoAttivita tipoAttivita = new TipoAttivita();
            tipoAttivita.LoadAll();

            while (!causaliERP.EOF)
            {
                causaliAttivita.MoveToNextFieldValue(causaliAttivita.Fields.CodiceEsterno, causaliERP.Causaleattivita.ToString(), true);

                if (causaliAttivita.EOF)
                {
                    //Tentativo di riconoscimento

                    {
                        tipoAttivita.MoveToNextFieldValue(tipoAttivita.Fields.Descrizione, causaliERP.Descategoriaattivita, true);
                        if (!tipoAttivita.EOF)
                        {
                            causaliAttivita.MoveFirst();
                            while (!causaliAttivita.EOF)
                            {
                                if (causaliAttivita.IDTipoAttivita == tipoAttivita.IDTipoAttivita &&
                                    causaliAttivita.DescrizioneCausale == causaliERP.Des &&
                                    causaliAttivita.CodiceEsterno == "")
                                {
                                    causaliAttivita.CodiceEsterno = causaliERP.Causaleattivita.ToString();

                                    Zero5.Util.Log.WriteLog("Autodetect codice esterno per causale " + causaliAttivita.IDCausaleAttivita + " " + causaliAttivita.CodiceCausale + " " + causaliAttivita.DescrizioneCausale + " " + causaliAttivita.CodiceEsterno);
                                    break;
                                }
                                causaliAttivita.MoveNext();
                            }
                        }
                    }

                    if (causaliAttivita.EOF)
                    {
                        causaliAttivita.AddNewAndNewID();
                        causaliAttivita.CodiceCausale = causaliERP.Causaleattivita.ToString();
                        causaliAttivita.DescrizioneCausale = causaliERP.Des;
                        causaliAttivita.CodiceEsterno = causaliERP.Causaleattivita.ToString();
                        causaliAttivita.IDTipoAttivita = Common.TipoAttivitaBaseEsolver();
                    }

                    causaliAttivita.Save();
                }

                causaliERP.MoveNext();
            }

            sw.Stop();
            Zero5.Util.Log.WriteLog("Fine Importazione Causali. Elapsed: " + sw.Elapsed.ToString(@"dd\.hh\:mm\:ss"));
        }
    }
}
