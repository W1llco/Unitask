using Microsoft.EntityFrameworkCore;
using UniTask.data;

namespace Uni_tasl
    
{
    // Form1 is the main entry form of the application, responsible for initializing the database and navigating to different user roles.
    public partial class Form1 : Form
    {
        // Field for the database context, which is injected through the constructor to interact with the database.
        private readonly VotingContext _dbContext;

        // Constructor initializes the form and receives a database context to operate with.
        public Form1(VotingContext dbContext)
        {
            _dbContext = dbContext;  // Storing the provided database context for later use.
            InitializeComponent();  // Initializes the form's UI components as defined in the designer file.
        }

        // Overriding the OnLoad method to ensure database setup and data loading upon starting the application.
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);  // Ensuring that base class load operations are performed.

            // Ensures the database is deleted and recreated every time the application loads. This is useful for development and testing.
            _dbContext.Database.EnsureDeletedAsync();  // Asynchronously delete the existing database.
            _dbContext.Database.EnsureCreatedAsync();  // Asynchronously create a new database structure.

            // Load all relevant data from the database into the application's context. This is often done in desktop applications to improve performance.
            _dbContext.Users.Load();  // Preloads user data.
            _dbContext.Regions.Load();  // Preloads region data.
            _dbContext.Admins.Load();  // Preloads admin data.
            _dbContext.Voters.Load();  // Preloads voter data.
            _dbContext.Votes.Load();  // Preloads votes data.
            _dbContext.Elections.Load();  // Preloads election data.
            _dbContext.Partys.Load();  // Preloads party data.
            _dbContext.Candidates.Load();  // Preloads candidate data.
            _dbContext.VotingSystems.Load();  // Preloads voting system data.
        }

        // Event handler for the Home login button, which opens the external voter login form.
        private void LoginFromHomeButton_Click(object sender, EventArgs e)
        {
            // Retrieve an instance of the ExternalVoterLogin form from the service provider and show it.
            var pageOpen = (ExternalVoterLogin)Program._provider.GetService(typeof(ExternalVoterLogin));
            pageOpen.Show();
            this.Hide();  // Hides the main form to focus on the external voter login.
        }

        // Event handler for the Booth login button, which opens the internal voter login form.
        private void LoginFromBoothButton_Click(object sender, EventArgs e)
        {
            // Retrieve an instance of the InternalVoterLogin form from the service provider, show it, and hide the main form.
            var pageOpen = (InternalVoterLogin)Program._provider.GetService(typeof(InternalVoterLogin));
            pageOpen.Show();
            this.Hide();  // Hides the main form to focus on the internal voter login.
        }

        // Event handler for the Admin login button, which opens the admin login form.
        private void LoginAsAdminButton_Click(object sender, EventArgs e)
        {
            // Retrieve an instance of the AdminLogin form from the service provider, show it, and hide the main form.
            var pageOpen = (AdminLogin)Program._provider.GetService(typeof(AdminLogin));
            pageOpen.Show();
            this.Hide();  // Hides the main form to focus on the admin login.
        }
    }
}
