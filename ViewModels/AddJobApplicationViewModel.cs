namespace Surprise_Test.ViewModels
{
    public class AddJobApplicationViewModel
    {
        public int JobAppliedId { get; set; }
        public string ApplicantName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PhoneNo { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
