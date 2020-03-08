using System;
using System.Collections.Generic;
using System.Linq;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.APIModels
{
    public static class BuilderMappingExtention
    {
        public static BuilderModel ToApiModel(this Builder builder)
        {
            return new BuilderModel
            {
                Id = builder.Id,
                FirstName = builder.FirstName,
                LastName = builder.LastName,
                Phone = builder.Phone,
                Company = builder.Company,
                Address = builder.Address,
            };
        }

        public static BuilderModel ToDomainModel(this BuilderModel builderModel)
        {
            return new BuilderModel
            {
                Id = builderModel.Id,
                FirstName = builderModel.FirstName,
                LastName = builderModel.LastName,
                Phone = builderModel.Phone,
                Company = builderModel.Company,
                Address = builderModel.Address,
            };
        }

        public static IEnumerable<BuilderModel> ToApiModels(this IEnumerable<Builder> builders)
        {
            return builders.Select(b => b.ToApiModel());
        }

        public static IEnumerable<Builder> ToDomainModels(this IEnumerable<BuilderModel> builderModels)
        {
            return (System.Collections.Generic.IEnumerable<BandCFenceAPI.Core.Models.Builder>)builderModels.Select(b => b.ToDomainModel());
        }
    }
}
