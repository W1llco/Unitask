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
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class AdminDashboard : Form
    {
        
        private VotingContext _dbContext;
        private ElectionsRepositories _electionsRepositories;

        public AdminDashboard( ElectionsRepositories electionsRepositories, VotingContext dbContext)
        {
            
            _electionsRepositories = electionsRepositories;
            _dbContext = dbContext;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            var elections = _electionsRepositories.LoadAll();
            electionDataGridView.Columns.Add("Name","Name");
            electionDataGridView.Columns.Add("Start Date","Start Date");
            electionDataGridView.Columns.Add("End Date","End Date");
            electionDataGridView.Columns.Add("Voting System","Voting System");
            electionDataGridView.Columns.Add("Winner","Winner");

            electionDataGridView.AutoGenerateColumns = false;

            foreach( var election in elections)
            {
                electionDataGridView.Rows.Add(election.Name, election.StartTime, election.EndTime, election.VoteSystem, election.Winner);
            }
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

        private void pickElectionButton_Click(object sender, EventArgs e)
        {
            var modifyElection = (ModifyElection)Program._provider.GetService(typeof(ModifyElection));
            var selectedRow = electionDataGridView.SelectedRows[0];
            //modifyElection.SetIds(election.id);
            modifyElection.Show();

        }
    }
}
