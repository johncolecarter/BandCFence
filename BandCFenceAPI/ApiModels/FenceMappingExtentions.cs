using System;
using System.Linq;
using System.Collections.Generic;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.APIModels
{
    public static class FenceMappingExtentions
    {
        public static FenceModel ToApiModel(this Fence fence)
        {
            return new FenceModel
            {
                Id = fence.Id,
                Address = fence.Address,
                Date = fence.Date,
                BuilderId = fence.BuilderId,
                builderName = fence.Builder.FirstName + " " + fence.Builder.LastName,
                HomeOwner = fence.HomeOwner,
                FeetOfFence = fence.FeetOfFence,
                HeightOfFence = fence.HeightOfFence,
                TypeOfFence = fence.TypeOfFence,
                Gates = fence.Gates,
                Curb = fence.Curb,
                Stain = fence.Stain,
                BOrC = fence.BOrC,
                Price = fence.Price,
            };
        }

        public static Fence ToDomainModel(this FenceModel fenceModel)
        {
            return new Fence
            {
                Id = fenceModel.Id,
                Address = fenceModel.Address,
                Date = fenceModel.Date,
                BuilderId = fenceModel.BuilderId,
                HomeOwner = fenceModel.HomeOwner,
                FeetOfFence = fenceModel.FeetOfFence,
                HeightOfFence = fenceModel.HeightOfFence,
                TypeOfFence = fenceModel.TypeOfFence,
                Gates = fenceModel.Gates,
                Curb = fenceModel.Curb,
                Stain = fenceModel.Stain,
                BOrC = fenceModel.BOrC,
                Price = fenceModel.Price,
            };
        }

        public static IEnumerable<FenceModel> ToApiModels(this IEnumerable<Fence> fences)
        {
            return fences.Select(f => f.ToApiModel());
        }

        public static IEnumerator<Fence> ToDomainModels(this IEnumerable<FenceModel> fenceModels)
        {
            return (System.Collections.Generic.IEnumerator<BandCFenceAPI.Core.Models.Fence>)fenceModels.Select(f => f.ToDomainModel());
        }
    }
}
