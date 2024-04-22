using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // Class for managing database operations related to election results.
    public class ResultsRepositories
    {
        // Database context injected into the repository for database operations.
        private readonly VotingContext _context;

        // Constructor for injecting the database context.
        public ResultsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single result by its ID. Returns null if the ID is empty, avoiding erroneous fetches.
        public Result Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Indicates an invalid or non-existent identifier.
            return _context.Results.Local.First(x => x.ID == id); // Fetches the result from the local cache.
        }

        // Loads all results from the database.
        public IEnumerable<Result> LoadAll()
        {
            return _context.Results.Local.AsEnumerable(); // Returns all results stored locally.
        }

        // Saves a result to the database. If the result is new, it inserts it; if it exists, it updates it.
        public Result Save(Result entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new GUID if the result is new.
                Insert(entity); // Inserts the new result into the database.
                return entity; // Returns the newly inserted result.
            }
            Update(entity); // Updates an existing result.
            return entity; // Returns the updated result.
        }

        // Deletes an existing result from the database.
        public void Delete(Result entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the result from the database context.
                _context.SaveChanges(); // Commits the deletion to the database.
            }
        }

        // Private helper method to insert a new result into the database.
        private void Insert(Result entity)
        {
            _context.Results.Add(entity);
            _context.SaveChanges();

        }

        // Private helper method to update an existing result's information in the database.
        private void Update(Result entity)
        {
            var result = _context.Results.FirstOrDefault(x => x.ID == entity.ID);
            if (result != null)
            {
                result.Name = entity.Name; // Updates the name of the result.
                _context.SaveChanges(); // Saves all changes made to this result.
            }
        }
    }
}
