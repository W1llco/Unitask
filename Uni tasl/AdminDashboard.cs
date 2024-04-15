using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniTask.data;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class AdminDashboard : Form
    {
        private string _username;
        private VotingContext dbContext;

        public AdminDashboard(string username)
        {
            _username = username;
            InitializeComponent();
        }

        public AdminDashboard(VotingContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            this.label1.Text = _username;
        }

        public void ChangeLabelText(string text)
        {
            if (this.InvokeRequired)
            {
                // If true, call this method again on the UI thread
                this.Invoke(new MethodInvoker(() => ChangeLabelText(text)));
            }
            else
            {
                // If already on the UI thread, safely update the label's text
                this.label1.Text = text;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void verifyVoterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var pageOpen = (VerifyVoter)Program._provider.GetService(typeof(VerifyVoter));
            pageOpen.Show();
        }

        private void createCandidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pageOpen = (CreateCandidates)Program._provider.GetService(typeof(CreateCandidates));
            pageOpen.Show();
        }

        private void createElectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pageOpen = (CreateElection)Program._provider.GetService(typeof(CreateElection));
            pageOpen.Show();
        }
    }
}
