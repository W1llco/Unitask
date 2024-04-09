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
            this.votePagelocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.electionControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.votePagelocalToolStripMenuItem,
            this.electionControlToolStripMenuItem,
            this.verifyVoterToolStripMenuItem,
            this.getResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // votePagelocalToolStripMenuItem
            // 
            this.votePagelocalToolStripMenuItem.Name = "votePagelocalToolStripMenuItem";
            this.votePagelocalToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.votePagelocalToolStripMenuItem.Text = "Vote page (local)";
            // 
            // electionControlToolStripMenuItem
            // 
            this.electionControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startElectionToolStripMenuItem,
            this.endElectionToolStripMenuItem,
            this.countElectionToolStripMenuItem,
            this.createElectionToolStripMenuItem,
            this.deleteElectionToolStripMenuItem});
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
            // 
            // deleteElectionToolStripMenuItem
            // 
            this.deleteElectionToolStripMenuItem.Name = "deleteElectionToolStripMenuItem";
            this.deleteElectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteElectionToolStripMenuItem.Text = "Delete Election";
            // 
            // verifyVoterToolStripMenuItem
            // 
            this.verifyVoterToolStripMenuItem.Name = "verifyVoterToolStripMenuItem";
            this.verifyVoterToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.verifyVoterToolStripMenuItem.Text = "Verify Voter";
            // 
            // getResultsToolStripMenuItem
            // 
            this.getResultsToolStripMenuItem.Name = "getResultsToolStripMenuItem";
            this.getResultsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.getResultsToolStripMenuItem.Text = "Get results";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private ToolStripMenuItem votePagelocalToolStripMenuItem;
        private ToolStripMenuItem electionControlToolStripMenuItem;
        private ToolStripMenuItem startElectionToolStripMenuItem;
        private ToolStripMenuItem endElectionToolStripMenuItem;
        private ToolStripMenuItem countElectionToolStripMenuItem;
        private ToolStripMenuItem createElectionToolStripMenuItem;
        private ToolStripMenuItem deleteElectionToolStripMenuItem;
        private ToolStripMenuItem verifyVoterToolStripMenuItem;
        private ToolStripMenuItem getResultsToolStripMenuItem;
    }
}