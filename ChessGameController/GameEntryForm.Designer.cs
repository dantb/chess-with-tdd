namespace ChessGameController
{
    partial class GameEntryForm
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
            this.StartGameButton = new System.Windows.Forms.Button();
            this.BlackTeamRB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.YourTeamLabel = new System.Windows.Forms.Label();
            this.WhiteTeamRB = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.Color.SaddleBrown;
            this.StartGameButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartGameButton.FlatAppearance.BorderSize = 10;
            this.StartGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.StartGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.StartGameButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.ForeColor = System.Drawing.Color.BurlyWood;
            this.StartGameButton.Location = new System.Drawing.Point(12, 12);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(206, 109);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // BlackTeamRB
            // 
            this.BlackTeamRB.AutoSize = true;
            this.BlackTeamRB.Checked = true;
            this.BlackTeamRB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTeamRB.Location = new System.Drawing.Point(19, 38);
            this.BlackTeamRB.Name = "BlackTeamRB";
            this.BlackTeamRB.Size = new System.Drawing.Size(60, 18);
            this.BlackTeamRB.TabIndex = 1;
            this.BlackTeamRB.TabStop = true;
            this.BlackTeamRB.Text = "Black";
            this.BlackTeamRB.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.YourTeamLabel);
            this.panel1.Controls.Add(this.WhiteTeamRB);
            this.panel1.Controls.Add(this.BlackTeamRB);
            this.panel1.Location = new System.Drawing.Point(235, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 109);
            this.panel1.TabIndex = 2;
            // 
            // YourTeamLabel
            // 
            this.YourTeamLabel.AutoSize = true;
            this.YourTeamLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YourTeamLabel.Location = new System.Drawing.Point(16, 14);
            this.YourTeamLabel.Name = "YourTeamLabel";
            this.YourTeamLabel.Size = new System.Drawing.Size(126, 14);
            this.YourTeamLabel.TabIndex = 3;
            this.YourTeamLabel.Text = "Choose your team:";
            // 
            // WhiteTeamRB
            // 
            this.WhiteTeamRB.AutoSize = true;
            this.WhiteTeamRB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTeamRB.Location = new System.Drawing.Point(19, 62);
            this.WhiteTeamRB.Name = "WhiteTeamRB";
            this.WhiteTeamRB.Size = new System.Drawing.Size(60, 18);
            this.WhiteTeamRB.TabIndex = 2;
            this.WhiteTeamRB.Text = "White";
            this.WhiteTeamRB.UseVisualStyleBackColor = true;
            // 
            // GameEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(452, 134);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StartGameButton);
            this.Name = "GameEntryForm";
            this.Text = "Chess Game";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.RadioButton BlackTeamRB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton WhiteTeamRB;
        private System.Windows.Forms.Label YourTeamLabel;
    }
}

