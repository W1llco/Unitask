using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class PartysRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public PartysRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Party Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Partys.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Party> LoadAll()
        {
            return _context.Partys.Local.AsEnumerable();
        }

        //save new object 
        public Party Save(Party entity)
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
        public void Delete(Party entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Party entity)
        {
            _context.Partys.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(Party entity)
        {
            var party = _context.Partys.FirstOrDefault(x => x.ID == entity.ID);
            party.Name = entity.Name;
            party.ElectionID = entity.ElectionID;
            party.RegionID = entity.RegionID;
            _context.SaveChanges();
        }
    }
}
