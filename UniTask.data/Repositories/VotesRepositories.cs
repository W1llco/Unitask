using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class VotesRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public VotesRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Vote Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Votes.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Vote> LoadAll()
        {
            return _context.Votes.Local.AsEnumerable();
        }

        //save new object 
        public Vote Save(Vote entity)
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
        public void Delete(Vote entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Vote entity)
        {
            _context.Votes.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(Vote entity)
        {
            var vote = _context.Votes.FirstOrDefault(x => x.ID == entity.ID);
            vote.VoterId = entity.VoterId;
            vote.CandiateId = entity.CandiateId;
            vote.ElectionId = entity.ElectionId;
            _context.SaveChanges();
        }
    }
}
