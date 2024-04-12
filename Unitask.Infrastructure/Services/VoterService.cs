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

        //construsuror for service depenedency injection
        public VoterService(VotersRepositories votersRepositories, CandidateService candidateService)
        {
            _votersRepositories = votersRepositories;
            _candidateService = candidateService; 
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
                HasVoted = entity.HasVoted, 
                RegionID = entity.RegionID,
                DateOfBirth = entity.DateOfBirth
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
                HasVoted = DTO.HasVoted,
                RegionID = DTO.RegionID,
                DateOfBirth = DTO.DateOfBirth
            };
        }

        public bool VerifyId(string verificationCode)
        {
            // Find the voter by the verification ID
            var voter = _votersRepositories.FindByVerificationId(verificationCode);

            // Check if the voter exists and hasn't voted yet
            if (voter != null && !voter.HasVoted)
            {
                return true;
            }

            return false;
        }

        // Method to cast a vote
        public void CastVote(Guid voterId, Guid candidateId)
        {
            var voter = _votersRepositories.Load(voterId);

            // Verify the voter exists and hasn't voted yet
            if (voter != null && !voter.HasVoted)
            {
                // Now using CandidateService to increase the candidate's vote
                bool voteIncreased = _candidateService.IncreaseCandidateVote(candidateId);

                if (voteIncreased)
                {
                    voter.HasVoted = true;
                    _votersRepositories.Save(voter);
                }
            }
        }
    }
}
