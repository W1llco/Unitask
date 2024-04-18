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

namespace Unitask.Infrastructure.Services
{
    public class CandidateService
    {
        //declare
        private readonly CandidatesRepositories _candidatesRepositories;

        //construsuror for service depenedency injection
        public CandidateService(CandidatesRepositories candidatesRepositories)
        {
            _candidatesRepositories = candidatesRepositories;
        }
        // load object based on id
        public CandidateDTO Load(Guid id)
        {
            var entity = _candidatesRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<CandidateDTO> LoadAll()
        {
            var entities = _candidatesRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public CandidateDTO Save(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _candidatesRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            _candidatesRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
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

        // convert sata transfer obeject to database model
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

        //converting database modle to data treansfer object dto
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

        // convert sata transfer obeject to database model
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

        // Method to increase a candidate's vote count
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

        public IEnumerable<CandidateDTO> GetAllCandidates()
        {
            return LoadAll();
        }

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

        public IEnumerable<CandidateDTO> GetCandidatesForRegion(Guid regionID)
        {
            return _candidatesRepositories.GetCandidatesForRegion(regionID).Select(GetDTO);
        }

        public IEnumerable<CandidateXElectionDTO> GetAllCandidatesForElection(Guid electionId)
        {
            return _candidatesRepositories.GetAllCandidatesForElection(electionId).Select(GetCXEDTO);
        }

        //public IEnumerable<CandidateXElection> GetRegionWinners(Guid electionId)
        //{
        //    var candidateXElection = _
        //        var candidates = _candidatesRepositories.GetAllCandidatesForElection(electionId);
        //}
    }

}
