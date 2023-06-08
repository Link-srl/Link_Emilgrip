using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ScambioDati.Utility
{
    public class Utility
    {
        public enum PeriodiTipo
        {
            Macchina = 1,
        }

        public enum AzioniDaIntraprendere
        {
            Cancellazione = -1,
            Aggiornamento = 0,
            NonFareNulla = 1,
            Inserimento = 2,
        }

        public static string IntToHHmmss(int ora)
        {
            try
            {
                string HHmmss = ora.ToString().PadLeft(4, '0');
                HHmmss = HHmmss.Insert(2, ":");
                HHmmss += ":00";
                return HHmmss;
            }
            catch (Exception ex)
            {
                Zero5.Util.Log.WriteLog("Utility.IntToHHmmss() ex: " + ex.Message);
            }
            return string.Empty;
        }

        public static string CheckDirecoryPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Parametro varOdPCsvPath non valorizzato");

            if (!Directory.Exists(path))
                throw new ArgumentException("Directory:'" + path + "' non esistente o non raggiungibile");

            if (!path.EndsWith(@"\"))
                path += @"\";

            return path;
        }
        
    }
}
