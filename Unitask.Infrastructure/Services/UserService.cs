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
    // Service class responsible for managing user-related operations.
    public class UserService
    {
        // Repository for accessing user data.
        private readonly UsersRepositories _usersRepositories;

        // Constructor for dependency injection.
        public UserService(UsersRepositories usersRepositories)
        {
            _usersRepositories = usersRepositories;
        }

        // Loads a user by their ID and converts it to a DTO.
        public UserDTO Load(Guid id)
        {
            var entity = _usersRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all users and converts each to a DTO.
        public IEnumerable<UserDTO> LoadAll()
        {
            var dtos = new List<UserDTO>();
            foreach (var c in _usersRepositories.LoadAll())
            {
                dtos.Add(GetDTO(c));
            }
            return dtos;
        }

        // Saves or updates a user based on the provided DTO.
        public UserDTO Save(UserDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _usersRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes a user based on the provided DTO.
        public void Delete(UserDTO DTO)
        {
            var entity = GetEntity(DTO);
            _usersRepositories.Delete(entity);
        }

        // Converts a User entity to a UserDTO.
        private UserDTO GetDTO(User entity)
        {
            if (entity == null) return null;
            return new UserDTO()
            {
                ID = entity.ID,
                Username = entity.Username,
            };
        }

        // Converts a UserDTO to a User entity.
        private User GetEntity(UserDTO DTO)
        {
            return new User()
            {
                ID = DTO.ID,
                Username = DTO.Username,
            };
        }
    }
}
