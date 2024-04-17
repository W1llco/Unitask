using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using System.ComponentModel.DataAnnotations;

namespace Unitask.Infrastructure.Services
{
    public class VoterService
    {
        //declare
        private readonly VotersRepositories _votersRepositories;
        private readonly CandidateService _candidateService;
        private readonly VotesRepositories _votesRepositories;

        //construsuror for service depenedency injection
        public VoterService(VotersRepositories votersRepositories, CandidateService candidateService, VotesRepositories votesRepositories)
        {
            _votersRepositories = votersRepositories;
            _candidateService = candidateService;
            _votesRepositories = votesRepositories;
        }
        // load object based on id
        public VoterDTO Load(Guid id)
        {
            var entity = _votersRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<VoterDTO> LoadAll()
        {
            var entities = _votersRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public VoterDTO Save(VoterDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votersRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(VoterDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votersRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private VoterDTO GetDTO(Voter entity)
        {
            if (entity == null) return null;
            return new VoterDTO()
            {
                ID = entity.ID,
                UserID = entity.UserID,
                Password = entity.Password,
                VerifcationCode = entity.VerifcationCode,
                IsVerified = entity.IsVerified,
                HasVoted = entity.HasVoted,
                RegionID = entity.RegionID,
                DateOfBirth = entity.DateOfBirth,
                Name = entity.Name,
                Email = entity.Email,
            };
        }

        // convert sata transfer obeject to database model
        private Voter GetEntity(VoterDTO DTO)
        {
            return new Voter()
            {
                ID = DTO.ID,
                UserID = DTO.UserID,
                Password = DTO.Password,
                VerifcationCode = DTO.VerifcationCode,
                IsVerified=DTO.IsVerified,
                HasVoted = DTO.HasVoted,
                RegionID = DTO.RegionID,
                DateOfBirth = DTO.DateOfBirth,
                Name = DTO.Name,
                Email = DTO.Email
            };
        }

        public bool VerifyId(string verificationCode)
        {
            // Find the voter by the verification ID
            var voter = _votersRepositories.FindByVerificationCode(verificationCode);

            // Check if the voter exists and hasn't voted yet
            if (voter != null && !voter.HasVoted)
            {
                return true;
            }

            return false;
        }

        // Method to cast a vote
        public Vote? CastVote(Guid voterId, Guid electionId, Guid candidateId)
        {
            var vote = _votesRepositories.GetVote(voterId, electionId);
            if (vote != null)
            {
                vote.CandiateId = candidateId;
                _votesRepositories.Save(vote);
                _candidateService.IncreaseCandidateVote(candidateId, electionId);
                return vote;
            }
            else
            {
                return null;
            }
            
        }
    }
}
