using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Payout
    {
        [Key]
        public int EmpId { get; set; }
        public int Salary { get; set; }
    }
}