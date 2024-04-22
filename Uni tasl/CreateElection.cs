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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Uni_tasl
{
    public partial class CreateElection : Form
    {
        // Fields for database context and various services that are used to interact with underlying data.
        private readonly VotingContext _dbContext;
        private readonly CandidateService _candidateService;
        private readonly ElectionService _electionService;
        private readonly PartyService _partyService;
        private readonly RegionService _regionService;
        private readonly VotingSystemService _votingSystemService;

        // Helper class that contains utility functions for UI operations.
        public HelperFunctions helpersFunctions;

        // Constructor initializes services, context, and form components.
        public CreateElection( VotingContext dbContext, CandidateService candidateService, ElectionService electionService, PartyService partyService, RegionService regionService, VotingSystemService votingSystemService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _candidateService = candidateService;
            _electionService = electionService;
            _partyService = partyService;
            _regionService = regionService;
            _votingSystemService = votingSystemService;
            helpersFunctions = new HelperFunctions(_partyService);// Initialize helper functions with party service.
            InitializeComboBoxAll();

            // Set custom date/time format for DateTimePickers.
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
        }

        // Initializes all ComboBoxes by loading data from services and setting them up.
        private void InitializeComboBoxAll()
        {
            // Load parties, regions, and retrieve specific candidates based on region and party.
            var partys = _partyService.LoadAll();
            var regions = _regionService.LoadAll();
            var englandConservative = _candidateService.GetCandidates(regions.Single(x => x.Name == "England").ID, partys.Single(x => x.Name == "Conservative").ID);
            var englandLabour = _candidateService.GetCandidates(regions.Single(x => x.Name == "England").ID, partys.Single(x => x.Name == "Labour").ID);
            var scotlandConservative = _candidateService.GetCandidates(regions.Single(x => x.Name == "Scotland").ID, partys.Single(x => x.Name == "Conservative").ID);
            var scotlandLabour = _candidateService.GetCandidates(regions.Single(x => x.Name == "Scotland").ID, partys.Single(x => x.Name == "Labour").ID);
            var walesConservative = _candidateService.GetCandidates(regions.Single(x => x.Name == "Wales").ID, partys.Single(x => x.Name == "Conservative").ID);
            var walesLabour = _candidateService.GetCandidates(regions.Single(x => x.Name == "Wales").ID, partys.Single(x => x.Name == "Labour").ID);
            var votingsystem = _votingSystemService.LoadAll();

            // Populate ComboBoxes with candidates and voting systems without displaying party names.
            helpersFunctions.GetCandidateValuesForDropdown(candiateEnglandConservativeComboBox, englandConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateEnglandLabourComboBox, englandLabour, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateScotlandConservativeComboBox, scotlandConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateScotlandLabourComboBox, scotlandLabour, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateWalesConservativeComboBox, walesConservative, false);
            helpersFunctions.GetCandidateValuesForDropdown(candiateWalesLabourComboBox, walesLabour, false);
            helpersFunctions.GetVotingSystemValuesForDropdown(votingSystemComboBox, votingsystem);
        }

        // Handler for the form's submit button to create a new election.
        private void button1_Click(object sender, EventArgs e)
        {
            // Check that all candidate selections and voting system are valid before proceeding.
            if ((Guid)candiateEnglandConservativeComboBox.SelectedValue == Guid.Empty ||
                (Guid)candiateEnglandLabourComboBox.SelectedValue == Guid.Empty ||
                (Guid)candiateScotlandConservativeComboBox.SelectedValue == Guid.Empty ||
                (Guid)candiateScotlandLabourComboBox.SelectedValue == Guid.Empty ||
                (Guid)candiateWalesLabourComboBox.SelectedValue == Guid.Empty ||
                (Guid)candiateWalesConservativeComboBox.SelectedValue == Guid.Empty
                )
            {
                MessageBox.Show("Please make sure all regions have candidates selected", "Error", MessageBoxButtons.OK);
            }
            else if ((Guid)votingSystemComboBox.SelectedValue == Guid.Empty)
            {
                MessageBox.Show("Please select a voting system to use", "Error", MessageBoxButtons.OK);
            }
            else if (startDateTimePicker.Value <= DateTime.Now)
            {
                MessageBox.Show("The start date and time must be in the future.", "Date Error", MessageBoxButtons.OK);
            }
            // Check if the end date/time is in the past
            else if (endDateTimePicker.Value <= DateTime.Now)
            {
                MessageBox.Show("The end date and time must be in the future.", "Date Error", MessageBoxButtons.OK);
            }
            else
            {
                // Create and save a new election entity with candidates.
                var entity = new Election()
                {
                    Name = nameOfElectionTextBox.Text,
                    StartTime = startDateTimePicker.Value,
                    EndTime = endDateTimePicker.Value,
                    VoteSystem = (Guid)votingSystemComboBox.SelectedValue
                };
                _electionService.Save(entity);// Save the election.
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateEnglandConservativeComboBox.SelectedValue);// Assign selected candidates to the election.
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateEnglandLabourComboBox.SelectedValue);
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateScotlandConservativeComboBox.SelectedValue);
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateScotlandLabourComboBox.SelectedValue);
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateWalesConservativeComboBox.SelectedValue);
                _electionService.SaveElectionCandidate(entity.ID, (Guid)candiateWalesLabourComboBox.SelectedValue);

                MessageBox.Show("New Election Made", "Created", MessageBoxButtons.OK);
            }
            
        }
    }
}
