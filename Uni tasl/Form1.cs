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
            _dbContext.users.Load();
            _dbContext.Regions.Load();
            _dbContext.Admins.Load();
            _dbContext.Voters.Load();
            _dbContext.votes.Load();
            _dbContext.Elections.Load();
            _dbContext.Partys.Load();
            _dbContext.Candidates.Load();

        }

        
    }
}
