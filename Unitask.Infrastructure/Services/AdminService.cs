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
    // The service class responsible for handling business logic for admin-related data.
    public class AdminService
    {
        // Dependencies are injected via the constructor to promote loose coupling
        private readonly AdminsRepositories _adminsRepositories;
        private readonly VotersRepositories _votersRepository;
        private readonly ElectionsRepositories _electionRepository;
        private readonly CandidatesRepositories _candidatesRepository;

        // Constructor injects repositories that the service depends on.
        public AdminService(AdminsRepositories adminsRepositories, VotersRepositories votersRepository, ElectionsRepositories electionRepository, CandidatesRepositories candidatesRepository)
        {
            _adminsRepositories = adminsRepositories;
            _votersRepository = votersRepository;
            _electionRepository = electionRepository;
            _candidatesRepository = candidatesRepository;
        }

        // Loads an admin based on their ID and converts the entity to a DTO.
        public AdminDTO Load(Guid id)
        {
            var entity = _adminsRepositories.Load(id);

            return GetDTO(entity);
        }

        // Loads all admins and converts each entity to a DTO.
        public IEnumerable<AdminDTO> LoadAll()
        {
            var entities = _adminsRepositories.LoadAll();
            return entities.Select(GetDTO);
        }

        // Saves or updates an admin entity converted from a DTO.
        public AdminDTO Save(AdminDTO DTO)
        {
            var entity = GetEntity(DTO);
            entity = _adminsRepositories.Save(entity);
            return GetDTO(entity);
        }

        // Deletes an admin based on a DTO.
        public void Delete(AdminDTO DTO)
        {
            var entity = GetEntity(DTO);
            _adminsRepositories.Delete(entity);
        }

        // Helper method to convert an Admin entity to an AdminDTO.
        private AdminDTO GetDTO(Admin entity)
        {
            if (entity == null) return null;
            return new AdminDTO()
            {
                ID = entity.ID,
                UserID = entity.UserID,
                Username = entity.Username,
                Password = entity.Password
            };
        }

        // Helper method to convert an AdminDTO to an Admin entity.
        private Admin GetEntity(AdminDTO DTO)
        {
            return new Admin()
            {
                ID = DTO.ID,
                UserID = DTO.UserID,
                Username = DTO.Username,
                Password = DTO.Password
            };
        }

        // Initiates a new election process.
        public void StartElection()
        {
            var election = new Election
            {
                StartTime = DateTime.UtcNow // Sets the current UTC time as the start time.
            };
            _electionRepository.StartNewElection(election);
        }

        // Ends the current election.
        public void EndElection()
        {
            _electionRepository.EndCurrentElection(DateTime.UtcNow); // Sets the current UTC time as the end time.
        }

        // Counts votes for the current election and returns the resulting party.
        public Party CountElection()
        {
            return _electionRepository.CountVotes();
        }

        // Counts votes for the current election and returns the resulting party.
        public AdminDTO ConfirmVoterLogin(Admin admin)
        {
            // Convert DTO to Entity
            Admin adminEntity = new Admin
            {
                Username = admin.Username,
                Password = admin.Password // Ensure this is handled securely
            };

            // Perform the login check
            Admin loggedInAdmin = _adminsRepositories.ConfirmVoterLogin(adminEntity);
            if (loggedInAdmin != null)
            {
                return new AdminDTO
                {
                    ID = loggedInAdmin.ID,
                    UserID = loggedInAdmin.UserID,
                    Username = loggedInAdmin.Username
                    // Notice that the password is not included in the DTO for security reasons.
                };
            }
            return null;
        }
    }
}
