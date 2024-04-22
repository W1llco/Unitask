using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class SelectElection : Form
    {
        // Private fields for the database context and services that manage elections and votes.
        private readonly VotingContext _dbContext;
        private readonly ElectionService _electionService;
        private readonly VoteService _voteService;
        public Guid voterId; // Public field to store the voter's ID.
        public Guid electionId; // Public field to store the selected election ID.

        // Constructor initializes the form with necessary services and database context.
        public SelectElection(VotingContext _dbContext, ElectionService electionService, VoteService voteService)
        {
            this._dbContext = _dbContext; // Storing the provided database context.
            _electionService = electionService; // Storing the provided election service.
            _voteService = voteService; // Storing the provided vote service.
            InitializeComponent(); // Initialize the form's components as defined in the designer file.

        }

        // Method to initialize the form when it's loaded or refreshed.
        public void InitializePage()
        {
            InitializeComboBox();// Populate the combo box with available elections.
        }

        // Method to set the voter ID when the form is initialized or updated.
        public void SetIds(Guid voterId)
        {
            this.voterId = voterId;
        }

        // Initializes the combo box with elections that the voter has not yet voted in.
        private void InitializeComboBox()
        {
            var allElections = _electionService.LoadAllActive();// Load all active elections.
            var usedVoted = _voteService.GetUsedVotes(voterId); // Get elections where the voter has already voted.
            // Filter out elections that the voter has voted in.
            var election = allElections.Where(x => !usedVoted.Contains(x.ID));

            if (!election.Any()) // Check if there are no available elections.
            {
                comboBox1.Visible = false; // Hide the combo box if no elections are available.
                Continuebutton.Visible = false; // Hide the continue button if no elections are available.
                comboBox1.Text = "No Elections"; // Display a message indicating no available elections.
            }
            else
            {
                List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
                keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select")); // Default selection.
                foreach (ElectionDTO c in election)
                {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name}"));  // Add elections to the list.
                }
                comboBox1.DataSource = new BindingSource(keyValuePairs, null); // Bind the list to the combo box.
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Register an event handler for selection change.
                comboBox1.DisplayMember = "Value"; // Display the election name.
                comboBox1.ValueMember = "Key"; // Use the election ID as the underlying value.
            }
        }

        // Event handler for when a new election is selected in the combo box.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is Guid)
            {
                electionId = (Guid)comboBox1.SelectedValue;// Store the selected election ID.
            }
        }

        // Event handler for the continue button click.
        private void Continuebutton_Click(object sender, EventArgs e)
        {
            if ((Guid)comboBox1.SelectedValue == Guid.Empty)
            {
                MessageBox.Show("Please select a election", "Error", MessageBoxButtons.OK);
            }
            else
            {
                VoterPage voterPage = (VoterPage)Program._provider.GetService(typeof(VoterPage)); // Get the VoterPage form.
                voterPage.SetIds(voterId, electionId); // Pass the voter and election IDs to the VoterPage.
                voterPage.InitializePage(); // Initialize the VoterPage.
                voterPage.Show(); // Show the VoterPage.
                this.Hide(); // Hide the current form.
            }
        }

        // Event handler for the logout button click.
        private void logOutButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(_dbContext);// Get the main form.
            form1.Show(); // Show the main form.
            this.Close(); // Close the current form.
        }
    }
}
