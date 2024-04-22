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
            this.createCandidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.electionDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.pickElectionButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.electionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electionControlToolStripMenuItem,
            this.verifyVoterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(914, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // electionControlToolStripMenuItem
            // 
            this.electionControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createElectionToolStripMenuItem,
            this.createCandidatesToolStripMenuItem,
            this.createVoterToolStripMenuItem});
            this.electionControlToolStripMenuItem.Name = "electionControlToolStripMenuItem";
            this.electionControlToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.electionControlToolStripMenuItem.Text = "Election Control";
            // 
            // createElectionToolStripMenuItem
            // 
            this.createElectionToolStripMenuItem.Name = "createElectionToolStripMenuItem";
            this.createElectionToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createElectionToolStripMenuItem.Text = "Create Election";
            this.createElectionToolStripMenuItem.Click += new System.EventHandler(this.createElectionToolStripMenuItem_Click);
            // 
            // createCandidatesToolStripMenuItem
            // 
            this.createCandidatesToolStripMenuItem.Name = "createCandidatesToolStripMenuItem";
            this.createCandidatesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createCandidatesToolStripMenuItem.Text = "Create Candidates";
            this.createCandidatesToolStripMenuItem.Click += new System.EventHandler(this.createCandidatesToolStripMenuItem_Click);
            // 
            // createVoterToolStripMenuItem
            // 
            this.createVoterToolStripMenuItem.Name = "createVoterToolStripMenuItem";
            this.createVoterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createVoterToolStripMenuItem.Text = "Create Voter";
            this.createVoterToolStripMenuItem.Click += new System.EventHandler(this.createVoterToolStripMenuItem_Click);
            // 
            // verifyVoterToolStripMenuItem
            // 
            this.verifyVoterToolStripMenuItem.Name = "verifyVoterToolStripMenuItem";
            this.verifyVoterToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.verifyVoterToolStripMenuItem.Text = "Verify Voter";
            this.verifyVoterToolStripMenuItem.Click += new System.EventHandler(this.verifyVoterToolStripMenuItem_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeLabel.Location = new System.Drawing.Point(9, 59);
            this.welcomeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(241, 54);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Welcome ...";
            // 
            // electionDataGridView
            // 
            this.electionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.electionDataGridView.Location = new System.Drawing.Point(9, 191);
            this.electionDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.electionDataGridView.Name = "electionDataGridView";
            this.electionDataGridView.RowHeadersWidth = 51;
            this.electionDataGridView.RowTemplate.Height = 25;
            this.electionDataGridView.Size = new System.Drawing.Size(873, 245);
            this.electionDataGridView.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Elections";
            // 
            // pickElectionButton
            // 
            this.pickElectionButton.Location = new System.Drawing.Point(0, 459);
            this.pickElectionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pickElectionButton.Name = "pickElectionButton";
            this.pickElectionButton.Size = new System.Drawing.Size(182, 43);
            this.pickElectionButton.TabIndex = 4;
            this.pickElectionButton.Text = "Go to Election";
            this.pickElectionButton.UseVisualStyleBackColor = true;
            this.pickElectionButton.Click += new System.EventHandler(this.pickElectionButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Please select an Election to view or modify.";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(797, 152);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(86, 31);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(808, 33);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(94, 29);
            this.logOutButton.TabIndex = 7;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pickElectionButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.electionDataGridView);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private Label label4;
        private Button refreshButton;
        private ToolStripMenuItem createVoterToolStripMenuItem;
        private Button logOutButton;
    }
}