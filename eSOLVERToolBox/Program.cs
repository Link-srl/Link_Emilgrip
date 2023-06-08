using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSOLVERToolBox
{
    class Program
    {
        public const string CMD_SplitFilesByTES = "--SplitFilesByTes";


        static void Main(string[] args)
        {
            Zero5.Util.Log.ProgramName = "eSOLVERToolBox";
            Zero5.Util.Log.WriteLog("params: " + string.Join(" ", args));

            if (!Zero5.Threading.SingleInstance.ImAloneWithinSystem())
            {
                Zero5.Util.Log.WriteLog("...double istance, closing.");
                return;
            }

            try
            {


                if (args.Length == 2)
                {
                    switch (args[0])
                    {
                        case CMD_SplitFilesByTES:
                            SplitFilesByTES(args[1]);
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Zero5.Util.Log.WriteLog("EX: " + ex.Message);
            }

        }

        public static void SplitFilesByTES(string directory)
        {
            if (!System.IO.Directory.Exists(directory))
                Zero5.Util.Log.WriteLog("Directory sorgente " + directory + " non esistente");

            string[] files = System.IO.Directory.EnumerateFiles(directory).ToArray();

            string destinationFolder = directory + System.IO.Path.DirectorySeparatorChar + "Splitted" + DateTime.Now.Ticks;

            if (System.IO.Directory.Exists(destinationFolder))
                throw new Exception("Directory di destinazione " + destinationFolder + " già esistente");

            System.IO.Directory.CreateDirectory(destinationFolder);

            foreach (string file in files)
            {
                int chunkCounter = 0;

                string extension = System.IO.Path.GetExtension(file);
                string destinationFile = "";
                string[] lines = System.IO.File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (line.StartsWith("TES") || destinationFile == "")
                    {
                        chunkCounter++;
                        destinationFile = destinationFolder + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetFileNameWithoutExtension(file) + "_" + chunkCounter.ToString("000") + extension;
                    }

                    System.IO.File.AppendAllText(destinationFile, line + System.Environment.NewLine);
                }
            }

            Zero5.Util.Log.WriteLog("DONE");
        }
    }
}
