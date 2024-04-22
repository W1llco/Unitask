using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Unitask.Infrastructure.Services
{
    // Service class responsible for managing voter-related operations.
    public class VoterService
    {
        // Repositories for accessing voter and voting data.
        private readonly VotersRepositories _votersRepositories;
        private readonly CandidateService _candidateService;
        private readonly VotesRepositories _votesRepositories;

        // Constructor for dependency injection.
        public VoterService(VotersRepositories votersRepositories, CandidateService candidateService, VotesRepositories votesRepositories)
        {
            _votersRepositories = votersRepositories;
            _candidateService = candidateService;
            _votesRepositories = votesRepositories;
        }

        // Loads a voter by their ID and converts it to a DTO.
        public VoterDTO Load(Guid id)
        {
            var entity = _votersRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all voters and converts each to a DTO.
        public IEnumerable<VoterDTO> LoadAll()
        {
            var entities = _votersRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        // Saves or updates a voter based on the provided DTO.
        public VoterDTO Save(VoterDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votersRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a voter based on the provided DTO.
        public void Delete(VoterDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votersRepositories.Delete(entity);
        }

        // Generates a random verification code using a secure method.
        public string GetRandomCode(int length)
        {
            //secure algorithm for creating passcode 
            var provider = new RNGCryptoServiceProvider();
            var bytes = new byte[length];
            provider.GetBytes(bytes);
            var code = Convert.ToBase64String(bytes).Replace("/", "-").Replace("+", "_");
            return code;
        }

        // Converts a Voter entity to a VoterDTO.
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
                Salt = entity.Salt,
            };
        }

        // Converts a VoterDTO to a Voter entity.
        private Voter GetEntity(VoterDTO DTO)
        {
            return new Voter()
            {
                ID = DTO.ID,
                UserID = DTO.UserID,
                Password = DTO.Password,
                VerifcationCode = DTO.VerifcationCode,
                IsVerified = DTO.IsVerified,
                HasVoted = DTO.HasVoted,
                RegionID = DTO.RegionID,
                DateOfBirth = DTO.DateOfBirth,
                Name = DTO.Name,
                Email = DTO.Email,
                Salt = DTO.Salt,
            };
        }

        // Verifies a voter's ID using their verification code.
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

        // Casts a vote for a voter, updating the vote and candidate records accordingly.
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

        // Confirms a voter's login credentials.
        public VoterDTO ConfirmVoterLogin(VoterDTO voterDTO)
        {
            var voter = GetEntity(voterDTO);
            var confirmedVoter = _votersRepositories.ConfirmVoterLogin(voter);
            if (confirmedVoter != null)
            {
                return GetDTO(confirmedVoter);
            }
            return null;
        }

        // Confirms a voter's login credentials.
        public VoterDTO ConfirmInternalVoterLogin(VoterDTO voterDTO)
        {
            var voter = GetEntity(voterDTO);
            var confirmedVoter = _votersRepositories.ConfirmVoterLogin(voter);
            if (confirmedVoter != null)
            {
                return GetDTO(confirmedVoter);
            }
            return null;
        }

        // Finds voters by name and returns their DTOs.
        public IEnumerable<VoterDTO> FindByName(string name)
        {
            return _votersRepositories.FindByName(name).Select(x => GetDTO(x));
        }

        // Finds voters by email and returns their DTOs.
        public IEnumerable<VoterDTO> FindByEmail(string? email)
        {
            return _votersRepositories.FindByEmail(email).Select(x => GetDTO(x));
        }

        // Updates the information of an existing voter in the database.
        public void Update(VoterDTO voterDTO)
        {
            // Convert DTO to Entity
            Voter updatedVoter = GetEntity(voterDTO);

            // Fetch existing voter from the database
            Voter existingVoter = _votersRepositories.Load(updatedVoter.ID);
            if (existingVoter == null)
                throw new InvalidOperationException("Voter not found.");

            // Update properties
            existingVoter.UserID = updatedVoter.UserID;
            existingVoter.Password = updatedVoter.Password;
            existingVoter.VerifcationCode = updatedVoter.VerifcationCode;
            existingVoter.IsVerified = updatedVoter.IsVerified;
            existingVoter.HasVoted = updatedVoter.HasVoted;
            existingVoter.RegionID = updatedVoter.RegionID;
            existingVoter.DateOfBirth = updatedVoter.DateOfBirth;
            existingVoter.Name = updatedVoter.Name;
            existingVoter.Email = updatedVoter.Email;
            existingVoter.Salt = updatedVoter.Salt;

            // Save the updated entity
            _votersRepositories.Update(existingVoter);
        }
    }
    
}
