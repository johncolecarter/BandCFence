using System;
using System.Collections.Generic;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.Core.Services
{
    public class FenceService : IFenceService
    {
        private readonly IFenceRepository _fenceRepo;

        public FenceService(IFenceRepository fenceRepo)
        {
            _fenceRepo = fenceRepo;
        }

        public Fence Add(Fence addFence)
        {
            addFence.Date = DateTime.Now;

            return _fenceRepo.Add(addFence);
        }

        public Fence Get(int id)
        {
            return _fenceRepo.Get(id);
        }

        public Fence GetAddress(string address)
        {
            return _fenceRepo.GetAddress(address);
        }

        public IEnumerable<Fence> GetAll()
        {
            return _fenceRepo.GetAll();
        }

        public Fence GetBuilder(string builder)
        {
            return _fenceRepo.GetBuilder(builder);
        }

        public Fence GetDate(DateTime dateTime)
        {
            return _fenceRepo.GetDate(dateTime);
        }

        public Fence GetFeet(int feetOfFence)
        {
            return _fenceRepo.GetFeet(feetOfFence);
        }

        public Fence GetHeight(string heightOfFence)
        {
            return _fenceRepo.GetHeight(heightOfFence);
        }

        public Fence GetType(string typeOfFence)
        {
            return _fenceRepo.GetType(typeOfFence);
        }

        public void Remove(int id)
        {
            _fenceRepo.Remove(id);
        }

        public Fence Update(Fence updateFence)
        {
            var fence = _fenceRepo.Update(updateFence);

            return fence;
        }
    }
}
