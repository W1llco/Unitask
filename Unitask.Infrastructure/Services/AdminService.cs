﻿using System;
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
        private readonly VotersRepositories _votersRepository;
        private readonly ElectionsRepositories _electionRepository;
        private readonly CandidatesRepositories _candidatesRepository;

        //construsuror for service depenedency injection
        public AdminService(AdminsRepositories adminsRepositories, VotersRepositories votersRepository, ElectionsRepositories electionRepository, CandidatesRepositories candidatesRepository)
        {
            _adminsRepositories = adminsRepositories;
            _votersRepository = votersRepository;
            _electionRepository = electionRepository;
            _candidatesRepository = candidatesRepository;
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

        public bool VerifyVoter(string voterName, string verificationCode)
        {
            var voter = _votersRepository.FindByName(voterName);
            return voter != null && voter.VerifcationCode == verificationCode;
        }

        public void StartElection()
        {
            var election = new Election
            {
                StartTime = DateTime.UtcNow,
                EndTime = null 
            };
            _electionRepository.StartNewElection(election);
        }

        public void EndElection()
        {
            _electionRepository.EndCurrentElection(DateTime.UtcNow);
        }

        public Party CountElection()
        {
            return _electionRepository.CountVotes();
        }

        public Candidate RegisterCandidate(Candidate candidate)
        {
            return _candidatesRepository.Save(candidate);
        }
    }
}
