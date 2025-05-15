using Surprise_Test.Models;
using Surprise_Test.ViewModels;
public interface IEmployeeService
{
    List<Job_Posting> GetAll();
    void AddJobPosting(AddJobPostingViewModel model);
    void UpdateJobPosting(EditJobPostingViewModel model);
    void DeleteJobPosting(int id);
}