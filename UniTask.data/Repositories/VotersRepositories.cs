using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    public class VotersRepositories : BaseRepositories
    {
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public VotersRepositories(VotingContext context)
        {
            _context = context;
        }
        public Voter FindByVerificationCode(string verificationCode)
        {
            return _context.Voters.FirstOrDefault(v => v.VerifcationCode == verificationCode);
        }

        public IEnumerable<Voter> FindByName(string Name)
        {
            return _context.Voters.Where(v => v.Name == Name);
        }


        public IEnumerable<Voter> FindByEmail(string Email)
        {
            return _context.Voters.Where(v => v.Email == Email);
        }

        public Voter ConfirmVoterLogin(Voter voter)
        {
            return _context.Voters.FirstOrDefault(x => x.Name == voter.Name && x.Password == voter.Password && x.DateOfBirth == voter.DateOfBirth && x.VerifcationCode == voter.VerifcationCode);
        }

        // Load object based on primary key 
        public Voter Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Voters.Local.First(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Voter> LoadAll()
        {
            return _context.Voters.Local.AsEnumerable();
        }

        //save new object 
        public Voter Save(Voter entity)
        {
            if (entity.ID == Guid.Empty)
            {
                entity.ID = Guid.NewGuid();
                Insert(entity);
                return entity;
            }
            Update(entity);
            return entity;
        }

        //dele existing object 
        public void Delete(Voter entity)
        {
            if (entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Voter entity)
        {
            _context.Voters.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        public void Update(Voter entity)
        {
            var voter = _context.Voters.FirstOrDefault(x => x.ID == entity.ID);
            voter.UserID = entity.UserID;
            voter.Password = entity.Password;
            voter.VerifcationCode = entity.VerifcationCode;
            voter.IsVerified = entity.IsVerified;
            voter.HasVoted = entity.HasVoted;
            voter.RegionID = entity.RegionID;
            voter.DateOfBirth = entity.DateOfBirth;
            voter.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
