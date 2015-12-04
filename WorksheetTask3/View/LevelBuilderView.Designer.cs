namespace WinTandM.View
{
    partial class LevelBuilderView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_widthTxt = new System.Windows.Forms.Label();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_heightTxt = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.pb_maze = new System.Windows.Forms.PictureBox();
            this.lbl_click = new System.Windows.Forms.Label();
            this.gb_buildMap = new System.Windows.Forms.GroupBox();
            this.lbl_widthText = new System.Windows.Forms.Label();
            this.btn_bldMaze = new System.Windows.Forms.Button();
            this.nud_height = new System.Windows.Forms.NumericUpDown();
            this.lbl_HeightText = new System.Windows.Forms.Label();
            this.nud_width = new System.Windows.Forms.NumericUpDown();
            this.gb_occupiers = new System.Windows.Forms.GroupBox();
            this.btnImg_X = new System.Windows.Forms.Button();
            this.btnImg_M = new System.Windows.Forms.Button();
            this.btnImg_T = new System.Windows.Forms.Button();
            this.btn_removeExit = new System.Windows.Forms.Button();
            this.btn_removeM = new System.Windows.Forms.Button();
            this.btn_removeT = new System.Windows.Forms.Button();
            this.lbl_instructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_maze)).BeginInit();
            this.gb_buildMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).BeginInit();
            this.gb_occupiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_widthTxt
            // 
            this.lbl_widthTxt.AutoSize = true;
            this.lbl_widthTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_widthTxt.Location = new System.Drawing.Point(46, 33);
            this.lbl_widthTxt.Name = "lbl_widthTxt";
            this.lbl_widthTxt.Size = new System.Drawing.Size(51, 16);
            this.lbl_widthTxt.TabIndex = 13;
            this.lbl_widthTxt.Text = "Width:";
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_height.Location = new System.Drawing.Point(201, 32);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(16, 17);
            this.lbl_height.TabIndex = 12;
            this.lbl_height.Text = "0";
            // 
            // lbl_heightTxt
            // 
            this.lbl_heightTxt.AutoSize = true;
            this.lbl_heightTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_heightTxt.Location = new System.Drawing.Point(138, 32);
            this.lbl_heightTxt.Name = "lbl_heightTxt";
            this.lbl_heightTxt.Size = new System.Drawing.Size(57, 16);
            this.lbl_heightTxt.TabIndex = 11;
            this.lbl_heightTxt.Text = "Height:";
            this.lbl_heightTxt.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbl_width.Location = new System.Drawing.Point(103, 32);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(16, 17);
            this.lbl_width.TabIndex = 14;
            this.lbl_width.Text = "0";
            // 
            // pb_maze
            // 
            this.pb_maze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_maze.BackColor = System.Drawing.Color.White;
            this.pb_maze.Location = new System.Drawing.Point(0, 63);
            this.pb_maze.Name = "pb_maze";
            this.pb_maze.Size = new System.Drawing.Size(527, 457);
            this.pb_maze.TabIndex = 16;
            this.pb_maze.TabStop = false;
            this.pb_maze.Click += new System.EventHandler(this.pb_maze_Click);
            this.pb_maze.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_maze_Paint);
            // 
            // lbl_click
            // 
            this.lbl_click.AutoSize = true;
            this.lbl_click.Location = new System.Drawing.Point(345, 32);
            this.lbl_click.Name = "lbl_click";
            this.lbl_click.Size = new System.Drawing.Size(0, 13);
            this.lbl_click.TabIndex = 17;
            // 
            // gb_buildMap
            // 
            this.gb_buildMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_buildMap.Controls.Add(this.lbl_widthText);
            this.gb_buildMap.Controls.Add(this.btn_bldMaze);
            this.gb_buildMap.Controls.Add(this.nud_height);
            this.gb_buildMap.Controls.Add(this.lbl_HeightText);
            this.gb_buildMap.Controls.Add(this.nud_width);
            this.gb_buildMap.Location = new System.Drawing.Point(565, 63);
            this.gb_buildMap.Name = "gb_buildMap";
            this.gb_buildMap.Size = new System.Drawing.Size(277, 110);
            this.gb_buildMap.TabIndex = 18;
            this.gb_buildMap.TabStop = false;
            this.gb_buildMap.Text = "BuildMap";
            // 
            // lbl_widthText
            // 
            this.lbl_widthText.AutoSize = true;
            this.lbl_widthText.Location = new System.Drawing.Point(30, 36);
            this.lbl_widthText.Name = "lbl_widthText";
            this.lbl_widthText.Size = new System.Drawing.Size(38, 13);
            this.lbl_widthText.TabIndex = 2;
            this.lbl_widthText.Text = "Width:";
            // 
            // btn_bldMaze
            // 
            this.btn_bldMaze.Location = new System.Drawing.Point(161, 66);
            this.btn_bldMaze.Name = "btn_bldMaze";
            this.btn_bldMaze.Size = new System.Drawing.Size(92, 23);
            this.btn_bldMaze.TabIndex = 1;
            this.btn_bldMaze.Text = "Build Maze";
            this.btn_bldMaze.UseVisualStyleBackColor = true;
            this.btn_bldMaze.Click += new System.EventHandler(this.btn_bldMaze_Click);
            // 
            // nud_height
            // 
            this.nud_height.Location = new System.Drawing.Point(77, 69);
            this.nud_height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_height.Name = "nud_height";
            this.nud_height.Size = new System.Drawing.Size(59, 20);
            this.nud_height.TabIndex = 5;
            this.nud_height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbl_HeightText
            // 
            this.lbl_HeightText.AutoSize = true;
            this.lbl_HeightText.Location = new System.Drawing.Point(30, 71);
            this.lbl_HeightText.Name = "lbl_HeightText";
            this.lbl_HeightText.Size = new System.Drawing.Size(41, 13);
            this.lbl_HeightText.TabIndex = 3;
            this.lbl_HeightText.Text = "Height:";
            // 
            // nud_width
            // 
            this.nud_width.Location = new System.Drawing.Point(77, 34);
            this.nud_width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_width.Name = "nud_width";
            this.nud_width.Size = new System.Drawing.Size(59, 20);
            this.nud_width.TabIndex = 4;
            this.nud_width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gb_occupiers
            // 
            this.gb_occupiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_occupiers.Controls.Add(this.btnImg_X);
            this.gb_occupiers.Controls.Add(this.btnImg_M);
            this.gb_occupiers.Controls.Add(this.btnImg_T);
            this.gb_occupiers.Controls.Add(this.btn_removeExit);
            this.gb_occupiers.Controls.Add(this.btn_removeM);
            this.gb_occupiers.Controls.Add(this.btn_removeT);
            this.gb_occupiers.Location = new System.Drawing.Point(565, 202);
            this.gb_occupiers.Name = "gb_occupiers";
            this.gb_occupiers.Size = new System.Drawing.Size(277, 254);
            this.gb_occupiers.TabIndex = 19;
            this.gb_occupiers.TabStop = false;
            this.gb_occupiers.Text = "Occupiers";
            // 
            // btnImg_X
            // 
            this.btnImg_X.BackgroundImage = global::WinTandM.Properties.Resources.X_BtnImage;
            this.btnImg_X.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImg_X.Location = new System.Drawing.Point(183, 38);
            this.btnImg_X.Name = "btnImg_X";
            this.btnImg_X.Size = new System.Drawing.Size(60, 60);
            this.btnImg_X.TabIndex = 5;
            this.btnImg_X.UseVisualStyleBackColor = true;
            this.btnImg_X.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImg_MouseDown);
            // 
            // btnImg_M
            // 
            this.btnImg_M.BackgroundImage = global::WinTandM.Properties.Resources.M_BtnImage;
            this.btnImg_M.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImg_M.Location = new System.Drawing.Point(108, 38);
            this.btnImg_M.Name = "btnImg_M";
            this.btnImg_M.Size = new System.Drawing.Size(60, 60);
            this.btnImg_M.TabIndex = 4;
            this.btnImg_M.UseVisualStyleBackColor = true;
            this.btnImg_M.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImg_MouseDown);
            // 
            // btnImg_T
            // 
            this.btnImg_T.BackgroundImage = global::WinTandM.Properties.Resources.T_BtnImage;
            this.btnImg_T.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImg_T.Location = new System.Drawing.Point(33, 38);
            this.btnImg_T.Name = "btnImg_T";
            this.btnImg_T.Size = new System.Drawing.Size(60, 60);
            this.btnImg_T.TabIndex = 3;
            this.btnImg_T.Tag = "";
            this.btnImg_T.UseVisualStyleBackColor = true;
            this.btnImg_T.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImg_MouseDown);
            // 
            // btn_removeExit
            // 
            this.btn_removeExit.Location = new System.Drawing.Point(77, 176);
            this.btn_removeExit.Name = "btn_removeExit";
            this.btn_removeExit.Size = new System.Drawing.Size(136, 23);
            this.btn_removeExit.TabIndex = 2;
            this.btn_removeExit.Text = "Remove Exit";
            this.btn_removeExit.UseVisualStyleBackColor = true;
            this.btn_removeExit.Click += new System.EventHandler(this.btn_removeExit_Click);
            // 
            // btn_removeM
            // 
            this.btn_removeM.Location = new System.Drawing.Point(77, 147);
            this.btn_removeM.Name = "btn_removeM";
            this.btn_removeM.Size = new System.Drawing.Size(136, 23);
            this.btn_removeM.TabIndex = 1;
            this.btn_removeM.Text = "Remove Minotaur";
            this.btn_removeM.UseVisualStyleBackColor = true;
            this.btn_removeM.Click += new System.EventHandler(this.btn_removeM_Click);
            // 
            // btn_removeT
            // 
            this.btn_removeT.Location = new System.Drawing.Point(77, 118);
            this.btn_removeT.Name = "btn_removeT";
            this.btn_removeT.Size = new System.Drawing.Size(136, 23);
            this.btn_removeT.TabIndex = 0;
            this.btn_removeT.Text = "Remove Theseus";
            this.btn_removeT.UseVisualStyleBackColor = true;
            this.btn_removeT.Click += new System.EventHandler(this.btn_removeT_Click);
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Location = new System.Drawing.Point(562, 32);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(67, 13);
            this.lbl_instructions.TabIndex = 20;
            this.lbl_instructions.Text = "Instructions: ";
            // 
            // LevelBuilderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_instructions);
            this.Controls.Add(this.gb_occupiers);
            this.Controls.Add(this.gb_buildMap);
            this.Controls.Add(this.lbl_click);
            this.Controls.Add(this.lbl_heightTxt);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.lbl_widthTxt);
            this.Controls.Add(this.pb_maze);
            this.Name = "LevelBuilderView";
            this.Size = new System.Drawing.Size(911, 520);
            this.Load += new System.EventHandler(this.MazeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_maze)).EndInit();
            this.gb_buildMap.ResumeLayout(false);
            this.gb_buildMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_width)).EndInit();
            this.gb_occupiers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_widthTxt;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_heightTxt;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.PictureBox pb_maze;
        private System.Windows.Forms.Label lbl_click;
        private System.Windows.Forms.GroupBox gb_buildMap;
        private System.Windows.Forms.Label lbl_widthText;
        private System.Windows.Forms.Button btn_bldMaze;
        private System.Windows.Forms.NumericUpDown nud_height;
        private System.Windows.Forms.Label lbl_HeightText;
        private System.Windows.Forms.NumericUpDown nud_width;
        private System.Windows.Forms.GroupBox gb_occupiers;
        private System.Windows.Forms.Button btn_removeExit;
        private System.Windows.Forms.Button btn_removeM;
        private System.Windows.Forms.Button btn_removeT;
        private System.Windows.Forms.Button btnImg_T;
        private System.Windows.Forms.Button btnImg_M;
        private System.Windows.Forms.Button btnImg_X;
        private System.Windows.Forms.Label lbl_instructions;
    }
}
