using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinTandM.Model.Filer
{
    class WinFormsFiler : IFiler
    {
        const string DEFAULT_FILE_NAME = "001MapFile";
        private Compressor _compressor;
        private DeCompressor _deCompressor;

        private string _filePath;
        public string FilePath
        {
            get
            {
                return _filePath;
            }

            set
            {
                if (value != null)
                {
                    _filePath = value;
                }
            }
        }

        public string MapString
        {
            get; set;
        }

        public WinFormsFiler()
        {
            _filePath = DEFAULT_FILE_NAME;
            _compressor = new Compressor();
            _deCompressor = new DeCompressor();
        }

        public string ReadFile()
        {
            StringBuilder fileContents = new StringBuilder();

            try
            {
                if (!File.Exists(_filePath))
                    throw new FileNotFoundException();

                string[] lines = File.ReadAllLines(_filePath);

                foreach (string line in lines)
                {                   
                    fileContents.Append(line + "@");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file for input not found in the specified location");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                       
           return fileContents.ToString();
        }

        public void WriteFile(string mapStr)
        {
            mapStr = mapStr.Replace("@", "\r\n");
           
            try
            {
                //if (!File.Exists(_filePath))
                //    throw new FileNotFoundException();

                File.WriteAllText(_filePath, mapStr);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The File for output not found in the specified location");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string DeCompress(string mapFile)
        {
            return _deCompressor.DeCompress(mapFile);
        }

        public string Compress(string mapString)
        {
            return _compressor.Compress(mapString);
        }


    }
}
