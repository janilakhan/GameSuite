namespace GameConsole
{
    partial class SnakeForm
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
            this.snakeBoard = new System.Windows.Forms.Panel();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.snakeLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.snakeLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // snakeBoard
            // 
            this.snakeBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.snakeBoard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.snakeBoard.Location = new System.Drawing.Point(15, 15);
            this.snakeBoard.Name = "snakeBoard";
            this.snakeBoard.Size = new System.Drawing.Size(225, 225);
            this.snakeBoard.TabIndex = 0;
            this.snakeBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.snakeBoard_Paint);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(285, 50);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(77, 24);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score: ";
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.playerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.ForeColor = System.Drawing.Color.White;
            this.playerScoreLabel.Location = new System.Drawing.Point(360, 50);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(59, 29);
            this.playerScoreLabel.TabIndex = 3;
            this.playerScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playerScoreLabel.UseWaitCursor = true;
            // 
            // snakeLogo
            // 
            this.snakeLogo.BackgroundImage = global::GameConsole.Properties.Resources.snakeLogo;
            this.snakeLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.snakeLogo.Location = new System.Drawing.Point(255, 113);
            this.snakeLogo.Name = "snakeLogo";
            this.snakeLogo.Size = new System.Drawing.Size(200, 125);
            this.snakeLogo.TabIndex = 1;
            this.snakeLogo.TabStop = false;
            // 
            // SnakeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(469, 261);
            this.Controls.Add(this.playerScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.snakeLogo);
            this.Controls.Add(this.snakeBoard);
            this.Name = "SnakeForm";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.SnakeForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.snakeLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel snakeBoard;
        private System.Windows.Forms.PictureBox snakeLogo;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label playerScoreLabel;
    }
}