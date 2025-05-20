using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Surprise_Test.Models
{
    [Table("Job_Applications")]
    public class Job_Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("applicant_id")]
        public int ApplicantId { get; set; }
        [Column("job_applied_id")]
        public int JobAppliedId { get; set; }
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("phone")]
        public int PhoneNo { get; set; }
        [Column("status")]
        public string Status { get; set; } = "Pending";
        [Column("applicant_name")]
        public string ApplicantName { get; set; } = string.Empty;
        [Column("id")]
        public int Id { get; set; }
    }
}
