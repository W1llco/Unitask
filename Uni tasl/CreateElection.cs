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

            foreach (var c in englandConservative)
            {
                candiateEnglandConservativeComboBox.Items.Add(c.Name);
            }
            foreach (var c in englandLabour)
            {
                candiateEnglandLabourComboBox.Items.Add(c.Name);
            }
            foreach (var c in scotlandConservative)
            {
                candiateScotlandConservativeComboBox.Items.Add(c.Name); 
            }
            foreach (var c in scotlandLabour)
            {
                candiateScotlandLabourComboBox.Items.Add(c.Name);
            }
            foreach (var c in walesConservative)
            {
                candiateWalesConservativeComboBox.Items.Add(c.Name);
            }
            foreach (var c in walesLabour)
            {
                candiateWalesLabourComboBox.Items.Add(c.Name);
            }

        }

        
    }
}
