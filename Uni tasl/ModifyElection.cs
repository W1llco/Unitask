﻿using System;
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
        public Election _election;
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly VotingSystemsRepositories _votingSystemsRepositories;
        private readonly ElectionService _electionService;
        private readonly CandidateService _candidateService;
        private readonly RegionService _regionService;
        private readonly PartyService _partyService;
        public ModifyElection(ElectionsRepositories electionsRepositories, VotingSystemsRepositories votingSystemsRepositories, ElectionService electionService, CandidateService candidateService, RegionService regionService, PartyService partyService)
        {
            _electionsRepositories = electionsRepositories;
            _votingSystemsRepositories = votingSystemsRepositories;
            _electionService = electionService;
            _candidateService = candidateService;
            _regionService = regionService;
            _partyService = partyService;
            InitializeComponent();
            startDateTimePicker.Format = DateTimePickerFormat.Custom;
            startDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
            endDateTimePicker.Format = DateTimePickerFormat.Custom;
            endDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm";
        }
        public void InitializePage()
        {
            var votingSystems = _votingSystemsRepositories.LoadAll();
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            foreach (var c in votingSystems)
            {
                keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name}"));
            }
            votingSystemComboBox.DataSource = new BindingSource(keyValuePairs, null);
            votingSystemComboBox.DisplayMember = "Value";
            votingSystemComboBox.ValueMember = "Key";

            electionName.Text = _election.Name;
            startDateTimePicker.Value = _election.StartTime;
            endDateTimePicker.Value = _election.EndTime;
            votingSystemComboBox.SelectedItem = keyValuePairs.Where(x => x.Key == _election.VoteSystem);
            winnerLabel.Text = _election.Winner?.ToString();
            startDateTimePicker.Enabled = false;
            endDateTimePicker.Enabled = false;
            votingSystemComboBox.Enabled = false;

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
        public void SetElection(Election election)
        {
            _election = election;
        }

        

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (modifyButton.Text == "Modify")
            {
                startDateTimePicker.Enabled = true;
                endDateTimePicker.Enabled = true;
                votingSystemComboBox.Enabled = true;
                modifyButton.Text = "Save";
            }
            else
            {
                _election.StartTime = startDateTimePicker.Value;
                _election.EndTime = endDateTimePicker.Value;
                _election.VoteSystem = (Guid)votingSystemComboBox.SelectedValue;
                _electionsRepositories.Update(_election);

                startDateTimePicker.Enabled = false;
                endDateTimePicker.Enabled = false;
                votingSystemComboBox.Enabled = false;
                modifyButton.Text = "Modify";
            }
            
        }

        private void startElection_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to start the election?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                startDateTimePicker.Value = DateTime.Now;
                _electionsRepositories.Update(_election);
            }
        }

        private void endElection_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to end the election?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                endDateTimePicker.Value = DateTime.Now;
                _electionsRepositories.Update(_election);
            }
        }

        private void countElectionButton_Click(object sender, EventArgs e)
        {
            Guid electionId = _election.ID;
            Guid votingSystemId = _election.VoteSystem;

            PartyDTO result = _electionService.CountElection(electionId, votingSystemId);

            MessageBox.Show(result.Name);
        }
    }
}