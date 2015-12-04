namespace WinTandM.View
{
    partial class LoadOptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_mapType = new System.Windows.Forms.GroupBox();
            this.rb_unZipped = new System.Windows.Forms.RadioButton();
            this.rb_isZipped = new System.Windows.Forms.RadioButton();
            this.gb_mapType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_mapType
            // 
            this.gb_mapType.Controls.Add(this.rb_unZipped);
            this.gb_mapType.Controls.Add(this.rb_isZipped);
            this.gb_mapType.Location = new System.Drawing.Point(89, 44);
            this.gb_mapType.Name = "gb_mapType";
            this.gb_mapType.Size = new System.Drawing.Size(200, 100);
            this.gb_mapType.TabIndex = 2;
            this.gb_mapType.TabStop = false;
            this.gb_mapType.Text = "Map Type";
            // 
            // rb_unZipped
            // 
            this.rb_unZipped.AutoSize = true;
            this.rb_unZipped.Location = new System.Drawing.Point(34, 60);
            this.rb_unZipped.Name = "rb_unZipped";
            this.rb_unZipped.Size = new System.Drawing.Size(91, 17);
            this.rb_unZipped.TabIndex = 1;
            this.rb_unZipped.TabStop = true;
            this.rb_unZipped.Tag = "2";
            this.rb_unZipped.Text = "unzipped map";
            this.rb_unZipped.UseVisualStyleBackColor = true;
            this.rb_unZipped.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // rb_isZipped
            // 
            this.rb_isZipped.AutoSize = true;
            this.rb_isZipped.Location = new System.Drawing.Point(34, 28);
            this.rb_isZipped.Name = "rb_isZipped";
            this.rb_isZipped.Size = new System.Drawing.Size(79, 17);
            this.rb_isZipped.TabIndex = 0;
            this.rb_isZipped.TabStop = true;
            this.rb_isZipped.Tag = "1";
            this.rb_isZipped.Text = "zipped map";
            this.rb_isZipped.UseVisualStyleBackColor = true;
            this.rb_isZipped.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // LoadOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.gb_mapType);
            this.Name = "LoadOptionsDialog";
            this.Text = "Load Options";
            this.Controls.SetChildIndex(this.gb_mapType, 0);
            this.gb_mapType.ResumeLayout(false);
            this.gb_mapType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_mapType;
        private System.Windows.Forms.RadioButton rb_unZipped;
        private System.Windows.Forms.RadioButton rb_isZipped;
    }
}
