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
using UniTask.data;
using UniTask.data.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class VerifyVoter : Form
    {
        private readonly VotingContext _dbContext;
        private readonly VotersRepositories _votersRepositories;

        public VerifyVoter(VotingContext dbContext, VotersRepositories votersRepositories)
        {
            
            _dbContext = dbContext;
            _votersRepositories = votersRepositories;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewVoters.Columns.Add("name", "Name");
            dataGridViewVoters.Columns.Add("isVerified", "Is Verified");
            dataGridViewVoters.Columns.Add("DateOfBirth", "DateOfBirth");
            dataGridViewVoters.Columns.Add("Email", "Email");
            dataGridViewVoters.Columns.Add("Verifcation Code", "Verifcation Code");


            dataGridViewVoters.AutoGenerateColumns = false; 
        }


        private void Search_Click(object sender, EventArgs e)
        {
            string name = NameBox.Text.Trim();
            var voters = _votersRepositories.FindByName(name);
            dataGridViewVoters.Rows.Clear();

            if (voters != null && voters.Any())
            {
                foreach (var voter in voters)
                {
                    dataGridViewVoters.Rows.Add(voter.Name, voter.IsVerified, voter.DateOfBirth, voter.Email, voter.VerifcationCode);
                }
            }
            else
            {
                MessageBox.Show("Voter not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewVoters.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewVoters.SelectedRows[0];
                string email = selectedRow.Cells["Email"].Value.ToString();
                var voters = _votersRepositories.FindByEmail(email); ;

                if (voters != null )
                {
                    var voter = voters.First();  
                    voter.IsVerified = VerifyedcheckBox.Checked;
                    _votersRepositories.Update(voter);
                    _dbContext.SaveChanges();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
