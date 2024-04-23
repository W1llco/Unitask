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
    // The service class responsible for managing operations related to political parties.
    public class PartyService
    {
        // Repository for accessing party data.
        private readonly PartysRepositories _partysRepositories;

        // Constructor for injecting the party repository.
        public PartyService(PartysRepositories partysRepositories)
        {
            _partysRepositories = partysRepositories;
        }

        // Loads a party by its ID and converts it to a DTO.
        public PartyDTO Load(Guid id)
        {
            var entity = _partysRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all parties and converts them to DTOs.
        public IEnumerable<PartyDTO> LoadAll()
        {
            var entities = _partysRepositories.LoadAll();
            var dtos = new List<PartyDTO>();
            foreach (var e in entities)
            {
                dtos.Add(GetDTO(e));
            }
            return dtos;
        }

        // Saves a party based on the provided DTO.
        public PartyDTO Save(PartyDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _partysRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a party based on the provided DTO.
        public void Delete(PartyDTO DTO)
        {
            var entity = GetEntity(DTO);
            _partysRepositories.Delete(entity);
        }

        // Converts a Party entity to a PartyDTO.
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

        // Converts a PartyDTO to a Party entity.
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

        // Retrieves all parties and converts them to DTOs.
        public IEnumerable<PartyDTO> GetAllParties()
        {
            var entities = _partysRepositories.LoadAll();
            return entities.Select(entity => GetDTO(entity));
        }

        // Retrieves a party by name and converts it to a DTO if found.
        public PartyDTO GetParty(string partyName)
        {
            var party = _partysRepositories.GetParty(partyName);
            if (party != null)
            {
                return new PartyDTO
                {
                    ID = party.ID,
                    Name = party.Name
                };
            }
            return null;
        }
    }
}
