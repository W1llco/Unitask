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
using Uni_tasl;
using Unitask.DTOs;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;

namespace Uni_tasl
{
    public partial class ExternalVoterLogin : Form
    {
        //injecting voting context
        private readonly VotingContext _dbContext;
        private readonly VoteService _voteService;
        private readonly ElectionService _electionService;
        private readonly VoterService _voterService;

        public ExternalVoterLogin(VotingContext dbContext, VoterService voterService, VoteService voteService, ElectionService electionService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _voteService = voteService;
            _electionService = electionService;
            _voterService = voterService;
            PasswordTextBox.UseSystemPasswordChar = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var elections = _electionService.LoadAll();
            DateTime dateOfBirth = DobDateTimePicker.Value.Date;

            var x = _voterService.LoadAll();
            var voter = _voterService.ConfirmVoterLogin(new VoterDTO() {Name = UsernameTextBox.Text, Password = PasswordTextBox.Text, DateOfBirth = dateOfBirth, VerifcationCode = CodeTextBox.Text });

            if (voter != null )
            {
                var votes = _voteService.LoadAll().Where(x => x.VoterId == voter.ID);
                var existingVoteIds = votes.Select(x => x.ElectionId).ToList();
                var electionIds = elections.Select(x => x.ID).ToList();
                var electionsWithNoVotes = electionIds.Except(existingVoteIds).ToList();

                if (votes.Any())
                {
                    if (electionsWithNoVotes.Any())
                    {
                        foreach (var id in electionsWithNoVotes)
                        {
                            _voteService.Save(new VoteDTO() {ElectionId = id, VoterId = voter.ID});
                        }
                    }
                }
                else
                {
                    foreach (var id in electionsWithNoVotes)
                    {
                        _voteService.Save(new VoteDTO() { ElectionId = id, VoterId = voter.ID });
                    }

                }
                SelectElection selectElection = (SelectElection)Program._provider.GetService(typeof(SelectElection));
                selectElection.SetIds(voter.ID);
                selectElection.InitializePage();
                selectElection.Show();
                this.Hide();
            }
            else
            {
                // User not found, show error message
                MessageBox.Show("The username or password is wrong. Try again.");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                CodeTextBox.Clear();
                DobDateTimePicker.ResetText();
                UsernameTextBox.Focus();
            }
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(_dbContext);
            form1.Show();
            this.Close();
        }
    }
}
