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
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class VoterPage : Form
    {
        private readonly VotingContext _dbContext;
        private Guid _userId;
        private Guid _electionID;
        private readonly VotersRepositories _votersRepositories;
        private readonly RegionsRepositories _regionRepositories ;
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly CandidatesRepositories _candidatesRepositories;
        private readonly PartysRepositories _partysRepositories;

        public VoterPage(VotingContext _dbContext, Guid userID, Guid electionID)
        {
            this._dbContext = _dbContext;
            _userId = userID;
            _electionID = electionID;
            _votersRepositories = new VotersRepositories(_dbContext);
            _regionRepositories = new RegionsRepositories(_dbContext);
            _electionsRepositories = new ElectionsRepositories(_dbContext);
            _candidatesRepositories = new CandidatesRepositories(_dbContext);
            _partysRepositories = new PartysRepositories(_dbContext);
            InitializeComponent();
            InitializeComboBox();
        }


        private void InitializeComboBox()
        {
            var voter = _votersRepositories.Load(_userId);
            var regions = _regionRepositories.Load(voter.RegionID);
            var elections = _electionsRepositories.LoadAll();
            var candidates = _candidatesRepositories.LoadAll().Where(x => x.RegionID == voter.RegionID);
            var partys = _partysRepositories.LoadAll();
            DisplayName.Text = $"Hello {voter.Name} you are voting in {regions.Name}";
            dropdownVote.Text = "Click on this and choose a choice";
            foreach (var c in candidates)
            {
                dropdownVote.Items.Add($"{c.Name} ({partys.FirstOrDefault( x => x.ID == c.PartyID).Name})");
            }
        }

        private void voteButton_Click(object sender, EventArgs e)
        {
            string candidateName = dropdownVote.SelectedItem.ToString(); ; 
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to vote for " + candidateName + "?", "Vote Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // user clicked 'Yes'
                var selectedCandidate = _candidatesRepositories.LoadAll().FirstOrDefault(c => c.Name == candidateName);
                if (selectedCandidate != null)
                {
                    //selectedCandidate.VoteCount += 1;
                    _candidatesRepositories.Update(selectedCandidate);
                }
                MessageBox.Show("You have voted for " + candidateName + ".", "Vote Submitted", MessageBoxButtons.OK);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                // user clicked 'No', do nothing
            }
        }
    }
}
