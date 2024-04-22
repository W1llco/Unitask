using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // This class manages database operations related to political parties using Entity Framework.
    public class PartysRepositories
    {
        // The database context injected via constructor.
        private readonly VotingContext _context;

        // Constructor for injecting the database context.
        public PartysRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single party based on its ID. Returns null if the ID is empty.
        public Party Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Return null if the ID is invalid to avoid erroneous fetches.
            return _context.Partys.Local.First(x => x.ID == id); // Retrieves the party from the local cache.
        }

        // Loads all parties from the database.
        public IEnumerable<Party> LoadAll()
        {
            return _context.Partys.Local.AsEnumerable(); // Returns all parties from the local data set.
        }

        // Retrieves a party by its name.
        public Party GetParty(string party)
        {
            return _context.Partys.Local.FirstOrDefault(x => x.Name == party); // Finds the first party with the specified name.
        }

        // Saves a party to the database or updates it if it already exists.
        public Party Save(Party entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new party.
                Insert(entity); // Calls insert method to add the new party.
                return entity;
            }
            Update(entity); // Calls update method if the party exists.
            return entity;
        }

        // Deletes a party from the database.
        public void Delete(Party entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the party from the context.
                _context.SaveChanges(); // Persists the removal to the database.
            }
        }

        // Private helper method to insert a new party into the database.
        private void Insert(Party entity)
        {
            _context.Partys.Add(entity);
            _context.SaveChanges();

        }

        // Private helper method to update an existing party's information.
        private void Update(Party entity)
        {
            var party = _context.Partys.FirstOrDefault(x => x.ID == entity.ID);
            if (party != null)
            {
                // Update properties of the existing party.
                party.Name = entity.Name;
                party.ElectionID = entity.ElectionID; // Parties are linked to elections.
                party.RegionID = entity.RegionID; // Parties are linked to specific regions.
                _context.SaveChanges(); // Saves all changes made to this party.
            }
        }
    }
}
