using System;
using System.Collections.Generic;
using System.Linq;
using BandCFenceAPI.ApiModels;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.APIModels
{
    public static class AppUserMappingExtentions
    {
        public static AppUserModel ToApiModel(this AppUser user)
        {
            return new AppUserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static AppUser ToDomainModel(this AppUserModel userModel)
        {
            return new AppUser
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email
            };
        }

        public static IEnumerable<AppUserModel> ToApiModels(this IEnumerable<AppUser> Users)
        {
            return Users.Select(a => a.ToApiModel());
        }

        public static IEnumerable<AppUser> ToDomainModels(this IEnumerable<AppUserModel> UserModels)
        {
            return UserModels.Select(a => a.ToDomainModel());
        }
    }
}
