using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Preferred_Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobName { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
    }
}