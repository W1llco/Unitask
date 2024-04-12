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
    public class UserService
    {
        //declare
        private readonly UsersRepositories _usersRepositories;

        //construsuror for service depenedency injection
        public UserService(UsersRepositories usersRepositories)
        {
            _usersRepositories = usersRepositories;
        }
        // load object based on id
        public UserDTO Load(Guid id)
        {
            var entity = _usersRepositories.Load(id);

            return GetDTO(entity);
        }

        //select them all get them each
        public IEnumerable<UserDTO> LoadAll()
        {
            var entities = _usersRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        //cobverting data transfer object to database model for svaing
        public UserDTO Save(UserDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _usersRepositories.Save(entity);
            return GetDTO(entity);
        }

        public void Delete(UserDTO DTO)
        {
            var entity = GetEntity(DTO);
            _usersRepositories.Delete(entity);
        }

        //converting database modle to data treansfer object dto
        private UserDTO GetDTO(User entity)
        {
            if (entity == null) return null;
            return new UserDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                Username = entity.Username,
                Password = entity.Password,
                IsAdmin = entity.IsAdmin,
                OneTimeCode = entity.OneTimeCode,
                DateOfBirth = entity.DateOfBirth
            };
        }
        // convert sata transfer obeject to database model
        private User GetEntity(UserDTO DTO)
        {
            return new User()
            {
                ID = DTO.ID,
                Name = DTO.Name,
                Username = DTO.Username,
                Password = DTO.Password,
                IsAdmin = DTO.IsAdmin,
                OneTimeCode = DTO.OneTimeCode,
                DateOfBirth = DTO.DateOfBirth
            };
        }
    }
}
