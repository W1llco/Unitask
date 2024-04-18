using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using Unitask.DTOs.ViewModels;

namespace Unitask.Infrastructure.Services
{
    public class ElectionService
    {
        //declare
        private readonly ElectionsRepositories _electionsRepositories;
        private readonly VotingSystemService _votingSystemService;
        private readonly CandidatesRepositories _candidatesRepositories;
        private readonly RegionsRepositories _regionsRepositories;
        private readonly CandidateService _candidateService;

        //construsuror for service depenedency injection
        public ElectionService(ElectionsRepositories electionsRepositories, VotingSystemService votingSystemService, CandidatesRepositories candidatesRepositories, RegionsRepositories regionsRepositories, CandidateService candidateService)
        {
            _electionsRepositories = electionsRepositories;
            _votingSystemService = votingSystemService;
            _candidatesRepositories = candidatesRepositories;
            _regionsRepositories = regionsRepositories;
            _candidateService = candidateService;
        }
        // load object based on id
        public ElectionDTO Load(Guid id)
        {
            var entity = _electionsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<ElectionDTO> LoadAll()
        {
            var entities = _electionsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public ElectionDTO Save(ElectionDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _electionsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(ElectionDTO DTO)
        {
            var entity = GetEntity(DTO);
            _electionsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private ElectionDTO GetDTO(Election entity)
        {
            if (entity == null) return null;
            return new ElectionDTO()
            {
                ID = entity.ID, 
                Winner = entity.Winner,
                VoteSystem = entity.VoteSystem,
                RegionID = entity.RegionID,
                Name = entity.Name,

            };
        }

        // convert sata transfer obeject to database model
        private Election GetEntity(ElectionDTO DTO)
        {
            return new Election()
            {
                ID = DTO.ID,
                Winner = DTO.Winner,
                VoteSystem = DTO.VoteSystem,
                RegionID = DTO.RegionID,
                Name = DTO.Name,
            };
        }
        
        public PartyDTO CountElection(Guid electionId, Guid votingSystemId)
        {
            var votingSystem = _votingSystemService.LoadAll();
            var candidates = _candidatesRepositories.GetAllCandidatesForElection(electionId);
            var regions = _regionsRepositories.LoadAll();

            if (votingSystemId == votingSystem.Single(x => x.Name == "Proportional Representation").ID)
            {
                return _votingSystemService.GetWinnerProportional(candidates);
            }
            else
            {
                var candidateViewModels = _candidateService.CandidateXElectionViewModels(candidates);
                var regionWinners = new List<CandidateXElectionViewModel>();
                var scotland = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "Scotland").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);
                var england = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "England").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);
                var wales = candidateViewModels.Where(x => x.Candidate.RegionID == regions.Single(x => x.Name == "Wales").ID).OrderByDescending(x => x.CandidateXElection.VoteCount);

                regionWinners.Add(scotland.First());
                regionWinners.Add(england.First());
                regionWinners.Add(wales.First());

                return _votingSystemService.GetWinnerFPTP(regionWinners.Select(x => x.CandidateXElection));
            }
        }
    }
}
