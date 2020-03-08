using System;
using System.ComponentModel.DataAnnotations;
using BandCFenceAPI.Core.Models;

namespace BandCFenceAPI.APIModels
{
    public class FenceModel
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int BuilderId { get; set; }

        public string builderName { get; set; }

        public string HomeOwner { get; set; }

        public double FeetOfFence { get; set; }

        public int HeightOfFence { get; set; }

        public string TypeOfFence { get; set; }

        public int Gates { get; set; }

        public bool Curb { get; set; }

        public bool Stain { get; set; }

        public string BOrC { get; set; }

        public double Price { get; set; }
    }
}
