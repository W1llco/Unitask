using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Uni_tasl
{
    public partial class VerifyVoter : Form
    {
        public VerifyVoter()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string Username = UsernameBox.Text;
            dataGridViewUser.Rows.Add(Username, "Not Verified");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = UsernameBox.Text;
            bool isIdVerified = VerifyedcheckBox.Checked;

            string message = $"User: {userName} - ID Verified: {isIdVerified}";
            MessageBox.Show(message, "Submission Result");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
