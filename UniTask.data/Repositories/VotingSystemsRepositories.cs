using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class VotingSystemsRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public VotingSystemsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public VotingSystem Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.VotingSystems.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<VotingSystem> LoadAll()
        {
            return _context.VotingSystems.Local.AsEnumerable();
        }

        //save new object 
        public VotingSystem Save(VotingSystem entity)
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
        public void Delete(VotingSystem entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(VotingSystem entity)
        {
            _context.VotingSystems.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(VotingSystem entity)
        {
            var votingSystem = _context.VotingSystems.FirstOrDefault(x => x.ID == entity.ID);
            votingSystem.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
