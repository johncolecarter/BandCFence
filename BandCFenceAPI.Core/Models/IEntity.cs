using System;
namespace BandCFenceAPI.Core.Models
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }
}
