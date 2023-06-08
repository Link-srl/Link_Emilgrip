using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Zero5.Data.Layer
{
    class ESolverDataObject : Zero5.Data.MemoryDataObject
    {
        public ESolverDataObject(string tablename, string selectQuery) : base(tablename, "")
        {
            if (Shared.Configurazioni.ModalitaIntegrazioneEsolver == Shared.eTipoScambioDatiEsolver.OnPremise)
            {
                System.Data.DataSet ds = Zero5.Data.Util.DBSQLServer.LoadDataSet(Configurazioni.OnPremise_DatabaseDiScambio, selectQuery);
                Zero5.Data.Util.DBGeneric.TrimStringsOnDataSet(ds);
                this.UseThisDataset(ds);
            }
            else
            {
                Shared.Common.LeggiVistaTramiteWS(this);
            }
        }

    }
}
