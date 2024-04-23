using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.data.Repositories;
using Unitask.DTOs;
using UniTask.entites;

namespace Unitask.Infrastructure.Services
{
    public class VoteService
    {
        // Repository for accessing vote data.
        private readonly VotesRepositories _votesRepositories;

        // Repository for accessing vote data.
        public VoteService(VotesRepositories votesRepositories)
        {
            _votesRepositories = votesRepositories;
        }

        // Load a vote object based on its ID.
        public VoteDTO Load(Guid id)
        {
            var entity = _votesRepositories.Load(id);

            return GetDTO(entity);
        }

        // Load all vote objects and convert each to a DTO.
        public IEnumerable<VoteDTO> LoadAll()
        {
            var dtos = new List<VoteDTO>();
            foreach (var c in _votesRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Convert a data transfer object to a database model for saving.
        public VoteDTO Save(VoteDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votesRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Convert a database model to a data transfer object (DTO).
        public void Delete(VoteDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votesRepositories.Delete(entity);
        }

        // Convert a database model to a data transfer object (DTO).
        private VoteDTO GetDTO(Vote entity)
        {
            if (entity == null) return null;
            return new VoteDTO()
            {
                ID = entity.ID,
                VoterId = entity.VoterId,
                CandiateId = entity.CandiateId,
                ElectionId = entity.ElectionId
            };
        }

        // convert sata transfer obeject to database model
        private Vote GetEntity(VoteDTO DTO)
        {
            return new Vote()
            {
                ID = DTO.ID,
                VoterId = DTO.VoterId,
                CandiateId = DTO.CandiateId,
                ElectionId = DTO.ElectionId
            };
        }

        // Get a list of used votes for a specific voter.
        public IEnumerable<Guid> GetUsedVotes(Guid voterId)
        {
            return _votesRepositories.GetUsedVotes(voterId);
        }
    }
}
