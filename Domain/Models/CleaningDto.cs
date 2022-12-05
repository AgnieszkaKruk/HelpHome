using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CleaningDto
    {

        [Required]
        public int SurfaceToClean { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PriceOffer { get; set; }
        public Address Address { get; set; }

    }
}
