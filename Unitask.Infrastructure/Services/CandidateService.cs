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
    public class CandidateService
    {
        //declare
        private readonly CandidatesRepositories _candidatesRepositories;

        //construsuror for service depenedency injection
        public CandidateService(CandidatesRepositories candidatesRepositories)
        {
            _candidatesRepositories = candidatesRepositories;
        }
        // load object based on id
        public CandidateDTO Load(Guid id)
        {
            var entity = _candidatesRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<CandidateDTO> LoadAll()
        {
            var entities = _candidatesRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public CandidateDTO Save(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _candidatesRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(CandidateDTO DTO)
        {
            var entity = GetEntity(DTO);
            _candidatesRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private CandidateDTO GetDTO(Candidate entity)
        {
            if (entity == null) return null;
            return new CandidateDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                VoteCount = entity.VoteCount,
                PartyID = entity.PartyID,
                RegionID = entity.RegionID
            };
        }

        // convert sata transfer obeject to database model
        private Candidate GetEntity(CandidateDTO DTO)
        {
            return new Candidate()
            {
                ID = DTO.ID,
                Name = DTO.Name,
                VoteCount = DTO.VoteCount,
                PartyID = DTO.PartyID,
                RegionID = DTO.RegionID
            };
        }
    }
}
