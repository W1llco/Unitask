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
    public class VotingSystemService
    {
        //declare
        private readonly VotingSystemsRepositories _votingSystemsRepositories;

        //construsuror for service depenedency injection
        public VotingSystemService(VotingSystemsRepositories votingSystemsRepositories)
        {
            _votingSystemsRepositories = votingSystemsRepositories;
        }
        // load object based on id
        public VotingSystemDTO Load(Guid id)
        {
            var entity = _votingSystemsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<VotingSystemDTO> LoadAll()
        {
            var entities = _votingSystemsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public VotingSystemDTO Save(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _votingSystemsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(VotingSystemDTO DTO)
        {
            var entity = GetEntity(DTO);
            _votingSystemsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private VotingSystemDTO GetDTO(VotingSystem entity)
        {
            if (entity == null) return null;
            return new VotingSystemDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // convert sata transfer obeject to database model
        private VotingSystem GetEntity(VotingSystemDTO DTO)
        {
            return new VotingSystem()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }
    }
}
