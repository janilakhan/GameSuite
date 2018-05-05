namespace GameConsole
{
    partial class TetrisForm
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
            this.tetrisBoard = new System.Windows.Forms.Panel();
            this.nextBlock = new System.Windows.Forms.Panel();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.t_playerRowsLabel = new System.Windows.Forms.Label();
            this.t_playerScoreLabel = new System.Windows.Forms.Label();
            this.buttonsTextBox = new System.Windows.Forms.TextBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.t_playerLevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tetrisBoard
            // 
            this.tetrisBoard.BackColor = System.Drawing.Color.Black;
            this.tetrisBoard.Location = new System.Drawing.Point(29, 23);
            this.tetrisBoard.Name = "tetrisBoard";
            this.tetrisBoard.Size = new System.Drawing.Size(214, 421);
            this.tetrisBoard.TabIndex = 0;
            this.tetrisBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.tetrisBoard_Bucket);
            // 
            // nextBlock
            // 
            this.nextBlock.BackColor = System.Drawing.Color.Black;
            this.nextBlock.Location = new System.Drawing.Point(300, 25);
            this.nextBlock.Name = "nextBlock";
            this.nextBlock.Size = new System.Drawing.Size(154, 121);
            this.nextBlock.TabIndex = 1;
            this.nextBlock.Paint += new System.Windows.Forms.PaintEventHandler(this.nextBlock_Bucket);
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.rowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsLabel.ForeColor = System.Drawing.Color.White;
            this.rowsLabel.Location = new System.Drawing.Point(270, 165);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(55, 18);
            this.rowsLabel.TabIndex = 2;
            this.rowsLabel.Text = "Rows: ";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(270, 195);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(52, 18);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score:";
            // 
            // t_playerRowsLabel
            // 
            this.t_playerRowsLabel.BackColor = System.Drawing.Color.Black;
            this.t_playerRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_playerRowsLabel.ForeColor = System.Drawing.Color.White;
            this.t_playerRowsLabel.Location = new System.Drawing.Point(325, 160);
            this.t_playerRowsLabel.Name = "t_playerRowsLabel";
            this.t_playerRowsLabel.Size = new System.Drawing.Size(43, 24);
            this.t_playerRowsLabel.TabIndex = 0;
            this.t_playerRowsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t_playerScoreLabel
            // 
            this.t_playerScoreLabel.BackColor = System.Drawing.Color.Black;
            this.t_playerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_playerScoreLabel.ForeColor = System.Drawing.Color.White;
            this.t_playerScoreLabel.Location = new System.Drawing.Point(325, 190);
            this.t_playerScoreLabel.Name = "t_playerScoreLabel";
            this.t_playerScoreLabel.Size = new System.Drawing.Size(43, 24);
            this.t_playerScoreLabel.TabIndex = 0;
            this.t_playerScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonsTextBox
            // 
            this.buttonsTextBox.BackColor = System.Drawing.Color.Black;
            this.buttonsTextBox.Enabled = false;
            this.buttonsTextBox.ForeColor = System.Drawing.Color.White;
            this.buttonsTextBox.Location = new System.Drawing.Point(265, 223);
            this.buttonsTextBox.Multiline = true;
            this.buttonsTextBox.Name = "buttonsTextBox";
            this.buttonsTextBox.ReadOnly = true;
            this.buttonsTextBox.Size = new System.Drawing.Size(217, 100);
            this.buttonsTextBox.TabIndex = 9;
            this.buttonsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logo
            // 
            this.logo.Image = global::GameConsole.Properties.Resources.tetrisLogo;
            this.logo.Location = new System.Drawing.Point(265, 330);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(217, 112);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 10;
            this.logo.TabStop = false;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.White;
            this.levelLabel.Location = new System.Drawing.Point(380, 177);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(46, 18);
            this.levelLabel.TabIndex = 11;
            this.levelLabel.Text = "Level:";
            // 
            // t_playerLevelLabel
            // 
            this.t_playerLevelLabel.BackColor = System.Drawing.Color.Black;
            this.t_playerLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_playerLevelLabel.ForeColor = System.Drawing.Color.White;
            this.t_playerLevelLabel.Location = new System.Drawing.Point(430, 173);
            this.t_playerLevelLabel.Name = "t_playerLevelLabel";
            this.t_playerLevelLabel.Size = new System.Drawing.Size(42, 24);
            this.t_playerLevelLabel.TabIndex = 0;
            this.t_playerLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(514, 455);
            this.Controls.Add(this.t_playerLevelLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.buttonsTextBox);
            this.Controls.Add(this.t_playerScoreLabel);
            this.Controls.Add(this.t_playerRowsLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.nextBlock);
            this.Controls.Add(this.tetrisBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TetrisForm";
            this.Text = "Tetris Game";
            this.Load += new System.EventHandler(this.TetrisForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tetrisBoard;
        private System.Windows.Forms.Panel nextBlock;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label t_playerRowsLabel;
        private System.Windows.Forms.Label t_playerScoreLabel;
        private System.Windows.Forms.TextBox buttonsTextBox;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label t_playerLevelLabel;
    }
}