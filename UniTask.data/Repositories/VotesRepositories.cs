using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // Class for handling database operations for Vote entities.
    public class VotesRepositories
    {
        // Database context injected into the repository.
        private readonly VotingContext _context;

        // Constructor to inject the database context.
        public VotesRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single vote by its ID.
        public Vote Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Returns null if the provided ID is empty, avoiding erroneous fetches.
            return _context.Votes.Local.First(x => x.ID == id); // Fetches the vote from the local cache.
        }

        // Loads all votes from the database.
        public IEnumerable<Vote> LoadAll()
        {
            return _context.Votes.Local.AsEnumerable(); // Returns all votes stored locally in the context.
        }

        // Saves a vote to the database. If the vote is new, it inserts; if existing, it updates.
        public Vote Save(Vote entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new vote.
                Insert(entity); // Inserts the new vote into the database.
                return entity;
            }
            Update(entity); // Updates an existing vote.
            return entity;
        }

        // Deletes an existing vote from the database.
        public void Delete(Vote entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the vote from the context.
                _context.SaveChanges(); // Commits the removal to the database.
            }
        }

        // Inserts a new vote record into the database.
        private void Insert(Vote entity)
        {
            _context.Votes.Add(entity);
            _context.SaveChanges();
        }

        // Updates an existing vote's information in the database.
        private void Update(Vote entity)
        {
            var vote = _context.Votes.FirstOrDefault(x => x.ID == entity.ID);
            if (vote != null)
            {
                vote.VoterId = entity.VoterId;
                vote.CandiateId = entity.CandiateId;
                vote.ElectionId = entity.ElectionId;
                _context.SaveChanges(); // Saves all changes made to this vote.
            }
        }

        // Retrieves a specific vote by voter and election ID, returning null if not found.
        public Vote? GetVote(Guid voterId, Guid electionId)
        {
            var vote = _context.Votes.Where(x => x.VoterId == voterId && x.ElectionId == electionId).FirstOrDefault();
            if (vote != null)
            {
                return vote;
            }
            else
            {
                return null;
            }
        }

        // Retrieves a list of election IDs for which a voter has already cast votes.
        public IEnumerable<Guid> GetUsedVotes(Guid voterId)
        {
            // Returns the IDs of elections where the voter has cast votes.
            var x = _context.Votes.Where(x => x.VoterId == voterId && x.CandiateId != Guid.Empty).Select(x => x.ElectionId);
            return x;
        }
    }
}
