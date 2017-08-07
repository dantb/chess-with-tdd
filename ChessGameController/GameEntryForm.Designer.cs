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
            this.TeamRadioButtonsPanel = new System.Windows.Forms.Panel();
            this.PanelChooseOpponent = new System.Windows.Forms.Panel();
            this.LabelChooseOpponent = new System.Windows.Forms.Label();
            this.RadioButtonPVP = new System.Windows.Forms.RadioButton();
            this.RadioButtonPlayComputer = new System.Windows.Forms.RadioButton();
            this.PanelChooseColour = new System.Windows.Forms.Panel();
            this.LabelChooseColour = new System.Windows.Forms.Label();
            this.WhiteTeamRB = new System.Windows.Forms.RadioButton();
            this.BlackTeamRB = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonTeamSplitter = new System.Windows.Forms.SplitContainer();
            this.BrowsePositionFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.PanelLoadPosition = new System.Windows.Forms.Panel();
            this.LoadPositionButton = new System.Windows.Forms.Button();
            this.LoadPositionLabel = new System.Windows.Forms.Label();
            this.TeamRadioButtonsPanel.SuspendLayout();
            this.PanelChooseOpponent.SuspendLayout();
            this.PanelChooseColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonTeamSplitter)).BeginInit();
            this.ButtonTeamSplitter.Panel1.SuspendLayout();
            this.ButtonTeamSplitter.Panel2.SuspendLayout();
            this.ButtonTeamSplitter.SuspendLayout();
            this.PanelLoadPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.Color.SaddleBrown;
            this.StartGameButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartGameButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartGameButton.FlatAppearance.BorderSize = 10;
            this.StartGameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.StartGameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.StartGameButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGameButton.ForeColor = System.Drawing.Color.BurlyWood;
            this.StartGameButton.Location = new System.Drawing.Point(0, 0);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(398, 263);
            this.StartGameButton.TabIndex = 0;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // TeamRadioButtonsPanel
            // 
            this.TeamRadioButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TeamRadioButtonsPanel.Controls.Add(this.PanelLoadPosition);
            this.TeamRadioButtonsPanel.Controls.Add(this.PanelChooseOpponent);
            this.TeamRadioButtonsPanel.Controls.Add(this.PanelChooseColour);
            this.TeamRadioButtonsPanel.Controls.Add(this.label1);
            this.TeamRadioButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamRadioButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.TeamRadioButtonsPanel.Name = "TeamRadioButtonsPanel";
            this.TeamRadioButtonsPanel.Size = new System.Drawing.Size(404, 263);
            this.TeamRadioButtonsPanel.TabIndex = 2;
            // 
            // PanelChooseOpponent
            // 
            this.PanelChooseOpponent.Controls.Add(this.LabelChooseOpponent);
            this.PanelChooseOpponent.Controls.Add(this.RadioButtonPVP);
            this.PanelChooseOpponent.Controls.Add(this.RadioButtonPlayComputer);
            this.PanelChooseOpponent.Location = new System.Drawing.Point(3, 96);
            this.PanelChooseOpponent.Name = "PanelChooseOpponent";
            this.PanelChooseOpponent.Size = new System.Drawing.Size(394, 90);
            this.PanelChooseOpponent.TabIndex = 10;
            // 
            // LabelChooseOpponent
            // 
            this.LabelChooseOpponent.AutoSize = true;
            this.LabelChooseOpponent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelChooseOpponent.Location = new System.Drawing.Point(16, 10);
            this.LabelChooseOpponent.Name = "LabelChooseOpponent";
            this.LabelChooseOpponent.Size = new System.Drawing.Size(147, 14);
            this.LabelChooseOpponent.TabIndex = 6;
            this.LabelChooseOpponent.Text = "Choose you opponent:";
            // 
            // RadioButtonPVP
            // 
            this.RadioButtonPVP.AutoSize = true;
            this.RadioButtonPVP.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonPVP.Location = new System.Drawing.Point(19, 58);
            this.RadioButtonPVP.Name = "RadioButtonPVP";
            this.RadioButtonPVP.Size = new System.Drawing.Size(207, 18);
            this.RadioButtonPVP.TabIndex = 5;
            this.RadioButtonPVP.Text = "Local player versus player";
            this.RadioButtonPVP.UseVisualStyleBackColor = true;
            // 
            // RadioButtonPlayComputer
            // 
            this.RadioButtonPlayComputer.AutoSize = true;
            this.RadioButtonPlayComputer.Checked = true;
            this.RadioButtonPlayComputer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RadioButtonPlayComputer.Location = new System.Drawing.Point(19, 34);
            this.RadioButtonPlayComputer.Name = "RadioButtonPlayComputer";
            this.RadioButtonPlayComputer.Size = new System.Drawing.Size(144, 18);
            this.RadioButtonPlayComputer.TabIndex = 4;
            this.RadioButtonPlayComputer.TabStop = true;
            this.RadioButtonPlayComputer.Text = "Play the computer";
            this.RadioButtonPlayComputer.UseVisualStyleBackColor = true;
            // 
            // PanelChooseColour
            // 
            this.PanelChooseColour.Controls.Add(this.LabelChooseColour);
            this.PanelChooseColour.Controls.Add(this.WhiteTeamRB);
            this.PanelChooseColour.Controls.Add(this.BlackTeamRB);
            this.PanelChooseColour.Location = new System.Drawing.Point(3, 4);
            this.PanelChooseColour.Name = "PanelChooseColour";
            this.PanelChooseColour.Size = new System.Drawing.Size(394, 87);
            this.PanelChooseColour.TabIndex = 9;
            // 
            // LabelChooseColour
            // 
            this.LabelChooseColour.AutoSize = true;
            this.LabelChooseColour.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelChooseColour.Location = new System.Drawing.Point(16, 10);
            this.LabelChooseColour.Name = "LabelChooseColour";
            this.LabelChooseColour.Size = new System.Drawing.Size(126, 14);
            this.LabelChooseColour.TabIndex = 6;
            this.LabelChooseColour.Text = "Choose your team:";
            // 
            // WhiteTeamRB
            // 
            this.WhiteTeamRB.AutoSize = true;
            this.WhiteTeamRB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTeamRB.Location = new System.Drawing.Point(19, 58);
            this.WhiteTeamRB.Name = "WhiteTeamRB";
            this.WhiteTeamRB.Size = new System.Drawing.Size(60, 18);
            this.WhiteTeamRB.TabIndex = 5;
            this.WhiteTeamRB.Text = "White";
            this.WhiteTeamRB.UseVisualStyleBackColor = true;
            // 
            // BlackTeamRB
            // 
            this.BlackTeamRB.AutoSize = true;
            this.BlackTeamRB.Checked = true;
            this.BlackTeamRB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTeamRB.Location = new System.Drawing.Point(19, 34);
            this.BlackTeamRB.Name = "BlackTeamRB";
            this.BlackTeamRB.Size = new System.Drawing.Size(60, 18);
            this.BlackTeamRB.TabIndex = 4;
            this.BlackTeamRB.TabStop = true;
            this.BlackTeamRB.Text = "Black";
            this.BlackTeamRB.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Opponent:";
            // 
            // ButtonTeamSplitter
            // 
            this.ButtonTeamSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonTeamSplitter.Location = new System.Drawing.Point(12, 12);
            this.ButtonTeamSplitter.Name = "ButtonTeamSplitter";
            // 
            // ButtonTeamSplitter.Panel1
            // 
            this.ButtonTeamSplitter.Panel1.Controls.Add(this.StartGameButton);
            this.ButtonTeamSplitter.Panel1MinSize = 206;
            // 
            // ButtonTeamSplitter.Panel2
            // 
            this.ButtonTeamSplitter.Panel2.Controls.Add(this.TeamRadioButtonsPanel);
            this.ButtonTeamSplitter.Panel2MinSize = 206;
            this.ButtonTeamSplitter.Size = new System.Drawing.Size(806, 263);
            this.ButtonTeamSplitter.SplitterDistance = 398;
            this.ButtonTeamSplitter.TabIndex = 3;
            // 
            // BrowsePositionFileDialogue
            // 
            this.BrowsePositionFileDialogue.FileName = "openFileDialog1";
            // 
            // PanelLoadPosition
            // 
            this.PanelLoadPosition.Controls.Add(this.LoadPositionButton);
            this.PanelLoadPosition.Controls.Add(this.LoadPositionLabel);
            this.PanelLoadPosition.Location = new System.Drawing.Point(3, 191);
            this.PanelLoadPosition.Name = "PanelLoadPosition";
            this.PanelLoadPosition.Size = new System.Drawing.Size(394, 64);
            this.PanelLoadPosition.TabIndex = 11;
            // 
            // LoadPositionButton
            // 
            this.LoadPositionButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPositionButton.Location = new System.Drawing.Point(19, 28);
            this.LoadPositionButton.Name = "LoadPositionButton";
            this.LoadPositionButton.Size = new System.Drawing.Size(357, 25);
            this.LoadPositionButton.TabIndex = 9;
            this.LoadPositionButton.Text = "Load position";
            this.LoadPositionButton.UseVisualStyleBackColor = true;
            this.LoadPositionButton.Click += new System.EventHandler(this.LoadPositionButton_Click);
            // 
            // LoadPositionLabel
            // 
            this.LoadPositionLabel.AutoSize = true;
            this.LoadPositionLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPositionLabel.Location = new System.Drawing.Point(16, 11);
            this.LoadPositionLabel.Name = "LoadPositionLabel";
            this.LoadPositionLabel.Size = new System.Drawing.Size(364, 14);
            this.LoadPositionLabel.TabIndex = 8;
            this.LoadPositionLabel.Text = "Alternatively, load the board position from a file:";
            // 
            // GameEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(831, 290);
            this.Controls.Add(this.ButtonTeamSplitter);
            this.MinimumSize = new System.Drawing.Size(457, 175);
            this.Name = "GameEntryForm";
            this.Text = "Chess Game";
            this.TeamRadioButtonsPanel.ResumeLayout(false);
            this.TeamRadioButtonsPanel.PerformLayout();
            this.PanelChooseOpponent.ResumeLayout(false);
            this.PanelChooseOpponent.PerformLayout();
            this.PanelChooseColour.ResumeLayout(false);
            this.PanelChooseColour.PerformLayout();
            this.ButtonTeamSplitter.Panel1.ResumeLayout(false);
            this.ButtonTeamSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonTeamSplitter)).EndInit();
            this.ButtonTeamSplitter.ResumeLayout(false);
            this.PanelLoadPosition.ResumeLayout(false);
            this.PanelLoadPosition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Panel TeamRadioButtonsPanel;
        private System.Windows.Forms.SplitContainer ButtonTeamSplitter;
        private System.Windows.Forms.OpenFileDialog BrowsePositionFileDialogue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PanelChooseColour;
        private System.Windows.Forms.Label LabelChooseColour;
        private System.Windows.Forms.RadioButton WhiteTeamRB;
        private System.Windows.Forms.RadioButton BlackTeamRB;
        private System.Windows.Forms.Panel PanelChooseOpponent;
        private System.Windows.Forms.Label LabelChooseOpponent;
        private System.Windows.Forms.RadioButton RadioButtonPVP;
        private System.Windows.Forms.RadioButton RadioButtonPlayComputer;
        private System.Windows.Forms.Panel PanelLoadPosition;
        private System.Windows.Forms.Button LoadPositionButton;
        private System.Windows.Forms.Label LoadPositionLabel;
    }
}

