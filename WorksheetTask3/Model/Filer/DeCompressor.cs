using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WinTandM.Model.Filer
{
    class DeCompressor
    {
        public string DeCompress(string toDecompress)
        {
            return convertMap(unZip(toDecompress));
        }

        private string unZip(string zippedMap)
        {

            string outputMap = "";
            string tempQty = "";
            char ch;
            int qty;

            //StringBuilder newFile = new StringBuilder(zippedMap);
            string pattern = @"[^0-9mMtTXHWDSZ.|@ ]";
            //use pattern and regular expression to find match with unwanted character
            Regex regrx = new Regex(pattern, RegexOptions.IgnoreCase);
            Match matcher = regrx.Match(zippedMap);
            if (matcher.Success)
            {
                Console.WriteLine("Please enter a vaild Zip File.");
            }
            else
            {
                for (int i = 0; i < zippedMap.Length; i++)
                {
                    ch = zippedMap[i];
                    if (!Char.IsDigit(ch))
                    {// simply add the character to the output map, if it is not preceded with an integer
                        outputMap += zippedMap[i];
                    }
                    else
                    {
                        // otherwise an integer represents multiples check if there are more numeric digits
                        while (Char.IsDigit(ch))
                        {// the digits without any calculations or conversions
                            tempQty += ch;
                            // get the next value in the map
                            ch = zippedMap[i + 1];
                            i++;
                        };

                        qty = Int16.Parse(tempQty);

                        // quantity represents the number that was before the tile identifier
                        for (int x = 0; x < qty; x++)
                        {
                            //add the provided amount of tiles to the output map
                            outputMap += zippedMap[i];
                        }
                        qty = 0;
                        tempQty = "";
                        // reset the quantity variables
                    }
                }
            }
            return outputMap;
            
        }

        private string convertMap(string unzip)
        {
            StringBuilder unZipSb = new StringBuilder(unzip);

            unZipSb.Replace("S", "    ");
            unZipSb.Replace("M", "  M ");
            unZipSb.Replace("T", "  T ");
            unZipSb.Replace("t", "| T ");
            unZipSb.Replace("X", "| X ");
            unZipSb.Replace("H", "|   ");
            unZipSb.Replace("W", ".___");
            unZipSb.Replace("D", ".   ");
            unZipSb.Replace("m", "| M ");
            unZipSb.Replace("Z", "  X ");

            return unZipSb.ToString();
        }
    }
}
