using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class ResultsRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public ResultsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Result Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Results.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Result> LoadAll()
        {
            return _context.Results.Local.AsEnumerable();
        }

        //save new object 
        public Result Save(Result entity)
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
        public void Delete(Result entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Result entity)
        {
            _context.Results.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(Result entity)
        {
            var result = _context.Results.FirstOrDefault(x => x.ID == entity.ID);
            result.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
