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

        //construsuror for service depenedency injection
        public VoterService(VotersRepositories votersRepositories)
        {
            _votersRepositories = votersRepositories;
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
                VerifcationId = entity.VerifcationId,
                HasVoted = entity.HasVoted, 
                RegionID = entity.RegionID
            };
        }

        // convert sata transfer obeject to database model
        private Voter GetEntity(VoterDTO DTO)
        {
            return new Voter()
            {
                ID = DTO.ID,
                UserID = DTO.UserID,
                VerifcationId = DTO.VerifcationId,
                HasVoted = DTO.HasVoted,
                RegionID = DTO.RegionID
            };
        }
    }
}
