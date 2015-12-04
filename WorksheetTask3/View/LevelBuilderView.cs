using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTandM.Model.LevelBuilder;
using WinTandM.Controller;

namespace WinTandM.View
{
    public partial class LevelBuilderView : UserControl, IMazeObserver

    {
        private LevelBuilderController _myController;
        private int _mazeHeight;
        private int _mazeWidth;
        private int _tileLength;

        private int _wallThickness;
        private int _mazeTop;
        private int _mazeLeft;
        private int _minMargin;


        private Bitmap _bitmap;
        private SolidBrush _myBrush;
        private SolidBrush _wallBrush;
        private IMazeDescriber _mazeDescriber;

        private Color _wallColor;
        private Color _topColor;
        private Color _leftColor;
        private Color _backgroundColor;


        public LevelBuilderView()
        {
            InitializeComponent();
            //drawing setUp
            _wallColor = Color.Brown;
            _topColor = Color.LightGray;
            _leftColor = Color.LightBlue;
            _backgroundColor = Color.Beige;
            _myBrush = new SolidBrush(_backgroundColor);
            _wallBrush = new SolidBrush(_wallColor);

            //setUp ImageBtns
            btnImg_T.Tag = Occupiers.Theseus;
            btnImg_M.Tag = Occupiers.Minotaur;
            btnImg_X.Tag = Occupiers.Exit;
            pb_maze.AllowDrop = true;
            pb_maze.DragDrop += new System.Windows.Forms.DragEventHandler(pb_maze_DragDrop);
            pb_maze.DragEnter += new System.Windows.Forms.DragEventHandler(pb_maze_DragEnter);

        }

        public void SetMyController(LevelBuilderController controller)
        {
            _myController = controller;
        }

       
        public void Register(IMazeDescriber theDescriber)
        {
            _mazeDescriber = theDescriber;
        }

        //calc functions
        private int calcPercentageOfValue(int percentage, int value)
        {
            double ans = (percentage * value) / 100;
            return (int)ans;
        }

        private void SetMinMargin(int shorterSide)
        {
            _minMargin = calcPercentageOfValue(8, shorterSide);
        }

        private void CalcTileLength(int pbWidth, int pbHeight)
        {

            int shorterSide = pbWidth;
            if (pbHeight < pbWidth)
            {
                shorterSide = pbHeight;
            }
            SetMinMargin(shorterSide);
            int shorterSideLength = shorterSide - (2 * _minMargin);
            _tileLength = (shorterSideLength / _mazeHeight);
            if (_mazeWidth > _mazeHeight)
            {
                _tileLength = (shorterSideLength / _mazeWidth);
            }
            //move to seperate function
            _wallThickness = calcPercentageOfValue(30, _tileLength);
        }

        private void SetMazeBounds(int width, int height)
        {
            int mVWidth = _tileLength * _mazeWidth;
            _mazeLeft = (width - mVWidth) / 2;
            int mVHeight = _tileLength * _mazeHeight;
            _mazeTop = (height - mVHeight) / 2;
        }


        //end of calculations based on canvas size 

        /*Drawing the Maze*/
        private void DrawMaze()
        {
            _bitmap = new Bitmap(pb_maze.Width, pb_maze.Height);
            Graphics mazeGraphics;
            using (mazeGraphics = Graphics.FromImage(_bitmap))
            {
                mazeGraphics.Clear(Color.White);
            }

            int left;
            int top = _mazeTop;
            // draw a column
            for (int down = 0; down <= _mazeHeight; down++)
            {
                left = _mazeLeft;
                //draw a row -
                for (int across = 0; across <= _mazeWidth; across++)
                {
                    bool isOutside = _mazeDescriber.IsTileOutsideAt(across, down);
                    bool isLeft = _mazeDescriber.IsLeftWallAt(across, down);
                    bool isTop = _mazeDescriber.IsTopWallAt(across, down);
                    using (mazeGraphics = Graphics.FromImage(_bitmap))
                    {
                        DrawTile(mazeGraphics, top, left, across, down, isTop, isLeft, isOutside);
                    }

                    left = left + _tileLength;
                }
                top = top + _tileLength;

            }

            if (_mazeDescriber.WheresExit() != null)
            {            
                using (mazeGraphics = Graphics.FromImage(_bitmap))
                {
                    DrawLocation(mazeGraphics, _mazeDescriber.WheresExit().Value.X, _mazeDescriber.WheresExit().Value.Y, Occupiers.Exit);
                }
            }
            if (_mazeDescriber.WheresTheseus() != null)
            {
                using (mazeGraphics = Graphics.FromImage(_bitmap))
                {
                    DrawLocation(mazeGraphics,_mazeDescriber.WheresTheseus().Value.X,_mazeDescriber.WheresTheseus().Value.Y, Occupiers.Theseus);
                }
            }
            if (_mazeDescriber.WheresMinotaur() != null)
            {
                using (mazeGraphics = Graphics.FromImage(_bitmap))
                {
                    DrawLocation(mazeGraphics, _mazeDescriber.WheresMinotaur().Value.X, _mazeDescriber.WheresMinotaur().Value.Y , Occupiers.Minotaur);
                }
            }

            //Draw the GraphicsImage onto the DrawingPanel
            pb_maze.CreateGraphics().DrawImageUnscaled(_bitmap, new Point(0, 0));
        }
    
        private void DrawTile(Graphics mazeGraphics, int top, int left, int across, int down, bool isTopWall, bool isLeftWall, bool isOutside)
        {

            if (!isOutside)
            {
                DrawTileBackGround(mazeGraphics, top, left);
               
            }
            if (across != _mazeWidth )
            {
                DrawTileTop(mazeGraphics, left, top, isTopWall);
                   
            }
            if (down != _mazeHeight)
            {         
                DrawTileLeft(mazeGraphics, left, top, isLeftWall);
            }

            DrawCorner(mazeGraphics, left, top);
        }

        private void DrawTileBackGround(Graphics mazeGraphics, int top, int left)
        {
            _myBrush.Color = _backgroundColor;          
            mazeGraphics.FillRectangle(_myBrush, new Rectangle(left, top, _tileLength, _tileLength));
        }


        private void DrawTileTop(Graphics mazeGraphics, int left, int top, bool isWall)
        {
            if (isWall)
            {
   
                mazeGraphics.FillRectangle(_wallBrush, new Rectangle(left, top, _tileLength, _wallThickness));
            }
            else
            {
                _myBrush.Color = _topColor;
                mazeGraphics.FillRectangle(_myBrush, new Rectangle(left, top, _tileLength, _wallThickness));
            }
   
        }

        private void DrawTileLeft(Graphics mazeGraphics, int left, int top, bool isWall)
        {

            if (isWall)
            {

                mazeGraphics.FillRectangle(_wallBrush, new Rectangle(left, top, _wallThickness, _tileLength));
            }
            else
            {
                _myBrush.Color = _leftColor;
                mazeGraphics.FillRectangle(_myBrush, new Rectangle(left, top, _wallThickness, _tileLength));
            }
          
        }

        private void DrawCorner(Graphics mazeGraphics, int left, int top)
        {     
            mazeGraphics.FillRectangle(_wallBrush, new Rectangle(left, top, _wallThickness, _wallThickness));
        }


        private void DrawLocation(Graphics mazeGraphics,int across, int down, Occupiers theOccupier)
        {
            int margin = _wallThickness;
            int locationLeft = _mazeLeft + (across * _tileLength)+ margin;//not centered properly, but it will do for now
            int locationTop = _mazeTop + (down* _tileLength) + margin;           
            _myBrush.Color = Color.Black;
            Font locationFont = new Font("Arial", (_tileLength - margin), GraphicsUnit.Pixel);
            char locationChar = (char)theOccupier;       
            mazeGraphics.DrawString(locationChar.ToString(), locationFont, _myBrush, new Point(locationLeft, locationTop));
        }

  
        /*end of Drawing the View*/


        /* events*/
        private void MazeView_Load(object sender, EventArgs e)
        {

        }

        /*Event fired when model is updated*/
        public void mazeUpdated(IMaze maze, MazeEventArgs e)
        {
            _mazeWidth = e.Width;
            _mazeHeight = e.Height;

            lbl_width.Text = _mazeWidth.ToString();
            lbl_height.Text = _mazeHeight.ToString();

            //TODO  - disable remove buttons        
            
            CalcTileLength(pb_maze.Width, pb_maze.Height);
            SetMazeBounds(pb_maze.Width, pb_maze.Height);

            DrawMaze();
        }

        private void pb_maze_Paint(object sender, PaintEventArgs e)
        {

            if (e.Graphics != null && _bitmap !=null)
            {
                e.Graphics.DrawImageUnscaled(_bitmap, new Point(0, 0));
            }
        }


        //Move to subclass
        private void pb_maze_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int x = me.Location.X;
            int y = me.Location.Y;
            Color color = _bitmap.GetPixel(me.Location.X, me.Location.Y);
            //int mazeRight = (_tileLength * _mazeWidth) + _mazeLeft + _wallThickness;
            //int mazeBottom = (_tileLength * _mazeHeight) + _mazeTop + _wallThickness;
            string clickMesg = "";

           if (ValidMazePos(me.Location)!=null)
            {
                int across = ValidMazePos(me.Location).Value.X;
                int down = ValidMazePos(me.Location).Value.Y;
                              
                if (color.ToArgb() == _leftColor.ToArgb())
                {
                    _myController.SetTileLeftAt(across, down, true);
                }

                else  if (color.ToArgb() == _topColor.ToArgb())
                {
                    _myController.SetTileTopAt(across, down, true);
                }                
                 else if (color.ToArgb() == _wallColor.ToArgb())
                {
                    bool isInLeft = ((x - _mazeLeft) % _tileLength) < _wallThickness;
                    bool isInTop = ((y - _mazeTop) % _tileLength) < _wallThickness;

                    if (!isInTop && isInLeft)
                    {
                        _myController.SetTileLeftAt(across, down, false);
                    }
                    else if (isInTop && !isInLeft)
                    {
                        _myController.SetTileTopAt(across, down, false);
                    }
                    else
                    {
                        clickMesg += " corner Clicked";
                    }
                }
            }
           else
            {
                clickMesg = "Not On Maze!";
            }

            lbl_click.Text = clickMesg;
        }


        private Point? ValidMazePos(Point clickPoint)
        {
            int across = ((clickPoint.X - _mazeLeft) / _tileLength);
            int down = ((clickPoint.Y - _mazeTop) / _tileLength);
            if (across >= 0 && across <= _mazeWidth && down >= 0 && down <= _mazeHeight)
            {
                return new Point(across, down);
            }
            else
            {
                return null;
            }

        }

        private void btn_bldMaze_Click(object sender, EventArgs e)
        {
            UnsavedDataWarning warningDialog = new UnsavedDataWarning();
            if (warningDialog.ShowDialog() == DialogResult.OK)
            {
                _myController.BuildMaze((int)nud_width.Value, (int)nud_height.Value);
            }
        }

        private void btn_removeT_Click(object sender, EventArgs e)
        {
            _myController.RemoveTheseus();
        }

        private void btn_removeM_Click(object sender, EventArgs e)
        {
            _myController.RemoveMinotaur();
        }

        private void btn_removeExit_Click(object sender, EventArgs e)
        {
            _myController.RemoveExit();
        }

        private void btnImg_MouseDown(object sender, MouseEventArgs e)
        {
            Button btnPic = (Button)sender;
            btnPic.DoDragDrop(btnPic.Tag, DragDropEffects.Copy);          
        }

        private void pb_maze_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Occupiers))!= null)
                //add code to check the Tag value is not null
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pb_maze_DragDrop(object sender, DragEventArgs e)
        {
            Point dropPoint = pb_maze.PointToClient(new Point(e.X, e.Y));
            Color color = _bitmap.GetPixel(dropPoint.X, dropPoint.Y);

            // if there is already a occupier thiscan be a bit buggy
            if (ValidMazePos(dropPoint) != null && color.ToArgb() == _backgroundColor.ToArgb())
            {
                int across = ValidMazePos(dropPoint).Value.X;
                int down = ValidMazePos(dropPoint).Value.Y;

                 Occupiers theOccupier = (Occupiers)e.Data.GetData(typeof(Occupiers));             
                _myController.PutOccupier(theOccupier, across, down);
            }
            else
            {
                lbl_click.Text = String.Format("Not a valid position. Click in {0} areas", _backgroundColor.Name);
            }
        }

       
    }
}
