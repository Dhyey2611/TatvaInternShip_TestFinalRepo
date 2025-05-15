using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Experience
    {
        [Key]
        public int EmpId { get; set; }
        public string PreviousCompany { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}