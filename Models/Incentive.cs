using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Incentive
    {
        [Key]
        public int EmpId { get; set; }
        public string  Benefit { get; set; } = string.Empty;
    }   
}