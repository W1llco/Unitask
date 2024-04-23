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
    // The service class responsible for managing operations related to election results.
    public class ResultService
    {
        // Repository for accessing result data.
        private readonly ResultsRepositories _resultsRepositories;

        // Constructor for dependency injection, which enhances testability and modularity.
        public ResultService(ResultsRepositories resultsRepositories)
        {
            _resultsRepositories = resultsRepositories;
        }

        // Loads a result by its ID and converts it to a DTO.
        public ResultDTO Load(Guid id)
        {
            var entity = _resultsRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all results and converts each to a DTO.
        public IEnumerable<ResultDTO> LoadAll()
        {
            var dtos = new List<ResultDTO>();
            foreach (var c in _resultsRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Saves or updates a result based on the provided DTO.
        public ResultDTO Save(ResultDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _resultsRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a result based on the provided DTO.
        public void Delete(ResultDTO DTO)
        {
            var entity = GetEntity(DTO);
            _resultsRepositories.Delete(entity);
        }

        // Helper method to convert a Result entity to a ResultDTO.
        private ResultDTO GetDTO(Result entity)
        {
            if (entity == null) return null;
            return new ResultDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // Helper method to convert a ResultDTO to a Result entity.
        private Result GetEntity(ResultDTO DTO)
        {
            return new Result()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }
    }
}
