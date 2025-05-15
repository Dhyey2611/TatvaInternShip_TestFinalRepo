using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Offer
    {
        [Key]
        public int EmpId { get; set; }
        public string OfferName { get; set; } = string.Empty;
    }
}