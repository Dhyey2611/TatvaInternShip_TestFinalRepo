using Surprise_Test.Models;
using Surprise_Test.ViewModels;

namespace Surprise_Test.Repositories{

        public interface IEmployeeRepository
        {
                List<Job_Posting> GetAll();
                void AddJobPosting(Job_Posting JobPosting);
                void UpdateJobPosting(EditJobPostingViewModel model);
                void DeleteJobPosting(int id);
                User? GetUserByCredentials(string username, string password);
                void AddJobApplication(Job_Application application);
                List<JobApplicationViewModel> GetAllJobApplications(string userType, int userId);
                public void UpdateJobApplicationStatus(UpdateJobApplicationViewModel model);
        }
}