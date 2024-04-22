using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unitask.DTOs.ViewModels;
using UniTask.entites;
using UniTask.Entites;

namespace UniTask.data.Repositories
{
    public class CandidatesRepositories
    {
        // Field to store the database context, injected via the constructor. 
        private readonly VotingContext _context;

        // Constructor to initialize the repository with a database context.
        public CandidatesRepositories(VotingContext context)
        {
            _context = context;
        }

        // Loads a single candidate by their unique identifier.
        public Candidate Load(Guid id)
        {
            if (id == Guid.Empty)
                return null; // Returns null if the provided ID is empty to prevent errors.
            return _context.Candidates.Local.First(x => x.ID == id); // Fetches the candidate from the local data set.
        }

        // Loads all candidates from the database.
        public IEnumerable<Candidate> LoadAll()
        {
            return _context.Candidates.Local.AsEnumerable(); // Returns an enumerable of all candidates in the local data set.
        }

        // Retrieves candidates filtered by region and party.
        public IEnumerable<Candidate> GetCandidates(Guid regionId, Guid partyId)
        {
            return _context.Candidates.Local.Where(x => x.RegionID == regionId && x.PartyID == partyId); // Filters candidates by region and party.
        }

        // Saves a candidate object to the database, either by inserting or updating.
        public Candidate Save(Candidate entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid(); // Assigns a new GUID if the candidate is new.
                Insert(entity); // Inserts the new candidate into the database.
                return entity;
            }
            Update(entity); // Updates an existing candidate.
            return entity;
        }

        // Deletes a candidate from the database.
        public void Delete(Candidate entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity); // Removes the candidate from the context.
                _context.SaveChanges(); // Persists changes to the database.
            }
        }

        // Helper method to insert a new candidate into the database.
        private void Insert(Candidate entity)
        {
            _context.Candidates.Add(entity);
            _context.SaveChanges();

        }

        // Helper method to update an existing candidate's information in the database
        public void Update(Candidate entity)
        {
            var candidate = _context.Candidates.FirstOrDefault(x => x.ID == entity.ID);
            if (candidate != null)
            {
                candidate.Name = entity.Name;
                candidate.PartyID = entity.PartyID;
                candidate.RegionID = entity.RegionID;
                _context.SaveChanges();
            }
        }

        // Retrieves candidates for a specific election and region.
        public IEnumerable<Candidate> GetCandidatesForRegion(Guid regionID)
        {
           return _context.Candidates.Local.Where(x => x.RegionID == regionID);
        }

        // Retrieves all candidates for a given election.
        public IEnumerable<Candidate> GetCandidatesForElection(Guid electionId)
        {
            var candidatesXElections = _context.CandidateXElection.Where(x => x.ElectionId == electionId).Select(x => x.CandidateId).AsEnumerable();
            return _context.Candidates.Where(x => candidatesXElections.Contains(x.ID));
        }

        // Retrieves candidates for a specific election and region.
        public IEnumerable<Candidate> GetCandidatesForElectionByRegion(Guid electionId, Guid regionID)
        {
            var candidatesXElections = _context.CandidateXElection.Where(x => x.ElectionId == electionId).Select(x => x.CandidateId).AsEnumerable();
            return _context.Candidates.Where(x => candidatesXElections.Contains(x.ID)&& x.RegionID == regionID);
        }

        // Retrieves the CandidateXElection association for a specific candidate and election.
        public CandidateXElection GetElectionCandidate(Guid candidateId, Guid electionId)
        {
            var returns = _context.CandidateXElection.Where(x => x.CandidateId == candidateId  && x.ElectionId == electionId).AsEnumerable();
            if (returns.Count() == 1)
            {
                return returns.First();
            }
            else
            {
                throw new Exception();
            }
        }

        // Updates the CandidateXElection data for a candidate.
        public void SaveElectionCandidate (CandidateXElection candidate)
        {
            _context.CandidateXElection.Update(candidate);
            _context.SaveChanges();
        }

        // Retrieves all CandidateXElection entries for a given election.
        public IEnumerable<CandidateXElection> GetAllCandidatesForElection(Guid electionId)
        {
            return _context.CandidateXElection.Where(x => x.ElectionId == electionId);
        }
    }
}
