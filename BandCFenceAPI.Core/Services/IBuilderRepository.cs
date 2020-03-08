using System;
using System.Collections.Generic;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.Core.Services
{
    public interface IBuilderRepository
    {
        Builder Get(int id);

        Builder GetName(string name);

        Builder GetCompany(string company);

        IEnumerable<Builder> GetAll();

        IEnumerable<Builder> GetFencesByBuilder(int id);

        Builder Add(Builder addBuilder);

        Builder Update(Builder builder);

        void Remove(int id);
    }
}
