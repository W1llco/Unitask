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

namespace Uni_tasl
{
    public partial class AdminLogin : Form
    {
        //injecting voting context
        private readonly VotingContext _dbContext;

        public AdminLogin(VotingContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
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


        private void LoginButton_Click(object sender, EventArgs e)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == UsernameTextBox.Text && u.Password == PasswordTextBox.Text);

            if (user.IsAdmin)
            {
                // Open admin area
                new AdminDashboard(user.Username).Show();
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
