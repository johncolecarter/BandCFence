using System;
using System.Collections.Generic;
using System.Linq;
using BandCFenceAPI.Core.Models;
using BandCFenceAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace BandCFenceAPI.Infrastructure.Data
{
    public class BuilderRepository : IBuilderRepository
    {
        private readonly AppDbContext _dbContext;

        public BuilderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Builder Add(Builder addBuilder)
        {
            _dbContext.Builders.Add(addBuilder);
            _dbContext.SaveChanges();

            return addBuilder;
        }

        public Builder Get(int id)
        {
            return _dbContext.Builders
                .SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Builder> GetAll()
        {
            return _dbContext.Builders
                .ToList();
        }

        public Builder GetCompany(string company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Builder> GetFencesByBuilder(int id)
        {
            throw new NotImplementedException();
        }

        public Builder GetName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            var builder = _dbContext.Builders.FirstOrDefault(b => b.Id == id);

            if (builder != null)
            {
                _dbContext.Builders.Remove(builder);
                _dbContext.SaveChanges();
            }
        }

        public Builder Update(Builder builder)
        {
            var existingBuilder = _dbContext.Builders.Find(builder.Id);

            if (existingBuilder == null)
                return null;

            _dbContext.Entry(existingBuilder)
                .CurrentValues
                .SetValues(builder);

            _dbContext.Update(existingBuilder);
            _dbContext.SaveChanges();

            return existingBuilder;
        }
    }
}
