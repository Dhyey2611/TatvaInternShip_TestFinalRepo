using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Surprise_Test.Models
{
    public class Job_Posting
    {
        [Key]
        public int JobId { get; set; }
        public string CName { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;

    }
}