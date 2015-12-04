using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTandM.Model.LevelBuilder
{
    public class Location
    {
        private Occupiers occupier;
        public const int NOT_ON_MAZE = -1;
        private int _across;       
        public int Across {
            get
            {
                return _across;
            }

            set
            {
                _across = value;
                if (_across == NOT_ON_MAZE)
                {
                    _isOnMaze = false;
                }
                else {
                    _isOnMaze = true;
                }
            }
        }

        private int _down;
        public int Down
        {
            get
            {
                return _down;
            }

            set
            {
                _down = value;
                if (_down == NOT_ON_MAZE)
                {
                    _isOnMaze = false;
                }
                else
                {
                    _isOnMaze = true;
                }

            }
        }
        private bool _isOnMaze;
        public bool IsOnMaze
        {
            get
            {
                return _isOnMaze;
            }
        }

        public Location(Occupiers theOccupier)
        {
            occupier = theOccupier;
            Across = NOT_ON_MAZE;
            Down = NOT_ON_MAZE;
        }

        public Location(Occupiers theOccupier, int theAcross, int theDown)
        {
            occupier = theOccupier;
            Across = theAcross;
            Down = theDown;
        }
   
    }
}
