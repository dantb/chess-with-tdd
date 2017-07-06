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
            this.TeamRadioButtonsPanel = new System.Windows.Forms.Panel();
            this.YourTeamLabel = new System.Windows.Forms.Label();
            this.WhiteTeamRB = new System.Windows.Forms.RadioButton();
            this.ButtonTeamSplitter = new System.Windows.Forms.SplitContainer();
            this.BrowsePositionFilesButton = new System.Windows.Forms.Button();
            this.PositionFilePathTextBox = new System.Windows.Forms.TextBox();
            this.LoadPositionLabel = new System.Windows.Forms.Label();
            this.LoadPositionButton = new System.Windows.Forms.Button();
            this.BrowsePositionFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.TeamRadioButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonTeamSplitter)).BeginInit();
            this.ButtonTeamSplitter.Panel1.SuspendLayout();
            this.ButtonTeamSplitter.Panel2.SuspendLayout();
            this.ButtonTeamSplitter.SuspendLayout();
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
            this.StartGameButton.Size = new System.Drawing.Size(382, 182);
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
            // TeamRadioButtonsPanel
            // 
            this.TeamRadioButtonsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TeamRadioButtonsPanel.Controls.Add(this.LoadPositionButton);
            this.TeamRadioButtonsPanel.Controls.Add(this.LoadPositionLabel);
            this.TeamRadioButtonsPanel.Controls.Add(this.PositionFilePathTextBox);
            this.TeamRadioButtonsPanel.Controls.Add(this.BrowsePositionFilesButton);
            this.TeamRadioButtonsPanel.Controls.Add(this.YourTeamLabel);
            this.TeamRadioButtonsPanel.Controls.Add(this.WhiteTeamRB);
            this.TeamRadioButtonsPanel.Controls.Add(this.BlackTeamRB);
            this.TeamRadioButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamRadioButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.TeamRadioButtonsPanel.Name = "TeamRadioButtonsPanel";
            this.TeamRadioButtonsPanel.Size = new System.Drawing.Size(387, 182);
            this.TeamRadioButtonsPanel.TabIndex = 2;
            // 
            // YourTeamLabel
            // 
            this.YourTeamLabel.AutoSize = true;
            this.YourTeamLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YourTeamLabel.Location = new System.Drawing.Point(16, 14);
            this.YourTeamLabel.Name = "YourTeamLabel";
            this.YourTeamLabel.Size = new System.Drawing.Size(238, 14);
            this.YourTeamLabel.TabIndex = 3;
            this.YourTeamLabel.Text = "Choose your team and click start:";
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
            this.ButtonTeamSplitter.Size = new System.Drawing.Size(773, 182);
            this.ButtonTeamSplitter.SplitterDistance = 382;
            this.ButtonTeamSplitter.TabIndex = 3;
            // 
            // BrowsePositionFilesButton
            // 
            this.BrowsePositionFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowsePositionFilesButton.Location = new System.Drawing.Point(336, 113);
            this.BrowsePositionFilesButton.Name = "BrowsePositionFilesButton";
            this.BrowsePositionFilesButton.Size = new System.Drawing.Size(40, 20);
            this.BrowsePositionFilesButton.TabIndex = 4;
            this.BrowsePositionFilesButton.Text = "...";
            this.BrowsePositionFilesButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BrowsePositionFilesButton.UseVisualStyleBackColor = true;
            this.BrowsePositionFilesButton.Click += new System.EventHandler(this.BrowsePositionFilesButton_Click);
            // 
            // PositionFilePathTextBox
            // 
            this.PositionFilePathTextBox.Location = new System.Drawing.Point(19, 113);
            this.PositionFilePathTextBox.Name = "PositionFilePathTextBox";
            this.PositionFilePathTextBox.Size = new System.Drawing.Size(311, 20);
            this.PositionFilePathTextBox.TabIndex = 5;
            // 
            // LoadPositionLabel
            // 
            this.LoadPositionLabel.AutoSize = true;
            this.LoadPositionLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPositionLabel.Location = new System.Drawing.Point(19, 94);
            this.LoadPositionLabel.Name = "LoadPositionLabel";
            this.LoadPositionLabel.Size = new System.Drawing.Size(357, 14);
            this.LoadPositionLabel.TabIndex = 6;
            this.LoadPositionLabel.Text = "Alternatively, load the board position from a file";
            // 
            // LoadPositionButton
            // 
            this.LoadPositionButton.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadPositionButton.Location = new System.Drawing.Point(19, 140);
            this.LoadPositionButton.Name = "LoadPositionButton";
            this.LoadPositionButton.Size = new System.Drawing.Size(357, 25);
            this.LoadPositionButton.TabIndex = 7;
            this.LoadPositionButton.Text = "Load position";
            this.LoadPositionButton.UseVisualStyleBackColor = true;
            this.LoadPositionButton.Click += new System.EventHandler(this.LoadPositionButton_Click);
            // 
            // BrowsePositionFileDialogue
            // 
            this.BrowsePositionFileDialogue.FileName = "openFileDialog1";
            // 
            // GameEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(798, 209);
            this.Controls.Add(this.ButtonTeamSplitter);
            this.MinimumSize = new System.Drawing.Size(457, 175);
            this.Name = "GameEntryForm";
            this.Text = "Chess Game";
            this.TeamRadioButtonsPanel.ResumeLayout(false);
            this.TeamRadioButtonsPanel.PerformLayout();
            this.ButtonTeamSplitter.Panel1.ResumeLayout(false);
            this.ButtonTeamSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ButtonTeamSplitter)).EndInit();
            this.ButtonTeamSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.RadioButton BlackTeamRB;
        private System.Windows.Forms.Panel TeamRadioButtonsPanel;
        private System.Windows.Forms.RadioButton WhiteTeamRB;
        private System.Windows.Forms.Label YourTeamLabel;
        private System.Windows.Forms.SplitContainer ButtonTeamSplitter;
        private System.Windows.Forms.Button BrowsePositionFilesButton;
        private System.Windows.Forms.TextBox PositionFilePathTextBox;
        private System.Windows.Forms.Label LoadPositionLabel;
        private System.Windows.Forms.Button LoadPositionButton;
        private System.Windows.Forms.OpenFileDialog BrowsePositionFileDialogue;
    }
}

