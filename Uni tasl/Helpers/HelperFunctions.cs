using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unitask.DTOs;
using Unitask.Infrastructure.Services;
using UniTask.data.Repositories;
using UniTask.entites;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Uni_tasl.Helpers
{
    public class HelperFunctions
    {
        // Private field to hold the PartyService reference
        private readonly PartyService _partyService;

        // Constructor that initializes the PartyService field
        public HelperFunctions(PartyService partyService)
        {
            _partyService = partyService;
        }
        // Method to populate a ComboBox with candidates. Includes an option to display party names.
        public void GetCandidateValuesForDropdown(ComboBox comboBox, IEnumerable<CandidateDTO> candidates, bool addPartyName)
        {
            // Create a list to hold key/value pairs representing candidate ID and display text
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            // Add a default "Please Select" option with an empty GUID as the key
            keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select"));
            // Loop through each candidate in the provided collection
            foreach (CandidateDTO c in candidates)
            {
                // Check if party names should be included in the display text
                if (addPartyName)
                {
                    // Load the party name using the party ID from the candidate and format the string to include it
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, $"{c.Name} ({_partyService.Load(c.PartyID).Name})"));
                }
                else
                {
                    // Add the candidate with only the candidate's name
                    keyValuePairs.Add(new KeyValuePair<Guid, string>(c.ID, c.Name));
                }
            }
            // Set the ComboBox's DataSource to a new BindingSource using the list of key/value pairs
            comboBox.DataSource = new BindingSource(keyValuePairs, null);
            // Set the properties to display the values and use the keys as values for internal use
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }

        // Method to populate a ComboBox with voting systems
        public void GetVotingSystemValuesForDropdown(ComboBox comboBox, IEnumerable<VotingSystemDTO> votingSystem)
        {
            // Create a list to hold key/value pairs representing voting system ID and name
            List<KeyValuePair<Guid, string>> keyValuePairs = new List<KeyValuePair<Guid, string>>();
            keyValuePairs.Add(new KeyValuePair<Guid, string>(Guid.Empty, "Please Select"));

            // Loop through each voting system in the provided collection
            foreach (VotingSystemDTO v in votingSystem)
            {
                // Add the voting system with the system's ID and name
                keyValuePairs.Add(new KeyValuePair<Guid, string>(v.ID, v.Name));
            }
            comboBox.DataSource = new BindingSource(keyValuePairs, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }
    }
}
