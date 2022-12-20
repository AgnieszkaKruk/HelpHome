

using Domain.Entities.Utils;
using HelpHome.Entities;

namespace Domain.Models
{
    public class OfferDto
    {
        public int Id { get; set; } 

        public Regularity Regularity { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int SeekerId { get; set; }
        public string SeekerName { get; set; }
        
    }
}
