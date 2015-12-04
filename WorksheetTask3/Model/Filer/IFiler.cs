using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTandM.Model.Filer
{
    interface IFiler
    {
        string FilePath { get; set; }       
        string ReadFile();
        void WriteFile(string mapStr);
        string DeCompress(string mapFile);
        string Compress(string mapString);
    }
}
