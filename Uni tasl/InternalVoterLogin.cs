using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Uni_tasl
{
    public partial class InternalVoterLogin : Form
    {
        // Private fields to store injected dependencies for database context and service layers.
        private readonly VotingContext _dbContext;
        private readonly VoteService _voteService;
        private readonly ElectionService _electionService;
        private readonly VoterService _voterService;

        // Constructor initializes the form with necessary services and database context.
        public InternalVoterLogin(VotingContext dbContext, VoterService voterService, VoteService voteService, ElectionService electionService)
        {
            InitializeComponent();  // Initialize the form's UI components as defined in the designer file.
            _dbContext = dbContext;  // Storing the provided database context.
            _voteService = voteService;  // Storing the provided vote service.
            _electionService = electionService;  // Storing the provided election service.
            _voterService = voterService;  // Storing the provided voter service.
        }

        // Event handler for the login button click.
        private void Login_Click(object sender, EventArgs e)
        {
            // Load all elections and all voters to validate the login.
            var elections = _electionService.LoadAll();
            var x = _voterService.LoadAll();
            // Load all elections and all voters to validate the login.
            var voter = _voterService.ConfirmInternalVoterLogin(new VoterDTO() { Name = UsernameTextBox.Text, VerifcationCode = CodeTextBox.Text, IsVerified = true });

            if (voter != null)
            {
                // Voter is successfully validated.
                // Load all votes associated with the validated voter.
                var votes = _voteService.LoadAll().Where(x => x.VoterId == voter.ID);
                var existingVoteIds = votes.Select(x => x.ElectionId).ToList();
                var electionIds = elections.Select(x => x.ID).ToList();
                // Determine elections without any votes from this voter.
                var electionsWithNoVotes = electionIds.Except(existingVoteIds).ToList();

                if (votes.Any())
                {
                    if (electionsWithNoVotes.Any())
                    {
                        foreach (var id in electionsWithNoVotes)
                        {
                            _voteService.Save(new VoteDTO() { ElectionId = id, VoterId = voter.ID });
                        }
                    }
                }
                else
                {
                    // Check if any new votes need to be recorded.
                    foreach (var id in electionsWithNoVotes)
                    {
                        _voteService.Save(new VoteDTO() { ElectionId = id, VoterId = voter.ID });
                    }
                }
                // Open the election selection form and pass along the voter's ID.
                SelectElection selectElection = (SelectElection)Program._provider.GetService(typeof(SelectElection));
                selectElection.SetIds(voter.ID);
                selectElection.InitializePage();
                selectElection.Show();
                this.Hide();// Hides the login form after successful navigation.
            }
            else
            {
                // Login failed, notify the user.
                MessageBox.Show("The username or password is wrong. Try again.");
                UsernameTextBox.Clear();
                CodeTextBox.Clear();
                UsernameTextBox.Focus();// Focuses back on the Username text box for re-entry.
            }
        }

        // Event handler for the main menu button click.
        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            // Navigates back to the main menu form.
            Form1 form1 = new Form1(_dbContext);
            form1.Show();
            this.Close();  // Closes the current login form.
        }
    }
}

