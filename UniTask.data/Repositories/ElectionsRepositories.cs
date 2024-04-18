using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;
using UniTask.Entites;

namespace UniTask.data.Repositories
{
    public class ElectionsRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public ElectionsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Election Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Elections.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Election> LoadAll()
        {
            return _context.Elections.Local.AsEnumerable();
        }

        public IEnumerable<Election> LoadAllActive()
        {
            return _context.Elections.Local.Where(x => x.StartTime<= DateTime.Now).Where(x => x.EndTime>= DateTime.Now).AsEnumerable();
        }

        //save new object 
        public Election Save(Election entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                Insert(entity);
                return entity;
            }
            Update(entity);
            return entity;
        }

        public void SaveElectionCandidate(Guid electionId, Guid candidateId)
        {
            var entity = new CandidateXElection() 
            {
                 CandidateId = candidateId,
                 ElectionId = electionId,
                 Id = Guid.NewGuid(),
                 VoteCount = 0                 
            };
            if (!_context.CandidateXElection.Any(x => x.ElectionId == electionId && x.CandidateId == candidateId))
            {
                _context.CandidateXElection.Add(entity);
                _context.SaveChanges();
            }
        }

        public Election GetByName(string electionName)
        {
            return _context.Elections.Local.Single(x => x.Name == electionName);
        }

        //dele existing object 
        public void Delete(Election entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Election entity)
        {
            _context.Elections.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        public void Update(Election entity)
        {
            var election = _context.Elections.FirstOrDefault(x => x.ID == entity.ID);
            election.Winner = entity.Winner;
            election.VoteSystem = entity.VoteSystem;
            election.RegionID = entity.RegionID;
            election.Name = entity.Name;
            _context.SaveChanges();
        }

        public void StartNewElection(Election election)
        {
            if (election == null)
                throw new ArgumentNullException(nameof(election));

            Save(election);
        }

        public void EndCurrentElection(DateTime utcEndDateTime)
        {
            var currentElection = _context.Elections
                .Where(e => e.EndTime<DateTime.Now) 
                .OrderByDescending(e => e.StartTime) 
                .FirstOrDefault();
            if (currentElection != null)
            {
                currentElection.EndTime = utcEndDateTime;
                Update(currentElection);
            }
        }

        public Party CountVotes()
        {
            var winningParty = new Party();
            return winningParty;
        }
    }
}
