using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Existing_Job
    {
        [Key]
        public int EmpId { get; set; }
        public string CName { get; set; } = string.Empty;
    }
}