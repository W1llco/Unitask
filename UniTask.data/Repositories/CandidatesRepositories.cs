using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class CandidatesRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public CandidatesRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Candidate Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Candidates.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Candidate> LoadAll()
        {
            return _context.Candidates.Local.AsEnumerable();
        }

        public IEnumerable<Candidate> GetCandidates(Guid regionId, Guid partyId)
        {
           return _context.Candidates.Local.Where(x => x.RegionID == regionId).Where(x => x.PartyID == partyId);
        }

        //save new object 
        public Candidate Save(Candidate entity)
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

        //dele existing object 
        public void Delete(Candidate entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Candidate entity)
        {
            _context.Candidates.Add(entity);
            _context.SaveChanges();

        }

        //update existing object 
        public void Update(Candidate entity)
        {
            var candidate = _context.Candidates.FirstOrDefault(x => x.ID == entity.ID);
            if (candidate != null)
            {
                candidate.Name = entity.Name;
                candidate.PartyID = entity.PartyID;
                candidate.RegionID = entity.RegionID;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Candidate> GetCandidatesForRegion(Guid regionID)
        {
           return _context.Candidates.Local.Where(x => x.RegionID == regionID);
        }
    }
}
