using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class AdminsRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public AdminsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Admin Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Admins.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Admin> LoadAll()
        {
            return _context.Admins.Local.AsEnumerable();
        }

        //save new object 
        public Admin Save(Admin entity)
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
        public void Delete(Admin entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Admin entity)
        {
            _context.Admins.Add(entity);
            _context.SaveChanges();

        }

        //update existing object 
        private void Update(Admin entity)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.ID == entity.ID);
            admin.UserID = entity.UserID;
            _context.SaveChanges();
        }
    }
}
