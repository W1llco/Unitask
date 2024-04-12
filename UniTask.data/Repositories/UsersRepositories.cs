using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class UsersRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public UsersRepositories(VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public User Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Users.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<User> LoadAll()
        {
            return _context.Users.Local.AsEnumerable();
        }

        //save new object 
        public User Save(User entity)
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
        public void Delete(User entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(x => x.ID == entity.ID);
            user.Name = entity.Name;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.IsAdmin = entity.IsAdmin;
            _context.SaveChanges();
        }
    }
}
