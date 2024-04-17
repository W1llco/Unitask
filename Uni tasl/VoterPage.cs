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
        private readonly VotingContext _dbContext;
        public Guid _voterId;
        public Guid _electionID;
        private readonly VotersRepositories _votersRepositories;
        private readonly RegionsRepositories _regionRepositories ;
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly CandidatesRepositories _candidatesRepositories;
        private readonly PartysRepositories _partysRepositories;
        private readonly VoterService _voterService;
        public HelperFunctions helpersFunctions;


        public void SetIds(Guid voterId, Guid electionId)
        {
            _voterId = voterId;
            _electionID = electionId;
        }

        public VoterPage( VotingContext _dbContext,VotersRepositories votersRepositories, RegionsRepositories regionsRepositories, ElectionsRepositories electionsRepositories, CandidatesRepositories candidatesRepositories, PartysRepositories partysRepositories, VoterService voterService, HelperFunctions helperFunctions)
        {
            this._dbContext = _dbContext;
            _votersRepositories = votersRepositories;
            _regionRepositories = regionsRepositories;
            _electionsRepositories = electionsRepositories;
            _candidatesRepositories = candidatesRepositories;
            _partysRepositories = partysRepositories;
            _voterService = voterService;
            helpersFunctions =  helperFunctions;
            InitializeComponent();
        }

        public void InitializePage()
        {
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            var voter = _votersRepositories.Load(_voterId);
            var regions = _regionRepositories.Load(voter.RegionID);
            var elections = _electionsRepositories.LoadAll();
            var candidates = _candidatesRepositories.GetCandidatesForElectionByRegion(_electionID, voter.RegionID);
            var partys = _partysRepositories.LoadAll();
            DisplayName.Text = $"Hello {voter.Name} you are voting in {regions.Name}";
            dropdownVote.Text = "Click on this and choose a choice";

            helpersFunctions.GetCandidateValuesForDropdown(dropdownVote, candidates, true);

            //foreach (var c in candidates)
            //{
            //    dropdownVote.Items.Add($"{c.Name} ({partys.FirstOrDefault( x => x.ID == c.PartyID).Name})");
            //}
        }


        private void voteButton_Click(object sender, EventArgs e)
        {
            string candidateName = dropdownVote.SelectedItem.ToString(); ; 
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to vote for " + candidateName + "?", "Vote Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // user clicked 'Yes'
                var selectedCandidate = _candidatesRepositories.Load((Guid) dropdownVote.SelectedValue);
                if (selectedCandidate != null)
                {
                    var x = _voterService.CastVote(_voterId, _electionID, selectedCandidate.ID);
                    if (x != null)
                    {
                        _candidatesRepositories.Update(selectedCandidate);
                    }
                    else
                    {
                        MessageBox.Show("You are not registered to vote", "Voting Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
