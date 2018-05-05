namespace GameConsole
{
    partial class MineScoreBoard
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.playerTimeLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.listTextBox = new System.Windows.Forms.TextBox();
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
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(270, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(215, 26);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
            // 
            // playerTimeLabel
            // 
            this.playerTimeLabel.AutoSize = true;
            this.playerTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTimeLabel.ForeColor = System.Drawing.Color.White;
            this.playerTimeLabel.Location = new System.Drawing.Point(135, 86);
            this.playerTimeLabel.Name = "playerScoreLabel";
            this.playerTimeLabel.Size = new System.Drawing.Size(113, 20);
            this.playerTimeLabel.TabIndex = 2;
            this.playerTimeLabel.Text = "Player\'s Score:";
            // 
            // scoreTextBox
            // 
            this.timeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTextBox.Location = new System.Drawing.Point(270, 83);
            this.timeTextBox.Name = "scoreTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.Size = new System.Drawing.Size(215, 26);
            this.timeTextBox.TabIndex = 3;
            // 
            // listTextBox
            // 
            this.listTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTextBox.Location = new System.Drawing.Point(90, 135);
            this.listTextBox.Multiline = true;
            this.listTextBox.Name = "listTextBox";
            this.listTextBox.ReadOnly = true;
            this.listTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listTextBox.Size = new System.Drawing.Size(463, 175);
            this.listTextBox.TabIndex = 4;
            // 
            // MineScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(617, 336);
            this.Controls.Add(this.listTextBox);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.playerTimeLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.playerLabel);
            this.Name = "MineScoreBoard";
            this.Text = "Minesweeper ScoreBoard";
            this.Load += new System.EventHandler(this.MineScoreBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox listTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.Label playerTimeLabel;
    }
}