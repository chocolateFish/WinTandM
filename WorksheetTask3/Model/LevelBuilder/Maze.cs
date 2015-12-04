using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;


namespace WinTandM.Model.LevelBuilder
{

    public delegate void MazeHandler<IMaze>(IMaze sender, MazeEventArgs e);
    // The ModelEventArgs class which is derived from th EventArgs class to 
    // be passed on to the controller when the value is changed
    public class MazeEventArgs : EventArgs
    {

        public int Height { get; set; }
        public int Width { get; set; }
        public MazeEventArgs(int width,  int height)
        {          
            Width = width;
            Height = height;
        }

    }

    public enum Occupiers {
        Theseus = 'T', Minotaur = 'M', Exit = 'X' }


    public class Maze : IMaze
    {

        private List<List<Tile>> _allTiles;
        private int _widthPlusOutside;
        private int _heightPlusOutside;
        private Location _theseusLocation;
        private Location _minotaurLocation; 
        private Location _exitLocation;

        public const int NOT_ON_MAZE = -1;
        public event MazeHandler<IMaze> updated;

        public int Height
        {
            get
            {
                return _heightPlusOutside;
            }
            set
            {
                _heightPlusOutside = value + 1;
              
            }
        }

        public int HeightMinusOutside
        {
            get
            {
                return _heightPlusOutside - 1;
            }
        }

        public int Width
        {
            get
            {
                return _widthPlusOutside;
            }

            set
            {
                _widthPlusOutside = value + 1;
               
            }
        }

        public int WidthMinusOutside
        {
            get
            {
                return _widthPlusOutside -1;
            }
        } 

        public Maze()
        {
           // Build(10, 10);//  - loaded event cannot fire since attach hasn't been called yet.
        }

        protected void PopulateAllTiles()
        {
            for (int down = 0; down < _heightPlusOutside; down++)
            {
                List<Tile> tileRow = new List<Tile>();
                for (int across = 0; across < _widthPlusOutside; across++)
                {
                    bool outside = (across == (_widthPlusOutside - 1)) || (down == (_heightPlusOutside - 1));
                    Tile tile = new Tile(outside);
                    tileRow.Add(tile);
                }
                _allTiles.Add(tileRow);
            }
        }

        public void Build(int theWidth, int theHeight)
        {
            if (theWidth < 1)
                throw new ArgumentException("expect at least 1", "theWidth");
            if (theHeight < 1)
                throw new ArgumentException("expect at least 1", "theHeight");

            Width = theWidth;
            Height = theHeight;
            _allTiles = new List<List<Tile>>();
            PopulateAllTiles();
            _theseusLocation = new Location(Occupiers.Theseus);
            _minotaurLocation = new Location(Occupiers.Minotaur);
            _exitLocation = new Location(Occupiers.Exit);

            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        public void Reset()
        {
            foreach (List<Tile> tileRow in _allTiles)
            {
                foreach (Tile theTile in tileRow)
                {
                    theTile.IsLeftWall = false;
                    theTile.IsTopWall = false;
                }
            }
            RemoveMinotaur();
            RemoveThesues();
            RemoveExit();

            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }


        protected bool TopWallFromStr(int across, int down, string theString)
        {
            //index = across + (width * down)
            int topStartPos = (across * 4) + 1 + (((_widthPlusOutside * 8) + 2) * down);
            if (theString.Substring(topStartPos, 3) == "___")
            {
                return true;
            }
            return false;
        }

        protected bool LeftWallFromStr(int across, int down, string theString)
        {
            //index = across + (width * down)
            int leftStartPos = ((_widthPlusOutside + across) * 4) + 1 + (2 * ((_widthPlusOutside * 4) + 1) * down);
            if (theString.Substring(leftStartPos, 1) == "|")
            {
                return true;
            }
            return false;
        }

        protected void LoadOccupiers(int minotaurIndex, int theseusIndex, int exitIndex)
        {


            if (minotaurIndex != -1)
            {
                int across = ((minotaurIndex % ((_widthPlusOutside * 4) + 1)) / 4);
                int down = (minotaurIndex / ((_widthPlusOutside * 4) + 1)) / 2;
                PutMinotaur(across, down);
            }

            if (theseusIndex != -1)
            {
                int across = ((theseusIndex % ((_widthPlusOutside * 4) + 1)) / 4);
                int down = (theseusIndex / ((_widthPlusOutside * 4) + 1)) / 2;
                PutTheseus(across, down);
            }

            if (exitIndex != -1)
            {
                int across = ((exitIndex % ((_widthPlusOutside * 4) + 1)) / 4);
                int down = (exitIndex / ((_widthPlusOutside * 4) + 1)) / 2;
                PutExit(across, down);
            }
        }

        public void Load(string mazeStr)
        {
            //find width
            int lineWidth = mazeStr.IndexOf('@');
            _widthPlusOutside = (lineWidth / 4);
            //find Height	
            _heightPlusOutside = (mazeStr.Count(x => x == '@') / 2);

            _allTiles = new List<List<Tile>>();
            PopulateAllTiles();
            _theseusLocation = new Location(Occupiers.Theseus);
            _minotaurLocation = new Location(Occupiers.Minotaur);
            _exitLocation = new Location(Occupiers.Exit);

            LoadOccupiers(mazeStr.IndexOf((char)Occupiers.Minotaur),
                mazeStr.IndexOf((char)Occupiers.Theseus), mazeStr.IndexOf((char)Occupiers.Exit));

            for (int down = 0; down < _heightPlusOutside; down++)
            {
                List<Tile> tileRow = _allTiles[down];
                for (int across = 0; across < _widthPlusOutside; across++)
                {
                    Tile theTile = tileRow[across];
                    //Tile theTile = _allTiles[down][across];
                    theTile.IsTopWall = TopWallFromStr(across, down, mazeStr);
                    theTile.IsLeftWall = LeftWallFromStr(across, down, mazeStr);
                }
                _allTiles.Add(tileRow);
            }

            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        protected int calcOccupierStrIndex(int across, int down)
        {
            return ((across + _widthPlusOutside) * 4) + (((_widthPlusOutside * 8) + 2) * down) + 3;
        }

        public override string ToString()
        {
            StringBuilder mazeSB = new StringBuilder();
            StringBuilder topsSB = new StringBuilder();
            StringBuilder middlesSB = new StringBuilder();


            for (int down = 0; down < _heightPlusOutside; down++)
            {
                for (int across = 0; across < _widthPlusOutside; across++)
                {
                    Tile tile = FindTile(across, down);
                    topsSB.Append('.').Append(tile.TopStr);
                    middlesSB.Append(tile.LeftStr).Append("   ");
                }
                mazeSB.Append(topsSB.ToString()).Append("@");
                mazeSB.Append(middlesSB.ToString()).Append("@");
                topsSB.Clear();
                middlesSB.Clear();
            }

            if (_minotaurLocation.IsOnMaze)
            {
                int minotaurPosInStr = calcOccupierStrIndex(_minotaurLocation.Across, _minotaurLocation.Down);
                mazeSB[minotaurPosInStr] = (char)Occupiers.Minotaur;
            }

            if (_theseusLocation.IsOnMaze)
            {
                int theseusPosInStr = calcOccupierStrIndex(_theseusLocation.Across, _theseusLocation.Down);
                mazeSB[theseusPosInStr] = (char)Occupiers.Theseus;
            }

            if (_exitLocation.IsOnMaze)
            {
                int exitPosInStr = calcOccupierStrIndex(_exitLocation.Across, _exitLocation.Down);
                mazeSB[exitPosInStr] = (char)Occupiers.Exit;
            }

            return mazeSB.ToString();
        }

        public Tile FindTile(int across, int down)
        { 
            return _allTiles[down][across];
        }

        public void InsertColumn(int across)
        {
            //for(int down = 0; down < _heightPlusOutside; down ++)
            int down = 0;
            foreach (List<Tile> tileRow in _allTiles)
            {
                bool outside = (across == (_widthPlusOutside - 1)) || (down == (_heightPlusOutside - 1));
                Tile tile = new Tile(outside);
                tileRow.Insert(across, tile);
                down++;
            }
        }


        public void InsertRow(int down)
        {
            
        }


        public void PutMinotaur(int across, int down)
        {
            if (across >= (_widthPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_widthPlusOutside - 1), "across");
            if (down >= (_heightPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_heightPlusOutside - 1), "down");
            if (across == _theseusLocation.Across && down == _theseusLocation.Down)
            {
                RemoveThesues();
            }
            else if (across == _exitLocation.Across && down == _exitLocation.Down)
            {
                RemoveExit();
            }
            _minotaurLocation.Across = across;
            _minotaurLocation.Down = down;
            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        public void PutTheseus(int across, int down)
        {
            if (across >= (_widthPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_widthPlusOutside - 1), "across");
            if (down >= (_heightPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_heightPlusOutside - 1), "down");
            if (across == _exitLocation.Across && down == _exitLocation.Down)
            {
                RemoveExit();
            }
            else if (across == _minotaurLocation.Across && down == _minotaurLocation.Down)
            {
                RemoveMinotaur();
            }

            _theseusLocation.Across = across;
            _theseusLocation.Down = down;
            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));

        }

        public void PutExit(int across, int down)
        {
            if (across >= (_widthPlusOutside - 1))
                throw new ArgumentException("across must be smaller than " + (_widthPlusOutside - 1), "across");
            if (down >= (_heightPlusOutside - 1))
                throw new ArgumentException("down must be smaller than " + (_heightPlusOutside - 1), "down");
            if (across == _theseusLocation.Across && down == _theseusLocation.Down)
            {
                RemoveThesues();
            }
            else if (across == _minotaurLocation.Across && down == _minotaurLocation.Down)
            {
                RemoveMinotaur();
            }

            _exitLocation.Across = across;
            _exitLocation.Down = down;
            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        public void RemoveMinotaur()
        {
            if (_minotaurLocation.IsOnMaze)
            {
                _minotaurLocation.Across = Location.NOT_ON_MAZE;
                _minotaurLocation.Down = Location.NOT_ON_MAZE;
                updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
            }
        }

        public void RemoveThesues()
        {
            if (_theseusLocation.IsOnMaze)
            {
                _theseusLocation.Across = Location.NOT_ON_MAZE;
                _theseusLocation.Down = Location.NOT_ON_MAZE;
                updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
            }
        }

        public void RemoveExit()
        {
            if (_exitLocation.IsOnMaze)
            {
                _exitLocation.Across = Location.NOT_ON_MAZE;
                _exitLocation.Down = Location.NOT_ON_MAZE;
                updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
            }
        }

        public void SetTopWall(int across, int down, bool isWall)
        {
            if (across >= (_widthPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_widthPlusOutside - 1), "across");
            if (down >= _heightPlusOutside)
                throw new ArgumentException("expected less than " + _heightPlusOutside, "down");

            Tile tile = FindTile(across, down);
            tile.IsTopWall = isWall;
            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        public void SetLeftWall(int across, int down, bool isWall)
        {

            if (across >= _widthPlusOutside)
                throw new ArgumentException("expected less than " + _widthPlusOutside, "across");
            if (down >= (_heightPlusOutside - 1))
                throw new ArgumentException("expected less than " + (_heightPlusOutside - 1), "down");


            Tile tile = FindTile(across, down);
            tile.IsLeftWall = isWall;
            updated.Invoke(this, new MazeEventArgs(WidthMinusOutside, HeightMinusOutside));
        }

        public bool IsTopWallAt(int across, int down)
        {
            if (across >= _widthPlusOutside)
                throw new ArgumentException("across must be smaller than width", "across");
            if (down >= _heightPlusOutside)
                throw new ArgumentException("down must be smaller than height", "down");

            Tile theTile = FindTile(across, down);
            return theTile.IsTopWall;
        }

        public bool IsLeftWallAt(int across, int down)
        {
            if (across >= _widthPlusOutside)
                throw new ArgumentException("across must be smaller than width", "across");
            if (down >= _heightPlusOutside)
                throw new ArgumentException("down must be smaller than height", "down");

            Tile theTile = FindTile(across, down);
            return theTile.IsLeftWall;
        }

        public bool IsTileOutsideAt(int across, int down)
        {
            if (across >= _widthPlusOutside)
                throw new ArgumentException("across must be smaller than width", "across");
            if (down >= _heightPlusOutside)
                throw new ArgumentException("down must be smaller than height", "down");

            Tile theTile = FindTile(across, down);
            return theTile.IsOutside;
        }

        public Point? WheresTheseus()
        {
            if (_theseusLocation.IsOnMaze)
            {
                return new Point(_theseusLocation.Across, _theseusLocation.Down);
            } else
            {
                return null;
            }
        }

        public Point? WheresMinotaur()
        {
            if (_minotaurLocation.IsOnMaze)
            {
                return new Point(_minotaurLocation.Across, _minotaurLocation.Down);
            }
            else
            {
                return null;
            }
        }

        public Point? WheresExit()
        {
            if (_exitLocation.IsOnMaze)
            {
                return new Point(_exitLocation.Across, _exitLocation.Down);
            }
            else
            {
                return null;
            }
        }


        public void Attach(IMazeObserver myObserver)
        {
            updated += new MazeHandler<IMaze>(myObserver.mazeUpdated);
        }

    }
}
