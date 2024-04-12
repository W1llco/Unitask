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

namespace Uni_tasl
{
    public partial class SelectElection : Form
    {
        private readonly VotingContext _dbContext;
        private Guid _userId;
        private readonly ElectionsRepositories _electionsRepositories;
        public SelectElection(VotingContext _dbContext, Guid userID)
        {
            this._dbContext = _dbContext;
            _userId = userID;
            _electionsRepositories = new ElectionsRepositories(_dbContext);
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
            var election = _electionsRepositories.LoadAll();
            if (!election.Any()) 
            { 
                comboBox1.Visible = false; 
                Continuebutton.Visible = false;
                comboBox1.Text = "No Elections";
            }
            else 
            {
                comboBox1.Text = "Please select your Election";
                foreach (var e in election)
                {
                    comboBox1.Items.Add($"{e.Name}");
                    //dropdownVote.Items.Add(new KeyValuePair($"{c.Name} ({partys.FirstOrDefault( x => x.ID == c.PartyID).Name})", c.ID));
                }

                comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Continuebutton_Click(object sender, EventArgs e)
        {          
            new VoterPage(_dbContext, _userId, _electionsRepositories.GetByName(comboBox1.SelectedItem.ToString()).ID).Show();
        }
    }
}
