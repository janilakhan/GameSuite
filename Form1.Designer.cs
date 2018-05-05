using System;

namespace GameConsole
{
    partial class GameSuite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; 
        /// otherwise, false.</param>
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
            this.welcome = new System.Windows.Forms.Label();
            this.snakeBox = new System.Windows.Forms.PictureBox();
            this.mineBox = new System.Windows.Forms.PictureBox();
            this.tetBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.snakeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetBox)).BeginInit();
            this.SuspendLayout();
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.BackColor = System.Drawing.Color.Transparent;
            this.welcome.Font = new System.Drawing.Font("Mistral", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.welcome.Location = new System.Drawing.Point(188, 58);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(402, 57);
            this.welcome.TabIndex = 2;
            this.welcome.Text = "Choose A Game To Play";
            // 
            // snakeBox
            // 
            this.snakeBox.BackColor = System.Drawing.Color.White;
            this.snakeBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.snakeBox.Image = global::GameConsole.Properties.Resources.snakeIcon;
            this.snakeBox.Location = new System.Drawing.Point(520, 175);
            this.snakeBox.Name = "snakeBox";
            this.snakeBox.Size = new System.Drawing.Size(182, 180);
            this.snakeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.snakeBox.TabIndex = 0;
            this.snakeBox.TabStop = false;
            this.snakeBox.Click += new System.EventHandler(this.snakeBox_Click);
            // 
            // mineBox
            // 
            this.mineBox.BackColor = System.Drawing.Color.AntiqueWhite;
            this.mineBox.BackgroundImage = global::GameConsole.Properties.Resources.minesweeper;
            this.mineBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mineBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mineBox.Location = new System.Drawing.Point(300, 175);
            this.mineBox.Name = "mineBox";
            this.mineBox.Size = new System.Drawing.Size(182, 180);
            this.mineBox.TabIndex = 1;
            this.mineBox.TabStop = false;
            this.mineBox.Click += new System.EventHandler(this.mineBox_Click);
            // 
            // tetBox
            // 
            this.tetBox.BackColor = System.Drawing.Color.Transparent;
            this.tetBox.BackgroundImage = global::GameConsole.Properties.Resources.tetris;
            this.tetBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tetBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tetBox.Location = new System.Drawing.Point(75, 175);
            this.tetBox.Name = "tetBox";
            this.tetBox.Size = new System.Drawing.Size(182, 180);
            this.tetBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tetBox.TabIndex = 0;
            this.tetBox.TabStop = false;
            this.tetBox.Click += new System.EventHandler(this.tetBox_Click);
            // 
            // GameSuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameConsole.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(759, 436);
            this.Controls.Add(this.snakeBox);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.mineBox);
            this.Controls.Add(this.tetBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GameSuite";
            this.Text = "Senior Project: Game Suite";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.GameSuite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.snakeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mineBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox tetBox;
        private System.Windows.Forms.PictureBox mineBox;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.PictureBox snakeBox;
    }
}

