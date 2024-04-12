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
        public ExternalVoterLogin(VotingContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _votesRepositories = new VotesRepositories(_dbContext);
            _electionsRepositories = new ElectionsRepositories(_dbContext);
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //_dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _dbContext.Users.Load();
            _dbContext.Regions.Load();
            _dbContext.Admins.Load();
            _dbContext.Voters.Load();
            _dbContext.Votes.Load();
            _dbContext.Elections.Load();
            _dbContext.Partys.Load();
            _dbContext.Candidates.Load();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Login_Click(object sender, EventArgs e)
        {
            var elections = _electionsRepositories.LoadAll();
            DateTime dateOfBirth = DobDateTimePicker.Value.Date;
            
            var voter = _dbContext.Voters.FirstOrDefault(u => u.Name == UsernameTextBox.Text && u.Password == PasswordTextBox.Text && u.DateOfBirth == dateOfBirth && u.VerifcationCode == CodeTextBox.Text);

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
                new SelectElection(_dbContext, voter.UserID).Show();
            }
            else
            {
                // User not found, show error message
                MessageBox.Show("The username or password is wrong. Try again.");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                UsernameTextBox.Focus();
            }
        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
