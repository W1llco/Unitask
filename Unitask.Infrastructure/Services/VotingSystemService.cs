using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using UniTask.Entites;

namespace Unitask.Infrastructure.Services
{
    // The service responsible for managing Voting System Service related operations.
    public class VotingSystemService
    {
        // Dependencies are injected via the constructor.
        private readonly VotingSystemsRepositories _votingSystemsRepositories;
        private readonly PartyService _partyService;
        private readonly CandidateService _candidateService;

        // Constructor for dependency injection.
        public VotingSystemService(VotingSystemsRepositories votingSystemsRepositories, PartyService partyService, CandidateService candidateService)
        {
            _votingSystemsRepositories = votingSystemsRepositories;
            _partyService = partyService;
            _candidateService = candidateService;
        }

        // Loads an VotingSystem by its ID and converts it to a DTO.
        public VotingSystemDTO Load(Guid id)
        {
            var entity = _votingSystemsRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all VotingSystem and converts them to DTOs.
        public IEnumerable<VotingSystemDTO> LoadAll()
        {
            var entities = _votingSystemsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        // Saves an VotingSystem based on the provided DTO.
        public VotingSystemDTO Save(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votingSystemsRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes an VotingSystem based on the provided DTO.
        public void Delete(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votingSystemsRepositories.Delete(entity);
        }

        // Converts an VotingSystem entity to an VotingSystemDTO.
        private VotingSystemDTO GetDTO(VotingSystem entity)
        {
            if (entity == null) return null;
            return new VotingSystemDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // Converts an VotingSystemDTO to an VotingSystem entity.
        private VotingSystem GetEntity(VotingSystemDTO DTO)
        {
            return new VotingSystem()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }

        // Get the winner using First-Past-the-Post (FPTP) voting system.
        public PartyDTO GetWinnerFPTP(IEnumerable<CandidateXElectionDTO> regionWinners)
        {   
            int labourWins = 0;
            int conservativeWins = 0;
            var partys = _partyService.LoadAll();
            // going through each winner and increasing the wins for the party
            foreach (CandidateXElectionDTO candidateXElection in regionWinners)
            {
                // Return the party with the most votes.
                var candidate = _candidateService.Load(candidateXElection.CandidateId);
                if (candidate.PartyID == partys.First(x => x.Name == "Labour").ID)
                {
                    labourWins++;
                }
                else
                {
                    conservativeWins++;
                }
            }
            // Return the party with the most votes.
            return labourWins > conservativeWins ? partys.Single(x => x.Name == "Labour") : partys.Single(x => x.Name == "Conservative");
        }

        // Get the winner using Proportional Representation voting system.
        public PartyDTO GetWinnerProportional(IEnumerable<CandidateXElectionDTO> candidates)
        {
            var partys = _partyService.LoadAll();
            int labourVoteCount = 0;
            int conservativeVoteCount = 0;
            var candidateViewModels = _candidateService.CandidateXElectionViewModels(candidates);
            // Count the total votes for each party.
            foreach (var c in candidateViewModels)
            {
                if (c.Candidate.PartyID == partys.First(x => x.Name == "Labour").ID)
                {
                    labourVoteCount += c.CandidateXElection.VoteCount ;
                }
                else
                {
                    conservativeVoteCount+= c.CandidateXElection.VoteCount;
                }
            }
            // Return the party with the most votes.
            return labourVoteCount > conservativeVoteCount ? partys.Single(x => x.Name == "Labour") : partys.Single(x => x.Name == "Conservative");
        }
    }
}
