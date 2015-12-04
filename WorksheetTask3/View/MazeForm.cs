using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WinTandM.Model.Filer;
using WinTandM.Model.LevelBuilder;
using WinTandM.Controller;


namespace WinTandM.View
{
    public partial class MazeForm : Form, IMazeObserver
    {
        private FilingController _myController;
        //private MazeView _mazeUserControl;

        public MazeForm()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _myController = new FilingController(new WinFormsFiler(), new Maze(), this);


            //Move to Main form / LevelBuilder Click
            LevelBuilderView _mazeUserControl = new LevelBuilderView();
            _mazeUserControl.Dock = DockStyle.Fill;
             Controls.Add(_mazeUserControl);                    
            LevelBuilderController lbController = new LevelBuilderController(_myController.Maze, _mazeUserControl);
            _mazeUserControl.SetMyController(lbController);
          
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = "";
            int selectedType;
            LoadOptionsDialog loadPrompt = new LoadOptionsDialog();
            if (loadPrompt.ShowDialog() == DialogResult.OK)
            {
                selectedType = loadPrompt.GetSelected();// 1 = zipped, 2 = unzipped

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult dr = ofd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    file = ofd.FileName;             
                    _myController.Load(file, selectedType);
                }
                ofd.Dispose();

            }
            loadPrompt.Dispose();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePromptDialog savePrompt = new SavePromptDialog();
            if (savePrompt.ShowDialog() == DialogResult.OK)
            {
                _myController.Save();
            }
            savePrompt.Dispose();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Text File";
            sfd.InitialDirectory = "c:\\";
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                 _myController.SaveAs(sfd.FileName);          
            }
        }



      public void mazeUpdated(IMaze maze, MazeEventArgs e)
        {
      
        }

 

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoExit();
        }

       // private void uc_mazeView_Load(object sender, EventArgs e)
       // {
       //     LevelBuilderController lbController = new LevelBuilderController(_myController.Maze, this.uc_mazeView);
      //      uc_mazeView.SetMyController(lbController);
      //  }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DoExit();
        }

        private void DoExit()
        {
            UnsavedDataWarning ePrompt = new UnsavedDataWarning();
            if (ePrompt.ShowDialog() == DialogResult.OK)
            {
                this.Dispose();
            }
        }

    }
}
