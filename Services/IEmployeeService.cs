using Surprise_Test.Models;
using Surprise_Test.ViewModels;
public interface IEmployeeService
{
    List<Job_Posting> GetAll();
    void AddJobPosting(AddJobPostingViewModel model);
    void UpdateJobPosting(EditJobPostingViewModel model);
    void DeleteJobPosting(int id);
    User? ValidateUserLogin(string username, string password);
    void AddJobApplication(AddJobApplicationViewModel model);
    List<JobApplicationViewModel> GetAllJobApplications(string userType, int userId);
    public void UpdateJobApplicationStatus(UpdateJobApplicationViewModel model);
}