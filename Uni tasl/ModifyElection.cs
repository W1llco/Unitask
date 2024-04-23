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
using UniTask.data.Repositories;
using UniTask.entites;
using UniTask.Entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class ModifyElection : Form
    {
        public ElectionDTO _election; // Holds the current election data being modified.
        private readonly VotingSystemService _votingSystemService; // Service for handling voting system data.
        private readonly ElectionService _electionService; // Service for managing elections.
        private readonly CandidateService _candidateService; // Service for accessing candidate-related data.
        private readonly RegionService _regionService; // Service for region data management.
        private readonly PartyService _partyService; // Service for handling political party information.

        // Constructor to initialize services and setup form components.
        public ModifyElection(VotingSystemService votingSystemService, ElectionService electionService, CandidateService candidateService, RegionService regionService, PartyService partyService)
        {
            _votingSystemService = votingSystemService;
            _electionService = electionService;
            _candidateService = candidateService;
            _regionService = regionService;
            _partyService = partyService;
            InitializeComponent();
            // Set custom date and time formats for the DateTimePicker controls.
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
        }

        // Initializes form data when called, loading election details and candidate information.
        public void InitializePage()
        {
            var votingSystems = _votingSystemService.LoadAll();
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            foreach (var c in votingSystems)
            {
                keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name}"));
            }
            votingSystemComboBox.DataSource = new BindingSource(keyValuePairs, null);
            votingSystemComboBox.DisplayMember = "Value";
            votingSystemComboBox.ValueMember = "Key";
            votingSystemComboBox.Text = keyValuePairs.Single(x => x.Key == _election.VoteSystem).Value;
            // Set the form fields to the existing values from the election data.
            electionName.Text = _election.Name;
            startDateTimePicker.Value = _election.StartTime;
            endDateTimePicker.Value = _election.EndTime;
            votingSystemComboBox.SelectedItem = keyValuePairs.Where(x => x.Key == _election.VoteSystem);
            winnerLabel.Text = _election.Winner?.ToString();
            // Disable modification until explicitly allowed.
            startDateTimePicker.Enabled = false;
            endDateTimePicker.Enabled = false;
            votingSystemComboBox.Enabled = false;
            // Load and display candidates associated with this election.
            var candidateXElection = _candidateService.GetAllCandidatesForElection(_election.ID);
            var electionData = _candidateService.CandidateXElectionViewModels(candidateXElection).OrderBy(x => x.Candidate.RegionID).ThenBy(n => n.Candidate.PartyID);
            var regions = _regionService.LoadAll();
            var partys = _partyService.LoadAll();
            electionDataGridView.Columns.Add("Candidate Name", "Candidate Name");
            electionDataGridView.Columns.Add("Region", "Region");
            electionDataGridView.Columns.Add("Party","Party");
            electionDataGridView.Columns.Add("Vote Count","Vote Count");

            foreach (var c in electionData)
            {
                electionDataGridView.Rows.Add(c.Candidate.Name, regions.Single(x => x.ID == c.Candidate.RegionID).Name, partys.Single(x => x.ID == c.Candidate.PartyID).Name, c.CandidateXElection.VoteCount);
            }
        }

        // Setter for passing election details to the form
        public void SetElection(ElectionDTO electionDTO)
        {
            _election = electionDTO;
        }

        // Click event handler for modifying or saving changes to the election.
        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (modifyButton.Text == "Modify")
            {
                // Enable modification of election details.
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
                votingSystemComboBox.Enabled = true;
                countElectionButton.Enabled = false;
                startElection.Enabled = false;
                endElection.Enabled = false;                
                modifyButton.Text = "Save";
            }
            else
            {
                // Save the modified details back to the database.
                _election.StartTime = startDateTimePicker.Value;
                _election.EndTime = endDateTimePicker.Value;
                _election.VoteSystem = (Guid)votingSystemComboBox.SelectedValue;
                _electionService.Update(_election);

                // Disable modification after saving.
                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
                votingSystemComboBox.Enabled = false;
                countElectionButton.Enabled = true;
                startElection.Enabled = true;
                endElection.Enabled = true;
                modifyButton.Text = "Modify";
            }
        }

        // Starts the election immediately, setting the start time to now.
        private void startElection_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to start the election?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                startDateTimePicker.Value = DateTime.Now;
                _electionService.Update(_election);
            }
        }

        // Ends the election immediately, setting the end time to now.
        private void endElection_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to end the election?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                endDateTimePicker.Value = DateTime.Now;
                _electionService.Update(_election);
            }
        }

        // Triggers the count of votes for an election and displays the results.
        private void countElectionButton_Click(object sender, EventArgs e)
        {
            Guid electionId = _election.ID;
            Guid votingSystemId = _election.VoteSystem;
            PartyDTO? result = _electionService.CountElection(electionId, votingSystemId);
            _election.Winner = result?.ID;
            _electionService.Update(_election);
            MessageBox.Show(result != null? result.Name: "Draw");
        }
    }
}
