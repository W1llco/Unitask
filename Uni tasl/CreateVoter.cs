using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniTask.data.Repositories;
using UniTask.data;
using UniTask.entites;
using Unitask.Infrastructure.Services;
using Unitask.DTOs;

namespace Uni_tasl
{
    public partial class CreateVoter : Form
    {
        // Fields for the database context and services necessary for region and voter operations.
        private readonly VotingContext _dbContext;
        private readonly RegionService _regionService;
        private readonly VoterService _voterService;

        // Constructor initializing the form, database context, and services.
        public CreateVoter(VotingContext dbContext, RegionService regionService, VoterService voterService)
        {
            InitializeComponent(); // Initialize the form's components from the designer.
            _dbContext = dbContext; // Store the provided database context.
            _regionService = regionService; // Store the provided region service.
            _voterService = voterService; // Store the provided voter service.

            InitializeRegionComboBox(); // Populate the region dropdown.
            InitializeFormComponents(); // Initialize other UI components like DateTime pickers.
        }

        // Populates the region ComboBox with region names from the database.
        private void InitializeRegionComboBox()
        {
            var regions = _regionService.LoadAll(); // Load all regions using the region service.
            foreach (var region in regions)
            {
                regionComboBox.Items.Add(region.Name); // Add each region's name to the combo box.
            }
        }

        // Initializes other form components, such as date pickers and potentially other UI elements.
        private void InitializeFormComponents()
        {
            dobDateTimePicker.Format = DateTimePickerFormat.Custom; // Set the format of the date picker.
            dobDateTimePicker.CustomFormat = "yyyy-MM-dd"; // Custom format for the date display.
        }

        // Handler for the 'Add' button click event to register a new voter.
        private void addButton4_Click(object sender, EventArgs e)
        {
            // Validate input fields to ensure they are not empty.
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;// Exit the event handler if validation fails.
            }

            // Create a new VoterDTO object with information from the form.
            var voter = new VoterDTO()
            {
                Name = nameTextBox.Text.Trim(),
                RegionID = _regionService.GetRegion(regionComboBox.SelectedItem.ToString()).ID, // Retrieve the selected region's ID.
                DateOfBirth = dobDateTimePicker.Value, // Set the date of birth from the date picker.
                Email = emailTextBox.Text.Trim() // Set the email, trimmed of any leading/trailing whitespace.
            };
            _voterService.Save(voter); // Save the new voter using the voter service.
            MessageBox.Show("Voter registered successfully!", "Success", MessageBoxButtons.OK);

            // Clear the form fields and reset selections after successful registration.
            nameTextBox.Clear();
            emailTextBox.Clear();
            regionComboBox.SelectedIndex = -1; // Reset the region combo box selection.
            dobDateTimePicker.Value = DateTime.Now; // Reset the date picker to the current date.
            nameTextBox.Focus(); // Set focus back to the name text box for new entries.
        }
    }
}
