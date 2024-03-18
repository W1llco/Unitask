using Microsoft.EntityFrameworkCore;
using UniTask.entites;

namespace  UniTask.data
{
    public class VotingContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }    

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Election> Elections { get; set; }

        public DbSet<Party> Partys { get; set; }    

        public DbSet<Region> Regions { get; set; }

        public DbSet<Results> Results { get; set; }

        public DbSet<User>  users { get; set; }

        public DbSet<Vote> votes { get; set; }  

        public DbSet<Voter> Voters { get; set; }

        public DbSet<VotingSystem> VotingSystems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite("Data Source = VotingSytem.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>();
            builder.Entity<Election>();
            builder.Entity<Voter>();
            builder.Entity<Vote>();

            builder.Entity<VotingSystem>().HasData(new VotingSystem { ID = Guid.NewGuid(), Name = "Proportional Representation" },
                new VotingSystem { ID = Guid.NewGuid(), Name = "First Past The Post" });

            builder.Entity<Region>().HasData(new Region { ID = Guid.NewGuid(), Name = "Scotland" },
                new Region { ID = Guid.NewGuid(), Name = "Wales" }, 
                new Region { ID = Guid.NewGuid(), Name = "England" });

            builder.Entity<User>().HasData(new VotingSystem { ID = new Guid("B5434315-B59C-4365-A011-71AFA80B0D4B"), Name ="Admin 1" });

            builder.Entity<Admin>().HasData(new Admin { ID = Guid.NewGuid(), UserID = new Guid("B5434315-B59C-4365-A011-71AFA80B0D4B")});

        }
    }
}