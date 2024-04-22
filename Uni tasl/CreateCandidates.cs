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
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class CreateCandidates : Form
    {
        // Private readonly fields for database context and services.
        private readonly VotingContext _dbContext;
        private readonly PartyService _partyService;
        private readonly RegionService _regionService;
        private readonly CandidateService _candidateService;

        // Constructor initializing the form and its dependencies.
        public CreateCandidates(VotingContext dbContext, PartyService partyService, RegionService regionService, CandidateService candidateService)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _partyService = partyService;
            _regionService = regionService;
            _candidateService = candidateService;
            InitializeRegionComboBox();
            InitializePartyComboBox();
        }

        // Method to populate the Region ComboBox with region names.
        private void InitializeRegionComboBox()
        {
            var regions = _regionService.LoadAll(); // Load all regions using the region service.
            foreach (var r in regions)
            {
                regionComboBox.Items.Add(r.Name); // Add each region's name to the combo box.
            }
        }

        // Method to populate the Party ComboBox with party names.
        private void InitializePartyComboBox()
        {
            var parties = _partyService.LoadAll(); // Load all parties using the party service.
            foreach (var p in parties)
            {
                partyComboBox.Items.Add(p.Name); // Add each party's name to the combo box.
            }
        }

        // Event handler for the submit button click.
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Create a new CandidateDTO object with details from the form.
            var candidateDTO = new CandidateDTO()
            {
                Name = nameTextBox.Text, // Set the candidate's name from the text box.
                RegionID = _regionService.GetRegion(regionComboBox.SelectedItem.ToString()).ID, // Set the region ID based on selected item in combo box.
                PartyID = _partyService.GetParty(partyComboBox.SelectedItem.ToString()).ID // Set the party ID based on selected item in combo box.
            };

            // Save the candidate using the candidate service and receive the saved candidate.
            var savedCandidate = _candidateService.Save(candidateDTO);
            // Check if the save operation was successful.
            if (savedCandidate != null)
            {
                MessageBox.Show("New candidate created successfully!", "Success", MessageBoxButtons.OK);
                nameTextBox.Clear(); // Clear the name text box.
                nameTextBox.Focus(); // Set focus back to the name text box for potential new entries.
            }
            else
            {
                // If the save operation failed, show an error message.
                MessageBox.Show("Failed to create a new candidate.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
