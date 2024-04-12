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

        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dbContext.Database.EnsureDeleted();
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

        

        private void InitializeComboBox()
        {
            
            var voter = _votersRepositories.Load(_userId);
            var regions = _regionRepositories.Load(voter.RegionID);
            var elections = _electionsRepositories.LoadAll();
            var candidates = _candidatesRepositories.LoadAll().Where(x => x.RegionID == voter.RegionID);
            var partys = _partysRepositories.LoadAll();
            DisplayName.Text = $"Hello {voter.Name} you are voting in {regions.Name}";
            dropdownVote.Text = _userId.ToString();
            foreach (var c in candidates)
            {
                dropdownVote.Items.Add($"{c.Name} ({partys.FirstOrDefault( x => x.ID == c.PartyID).Name})");
                //dropdownVote.Items.Add(new KeyValuePair($"{c.Name} ({partys.FirstOrDefault( x => x.ID == c.PartyID).Name})", c.ID));
            }

            dropdownVote.SelectedIndexChanged += dropdownVote_SelectedIndexChanged;
        }

        private void dropdownVote_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"You selected: {dropdownVote.SelectedItem}");
        }

        private void voteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
