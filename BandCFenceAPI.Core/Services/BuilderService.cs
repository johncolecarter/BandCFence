using System;
using System.Collections.Generic;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.Core.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly IBuilderRepository _builderRepo;

        public BuilderService(IBuilderRepository builderRepo)
        {
            _builderRepo = builderRepo;
        }

        public Builder Add(Builder addBuilder)
        {
            return _builderRepo.Add(addBuilder);
        }

        public Builder Get(int id)
        {
            return _builderRepo.Get(id);
        }

        public IEnumerable<Builder> GetAll()
        {
            return _builderRepo.GetAll();
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
            _builderRepo.Remove(id);
        }

        public Builder Update(Builder builder)
        {
            return _builderRepo.Update(builder);
        }
    }
}
