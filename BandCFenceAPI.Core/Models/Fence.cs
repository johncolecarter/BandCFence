using System;
using System.ComponentModel.DataAnnotations;

namespace BandCFenceAPI.Core.Models
{
    public class Fence : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int BuilderId { get; set; }

        public Builder Builder { get; set; }

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
