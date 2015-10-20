namespace sudokuSolver
{
    partial class frmSudoku
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlSudoku = new System.Windows.Forms.Panel();
            this.TimeTaken = new System.Windows.Forms.Timer(this.components);
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.cmdRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(387, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Solve";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlSudoku
            // 
            this.pnlSudoku.Location = new System.Drawing.Point(12, 12);
            this.pnlSudoku.Name = "pnlSudoku";
            this.pnlSudoku.Size = new System.Drawing.Size(344, 338);
            this.pnlSudoku.TabIndex = 1;
            this.pnlSudoku.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSudoku_Paint);
            this.pnlSudoku.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlSudoku_MouseClick);
            this.pnlSudoku.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pnlSudoku_PreviewKeyDown);
            // 
            // TimeTaken
            // 
            this.TimeTaken.Interval = 1000;
            this.TimeTaken.Tick += new System.EventHandler(this.TimeTaken_Tick);
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeTaken.Location = new System.Drawing.Point(492, 9);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(80, 24);
            this.lblTimeTaken.TabIndex = 2;
            this.lblTimeTaken.Text = "00:00:00";
            // 
            // cmdRestart
            // 
            this.cmdRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRestart.Location = new System.Drawing.Point(387, 99);
            this.cmdRestart.Name = "cmdRestart";
            this.cmdRestart.Size = new System.Drawing.Size(185, 32);
            this.cmdRestart.TabIndex = 3;
            this.cmdRestart.Text = "Reset";
            this.cmdRestart.UseVisualStyleBackColor = true;
            this.cmdRestart.Click += new System.EventHandler(this.cmdRestart_Click);
            // 
            // frmSudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(588, 362);
            this.Controls.Add(this.cmdRestart);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.pnlSudoku);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmSudoku";
            this.Text = "Sudoku";
            this.Load += new System.EventHandler(this.frmSudoku_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlSudoku;
        private System.Windows.Forms.Timer TimeTaken;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.Button cmdRestart;
    }
}

