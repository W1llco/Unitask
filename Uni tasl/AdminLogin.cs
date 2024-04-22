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
using Unitask.Infrastructure.Services;
using UniTask.data;
using UniTask.data.Repositories;
using UniTask.entites;

namespace Uni_tasl
{
    public partial class AdminLogin : Form
    {
        // Private fields for database context and admin service injected via constructor.
        private readonly VotingContext _dbContext;
        private readonly AdminService _adminService;

        // Constructor for the AdminLogin form that initializes components and services.
        public AdminLogin(VotingContext dbContext, AdminService adminService)
        {
            InitializeComponent(); // Initializes form components defined in the designer.
            _dbContext = dbContext; // Stores the injected database context for later use.
            _adminService = adminService; // Stores the injected admin service for authentication.
            PasswordTextBox.UseSystemPasswordChar = true; // Secures password input by masking characters.
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Call AdminService to authenticate the admin using provided username and password.
            var x = _adminService.LoadAll();
            var admin = _adminService.ConfirmVoterLogin(new Admin() { Username = UsernameTextBox.Text, Password = PasswordTextBox.Text});

            if (admin != null)
            {
                // If authentication is successful, retrieve the admin details.
                var admins = _adminService.LoadAll().Where(x => x.ID == admin.ID);
                // Instantiate and show the AdminDashboard, passing the authenticated admin's ID.
                AdminDashboard adminDashboard = (AdminDashboard)Program._provider.GetService(typeof(AdminDashboard));
                adminDashboard.SetIds(admin.ID);
                adminDashboard.InitializePage();
                adminDashboard.Show();
                this.Hide();// Hides the login form.
            }
            else
            {
                // If authentication fails, show an error message and clear the input fields.
                MessageBox.Show("The username or password is wrong. Try again.");
                UsernameTextBox.Clear();
                PasswordTextBox.Clear();
                UsernameTextBox.Focus();// Focuses the cursor on the username text box for re-entry.
            }
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            // Opens the main form and closes the login form.
            Form1 form1 = new Form1(_dbContext); // Creates an instance of the main application form.
            form1.Show(); // Shows the main form.
            this.Close(); // Closes the login form.
        }
    }
}
