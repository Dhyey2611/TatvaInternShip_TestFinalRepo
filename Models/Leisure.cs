using System.ComponentModel.DataAnnotations;

namespace Surprise_Test.Models
{
    public class Leisure
    {
        [Key]
        public int EmpId { get; set; }
        public string Leis { get; set; } = string.Empty;

    }
}