using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.APIModels
{
    public class BuilderModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public ICollection<Fence> Fence { get; set; }
    }
}
