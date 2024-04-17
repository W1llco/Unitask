using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
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
    public partial class SelectElection : Form
    {
        private readonly VotingContext _dbContext;
        private readonly ElectionsRepositories _electionsRepositories;
        public Guid voterId;
        public Guid electionId;

        public SelectElection(VotingContext _dbContext, ElectionsRepositories electionsRepositories)
        {
            this._dbContext = _dbContext;
            _electionsRepositories = electionsRepositories;
            InitializeComponent();
            InitializeComboBox();
        }

        public void SetIds(Guid voterId)
        {
            this.voterId = voterId;
        }

        private void InitializeComboBox()
        {
            var election = _electionsRepositories.LoadAllActive();
            if (!election.Any())
            {
                comboBox1.Visible = false;
                Continuebutton.Visible = false;
                comboBox1.Text = "No Elections";
            }
            else
            {

                List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
                keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select"));
                foreach (Election c in election)
                {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name}"));
                }
                comboBox1.DataSource = new BindingSource(keyValuePairs, null);
                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is Guid)
            {
                electionId = (Guid)comboBox1.SelectedValue;
            }
        }

        private void Continuebutton_Click(object sender, EventArgs e)
        {
            if ((Guid)comboBox1.SelectedValue == Guid.Empty)
            {
                MessageBox.Show("Please select a election", "Error", MessageBoxButtons.OK);
            }
            else
            {

                VoterPage voterPage = (VoterPage)Program._provider.GetService(typeof(VoterPage));
                voterPage.SetIds(voterId, electionId);
                voterPage.InitializePage();
                voterPage.Show();
                this.Hide();
            }
        }
    }
}
