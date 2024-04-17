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
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dbContext.Database.EnsureDeletedAsync();
            _dbContext.Database.EnsureCreatedAsync();

            _dbContext.Users.Load();
            _dbContext.Regions.Load();
            _dbContext.Admins.Load();
            _dbContext.Voters.Load();
            _dbContext.Votes.Load();
            _dbContext.Elections.Load();
            _dbContext.Partys.Load();
            _dbContext.Candidates.Load();
            _dbContext.VotingSystems.Load();

        }

        private void LoginFromHomeButton_Click(object sender, EventArgs e)
        {
            var pageOpen = (ExternalVoterLogin)Program._provider.GetService(typeof(ExternalVoterLogin));
            pageOpen.Show();
        }

        private void LoginFromBoothButton_Click(object sender, EventArgs e)
        {
            InternalVoterLogin internalVoterLogin = new InternalVoterLogin(_dbContext);
            internalVoterLogin.Show();
            this.Hide();
        }

        private void LoginAsAdminButton_Click(object sender, EventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin(_dbContext);
            adminLogin.Show();
            this.Hide();
        }
    }
}
