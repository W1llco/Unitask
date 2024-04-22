using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // Class for managing database operations related to regions using Entity Framework.
    public class RegionsRepositories
    {
        // Field to store the database context, injected via the constructor.
        private readonly VotingContext _context;

        // Constructor to initialize the repository with a database context.
        public RegionsRepositories( VotingContext context)
        {
            _context = context;
        }

        // Loads a single region by its unique identifier.
        public Region Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Return null if the provided ID is empty to prevent erroneous fetches.
            return _context.Regions.Local.FirstOrDefault(x => x.ID == id); // Retrieves the region from the local cache.
        }

        // Loads all regions from the database.
        public IEnumerable<Region> LoadAll()
        {
            return _context.Regions.Local.AsEnumerable(); // Returns all regions from the local data set.
        }

        // Saves a region to the database or updates it if it already exists.
        public Region Save(Region entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new region.
                Insert(entity); // Calls insert method to add the new region.
                return entity;
            }
            Update(entity); // Calls update method if the region exists.
            return entity;
        }


        // Retrieves a region by its name.
        public Region GetRegion(string region)
        {
            return _context.Regions.Local.FirstOrDefault(x => x.Name == region);// Finds the first region with the specified name.
        }

        // Deletes an existing region from the database.
        public void Delete(Region entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the region from the context.
                _context.SaveChanges(); // Persists the removal to the database.
            }
        }

        // Private helper method to insert a new region into the database.
        private void Insert(Region entity)
        {
            _context.Regions.Add(entity);
            _context.SaveChanges();

        }

        // Private helper method to update an existing region's information.
        private void Update(Region entity)
        {
            var region = _context.Regions.FirstOrDefault(x => x.ID == entity.ID);
            // Update properties of the existing region.
            region.Name = entity.Name;
            _context.SaveChanges();// Saves all changes made to this region.
        }
    }
}
