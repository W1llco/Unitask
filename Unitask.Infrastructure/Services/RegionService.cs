using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unitask.DTOs;
using UniTask.data.Repositories;
using UniTask.entites;

namespace Unitask.Infrastructure.Services
{
    // Class responsible for managing operations related to regions.
    public class RegionService
    {
        // Repositories for accessing region and candidate data.
        private readonly RegionsRepositories _regionsRepositories;
        private readonly CandidatesRepositories _candidatesRepositories;

        // Constructor for injecting dependencies.
        public RegionService(RegionsRepositories regionsRepositories, CandidatesRepositories candidatesRepositories)
        {
            _regionsRepositories = regionsRepositories;
            _candidatesRepositories = candidatesRepositories;
        }

        // Loads a region by its ID and converts it to a DTO.
        public RegionDTO Load(Guid id)
        {
            var entity = _regionsRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all regions and converts each to a DTO.
        public IEnumerable<RegionDTO> LoadAll()
        {
            var dtos = new List<RegionDTO>();
            foreach (var c in _regionsRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Saves a region based on the provided DTO.
        public RegionDTO Save(RegionDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _regionsRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a region based on the provided DTO.
        public void Delete(RegionDTO DTO)
        {
            var entity = GetEntity(DTO);
            _regionsRepositories.Delete(entity);
        }

        // Converts a Region entity to a RegionDTO.
        private RegionDTO GetDTO(Region entity)
        {
            if(entity == null) return null;
            return new RegionDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // Converts a RegionDTO to a Region entity.
        private Region GetEntity(RegionDTO DTO)
        {
            return new Region()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }

        // Retrieves candidates associated with a specific region.
        public IEnumerable<Candidate> GetCandidatesForRegion (Guid RegionID)
        {
            return _candidatesRepositories.GetCandidatesForRegion(RegionID);
        }

        // Retrieves a region by name and converts it to a DTO if found.
        public RegionDTO GetRegion(string regionName)
        {
            var region = _regionsRepositories.GetRegion(regionName);
            if (region != null)
            {
                return new RegionDTO
                {
                    ID = region.ID,
                    Name = region.Name
                };
            }
            return null;
        }
    }
}
