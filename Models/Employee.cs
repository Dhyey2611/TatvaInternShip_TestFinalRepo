using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string CurrentCompany { get; set; } = string.Empty;
        public int Experience { get; set; }
    }
}