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
using Unitask.DTOs;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    // Partial class representing the administration dashboard form for managing election-related data
    public partial class AdminDashboard : Form
    {
        // Fields for database context and services necessary for election management
        private VotingContext _dbContext;
        private readonly ElectionService _electionService;
        private readonly AdminService _adminService;
        private readonly VotingSystemService _votingSystemService;
        private readonly PartyService _partyService;

        // Public field to store all elections loaded from the database
        public IEnumerable<ElectionDTO> allElections;
        // Identifier for the current admin user
        public Guid _adminId;

        // Constructor initializing services and database context
        public AdminDashboard(ElectionService electionService, VotingContext dbContext, AdminService adminService, VotingSystemService votingSystemService, PartyService partyService)
        {
            _electionService = electionService;
            _adminService = adminService;
            _votingSystemService = votingSystemService;
            _partyService = partyService;
            _dbContext = dbContext;
            InitializeComponent();
        }

        // Method to set up the initial layout of the DataGridView which lists elections
        public void InitializePage()
        {
            // Adding columns to the DataGridView
            electionDataGridView.Columns.Add("Name", "Name");
            electionDataGridView.Columns.Add("Start Date", "Start Date");
            electionDataGridView.Columns.Add("End Date", "End Date");
            electionDataGridView.Columns.Add("Voting System", "Voting System");
            electionDataGridView.Columns.Add("Winner", "Winner");
            electionDataGridView.Columns.Add("Id", "Id");

            // Populate the DataGridView with election data
            InitializeDataGridView();
        }

        // Helper method to populate the DataGridView with election data
        private void InitializeDataGridView()
        {
            // Clear existing rows
            electionDataGridView.Rows.Clear();

            // Load admin details and all voting systems
            var admin = _adminService.Load(_adminId);
            var votingSystem = _votingSystemService.LoadAll();
            var party = _partyService.LoadAll();
            // Set welcome message with the admin's username
            welcomeLabel.Text = $"Welcome {admin.Username}";
            // Load all elections and disable automatic column generation
            allElections = _electionService.LoadAll();
            electionDataGridView.AutoGenerateColumns = false;

            // Add rows to the DataGridView for each election
            foreach ( var election in allElections)
            {
                electionDataGridView.Rows.Add(election.Name, election.StartTime, election.EndTime, votingSystem.Single(x => x.ID == election.VoteSystem).Name, election.Winner != null ? party.Single(x => x.ID == election.Winner).Name : "", election.ID);
            }
        }

        // Set the current admin's ID
        public void SetIds(Guid adminId)
        {
            _adminId = adminId;
        }

        // Thread-safe method to change text of a label on the form
        public void ChangeLabelText(string text)
        {
            if (this.InvokeRequired)
            {
                // Thread-safe method to change text of a label on the form
                this.Invoke(new MethodInvoker(() => ChangeLabelText(text)));
            }
            else
            {
                // Update label text directly if on the UI thread
                this.label1.Text = text;
            }
        }

        // Event handler for verifying a voter
        private void verifyVoterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the Verify Voter page
            var pageOpen = (VerifyVoter)Program._provider.GetService(typeof(VerifyVoter));
            pageOpen.Show();
        }

        // Event handler for creating candidates
        private void createCandidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the Create Candidates page
            var pageOpen = (CreateCandidates)Program._provider.GetService(typeof(CreateCandidates));
            pageOpen.Show();
        }

        // Event handler for creating a new election
        private void createElectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the Create Election page
            var pageOpen = (CreateElection)Program._provider.GetService(typeof(CreateElection));
            pageOpen.Show();
        }

        // Event handler for creating a new voter
        private void createVoterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the Create Voter page
            var pageOpen = (CreateVoter)Program._provider.GetService(typeof(CreateVoter));
            pageOpen.Show();
        }

        // Event handler to log out the admin and close the dashboard
        private void logOutButton_Click(object sender, EventArgs e)
        {
            // Open the main form and close the admin dashboard
            Form1 form1 = new Form1(_dbContext);
            form1.Show();
            this.Close();
        }

        // Event handler for selecting an election to modify
        private void pickElectionButton_Click(object sender, EventArgs e)
        {
            if (electionDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = electionDataGridView.SelectedRows[0];
                var electionId = (Guid)selectedRow.Cells["Id"].Value;
                var saveElection = allElections.FirstOrDefault(x => x.ID == electionId);

                if (saveElection != null)
                {
                    // Open Modify Election page with selected election data
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

        // Event handler to refresh the DataGridView data
        private void refreshButton_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }
        
    }
}
