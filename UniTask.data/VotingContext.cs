using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using UniTask.data.Repositories;
using UniTask.entites;
using UniTask.Entites;

namespace  UniTask.data
{
    public class VotingContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }    

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateXElection> CandidateXElection { get; set; }

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
            builder.Entity<CandidateXElection>();

            builder.Entity<Election>().HasData(new Election { ID = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteSystem = new Guid("76F3108D-8960-41C6-AECB-9175896CDD94"), StartTime = new DateTime(2024, 04, 12, 23, 59, 0), EndTime = new DateTime(2024, 05, 1, 23, 59, 0), Name = "Proportional" },
                new Election { ID = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteSystem = new Guid("F0372C84-0AA9-4218-9D57-5248F2A99E18"), StartTime = new DateTime(2024, 04, 12, 23, 59, 0), EndTime = new DateTime(2024, 05, 5, 23, 59, 0), Name = "FPTP" });


            builder.Entity<VotingSystem>().HasData(new VotingSystem { ID = new Guid("76F3108D-8960-41C6-AECB-9175896CDD94"), Name = "Proportional Representation" },
                new VotingSystem { ID = new Guid("F0372C84-0AA9-4218-9D57-5248F2A99E18"), Name = "First Past The Post" });

            builder.Entity<Region>().HasData(new Region { ID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E"), Name = "Scotland" },
                new Region { ID = new Guid("EF2B02DB-456D-4E78-8ABD-E34F7CDCDA7D"), Name = "Wales" }, 
                new Region { ID = new Guid("95814AF1-4246-4722-AA92-4456D6BFCA6D"), Name = "England" });

            builder.Entity<Party>().HasData(new Party { ID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), Name = "Labour" },
                new Party { ID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), Name = "Conservative" });

            builder.Entity<Candidate>().HasData(new Candidate { ID = new Guid("B39B440B-38F2-492F-911F-1139797C441B"), Name = "Bob", PartyID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), RegionID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E") },
            new Candidate { ID = new Guid("1A3835A0-32CC-439D-AC7D-C923112893B9"), Name = "John", PartyID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), RegionID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E")},
            new Candidate { ID = new Guid("0945D2F4-71D2-4928-A5A5-DEA766223CAF"), Name = "Vev", PartyID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), RegionID = new Guid("95814AF1-4246-4722-AA92-4456D6BFCA6D")},
            new Candidate { ID = new Guid("03D3087A-47F9-449B-BE58-1A5AC4976BE8"), Name = "Greg", PartyID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), RegionID = new Guid("95814AF1-4246-4722-AA92-4456D6BFCA6D")},
            new Candidate { ID = new Guid("1F0F32E6-8B6B-4FF0-B592-641A6C2F0AFA"), Name = "Steve", PartyID = new Guid("05ECA4E5-4096-48D8-A5CE-8F041C1FAA0F"), RegionID = new Guid("EF2B02DB-456D-4E78-8ABD-E34F7CDCDA7D") },
            new Candidate { ID = new Guid("2BF5CD92-928C-4D2F-9C26-BF5421999153"), Name = "Fred", PartyID = new Guid("892C3F0B-DDBA-441C-970B-4AE2E305A6F2"), RegionID = new Guid("EF2B02DB-456D-4E78-8ABD-E34F7CDCDA7D") });

            builder.Entity<Voter>().HasData(new Voter { ID = Guid.NewGuid(), UserID = new Guid("B6434325-B59C-4765-A511-71AFA80B7D4B"), Password ="Voter", VerifcationCode="1234577", IsVerified = false ,HasVoted = false, RegionID= new Guid ("2E482B35-CC65-4322-B8F5-CB453D0BCE7E") ,Name ="Voter", DateOfBirth = new DateTime(2002, 10, 10), Email = "Tom@hotmail.com" },
            new Voter { ID = Guid.NewGuid(), UserID = new Guid("B6434325-B59C-4765-A512-81AFA80B7D4B"), Password = "Voter", VerifcationCode = "1234567", IsVerified = true, HasVoted = false, RegionID = new Guid("2E482B35-CC65-4322-B8F5-CB453D0BCE7E"), Name = "Voter", DateOfBirth = new DateTime(2002, 12, 11), Email = "John@hotmail.com" });

            builder.Entity<Admin>().HasData(new Admin { ID = Guid.NewGuid(), UserID = new Guid("B5434315-B59C-4365-A011-71AFA80B0D4B"), Username = "Admin", Password = "Admin"});

            builder.Entity<CandidateXElection>().HasData(
            new CandidateXElection { Id = new Guid("A9FD4DC1-FFEA-4631-B922-200793BA54FD"), CandidateId = new Guid("03D3087A-47F9-449B-BE58-1A5AC4976BE8"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 50 },
            new CandidateXElection { Id = new Guid("4EC11CFD-4671-43A4-BB36-BBCDBF80AB03"), CandidateId = new Guid("0945D2F4-71D2-4928-A5A5-DEA766223CAF"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 176 },
            new CandidateXElection { Id = new Guid("94D4A05A-0060-4310-96AC-EE29EF18B8D8"), CandidateId = new Guid("2BF5CD92-928C-4D2F-9C26-BF5421999153"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 33 },
            new CandidateXElection { Id = new Guid("0404FF4A-E4DE-4C8A-8ACE-462C3FC58922"), CandidateId = new Guid("1F0F32E6-8B6B-4FF0-B592-641A6C2F0AFA"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 22 },
            new CandidateXElection { Id = new Guid("75E36148-F603-4E9D-A197-AA7BA614B8EA"), CandidateId = new Guid("1A3835A0-32CC-439D-AC7D-C923112893B9"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 40 },
            new CandidateXElection { Id = new Guid("1D7AD91B-9A1F-49BF-AC81-271D0363FF3F"), CandidateId = new Guid("B39B440B-38F2-492F-911F-1139797C441B"), ElectionId = new Guid("B977D8D8-C3DC-47A4-89A5-509ABB0654C7"), VoteCount = 39 },
            new CandidateXElection { Id = new Guid("7A6D0372-1F76-4795-B407-4D7D8D87F417"), CandidateId = new Guid("03D3087A-47F9-449B-BE58-1A5AC4976BE8"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 50 },
            new CandidateXElection { Id = new Guid("C62AA3FF-08A3-4FA1-A2D4-9D3CBFE9132D"), CandidateId = new Guid("0945D2F4-71D2-4928-A5A5-DEA766223CAF"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 176 },
            new CandidateXElection { Id = new Guid("52D9D826-8F4D-4F70-85EC-0DBC0237ABCB"), CandidateId = new Guid("2BF5CD92-928C-4D2F-9C26-BF5421999153"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 33 },
            new CandidateXElection { Id = new Guid("101F0638-733C-4FBC-971F-785AAF14BEAF"), CandidateId = new Guid("1F0F32E6-8B6B-4FF0-B592-641A6C2F0AFA"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 22 },
            new CandidateXElection { Id = new Guid("23AFDCC5-D34A-4146-8DC7-1EA20AB293B8"), CandidateId = new Guid("1A3835A0-32CC-439D-AC7D-C923112893B9"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 40 },
            new CandidateXElection { Id = new Guid("86EAC873-E4E7-48FC-92D1-5531CA05B7C3"), CandidateId = new Guid("B39B440B-38F2-492F-911F-1139797C441B"), ElectionId = new Guid("6480BA97-1DCF-470F-BD3A-50905D7FDC3C"), VoteCount = 39 }
);

        }
    }
}