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
        //declare
        private readonly VotesRepositories _votesRepositories;

        //construsuror for service depenedency injection
        public VoteService(VotesRepositories votesRepositories)
        {
            _votesRepositories = votesRepositories;
        }
        // load object based on id
        public VoteDTO Load(Guid id)
        {
            var entity = _votesRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<VoteDTO> LoadAll()
        {
            var entities = _votesRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public VoteDTO Save(VoteDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votesRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(VoteDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votesRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
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
    }
}
