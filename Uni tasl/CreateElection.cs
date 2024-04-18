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
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Uni_tasl
{
    public partial class CreateElection : Form
    {
        private readonly VotingContext _dbContext;
        private readonly CandidatesRepositories _candidatesRepositories;
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly PartysRepositories _partysRepositories;
        private readonly RegionsRepositories _regionsRepositories;
        private readonly VotingSystemsRepositories _votingSystemsRepositories;
        public HelperFunctions helpersFunctions;

        public CreateElection( VotingContext dbContext, CandidatesRepositories candidatesRepositories, ElectionsRepositories electionsRepositories, PartysRepositories partysRepositories, RegionsRepositories regionsRepositories, VotingSystemsRepositories votingSystemsRepositories)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _candidatesRepositories = candidatesRepositories;
            _electionsRepositories = electionsRepositories;
            _partysRepositories = partysRepositories;
            _regionsRepositories = regionsRepositories;
            _votingSystemsRepositories = votingSystemsRepositories;
            helpersFunctions = new HelperFunctions(_partysRepositories);
            InitializeComboBoxAll();
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
        }

        private void InitializeComboBoxAll()
        {
            var partys = _partysRepositories.LoadAll();
            var regions = _regionsRepositories.LoadAll();
            var englandConservative = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "England").ID, partys.Single(x => x.Name == "Conservative").ID);
            var englandLabour = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "England").ID, partys.Single(x => x.Name == "Labour").ID);
            var scotlandConservative = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "Scotland").ID, partys.Single(x => x.Name == "Conservative").ID);
            var scotlandLabour = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "Scotland").ID, partys.Single(x => x.Name == "Labour").ID);
            var walesConservative = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "Wales").ID, partys.Single(x => x.Name == "Conservative").ID);
            var walesLabour = _candidatesRepositories.GetCandidates(regions.Single(x => x.Name == "Wales").ID, partys.Single(x => x.Name == "Labour").ID);
            var votingsystem = _votingSystemsRepositories.LoadAll();

            helpersFunctions.GetCandidateValuesForDropdown(candiateEnglandConservativeComboBox, englandConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateEnglandLabourComboBox, englandLabour, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateScotlandConservativeComboBox, scotlandConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateScotlandLabourComboBox, scotlandLabour, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateWalesConservativeComboBox, walesConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateWalesLabourComboBox, walesLabour, false);
            helpersFunctions.GetVotingSystemValuesForDropdown(votingSystemComboBox, votingsystem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((Guid)candiateEnglandConservativeComboBox.SelectedValue == Guid.Empty||
                (Guid)candiateEnglandLabourComboBox.SelectedValue == Guid.Empty||
                (Guid)candiateScotlandConservativeComboBox.SelectedValue == Guid.Empty||
                (Guid)candiateScotlandLabourComboBox.SelectedValue == Guid.Empty||
                (Guid)candiateWalesLabourComboBox.SelectedValue == Guid.Empty||
                (Guid)candiateWalesConservativeComboBox.SelectedValue == Guid.Empty
                )
            {
                MessageBox.Show("Please select for all candidates", "Error", MessageBoxButtons.OK);
            }
            else if((Guid)votingSystemComboBox.SelectedValue == Guid.Empty)
            {
                MessageBox.Show("Please select a voting system", "Error", MessageBoxButtons.OK);
            }
            else
            {
                var entity = new Election()
                {
                    Name = nameOfElectionTextBox.Text,
                    StartTime = startDateTimePicker.Value,
                    EndTime = endDateTimePicker.Value,
                    VoteSystem = (Guid)votingSystemComboBox.SelectedValue
                };
                _electionsRepositories.Save(entity);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateEnglandConservativeComboBox.SelectedValue);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateEnglandLabourComboBox.SelectedValue);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateScotlandConservativeComboBox.SelectedValue);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateScotlandLabourComboBox.SelectedValue);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateWalesConservativeComboBox.SelectedValue);
                _electionsRepositories.SaveElectionCandidate(entity.ID, (Guid)candiateWalesLabourComboBox.SelectedValue);

                MessageBox.Show("New Election Made", "Created", MessageBoxButtons.OK);
            }
            
        }
    }
}
