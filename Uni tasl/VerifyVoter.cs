using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class VerifyVoter : Form
    {
        // Fields for the database context and the voter service, injected via the constructor.
        private readonly VotingContext _dbContext;
        private readonly VoterService _voterService;

        // Constructor initializing the database context, voter service, and form components.
        public VerifyVoter(VotingContext dbContext, VoterService voterService)
        {
            _dbContext = dbContext;// Storing the database context for later use.
            _voterService = voterService;  // Storing the voter service for managing voter data.
            InitializeComponent();  // Initialize form components defined in the designer.
            InitializeDataGridView();  // Setup the data grid view when the form is created.
        }

        // Initializes the DataGridView with specific columns to display voter information.
        private void InitializeDataGridView()
        {
            // Add columns for voter details to the DataGridView.
            dataGridViewVoters.Columns.Add("name", "Name");
            dataGridViewVoters.Columns.Add("isVerified", "Is Verified");
            dataGridViewVoters.Columns.Add("DateOfBirth", "DateOfBirth");
            dataGridViewVoters.Columns.Add("Email", "Email");
            dataGridViewVoters.Columns.Add("Verifcation Code", "Verifcation Code");
            dataGridViewVoters.AutoGenerateColumns = false; // Prevents automatic generation of columns to use custom setup.
        }

        // Event handler for the Search button click.
        private void Search_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text.Trim();  // Retrieve and trim the text from the name search box.
            var voters = _voterService.FindByName(name);  // Search for voters by name using the voter service.
            dataGridViewVoters.Rows.Clear();  // Clear existing rows before populating new data.

            if (voters != null && voters.Any())
            {
                // Populate the DataGridView with voter details if any are found.
                foreach (var voter in voters)
                {
                    dataGridViewVoters.Rows.Add(voter.Name, voter.IsVerified, voter.DateOfBirth, voter.Email, voter.VerifcationCode);
                }
            }
            else
            {
                // Display a message box if no voters are found.
                MessageBox.Show("Voter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ensure that a row is selected in the DataGridView.
            if (dataGridViewVoters.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewVoters.SelectedRows[0];
                string email = selectedRow.Cells["Email"].Value.ToString();// Extract the email from the selected row.
                var voters = _voterService.FindByEmail(email);  // Find voters by email.

                if (voters != null )
                {
                    var voter = voters.First();  // Assume the first match is the correct one (based on unique email).
                    voter.IsVerified = VerifyedcheckBox.Checked;  // Set the verification status from the checkbox.
                    _voterService.Update(voter);  // Update the voter's record.
                    _dbContext.SaveChanges();  // Commit changes to the database.
                    MessageBox.Show($"Voter: {voter.Name} - ID Verified: {voter.IsVerified}", "Submission Result", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Voter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No row selected", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
