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
            menuStrip1 = new MenuStrip();
            votePagelocalToolStripMenuItem = new ToolStripMenuItem();
            electionControlToolStripMenuItem = new ToolStripMenuItem();
            startElectionToolStripMenuItem = new ToolStripMenuItem();
            endElectionToolStripMenuItem = new ToolStripMenuItem();
            countElectionToolStripMenuItem = new ToolStripMenuItem();
            createElectionToolStripMenuItem = new ToolStripMenuItem();
            deleteElectionToolStripMenuItem = new ToolStripMenuItem();
            verifyVoterToolStripMenuItem = new ToolStripMenuItem();
            getResultsToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { votePagelocalToolStripMenuItem, electionControlToolStripMenuItem, verifyVoterToolStripMenuItem, getResultsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1143, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // votePagelocalToolStripMenuItem
            // 
            votePagelocalToolStripMenuItem.Name = "votePagelocalToolStripMenuItem";
            votePagelocalToolStripMenuItem.Size = new Size(160, 29);
            votePagelocalToolStripMenuItem.Text = "Vote page (local)";
            // 
            // electionControlToolStripMenuItem
            // 
            electionControlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startElectionToolStripMenuItem, endElectionToolStripMenuItem, countElectionToolStripMenuItem, createElectionToolStripMenuItem, deleteElectionToolStripMenuItem });
            electionControlToolStripMenuItem.Name = "electionControlToolStripMenuItem";
            electionControlToolStripMenuItem.Size = new Size(153, 29);
            electionControlToolStripMenuItem.Text = "Election Control";
            // 
            // startElectionToolStripMenuItem
            // 
            startElectionToolStripMenuItem.Name = "startElectionToolStripMenuItem";
            startElectionToolStripMenuItem.Size = new Size(270, 34);
            startElectionToolStripMenuItem.Text = "Start Election";
            // 
            // endElectionToolStripMenuItem
            // 
            endElectionToolStripMenuItem.Name = "endElectionToolStripMenuItem";
            endElectionToolStripMenuItem.Size = new Size(270, 34);
            endElectionToolStripMenuItem.Text = "End Election";
            // 
            // countElectionToolStripMenuItem
            // 
            countElectionToolStripMenuItem.Name = "countElectionToolStripMenuItem";
            countElectionToolStripMenuItem.Size = new Size(270, 34);
            countElectionToolStripMenuItem.Text = "Count Election";
            // 
            // createElectionToolStripMenuItem
            // 
            createElectionToolStripMenuItem.Name = "createElectionToolStripMenuItem";
            createElectionToolStripMenuItem.Size = new Size(270, 34);
            createElectionToolStripMenuItem.Text = "Create Election";
            // 
            // deleteElectionToolStripMenuItem
            // 
            deleteElectionToolStripMenuItem.Name = "deleteElectionToolStripMenuItem";
            deleteElectionToolStripMenuItem.Size = new Size(270, 34);
            deleteElectionToolStripMenuItem.Text = "Delete Election";
            // 
            // verifyVoterToolStripMenuItem
            // 
            verifyVoterToolStripMenuItem.Name = "verifyVoterToolStripMenuItem";
            verifyVoterToolStripMenuItem.Size = new Size(119, 29);
            verifyVoterToolStripMenuItem.Text = "Verify Voter";
            // 
            // getResultsToolStripMenuItem
            // 
            getResultsToolStripMenuItem.Name = "getResultsToolStripMenuItem";
            getResultsToolStripMenuItem.Size = new Size(111, 29);
            getResultsToolStripMenuItem.Text = "Get results";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(433, 96);
            label1.TabIndex = 1;
            label1.Text = "Welcome ...";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(31, 169);
            label2.Name = "label2";
            label2.Size = new Size(744, 65);
            label2.TabIndex = 2;
            label2.Text = "Any Current Elections going on ";
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminDashboard";
            Text = " ";
            Load += AdminDashboard_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label1;
        private Label label2;
    }
}