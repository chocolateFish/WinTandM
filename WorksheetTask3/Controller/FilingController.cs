using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTandM.Model.Filer;
using WinTandM.Model.LevelBuilder;
using WinTandM.View;

namespace WinTandM.Controller
{
    class FilingController
    {
        private WinFormsFiler _winFiler;
        private MazeForm view;

        private IMaze _maze;
        public IMaze Maze
        {
            get
            {
                return _maze;
            }
        }
     
        public FilingController(WinFormsFiler theFiler, IMaze theModel, MazeForm theView)
        {
            _winFiler = theFiler;
            view = theView;
            _maze = theModel;
        }

        public void Load(string filename, int type)
        {
            _winFiler.FilePath = filename;
            Console.WriteLine(type);
            if (type == 1)// 1 = zipped, 2 = unzipped
            {        
                _maze.Load(_winFiler.DeCompress(_winFiler.ReadFile()));

            }
            else
            {
                _maze.Load(_winFiler.ReadFile());
            }
        }

        public void SaveAs(string fileName)
        {
           _winFiler.FilePath = fileName;
            string compressed = _winFiler.Compress(_maze.ToString());
           _winFiler.WriteFile(compressed);
        }

        public void Save()
        {
            string compressed = _winFiler.Compress(_maze.ToString());
            _winFiler.WriteFile(compressed);
        }

    }
}
