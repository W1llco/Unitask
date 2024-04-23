using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uni_tasl.Helpers;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class VoterPage : Form
    {
        // Fields for database context and various services necessary for fetching and managing election data.
        private readonly VotingContext _dbContext;
        public Guid _voterId; // Stores the current voter's ID.
        public Guid _electionID; // Stores the current election's ID.
        private readonly RegionService _regionService; // Service for managing region-related data.
        private readonly CandidateService _candidateService; // Service for handling candidate-related operations.
        private readonly ElectionService _electionService; // Service for election-related queries.
        private readonly PartyService _partyService; // Service for handling political party data.
        private readonly VoterService _voterService; // Service for managing voter-specific information.
        public HelperFunctions helpersFunctions; // Utility class for common functionality across forms.

        // Sets the voter and election IDs for this session.
        public void SetIds(Guid voterId, Guid electionId)
        {
            _voterId = voterId;
            _electionID = electionId;
        }

        // Constructor initializes components and services.
        public VoterPage( VotingContext _dbContext, RegionService regionService, CandidateService candidateService, ElectionService electionService, PartyService partyService, VoterService voterService, HelperFunctions helperFunctions)
        {
            this._dbContext = _dbContext;
            _regionService = regionService;
            _candidateService = candidateService;
            _electionService = electionService;
            _partyService = partyService;
            _voterService = voterService;

            helpersFunctions =  helperFunctions;
            InitializeComponent();
        }

        // Initializes the form upon loading, preparing data relevant to the current voter and election.
        public void InitializePage()
        {
            InitializeComboBox(); // Initializes the dropdown list with candidates available for voting.
        }

        private void InitializeComboBox()
        {
            var voter = _voterService.Load(_voterId);// Load the voter's data.
            var regions = _regionService.Load(voter.RegionID); // Load the voter's region data.
            var elections = _electionService.LoadAll(); // Load the electionService
            var candidates = _candidateService.GetCandidatesForElectionByRegion(_electionID, voter.RegionID); // Get candidates for the election in the voter's region.
            DisplayName.Text = $"Hello {voter.Name} you are voting in {regions.Name}";
            dropdownVote.Text = "Click on this and choose a choice";// Set initial text for dropdown.

            // Populate the dropdown with candidate data using helper functions.
            helpersFunctions.GetCandidateValuesForDropdown(dropdownVote, candidates, true);
        }


        private void voteButton_Click(object sender, EventArgs e)
        {
            var partys = _partyService.LoadAll(); // Load all parties for candidate identification.
            var voter = _voterService.Load(_voterId); // Reload the voter's data.
            var selectedCandidate = _candidateService.Load((Guid)dropdownVote.SelectedValue);// Get the selected candidate's details.

            // Confirm the voter's choice and proceed with the vote if confirmed.
            if (selectedCandidate != null)
            {
                string candidateName = selectedCandidate.Name + " (" + partys.Single(x => x.ID == selectedCandidate.PartyID).Name + ")";
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to vote for " + candidateName + "?", "Vote Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    // Process the vote.
                    var x = _voterService.CastVote(_voterId, _electionID, selectedCandidate.ID);
                    if (x != null)
                    {
                        _candidateService.Update(selectedCandidate); // Update the candidate's record post-vote.
                        MessageBox.Show("You have voted for " + candidateName + ".", "Vote Submitted", MessageBoxButtons.OK);
                        voter.IsVerified = false; // Update voter's status post-vote.
                        _voterService.Update(voter);
                        Form1 form1 = new Form1(_dbContext); // Return to the main form.
                        form1.Show();
                        this.Close(); // Close the current form.
                    }
                    else
                    {
                        MessageBox.Show("You are not registered to vote", "Voting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    // user clicked 'No', do nothing
                }
            }
        }

        // Logs out the user and returns to the main application form.
        private void logOutButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(_dbContext);
            form1.Show();
            this.Close();
        }
    }
}
