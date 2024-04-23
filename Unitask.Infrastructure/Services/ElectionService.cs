using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using Unitask.DTOs.ViewModels;
using Microsoft.EntityFrameworkCore;
using UniTask.Entites;
using System.Net.Http.Headers;

namespace Unitask.Infrastructure.Services
{
    // The service responsible for managing election-related operations.
    public class ElectionService
    {
        // Dependencies are injected via the constructor.
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly VotingSystemService _votingSystemService;
        private readonly CandidatesRepositories _candidatesRepositories;
        private readonly RegionsRepositories _regionsRepositories;
        private readonly CandidateService _candidateService;

        // Constructor for dependency injection.
        public ElectionService(ElectionsRepositories electionsRepositories, VotingSystemService votingSystemService, CandidatesRepositories candidatesRepositories, RegionsRepositories regionsRepositories, CandidateService candidateService)
        {
            _electionsRepositories = electionsRepositories;
            _votingSystemService = votingSystemService;
            _candidatesRepositories = candidatesRepositories;
            _regionsRepositories = regionsRepositories;
            _candidateService = candidateService;
        }

        // Loads an election by its ID and converts it to a DTO.
        public ElectionDTO Load(Guid id)
        {
            var entity = _electionsRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all elections and converts them to DTOs.
        
        public IEnumerable<ElectionDTO> LoadAll()
        {
            var dtos = new List<ElectionDTO>();
            foreach (var c in _electionsRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos.OrderBy(e => e.StartTime);
        }


        // Saves an election based on the provided DTO.
        public ElectionDTO Save(ElectionDTO DTO)
        {
            var entity = GetEntity(DTO);
            var savedEntity = _electionsRepositories.Save(entity);
            return GetDTO(savedEntity);
        }

        // Deletes an election based on the provided DTO.
        public void Delete(ElectionDTO DTO)
        {
            var entity = GetEntity(DTO);
            _electionsRepositories.Delete(entity);
        }

        // Converts an Election entity to an ElectionDTO.
        private ElectionDTO GetDTO(Election entity)
        {
            if (entity == null) return null;
            return new ElectionDTO()
            {
                ID = entity.ID, 
                Winner = entity.Winner,
                VoteSystem = entity.VoteSystem,
                RegionID = entity.RegionID,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                Name = entity.Name,


            };
        }

        // Converts an ElectionDTO to an Election entity.
        private Election GetEntity(ElectionDTO DTO)
        {
            return new Election()
            {
                ID = DTO.ID,
                Winner = DTO.Winner,
                VoteSystem = DTO.VoteSystem,
                RegionID = DTO.RegionID,
                StartTime = DTO.StartTime,
                EndTime = DTO.EndTime,
                Name = DTO.Name,

            };
        }

        // Counts votes for a specified election and voting system.
        public PartyDTO? CountElection(Guid electionId, Guid votingSystemId)
        { 
            // Loads all the data 
            var votingSystem = _votingSystemService.LoadAll();
            var candidates = _candidateService.GetAllCandidatesForElection(electionId);
            var regions = _regionsRepositories.LoadAll();
            //Check the voting system type that is used
            if (votingSystemId == votingSystem.Single(x => x.Name == "Proportional Representation").ID)
            {
                // run the Proportional vote count
                return _votingSystemService.GetWinnerProportional(candidates);
            }
            else
            {   
                //We need to know the vote count for each candidate for each election the vote count is on candidatXelection but the region is on candidate
                var candidateViewModels = _candidateService.CandidateXElectionViewModels(candidates);
                var regionWinners = new List<CandidateXElectionViewModel>();
                // Seperating the view models into regions to find the winner for each region
                var scotland = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "Scotland").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);
                var england = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "England").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);
                var wales = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "Wales").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);
                //Add just the region winner to a list
                regionWinners.Add(scotland.First());
                regionWinners.Add(england.First());
                regionWinners.Add(wales.First());
                // Returns the winner based on the region winners
                return _votingSystemService.GetWinnerFPTP(regionWinners.Select(x => x.CandidateXElection));
            }
        }

        // Updates an election with the provided DTO.
        public ElectionDTO Update(ElectionDTO DTO)
        {
            // Convert the DTO to an entity
            var entity = GetEntity(DTO);

            // Check if the entity exists before attempting an update
            var existingElection = _electionsRepositories.Load(entity.ID);
            

            // Update the entity using the repository's update method
            _electionsRepositories.Update(entity);
            var updatedEntity = _electionsRepositories.Load(entity.ID);
            return GetDTO(updatedEntity);
        }

        public Election Save(Election entity)
        {
            return _electionsRepositories.Save(entity);
        }

        // Saves a candidate to a specific election.
        public void SaveElectionCandidate(Guid electionId, Guid candidateId)
        {
            _electionsRepositories.SaveElectionCandidate(electionId, candidateId);
        }

        // Saves a candidate to a specific election.
        public IEnumerable<ElectionDTO> LoadAllActive()
        {
   
            var dtos = new List<ElectionDTO>();
            foreach (var c in _electionsRepositories.LoadAllActive())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos.OrderBy(e => e.StartTime);
        }
    }
}
