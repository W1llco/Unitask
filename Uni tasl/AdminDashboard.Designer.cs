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
            this.startElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCandidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
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
            this.startElectionToolStripMenuItem,
            this.endElectionToolStripMenuItem,
            this.countElectionToolStripMenuItem,
            this.createElectionToolStripMenuItem,
            this.deleteElectionToolStripMenuItem,
            this.createCandidatesToolStripMenuItem});
            this.electionControlToolStripMenuItem.Name = "electionControlToolStripMenuItem";
            this.electionControlToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.electionControlToolStripMenuItem.Text = "Election Control";
            // 
            // startElectionToolStripMenuItem
            // 
            this.startElectionToolStripMenuItem.Name = "startElectionToolStripMenuItem";
            this.startElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startElectionToolStripMenuItem.Text = "Start Election";
            // 
            // endElectionToolStripMenuItem
            // 
            this.endElectionToolStripMenuItem.Name = "endElectionToolStripMenuItem";
            this.endElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.endElectionToolStripMenuItem.Text = "End Election";
            // 
            // countElectionToolStripMenuItem
            // 
            this.countElectionToolStripMenuItem.Name = "countElectionToolStripMenuItem";
            this.countElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.countElectionToolStripMenuItem.Text = "Count Election";
            // 
            // createElectionToolStripMenuItem
            // 
            this.createElectionToolStripMenuItem.Name = "createElectionToolStripMenuItem";
            this.createElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.createElectionToolStripMenuItem.Text = "Create Election";
            this.createElectionToolStripMenuItem.Click += new System.EventHandler(this.createElectionToolStripMenuItem_Click);
            // 
            // deleteElectionToolStripMenuItem
            // 
            this.deleteElectionToolStripMenuItem.Name = "deleteElectionToolStripMenuItem";
            this.deleteElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteElectionToolStripMenuItem.Text = "Delete Election";
            // 
            // createCandidatesToolStripMenuItem
            // 
            this.createCandidatesToolStripMenuItem.Name = "createCandidatesToolStripMenuItem";
            this.createCandidatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome ...";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "Any Current Elections going on ";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminDashboard";
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem electionControlToolStripMenuItem;
        private ToolStripMenuItem startElectionToolStripMenuItem;
        private ToolStripMenuItem endElectionToolStripMenuItem;
        private ToolStripMenuItem countElectionToolStripMenuItem;
        private ToolStripMenuItem createElectionToolStripMenuItem;
        private ToolStripMenuItem deleteElectionToolStripMenuItem;
        private ToolStripMenuItem verifyVoterToolStripMenuItem;
        private ToolStripMenuItem getResultsToolStripMenuItem;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem createCandidatesToolStripMenuItem;
    }
}