using Microsoft.EntityFrameworkCore;
using UniTask.data;

namespace Uni_tasl
    
{
    public partial class Form1 : Form
    {
        //injecting voting context
        private readonly VotingContext _dbContext;

        
        public Form1(VotingContext dbContext)
        {
            _dbContext = dbContext;

            InitializeComponent();
            dg_Regions.DataSource = _dbContext.Regions.Local.ToBindingList();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //_dbContext.Database.EnsureDeleted();
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



        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == textBoxUsername.Text && u.Password == textBoxPassword.Text);

            if (user != null)
            {
                // User found, check if user is an admin
                if (user.IsAdmin)
                {
                    // Open admin area
                    new AdminDashboard(user.Username).Show();
                }
                else
                {
                    // User is not an admin, proceed with normal login
                    new VoterPage(user.Username).Show();
                }

                this.Close();
            }
            else
            {
                // User not found, show error message
                MessageBox.Show("The username or password is wrong. Try again.");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
                textBoxUsername.Focus();
            }
        }

    }
}
