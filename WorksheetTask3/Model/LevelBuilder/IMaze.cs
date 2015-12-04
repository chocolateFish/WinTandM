using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace WinTandM.Model.LevelBuilder
{
    public interface IMaze
    {
  
        int Height
        {
            get;
            set;
        }

        int HeightMinusOutside
        {
            get;
        }

        int Width
        {
            get;
            set;
        }

        int WidthMinusOutside
        {
            get;
        } 

       
        //takes the width and height the user wants (the model adds 1)
        void Build(int width, int height);
        void Reset();
        void Load(string mazeStr);
        
        string ToString();
        void InsertColumn(int across);
        void InsertRow(int down);
        void PutMinotaur(int across, int Down);
        void PutTheseus(int across, int Down);
        void PutExit(int across, int Down);
        void RemoveMinotaur();
        void RemoveThesues();
        void RemoveExit();
        void SetTopWall(int across, int down, bool isWall);
        void SetLeftWall(int across, int down, bool isWall);

        bool IsTopWallAt(int across, int down);
        bool IsLeftWallAt(int across, int down);
        bool IsTileOutsideAt(int across, int down);
        Point? WheresTheseus();
        Point? WheresMinotaur();
        Point? WheresExit();
        

        void Attach(IMazeObserver myObserver);

    }
}
