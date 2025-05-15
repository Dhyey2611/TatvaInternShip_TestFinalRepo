using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Office_Address
    {
        [Key]
        public int EmpId { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}