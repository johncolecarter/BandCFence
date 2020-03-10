using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BandCFenceAPI.Core.Models;
using BandCFenceAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BandCFenceAPI.Infrastructure.Data
{
    public class FenceRepository : IFenceRepository
    {
        private readonly AppDbContext _dbContext;

        public FenceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Fence Add(Fence addFence)
        {
            _dbContext.Fences.Add(addFence);
            _dbContext.SaveChanges();

            return addFence;
        }

        public Fence Get(int id)
        {
            return _dbContext.Fences
                     .Include(f => f.Builder)
                     .SingleOrDefault(f => f.Id == id);
        }

        public Fence GetAddress(string address)
        {
            return _dbContext.Fences
                    .SingleOrDefault(f => f.Address == address);
        }

        public IEnumerable<Fence> GetAll()
        {
            return _dbContext.Fences
                    .Include(f => f.Builder)
                    .ToList();
        }

        public Fence GetBuilder(string builder)
        {
            throw new NotImplementedException();
        }

        public Fence GetDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Fence> GetFeet(double feetOfFence)
        {
            return _dbContext.Fences.FromSql("SELECT * FROM Fences WHERE FeetOfFence = {0}", feetOfFence).ToList();
                    
        }

        public Fence GetHeight(string heightOfFence)
        {
            throw new NotImplementedException();
        }

        public Fence GetType(string typeOfFence)
        {
            //return _dbContext.Fences
            //        .Where(f => f.TypeOfFence.Contains(typeOfFence));
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var fence = _dbContext.Fences.FirstOrDefault(f => f.Id == id);

            if (fence != null)
            {
                _dbContext.Fences.Remove(fence);
                _dbContext.SaveChanges();
            }

        }

        public Fence Update(Fence updateFence)
        {
            var existingFence = _dbContext.Fences.FirstOrDefault(f => f.Id == updateFence.Id);

            if (existingFence == null)
                return null;

            _dbContext.Entry(existingFence)
                .CurrentValues
                .SetValues(updateFence);

            _dbContext.Update(existingFence);
            _dbContext.SaveChanges();

            return existingFence;
        }
    }
}
