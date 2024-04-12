using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using UniTask.data.Repositories;
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

        public DbSet<Result> Results { get; set; }

        public DbSet<User>  Users { get; set; }

        public DbSet<Vote> Votes { get; set; }  

        public DbSet<Voter> Voters { get; set; }

        public DbSet<VotingSystem> VotingSystems { get; set; }

        public RegionsRepositories RegionsRepositories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlite("Data Source = VotingSytem.db");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Candidate>();
            builder.Entity<Election>();
            builder.Entity<Voter>();
            builder.Entity<Vote>();
            builder.Entity<Party>();

            builder.Entity<Election>().HasData(new Election { ID = Guid.NewGuid(), VoteSystem = new Guid("17F98667-0112-413F-9819-535CC2A85F8F"), RegionID = new Guid ("2E482B35-CC65-4322-B8F5-CB453D0BCE7E"), Name = "Election 1" });

            builder.Entity<VotingSystem>().HasData(new VotingSystem { ID = Guid.NewGuid(), Name = "Proportional Representation" },
                new VotingSystem { ID = Guid.NewGuid(), Name = "First Past The Post" });

            builder.Entity<Region>().HasData(new Region { ID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E"), Name = "Scotland" },
                new Region { ID = new Guid("EF2B02DB-456D-4E78-8ABD-E34F7CDCDA7D"), Name = "Wales" }, 
                new Region { ID = new Guid("95814AF1-4246-4722-AA92-4456D6BFCA6D"), Name = "England" });

            builder.Entity<Party>().HasData(new Party { ID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), Name = "Labour" },
                new Party { ID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), Name = "Conservative" });

            builder.Entity<Candidate>().HasData(new Candidate { ID = Guid.NewGuid(), Name = "Bob", VoteCount = 0, PartyID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), RegionID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E") },
            new Candidate{ ID = Guid.NewGuid(), Name = "John", VoteCount = 0, PartyID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), RegionID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E")});

            //builder.Entity<User>().HasData(new VotingSystem { ID = new Guid("B5434315-B59C-4365-A011-71AFA80B0D4B"), Name ="Admin 1"});

            builder.Entity<Voter>().HasData(new Voter { ID = Guid.NewGuid(), UserID = new Guid("B6434325-B59C-4765-A511-71AFA80B7D4B"), Password ="Voter", VerifcationCode="1234567", HasVoted = false, RegionID= new Guid ("2E482B35-CC65-4322-B8F5-CB453D0BCE7E") ,Name ="Voter", DateOfBirth = new DateTime(2002, 10, 10) });

            builder.Entity<Admin>().HasData(new Admin { ID = Guid.NewGuid(), UserID = new Guid("B5434315-B59C-4365-A011-71AFA80B0D4B")});

            builder.Entity<User>().HasData(new User { ID = Guid.NewGuid(), Name = "ExampleName", Username = "Admin", Password = "Admin", IsAdmin = true },
            new User { ID = Guid.NewGuid(), Name = "ExampleName1", Username = "User", Password = "User", IsAdmin = false,DateOfBirth = new DateTime(2002, 10, 10), OneTimeCode="1234567"});
        }
    }
}