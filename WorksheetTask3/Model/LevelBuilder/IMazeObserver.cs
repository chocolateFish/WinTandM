using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinTandM.Model.LevelBuilder;

namespace WinTandM.Model.LevelBuilder
{
    // The interface which the form/view must implement so that, the event will be
    // fired when a value is changed in the model.
    public interface IMazeObserver
    {
        void mazeUpdated(IMaze maze, MazeEventArgs e);
    }
}



