namespace GameConsole
{
    partial class MineForm
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
            this.mineBoardPanel = new System.Windows.Forms.Panel();
            this.timerLabel = new System.Windows.Forms.Label();
            this.flagLabel = new System.Windows.Forms.Label();
            this.m_playerTimeLabel = new System.Windows.Forms.Label();
            this.m_flagLabel = new System.Windows.Forms.Label();
            this.mineLogoBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mineLogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mineBoardPanel
            // 
            this.mineBoardPanel.BackColor = System.Drawing.Color.White;
            this.mineBoardPanel.Location = new System.Drawing.Point(65, 75);
            this.mineBoardPanel.Name = "mineBoardPanel";
            this.mineBoardPanel.Size = new System.Drawing.Size(225, 215);
            this.mineBoardPanel.TabIndex = 0;
            this.mineBoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mineBoardPanel_Bucket);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(15, 25);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(76, 24);
            this.timerLabel.TabIndex = 1;
            this.timerLabel.Text = "Timer: ";
            // 
            // flagLabel
            // 
            this.flagLabel.AutoSize = true;
            this.flagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagLabel.Location = new System.Drawing.Point(175, 25);
            this.flagLabel.Name = "flagLabel";
            this.flagLabel.Size = new System.Drawing.Size(73, 24);
            this.flagLabel.TabIndex = 2;
            this.flagLabel.Text = "Flags: ";
            // 
            // m_playerTimeLabel
            // 
            this.m_playerTimeLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.m_playerTimeLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.m_playerTimeLabel.Font = new System.Drawing.Font("Modern No. 20", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_playerTimeLabel.ForeColor = System.Drawing.Color.Black;
            this.m_playerTimeLabel.Location = new System.Drawing.Point(85, 25);
            this.m_playerTimeLabel.Name = "m_playerTimeLabel";
            this.m_playerTimeLabel.Size = new System.Drawing.Size(74, 28);
            this.m_playerTimeLabel.TabIndex = 3;
            this.m_playerTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_flagLabel
            // 
            this.m_flagLabel.BackColor = System.Drawing.Color.ForestGreen;
            this.m_flagLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.m_flagLabel.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_flagLabel.ForeColor = System.Drawing.Color.Black;
            this.m_flagLabel.Location = new System.Drawing.Point(250, 25);
            this.m_flagLabel.Name = "m_flagLabel";
            this.m_flagLabel.Size = new System.Drawing.Size(74, 28);
            this.m_flagLabel.TabIndex = 4;
            this.m_flagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mineLogoBox
            // 
            this.mineLogoBox.Image = global::GameConsole.Properties.Resources.mineLogo;
            this.mineLogoBox.Location = new System.Drawing.Point(50, 300);
            this.mineLogoBox.Name = "mineLogoBox";
            this.mineLogoBox.Size = new System.Drawing.Size(252, 149);
            this.mineLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mineLogoBox.TabIndex = 5;
            this.mineLogoBox.TabStop = false;
            // 
            // MineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(359, 461);
            this.Controls.Add(this.mineLogoBox);
            this.Controls.Add(this.m_flagLabel);
            this.Controls.Add(this.m_playerTimeLabel);
            this.Controls.Add(this.flagLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.mineBoardPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MineForm";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.MineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mineLogoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mineBoardPanel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label flagLabel;
        private System.Windows.Forms.Label m_playerTimeLabel;
        private System.Windows.Forms.Label m_flagLabel;
        private System.Windows.Forms.PictureBox mineLogoBox;
    }
}