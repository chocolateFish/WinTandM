using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;


namespace WinTandM.Model.Filer
{
    class Compressor  
    {
        public string Compress(string toCompress)
        {
            return zipFile(ConvertedFile(toCompress));
        }

        /********************convert map file to smaller format*************************/
        private string ConvertedFile(string mapFile)
        {
            StringBuilder mapFileSb = new StringBuilder(mapFile);
            mapFileSb.Replace(".   ", "D");
            mapFileSb.Replace("| M ", "m");
            mapFileSb.Replace("  M ", "M");
            mapFileSb.Replace("  T ", "T");
            mapFileSb.Replace("| T ", "t");
            mapFileSb.Replace("| X ", "X");
            mapFileSb.Replace("|   ", "H");
            mapFileSb.Replace(".___", "W");
            mapFileSb.Replace("    ", "S");
            mapFileSb.Replace("  X ", "Z");//chancge from |___
            return mapFileSb.ToString();
        }

        private string zipFile(string unZippedFile)
        {
            StringBuilder theFile = new StringBuilder();
            //StringBuilder allows to append the character
            string pattern = @"[^mMtTXHWDSZ.|@ ]";
            //use pattern and regular expression to find match with unwanted character
            Regex regrx = new Regex(pattern, RegexOptions.None);

            Match match = regrx.Match(unZippedFile);
            if (match.Success)
            {
                Console.WriteLine("Please enter a vaild Map File.");

            } // only allow the chracters such as "mMtTXHWDSZ.|@" 

            else
            {
                for (int i = 0; i < unZippedFile.Length; i++)
                {
                    // reading the String
                    int repeat = 1;
                    // set the character not repeated to length = 1
                    while (i + 1 < unZippedFile.Length && unZippedFile[i] == unZippedFile[i + 1])
                    //if character repeated time less than the entire string 
                    {
                        //and the first character match the one after it
                        repeat++;             // than length++
                        i++;                 //character move on
                    }
                    if (repeat == 1)
                    {   //if the length is "1"
                        theFile.Append(unZippedFile[i]);     //only append the character
                    }
                    else
                    {   //more than one 
                        theFile.Append(repeat); //push the times of repeat 
                        theFile.Append(unZippedFile[i]);//and append the repeated character
                    }
                }
            }
            return theFile.ToString();
        }
    }
}
