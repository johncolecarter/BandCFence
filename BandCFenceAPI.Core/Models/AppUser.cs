using System;
using Microsoft.AspNetCore.Identity;

namespace BandCFenceAPI.Core.Models
{
    public class AppUser : IdentityUser, IEntity<string>
    {
        public string Name { get; set; }
    }
}
