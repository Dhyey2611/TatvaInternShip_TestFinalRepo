namespace Surprise_Test.ViewModels
{
    public class JobApplicationViewModel
    {
        public int ApplicantId { get; set; } 
        public string ApplicantName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNo { get; set; }
        public string Status { get; set; } = "Pending";
        public string CompanyName { get; set; } = string.Empty;
        public string JobRole { get; set; } = string.Empty;
    }
}
