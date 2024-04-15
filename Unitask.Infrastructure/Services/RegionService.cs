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
    public class RegionService
    {
        //declare
        private readonly RegionsRepositories _regionsRepositories;
        private readonly CandidatesRepositories _candidatesRepositories;

        //construsuror for service depenedency injection
        public RegionService(RegionsRepositories regionsRepositories, CandidatesRepositories candidatesRepositories)
        {
            _regionsRepositories = regionsRepositories;
            _candidatesRepositories = candidatesRepositories;
        }
        // load object based on id
        public RegionDTO Load(Guid id)
        {
            var entity = _regionsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<RegionDTO> LoadAll()
        {
            var entities = _regionsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public RegionDTO Save(RegionDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _regionsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(RegionDTO DTO)
        {
            var entity = GetEntity(DTO);
            _regionsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private RegionDTO GetDTO(Region entity)
        {
            if(entity == null) return null;
            return new RegionDTO()
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        // convert sata transfer obeject to database model
        private Region GetEntity(RegionDTO DTO)
        {
            return new Region()
            {
                ID = DTO.ID,
                Name = DTO.Name
            };
        }

        // Get the Candidates for the region
        public IEnumerable<Candidate> GetCandidatesForRegion (Guid RegionID)
        {
            return _candidatesRepositories.GetCandidatesForRegion(RegionID);
        }

        //public Candidate GetRegionWinner(Guid RegionID, IEnumerable<Candidate> candidates )
        //{
        //    //var RegionCanidates = GetCandidatesForRegion(RegionID).OrderByDescending(x => x.VoteCount) ;
        //    //return RegionCanidates.FirstOrDefault();
        //}
    }
}
