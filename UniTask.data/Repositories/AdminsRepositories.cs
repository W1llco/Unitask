using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class AdminsRepositories
    {
        // Field to hold the database context, injected via the constructor.
        private readonly VotingContext _context;

        // Constructor that injects the VotingContext to be used by this repository.
        public AdminsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Retrieves an Admin entity by its ID. Returns null if the ID is empty (Guid.Empty).
        public Admin Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Return null if the provided ID is empty, indicating no valid ID was provided.
            return _context.Admins.Local.First(x => x.ID == id); // Return the first local Admin matching the ID.
        }

        // Retrieves all Admin entities from the local context.
        public IEnumerable<Admin> LoadAll()
        {
            return _context.Admins.Local.AsEnumerable(); // Return all Admin entities as an IEnumerable.
        }

        // Saves an Admin entity to the context. If the Admin is new, it inserts; if existing, it updates.
        public Admin Save(Admin entity)
        {
            if (entity.ID == Guid.Empty) // Check if the Admin entity is new.
            {
                entity.ID = Guid.NewGuid(); // Assign a new GUID.
                Insert(entity); // Insert the new Admin entity into the context.
                return entity; // Return the newly added entity.
            }
            Update(entity); // Update the existing entity.
            return entity; // Return the updated entity.
        }

        // Deletes an Admin entity from the context.
        public void Delete(Admin entity)
        {
            if (entity.ID != Guid.Empty) // Ensure the Admin has a valid ID.
            {
                _context.Remove(entity); // Remove the Admin from the context.
                _context.SaveChanges(); // Persist changes to the database.
            }
        }

        // Inserts a new Admin entity into the database.
        private void Insert(Admin entity)
        {
            _context.Admins.Add(entity); // Add the new Admin to the context.
            _context.SaveChanges(); // Save changes to the database.
        }

        // Updates an existing Admin entity in the database.
        private void Update(Admin entity)
        {
            var admin = _context.Admins.FirstOrDefault(x => x.ID == entity.ID); // Find the existing Admin by ID.
            if (admin != null) // Ensure the Admin exists before updating.
            {
                // Update the Admin properties.
                admin.UserID = entity.UserID;
                admin.Username = entity.Username;
                admin.Password = entity.Password;
                _context.SaveChanges(); // Save the updated properties to the database.
            }
        }

        // Authenticates an Admin by username and password.
        public Admin ConfirmVoterLogin(Admin admin)
        {
            // Return the Admin whose username and password match those provided.
            return _context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
        }
    }
}
