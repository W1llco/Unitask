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
    public class VotingSystemService
    {
        //declare
        private readonly VotingSystemsRepositories _votingSystemsRepositories;
        private readonly PartyService _partyService;
        private readonly CandidateService _candidateService;

        //construsuror for service depenedency injection
        public VotingSystemService(VotingSystemsRepositories votingSystemsRepositories, PartyService partyService, CandidateService candidateService)
        {
            _votingSystemsRepositories = votingSystemsRepositories;
            _partyService = partyService;
            _candidateService = candidateService;
        }

        // load object based on id
        public VotingSystemDTO Load(Guid id)
        {
            var entity = _votingSystemsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<VotingSystemDTO> LoadAll()
        {
            var entities = _votingSystemsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public VotingSystemDTO Save(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votingSystemsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votingSystemsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private VotingSystemDTO GetDTO(VotingSystem entity)
        {
            if (entity == null) return null;
            return new VotingSystemDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // convert sata transfer obeject to database model
        private VotingSystem GetEntity(VotingSystemDTO DTO)
        {
            return new VotingSystem()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }

        public PartyDTO GetWinnerFPTP(IEnumerable<CandidateXElectionDTO> regionWinners)
        {   
            int labourWins = 0;
            int conservativeWins = 0;
            var partys = _partyService.LoadAll();
            foreach (CandidateXElectionDTO candidateXElection in regionWinners)
            {
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

            return labourWins > conservativeWins ? partys.Single(x => x.Name == "Labour") : partys.Single(x => x.Name == "Conservative");
        }

        public PartyDTO GetWinnerProportional(IEnumerable<CandidateXElectionDTO> candidates)
        {
            var partys = _partyService.LoadAll();
            int labourVoteCount = 0;
            int conservativeVoteCount = 0;
            var candidateViewModels = _candidateService.CandidateXElectionViewModels(candidates);

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
            
            return labourVoteCount > conservativeVoteCount ? partys.Single(x => x.Name == "Labour") : partys.Single(x => x.Name == "Conservative");
        }
    }
}
