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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class AdminDashboard : Form
    {
        private VotingContext _dbContext;
        private ElectionsRepositories _electionsRepositories;
        private readonly AdminsRepositories _adminsRepositories;
        public IEnumerable<Election> allElections;
        public Guid _adminId;

        public AdminDashboard( ElectionsRepositories electionsRepositories, VotingContext dbContext, AdminsRepositories adminsRepositories)
        {
            _electionsRepositories = electionsRepositories;
            _adminsRepositories = adminsRepositories;
            _dbContext = dbContext;
            InitializeComponent();
        }

        public void InitializePage()
        {
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            var admin = _adminsRepositories.Load(_adminId);
            welcomeLabel.Text = $"Welcome {admin.Username}";
            allElections = _electionsRepositories.LoadAll();
            electionDataGridView.Columns.Add("Name","Name");
            electionDataGridView.Columns.Add("Start Date","Start Date");
            electionDataGridView.Columns.Add("End Date","End Date");
            electionDataGridView.Columns.Add("Voting System","Voting System");
            electionDataGridView.Columns.Add("Winner","Winner");
            electionDataGridView.Columns.Add("Id","Id");
            electionDataGridView.AutoGenerateColumns = false;

            foreach( var election in allElections)
            {
                electionDataGridView.Rows.Add(election.Name, election.StartTime, election.EndTime, election.VoteSystem, election.Winner, election.ID);
            }
        }
        public void SetIds(Guid adminId)
        {
            _adminId = adminId;
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
            if (electionDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = electionDataGridView.SelectedRows[0];
                var electionId = (Guid)selectedRow.Cells["Id"].Value;
                var saveElection = allElections.FirstOrDefault(x => x.ID == electionId);

                if (saveElection != null)
                {
                    var modifyElection = (ModifyElection)Program._provider.GetService(typeof(ModifyElection));
                    modifyElection.SetElection(saveElection);
                    modifyElection.InitializePage();
                    modifyElection.Show();
                }
                else
                {
                    MessageBox.Show("Voter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No row selected", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
