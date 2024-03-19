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
    public class ResultService
    {
        //declare
        private readonly ResultsRepositories _resultsRepositories;

        //construsuror for service depenedency injection
        public ResultService(ResultsRepositories resultsRepositories)
        {
            _resultsRepositories = resultsRepositories;
        }
        // load object based on id
        public ResultDTO Load(Guid id)
        {
            var entity = _resultsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<ResultDTO> LoadAll()
        {
            var entities = _resultsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public ResultDTO Save(ResultDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _resultsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(ResultDTO DTO)
        {
            var entity = GetEntity(DTO);
            _resultsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private ResultDTO GetDTO(Result entity)
        {
            if (entity == null) return null;
            return new ResultDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // convert sata transfer obeject to database model
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
