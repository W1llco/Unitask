using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using UniTask.Entites;
using Unitask.DTOs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Unitask.Infrastructure.Services
{
    // Class responsible for handling business logic related to candidate operations.
    public class CandidateService
    {
        // Repository for accessing candidate data.
        private readonly CandidatesRepositories _candidatesRepositories;

        // Constructor for injecting the candidate repository.
        public CandidateService(CandidatesRepositories candidatesRepositories)
        {
            _candidatesRepositories = candidatesRepositories;
        }

        // Retrieves a candidate by their ID and converts them to a DTO.
        public CandidateDTO Load(Guid id)
        {
            var entity = _candidatesRepositories.Load(id);

            return GetDTO(entity);
        }

        // Retrieves all candidates and converts them to DTOs.
        public IEnumerable<CandidateDTO> LoadAll()
        {
            var dtos = new List<CandidateDTO>();
            foreach (var c in _candidatesRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Saves or updates a candidate based on the DTO provided.
        public CandidateDTO Save(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _candidatesRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a candidate based on the DTO provided.
        public void Delete(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            _candidatesRepositories.Delete(entity);
        }

        // Converts a Candidate entity to a CandidateDTO.
        private CandidateDTO GetDTO(Candidate entity)
        {
            if (entity == null) return null;
            return new CandidateDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                PartyID = entity.PartyID,
                RegionID = entity.RegionID
            };
        }

        // Converts a CandidateDTO to a Candidate entity.
        private Candidate GetEntity(CandidateDTO DTO)
        {
            return new Candidate()
            {
                ID = DTO.ID,
                Name = DTO.Name,
                PartyID = DTO.PartyID,
                RegionID = DTO.RegionID
            };
        }

        // Converts a CandidateXElection entity to a CandidateXElectionDTO.
        private CandidateXElectionDTO GetCXEDTO(CandidateXElection entity)
        {
            if (entity == null) return null;
            return new CandidateXElectionDTO()
            {
                Id = entity.Id,
                CandidateId = entity.CandidateId,
                ElectionId = entity.ElectionId,
                VoteCount = entity.VoteCount
            };
        }

        // Converts a CandidateXElectionDTO to a CandidateXElection entity.
        private CandidateXElection GetCXEEntity(CandidateXElectionDTO DTO)
        {
            return new CandidateXElection()
            {
                Id = DTO.Id,
                CandidateId = DTO.CandidateId,
                ElectionId = DTO.ElectionId,
                VoteCount = DTO.VoteCount
            };
        }

        // Increases the vote count for a candidate in a specific election.
        public bool IncreaseCandidateVote(Guid candidateId, Guid electionId)
        {
            var candidate = _candidatesRepositories.GetElectionCandidate(candidateId, electionId);
            
            // Verify the candidate exists
            if (candidate != null)
            {
                candidate.VoteCount += 1;
                _candidatesRepositories.SaveElectionCandidate(candidate);
                return true;
            }

            return false;
        }

        // Retrieves all candidates
        public IEnumerable<CandidateDTO> GetAllCandidates()
        {
            return LoadAll();
        }

        // Retrieves all candidates with additional information from the CandidateXElection table.
        public IEnumerable<CandidateXElectionViewModel> CandidateXElectionViewModels(IEnumerable<CandidateXElectionDTO> candidateXElections)
        {
            var candidates = new List<CandidateXElectionViewModel>();
            foreach (var c in candidateXElections)
            {
                candidates.Add(new CandidateXElectionViewModel()
                {
                    CandidateXElection = c,
                    Candidate = GetDTO(_candidatesRepositories.Load(c.CandidateId))
                });
            }
            return candidates;
        }

        // Retrieves all candidates for a given region and converts them to DTOs.
        public IEnumerable<CandidateDTO> GetCandidatesForRegion(Guid regionID)
        {
            var dtos = new List<CandidateDTO>();
            foreach (var c in _candidatesRepositories.GetCandidatesForRegion(regionID))
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Retrieves all candidate entries for a specific election.
        public IEnumerable<CandidateXElectionDTO> GetAllCandidatesForElection(Guid electionId)
        {
            return _candidatesRepositories.GetAllCandidatesForElection(electionId).Select(GetCXEDTO);
        }

        // Retrieves candidates filtered by region and party.
        public IEnumerable<CandidateDTO> GetCandidates(Guid regionId, Guid partyId)
        {
            var candidates = _candidatesRepositories.GetCandidates(regionId, partyId);
            return candidates.Select(GetDTO);
        }

        // Retrieves candidates filtered by region and party.
        public IEnumerable<CandidateDTO> GetCandidatesForElectionByRegion(Guid electionID, Guid regionID)
        {
            var candidates = _candidatesRepositories.GetCandidatesForElectionByRegion(electionID, regionID);
            return candidates.Select(GetDTO);
        }

        // Updates a candidate based on changes in the DTO and returns the updated DTO.
        public CandidateDTO Update(CandidateDTO selectedCandidate)
        {
            var entity = _candidatesRepositories.Load(selectedCandidate.ID);
            entity.Name = selectedCandidate.Name;
            entity.PartyID = selectedCandidate.PartyID;
            entity.RegionID = selectedCandidate.RegionID;
            _candidatesRepositories.Save(entity);
            return GetDTO(entity);
        }

    }

}
