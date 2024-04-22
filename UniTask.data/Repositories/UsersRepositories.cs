using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // This class manages database operations related to user entities.
    public class UsersRepositories
    {
        // Database context injected into the repository.
        private readonly VotingContext _context;

        // Constructor for injecting the database context, enabling operations on the Users dataset.
        public UsersRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single user by their unique identifier. Returns null if the ID is empty.
        public User Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Prevents attempting to load a user with an invalid ID.
            return _context.Users.Local.First(x => x.ID == id); // Fetches the user from the local cache.
        }

        // Loads all users from the database.
        public IEnumerable<User> LoadAll()
        {
            return _context.Users.Local.AsEnumerable(); // Returns all users stored locally in the context.
        }

        // Saves a user to the database. If the user is new, it inserts; if existing, it updates.
        public User Save(User entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new user.
                Insert(entity); // Inserts the new user into the database.
                return entity;
            }
            Update(entity); // Updates an existing user.
            return entity;
        }

        // Deletes an existing user from the database.
        public void Delete(User entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the user from the context.
                _context.SaveChanges(); // Persists the removal to the database.
            }
        }

        // Private helper method to insert a new user into the database.
        private void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        // Private helper method to update an existing user's information in the database.
        private void Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(x => x.ID == entity.ID);
            if (user != null)
            {
                // Update properties of the existing user.
                user.Username = entity.Username;
                _context.SaveChanges(); // Saves all changes made to this user.
            }
        }
    }
}
