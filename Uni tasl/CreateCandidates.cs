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
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class CreateCandidates : Form
    {
        private readonly VotingContext _dbContext;
        private readonly PartysRepositories _partysRepositories;
        private readonly RegionsRepositories _regionsRepositories;
        private readonly CandidatesRepositories _candidatesRepositories;
        public CreateCandidates(VotingContext dbContext, PartysRepositories partysRepositories, RegionsRepositories regionsRepositories, CandidatesRepositories candidatesRepositories)
        {

            InitializeComponent();
            _dbContext = dbContext;
            _partysRepositories = partysRepositories;
            _regionsRepositories = regionsRepositories;
            _candidatesRepositories = candidatesRepositories;
            InitializeRegionComboBox();
            InitializePartyComboBox();
        }

        private void InitializeRegionComboBox()
        {
            var region = _regionsRepositories.LoadAll();
            foreach (var r in region)
            {
                regionComboBox.Items.Add($"{r.Name}");
            }

        }

        private void InitializePartyComboBox()
        {
            var party = _partysRepositories.LoadAll();
            foreach (var p in party)
            {
                partyComboBox.Items.Add($"{p.Name}");
            }

        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            var entity = new Candidate()
            {
                Name = nameTextBox.Text,
                RegionID = _regionsRepositories.GetRegion(regionComboBox.SelectedItem.ToString()).ID,
                PartyID = _partysRepositories.GetParty(partyComboBox.SelectedItem.ToString()).ID
            };
            _candidatesRepositories.Save(entity);
            MessageBox.Show("New person made", "Yay", MessageBoxButtons.OK);
        }
    }
}
