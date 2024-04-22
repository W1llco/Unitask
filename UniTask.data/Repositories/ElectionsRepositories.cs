using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;
using UniTask.Entites;

namespace UniTask.data.Repositories
{
    // Class for handling database operations related to elections.
    public class ElectionsRepositories
    {
        // Database context injected into the repository.
        private readonly VotingContext _context;

        // Database context injected into the repository.
        public ElectionsRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single election based on its ID.
        public Election Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Return null if the ID is empty, indicating an invalid request.
            return _context.Elections.Local.First(x => x.ID == id); // Fetches the election from the local cache.
        }

        // Loads all elections.
        public IEnumerable<Election> LoadAll()
        {
            return _context.Elections.Local.AsEnumerable(); // Returns all elections from the local data set.
        }

        // Loads all active elections that are currently ongoing.
        public IEnumerable<Election> LoadAllActive()
        {
            // Filters elections that are within their active period.
            return _context.Elections.Local.Where(x => x.StartTime <= DateTime.Now && x.EndTime >= DateTime.Now);
        }

        // Saves or updates an election object in the database.
        public Election Save(Election entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new unique identifier if it's a new election.
                Insert(entity); // Calls insert method to add a new election.
                return entity;
            }
            Update(entity); // Updates the existing election.
            return entity;
        }

        // Associates a candidate with an election.
        public void SaveElectionCandidate(Guid electionId, Guid candidateId)
        {
            // Creates a new linkage between an election and a candidate if it does not already exist.
            if (!_context.CandidateXElection.Any(x => x.ElectionId == electionId && x.CandidateId == candidateId))
            {
                _context.CandidateXElection.Add(new CandidateXElection
                {
                    CandidateId = candidateId,
                    ElectionId = electionId,
                    Id = Guid.NewGuid(),
                    VoteCount = 0
                });
                _context.SaveChanges();
            }
        }

        // Retrieves an election by its name.
        public Election GetByName(string electionName)
        {
            return _context.Elections.Local.Single(x => x.Name == electionName); // Returns the election with the specified name.
        }

        // Deletes an existing election from the database.
        public void Delete(Election entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the election from the database context.
                _context.SaveChanges(); // Persists changes to the database.
            }
        }

        // Private helper method to insert a new election into the database.
        private void Insert(Election entity)
        {
            _context.Elections.Add(entity);
            _context.SaveChanges();
        }

        // Private helper method to update an existing election in the database.
        public void Update(Election entity)
        {
            var election = _context.Elections.FirstOrDefault(x => x.ID == entity.ID);
            if (election != null)
            {
                // Update properties of the existing election.
                election.Winner = entity.Winner;
                election.VoteSystem = entity.VoteSystem;
                election.RegionID = entity.RegionID;
                election.Name = entity.Name;
                election.StartTime = entity.StartTime;
                election.EndTime = entity.EndTime;
                _context.SaveChanges(); // Saves all changes made to this election.
            }
        }

        // Method to start a new election and save it in the database.
        public void StartNewElection(Election election)
        {
            if (election == null)
                throw new ArgumentNullException(nameof(election));
            Save(election); // Saves the new election.
        }

        // Method to end the current active election.
        public void EndCurrentElection(DateTime utcEndDateTime)
        {
            // Finds the most recent active election and ends it.
            var currentElection = _context.Elections
                .Where(e => e.EndTime < DateTime.Now)
                .OrderByDescending(e => e.StartTime)
                .FirstOrDefault();
            if (currentElection != null)
            {
                currentElection.EndTime = utcEndDateTime;
                Update(currentElection); // Updates the end time of the current election.
            }
        }

        public Party CountVotes()
        {
            var winningParty = new Party(); 
            return winningParty;
        }

    }
}
