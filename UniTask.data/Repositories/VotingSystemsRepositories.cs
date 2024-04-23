using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // Class to manage database operations for VotingSystem entities.
    public class VotingSystemsRepositories
    {
        // Field to store the injected database context.
        private readonly VotingContext _context;

        // Constructor for injecting the database context.
        public VotingSystemsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single voting system by its ID.
        public VotingSystem Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Returns null if the provided ID is empty, avoiding erroneous fetches.
            return _context.VotingSystems.Local.First(x => x.ID == id); // Fetches the voting system from the local cache.
        }

        // Loads all voting systems from the database.
        public IEnumerable<VotingSystem> LoadAll()
        {
            var x = _context.VotingSystems.Local.AsEnumerable(); // Returns all voting systems stored locally.
            return x;
        }

        // Saves a voting system to the database. If the system is new, it inserts; if existing, it updates.
        public VotingSystem Save(VotingSystem entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new system.
                Insert(entity); // Inserts the new voting system into the database.
                return entity;
            }
            Update(entity); // Updates an existing voting system.
            return entity;
        }

        // Deletes an existing voting system from the database.
        public void Delete(VotingSystem entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the voting system from the context.
                _context.SaveChanges(); // Commits the removal to the database.
            }
        }

        // Inserts a new voting system record into the database.
        private void Insert(VotingSystem entity)
        {
            _context.VotingSystems.Add(entity);
            _context.SaveChanges();

        }

        // Updates an existing voting system's information in the database.
        private void Update(VotingSystem entity)
        {
            var votingSystem = _context.VotingSystems.FirstOrDefault(x => x.ID == entity.ID);
            // Update properties of the existing system.
            votingSystem.Name = entity.Name;
            _context.SaveChanges(); // Saves all changes made to this voting system.
        }
    }
}
