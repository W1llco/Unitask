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
    public class PartyService
    {
        //declare
        private readonly PartysRepositories _partysRepositories;

        //construsuror for service depenedency injection
        public PartyService(PartysRepositories partysRepositories)
        {
            _partysRepositories = partysRepositories;
        }
        // load object based on id
        public PartyDTO Load(Guid id)
        {
            var entity = _partysRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<PartyDTO> LoadAll()
        {
            var entities = _partysRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public PartyDTO Save(PartyDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _partysRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(PartyDTO DTO)
        {
            var entity = GetEntity(DTO);
            _partysRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private PartyDTO GetDTO(Party entity)
        {
            if (entity == null) return null;
            return new PartyDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                ElectionID = entity.ElectionID,
                RegionID = entity.RegionID
            };
        }

        // convert sata transfer obeject to database model
        private Party GetEntity(PartyDTO DTO)
        {
            return new Party()
            {
                ID = DTO.ID,
                Name = DTO.Name,
                ElectionID = DTO.ElectionID,
                RegionID = DTO.RegionID
            };
        }

        // Retrieves all party entities, converting them to PartyDTO objects
        public IEnumerable<PartyDTO> GetAllParties()
        {
            var entities = _partysRepositories.LoadAll();
            return entities.Select(entity => GetDTO(entity));
        }
    }
}
