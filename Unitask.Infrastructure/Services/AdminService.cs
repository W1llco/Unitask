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
    public class AdminService
    {
        //declare
        private readonly AdminsRepositories _adminsRepositories;

        //construsuror for service depenedency injection
        public AdminService(AdminsRepositories adminsRepositories)
        {
            _adminsRepositories = adminsRepositories;
        }
        // load object based on id
        public AdminDTO Load(Guid id)
        {
            var entity = _adminsRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<AdminDTO> LoadAll()
        {
            var entities = _adminsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public AdminDTO Save(AdminDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _adminsRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(AdminDTO DTO)
        {
            var entity = GetEntity(DTO);
            _adminsRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private AdminDTO GetDTO(Admin entity)
        {
            if (entity == null) return null;
            return new AdminDTO()
            {
                ID = entity.ID,
                UserID = entity.UserID
            };
        }

        // convert sata transfer obeject to database model
        private Admin GetEntity(AdminDTO DTO)
        {
            return new Admin()
            {
                ID = DTO.ID,
                UserID = DTO.UserID
            };
        }
    }
}
