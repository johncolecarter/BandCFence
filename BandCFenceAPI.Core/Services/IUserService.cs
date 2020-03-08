using System;
using System.Security.Claims;

namespace BandCFenceAPI.Core.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; }
        string CurrentUserId { get; }
    }
}
