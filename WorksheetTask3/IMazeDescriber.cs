using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinTandM
{
    public interface IMazeDescriber
    {
        bool IsTopWallAt(int across, int down);
        bool IsLeftWallAt(int across, int down);
        bool IsTileOutsideAt(int across, int down);
        Point? WheresTheseus();
        Point? WheresMinotaur();
        Point? WheresExit();


    }
}
