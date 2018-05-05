namespace GameConsole
{
    partial class TetrisScoreBoard
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
            this.playerLabel = new System.Windows.Forms.Label();
            this.t_nameTextBox = new System.Windows.Forms.TextBox();
            this.playerScoreLabel = new System.Windows.Forms.Label();
            this.t_scoreTextBox = new System.Windows.Forms.TextBox();
            this.t_listTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerLabel.ForeColor = System.Drawing.Color.White;
            this.playerLabel.Location = new System.Drawing.Point(135, 45);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(117, 20);
            this.playerLabel.TabIndex = 0;
            this.playerLabel.Text = "Player\'s Name: ";
            // 
            // nameTextBox
            // 
            this.t_nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_nameTextBox.Location = new System.Drawing.Point(270, 43);
            this.t_nameTextBox.Name = "nameTextBox";
            this.t_nameTextBox.Size = new System.Drawing.Size(215, 26);
            this.t_nameTextBox.TabIndex = 1;
            this.t_nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // playerScoreLabel
            // 
            this.playerScoreLabel.AutoSize = true;
            this.playerScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScoreLabel.ForeColor = System.Drawing.Color.White;
            this.playerScoreLabel.Location = new System.Drawing.Point(135, 86);
            this.playerScoreLabel.Name = "playerScoreLabel";
            this.playerScoreLabel.Size = new System.Drawing.Size(113, 20);
            this.playerScoreLabel.TabIndex = 2;
            this.playerScoreLabel.Text = "Player\'s Score:";
            // 
            // scoreTextBox
            // 
            this.t_scoreTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_scoreTextBox.Location = new System.Drawing.Point(270, 83);
            this.t_scoreTextBox.Name = "scoreTextBox";
            this.t_scoreTextBox.ReadOnly = true;
            this.t_scoreTextBox.Size = new System.Drawing.Size(215, 26);
            this.t_scoreTextBox.TabIndex = 3;
            // 
            // listTextBox
            // 
            this.t_listTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_listTextBox.Location = new System.Drawing.Point(90, 135);
            this.t_listTextBox.Multiline = true;
            this.t_listTextBox.Name = "listTextBox";
            this.t_listTextBox.ReadOnly = true;
            this.t_listTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.t_listTextBox.Size = new System.Drawing.Size(463, 175);
            this.t_listTextBox.TabIndex = 4;
            // 
            // TetrisScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(617, 336);
            this.Controls.Add(this.t_listTextBox);
            this.Controls.Add(this.t_scoreTextBox);
            this.Controls.Add(this.playerScoreLabel);
            this.Controls.Add(this.t_nameTextBox);
            this.Controls.Add(this.playerLabel);
            this.Name = "TetrisScoreBoard";
            this.Text = "Tetris ScoreBoard";
            this.Load += new System.EventHandler(this.TetrisScoreBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.TextBox t_nameTextBox;
        private System.Windows.Forms.Label playerScoreLabel;
        private System.Windows.Forms.TextBox t_scoreTextBox;
        private System.Windows.Forms.TextBox t_listTextBox;
    }
}