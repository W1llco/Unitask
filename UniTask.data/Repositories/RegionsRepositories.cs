using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UniTask.entites;

namespace UniTask.data.Repositories
{
    // ingerut from baseRepositories
    public class RegionsRepositories : BaseRepositories
    {   
        //Variable depenedency injection 
        private readonly VotingContext _context;

        // construstor  dependency injection
        public RegionsRepositories( VotingContext context)
        {
            _context = context;
        }

        // Load object based on primary key 
        public Region Load(Guid id)
        {
            if (id == Guid.Empty)
                return null;
            return _context.Regions.Local.FirstOrDefault(x => x.ID == id);
        }
        //Load all
        public IEnumerable<Region> LoadAll()
        {
            return _context.Regions.Local.AsEnumerable();
        }

        //save new object 
        public Region Save(Region entity)
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

        public Region GetRegion(string region)
        {
            return _context.Regions.Local.FirstOrDefault(x => x.Name == region);
        }

        //dele existing object 
        public void Delete(Region entity)
        {
            if(entity.ID != Guid.Empty)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        // insert new object 
        private void Insert(Region entity)
        {
            _context.Regions.Add(entity);
            _context.SaveChanges();

        }

        //udate existing object 
        private void Update(Region entity)
        {
            var region = _context.Regions.FirstOrDefault(x => x.ID == entity.ID);
            region.Name = entity.Name;
            _context.SaveChanges();
        }
    }
}
