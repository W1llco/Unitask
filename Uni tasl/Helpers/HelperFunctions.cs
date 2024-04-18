using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using UniTask.entites;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Uni_tasl.Helpers
{
    public class HelperFunctions
    {
        private readonly PartysRepositories _partysRepositories;

        public HelperFunctions(PartysRepositories partysRepositories)
        {
             _partysRepositories = partysRepositories;
        }
        public void GetCandidateValuesForDropdown(ComboBox comboBox, IEnumerable<Candidate> candidates, bool addPartyName)
        {
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select"));
            foreach (Candidate c in candidates)
            {
                if (addPartyName)
                {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name} ({_partysRepositories.Load(c.PartyID).Name})"));
                }
                else
                {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, c.Name));
                }
            }
            comboBox.DataSource = new BindingSource(keyValuePairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        public void GetVotingSystemValuesForDropdown(ComboBox comboBox, IEnumerable<VotingSystem> votingSystem)
        {
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select"));
            foreach (VotingSystem v in votingSystem)
            {
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(v.ID, v.Name));
            }
            comboBox.DataSource = new BindingSource(keyValuePairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
    }
}
