using Microsoft.EntityFrameworkCore;
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
    public partial class AdminLogin : Form
    {
        //injecting voting context
        private readonly VotingContext _dbContext;
        private readonly AdminsRepositories _adminsRepositories;

        public AdminLogin(VotingContext dbContext, AdminsRepositories adminsRepositories)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _adminsRepositories = adminsRepositories;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var x = _adminsRepositories.LoadAll();
            var admin = _adminsRepositories.ConfirmVoterLogin(new Admin() { Username = UsernameTextBox.Text, Password = PasswordTextBox.Text});

            if (admin != null)
            {
                var admins = _adminsRepositories.LoadAll().Where(x => x.ID == admin.ID);
                // Open admin area
                AdminDashboard adminDashboard = (AdminDashboard)Program._provider.GetService(typeof(AdminDashboard));
                adminDashboard.SetIds(admin.ID);
                adminDashboard.InitializePage();
                adminDashboard.Show();
                this.Hide();
            }
            else
            {
                // User not found, show error message
                MessageBox.Show("The username or password is wrong. Try again.");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                UsernameTextBox.Focus();
            }
        }
    }
}
