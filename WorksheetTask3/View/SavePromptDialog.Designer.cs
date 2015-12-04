namespace WinTandM.View
{
    partial class SavePromptDialog
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
            this.msg_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msg_lbl
            // 
            this.msg_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.msg_lbl.Location = new System.Drawing.Point(92, 96);
            this.msg_lbl.Name = "msg_lbl";
            this.msg_lbl.Size = new System.Drawing.Size(218, 56);
            this.msg_lbl.TabIndex = 2;
            this.msg_lbl.Text = "Override exsisting maze?";
            // 
            // SaveOptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(384, 262);
            this.Controls.Add(this.msg_lbl);
            this.Name = "SaveOptionsDialog";
            this.Text = "Save Prompt";
            this.Controls.SetChildIndex(this.msg_lbl, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label msg_lbl;
    }
}
