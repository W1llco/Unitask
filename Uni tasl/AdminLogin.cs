﻿using Microsoft.EntityFrameworkCore;
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

       


        private void LoginButton_Click(object sender, EventArgs e)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == UsernameTextBox.Text && u.Password == PasswordTextBox.Text);

            if (user.IsAdmin)
            {
                // Open admin area
                AdminDashboard adminDashboard = (AdminDashboard)Program._provider.GetService(typeof(AdminDashboard));
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
