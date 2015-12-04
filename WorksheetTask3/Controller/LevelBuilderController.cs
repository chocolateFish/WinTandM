using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WinTandM.Model.LevelBuilder;
using WinTandM.View;

namespace WinTandM.Controller
{
    public class LevelBuilderController : IMazeDescriber
    {

        public const int addTop = 1;
        public const int addLeft = 2;
        public const int removeTop = 3;
        public const int removeLeft = 4;

        private LevelBuilderView _mazeView;
        private IMaze _maze;

        public LevelBuilderController(IMaze theModel, LevelBuilderView theView)
        {
            _mazeView = theView;
            _mazeView.Register(this);
            _maze = theModel;
            _maze.Attach((IMazeObserver)_mazeView);
            _maze.Build(10, 10);
        }


        public void BuildMaze(int across, int down) 
        {
            _maze.Build(across, down);
        }

        public void SetTileTopAt(int across, int down, bool isWall)
        {
            _maze.SetTopWall(across, down, isWall);
        }

        public void SetTileLeftAt(int across, int down, bool isWall)
        {
            _maze.SetLeftWall(across, down, isWall);
        }

        public void RemoveTheseus()
        {
            _maze.RemoveThesues();
        }

        public void RemoveMinotaur()
        {
            _maze.RemoveMinotaur();
        }

        public void RemoveExit()
        {
            _maze.RemoveExit();
        }

        public void PutOccupier(Occupiers theOccupier, int across, int down)
        {
            if (theOccupier == Occupiers.Theseus)
            {
                _maze.PutTheseus(across, down);
            }
            else if (theOccupier == Occupiers.Minotaur)
            {
                _maze.PutMinotaur(across, down);
            }
            else {
                _maze.PutExit(across, down);
            }

        }

        //IMazeDescriber functions//
        public bool IsTopWallAt(int across, int down)
        {
            return _maze.IsTopWallAt(across, down);
        }

        public bool IsLeftWallAt(int across, int down)
        {
            return _maze.IsLeftWallAt(across, down);
        }

        public bool IsTileOutsideAt(int across, int down)
        {
            return _maze.IsTileOutsideAt(across, down);

        }

        public Point? WheresTheseus()
        {
            return _maze.WheresTheseus();
        }

        public Point? WheresMinotaur()
        {
            return _maze.WheresMinotaur();
        }

        public Point? WheresExit()
        {
            return _maze.WheresExit();
        }
        //End Of IMazeDescriber functions//
    }
}
