﻿using System;
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
        private void Update(Voter entity)
        {
            var voter = _context.Voters.FirstOrDefault(x => x.ID == entity.ID);
            voter.UserID = entity.UserID;
            voter.VerifcationId = entity.VerifcationId;
            voter.HasVoted = entity.HasVoted;
            voter.RegionID = entity.RegionID;
            _context.SaveChanges();
        }
    }
}