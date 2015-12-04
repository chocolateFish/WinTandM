using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinTandM.View
{
    public partial class LoadOptionsDialog : DialogForm
    {
        private int _selected;

        public LoadOptionsDialog()
        {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _selected = int.Parse(rb.Tag.ToString());

            }
        }

        public int GetSelected()
        {
            return _selected;
        }
    }
}
