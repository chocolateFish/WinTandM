using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTandM.Model.LevelBuilder
{
    public class Tile
    {  
        public bool IsTopWall { get; set; }
        public bool IsLeftWall { get; set; }
        private bool _isOutside;
        public bool IsOutside
        {
            get
            {
                return _isOutside;
            }
        }
 
        public string TopStr
        { 
            get
            {
                if (!IsTopWall)
                {
                    return "   ";
                }
               else
                {
                    return "___";
                }     
            }
        }

        public string LeftStr
        {
            get
            {
                if (!IsLeftWall)
                {
                    return " ";
                }
                else
                {
                    return "|";
                }               
            }
        }

        public Tile(bool newIsOutside)
        {
            _isOutside = newIsOutside;
            IsLeftWall = false;
            IsTopWall = false;
        }
    }
}
