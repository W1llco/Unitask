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
    public class ElectionService
    {
        //declare
        private readonly ElectionsRepositories _electionsRepositories;

        //construsuror for service depenedency injection
        public ElectionService(ElectionsRepositories electionsRepositories)
        {
            _electionsRepositories = electionsRepositories;
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
    }
}
