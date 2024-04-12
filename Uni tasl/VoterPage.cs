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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Uni_tasl
{
    public partial class VoterPage : Form
    {
        
        private VotingContext dbContext;

        public VoterPage(VotingContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            dropdownVote.Text = "Select below";

            dropdownVote.Items.Add("Item 1");
            dropdownVote.Items.Add("Item 2");

            dropdownVote.SelectedIndexChanged += dropdownVote_SelectedIndexChanged;
        }

        private void dropdownVote_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show($"You selected: {dropdownVote.SelectedItem}");
        }

    }
}
