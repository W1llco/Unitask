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
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;

namespace Uni_tasl
{
    public partial class ExternalVoterLogin : Form
    {
        //injecting voting context
        private readonly VotingContext _dbContext;
        private readonly VotesRepositories _votesRepositories;
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly VotersRepositories _votersRepositories;
        public ExternalVoterLogin(VotingContext dbContext, VotersRepositories votersRepositories, VotesRepositories votesRepositories, ElectionsRepositories electionsRepositories)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _votesRepositories = votesRepositories;
            _electionsRepositories = electionsRepositories;
            _votersRepositories = votersRepositories;
            
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            var elections = _electionsRepositories.LoadAll();
            DateTime dateOfBirth = DobDateTimePicker.Value.Date;

            var x = _votersRepositories.LoadAll();
            var voter = _votersRepositories.ConfirmVoterLogin(new Voter() {Name = UsernameTextBox.Text, Password = PasswordTextBox.Text, DateOfBirth = dateOfBirth, VerifcationCode = CodeTextBox.Text });

            if (voter != null )
            {
                var votes = _votesRepositories.LoadAll().Where(x => x.VoterId == voter.ID);
                var existingVoteIds = votes.Select(x => x.ElectionId).ToList();
                var electionIds = elections.Select(x => x.ID).ToList();
                var electionsWithNoVotes = electionIds.Except(existingVoteIds).ToList();

                if (votes.Any())
                {
                    if (electionsWithNoVotes.Any())
                    {
                        foreach (var id in electionsWithNoVotes)
                        {
                            _votesRepositories.Save(new Vote() {ElectionId = id, VoterId = voter.ID});
                        }
                    }
                }
                else
                {
                    foreach (var id in electionsWithNoVotes)
                    {
                        _votesRepositories.Save(new Vote() { ElectionId = id, VoterId = voter.ID });
                    }

                }
                SelectElection selectElection = (SelectElection)Program._provider.GetService(typeof(SelectElection));
                selectElection.SetIds(voter.ID);
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

        private void UsernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
