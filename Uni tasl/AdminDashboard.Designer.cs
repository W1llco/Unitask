namespace Uni_tasl
{
    partial class AdminDashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.electionControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCandidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.electionDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pickElectionButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electionControlToolStripMenuItem,
            this.verifyVoterToolStripMenuItem,
            this.getResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // electionControlToolStripMenuItem
            // 
            this.electionControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createElectionToolStripMenuItem,
            this.deleteElectionToolStripMenuItem,
            this.createCandidatesToolStripMenuItem});
            this.electionControlToolStripMenuItem.Name = "electionControlToolStripMenuItem";
            this.electionControlToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.electionControlToolStripMenuItem.Text = "Election Control";
            // 
            // createElectionToolStripMenuItem
            // 
            this.createElectionToolStripMenuItem.Name = "createElectionToolStripMenuItem";
            this.createElectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.createElectionToolStripMenuItem.Text = "Create Election";
            this.createElectionToolStripMenuItem.Click += new System.EventHandler(this.createElectionToolStripMenuItem_Click);
            // 
            // deleteElectionToolStripMenuItem
            // 
            this.deleteElectionToolStripMenuItem.Name = "deleteElectionToolStripMenuItem";
            this.deleteElectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deleteElectionToolStripMenuItem.Text = "Delete Election";
            // 
            // createCandidatesToolStripMenuItem
            // 
            this.createCandidatesToolStripMenuItem.Name = "createCandidatesToolStripMenuItem";
            this.createCandidatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.createCandidatesToolStripMenuItem.Text = "Create Candidates";
            this.createCandidatesToolStripMenuItem.Click += new System.EventHandler(this.createCandidatesToolStripMenuItem_Click);
            // 
            // verifyVoterToolStripMenuItem
            // 
            this.verifyVoterToolStripMenuItem.Name = "verifyVoterToolStripMenuItem";
            this.verifyVoterToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.verifyVoterToolStripMenuItem.Text = "Verify Voter";
            this.verifyVoterToolStripMenuItem.Click += new System.EventHandler(this.verifyVoterToolStripMenuItem_Click);
            // 
            // getResultsToolStripMenuItem
            // 
            this.getResultsToolStripMenuItem.Name = "getResultsToolStripMenuItem";
            this.getResultsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.getResultsToolStripMenuItem.Text = "Get results";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.Location = new System.Drawing.Point(8, 44);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(194, 45);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome ...";
            // 
            // electionDataGridView
            // 
            this.electionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.electionDataGridView.Location = new System.Drawing.Point(8, 143);
            this.electionDataGridView.Name = "electionDataGridView";
            this.electionDataGridView.RowTemplate.Height = 25;
            this.electionDataGridView.Size = new System.Drawing.Size(764, 184);
            this.electionDataGridView.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Elections";
            // 
            // pickElectionButton
            // 
            this.pickElectionButton.Location = new System.Drawing.Point(8, 345);
            this.pickElectionButton.Name = "pickElectionButton";
            this.pickElectionButton.Size = new System.Drawing.Size(159, 44);
            this.pickElectionButton.TabIndex = 4;
            this.pickElectionButton.Text = "Pick An Election To Modify";
            this.pickElectionButton.UseVisualStyleBackColor = true;
            this.pickElectionButton.Click += new System.EventHandler(this.pickElectionButton_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pickElectionButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.electionDataGridView);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminDashboard";
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem electionControlToolStripMenuItem;
        private ToolStripMenuItem createElectionToolStripMenuItem;
        private ToolStripMenuItem deleteElectionToolStripMenuItem;
        private ToolStripMenuItem verifyVoterToolStripMenuItem;
        private ToolStripMenuItem getResultsToolStripMenuItem;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem createCandidatesToolStripMenuItem;
        private DataGridView electionDataGridView;
        private Label label3;
        private Button pickElectionButton;
        private Label welcomeLabel;
    }
}