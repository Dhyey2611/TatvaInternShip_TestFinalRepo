using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Surprise_Test.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string JobDescription { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int ApplicantNo { get; set; }
    }
}