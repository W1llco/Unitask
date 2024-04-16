using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public CreateElection( VotingContext dbContext, CandidatesRepositories candidatesRepositories, ElectionsRepositories electionsRepositories, PartysRepositories partysRepositories, RegionsRepositories regionsRepositories)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _candidatesRepositories = candidatesRepositories;
            _electionsRepositories = electionsRepositories;
            _partysRepositories = partysRepositories;
            _regionsRepositories = regionsRepositories;
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

            GetVaulesForDropdown(candiateEnglandConservativeComboBox, englandConservative);
            GetVaulesForDropdown(candiateEnglandLabourComboBox, englandLabour);
            GetVaulesForDropdown(candiateScotlandConservativeComboBox, scotlandConservative);
            GetVaulesForDropdown(candiateScotlandLabourComboBox, scotlandLabour);
            GetVaulesForDropdown(candiateWalesConservativeComboBox, walesConservative);
            GetVaulesForDropdown(candiateWalesLabourComboBox, walesLabour);

            //foreach (var c in englandConservative)
            //{
            //    candiateEnglandConservativeComboBox.Items.Add(c.Name);
            //}
            //foreach (var c in englandLabour)
            //{
            //    candiateEnglandLabourComboBox.Items.Add(c.Name);
            //}
            //foreach (var c in scotlandConservative)
            //{
            //    candiateScotlandConservativeComboBox.Items.Add(c.Name);
            //}
            //foreach (var c in scotlandLabour)
            //{
            //    candiateScotlandLabourComboBox.Items.Add(c.Name);
            //}
            //foreach (var c in walesConservative)
            //{
            //    candiateWalesConservativeComboBox.Items.Add(c.Name);
            //}
            //foreach (var c in walesLabour)
            //{
            //    candiateWalesLabourComboBox.Items.Add(c.Name);
            //}

        }

        private void GetVaulesForDropdown(ComboBox comboBox, IEnumerable<Candidate> candidates)
        {
            BindingSource bs = new BindingSource();
            comboBox.DataBindings.Add(new Binding("Text", bs, "Format", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            foreach (Candidate c in candidates)
            {
                keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, c.Name));
            }
            comboBox.DataSource = new BindingSource(keyValuePairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entity = new Election()
            {
                Name = nameOfElectionTextBox.Text,
                StartTime = startDateTimePicker.Value,
                EndTime = endDateTimePicker.Value,

            };
            _electionsRepositories.Save(entity);

            MessageBox.Show("New person made", "Yay", MessageBoxButtons.OK);
        }
    }
}
