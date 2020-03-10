using System;
using System.Collections.Generic;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.Core.Services
{
    public interface IFenceService
    {
        Fence Get(int id);

        Fence GetBuilder(string builder);

        Fence GetType(string typeOfFence);

        Fence GetHeight(string heightOfFence);

        IEnumerable<Fence> GetFeet(double feetOfFence);

        Fence GetAddress(string address);

        Fence GetDate(DateTime dateTime);

        IEnumerable<Fence> GetAll();

        Fence Add(Fence addFence);

        Fence Update(Fence updateFence);

        void Remove(int id);
    }
}

