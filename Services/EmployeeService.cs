using Surprise_Test.Models;
using Surprise_Test.Repositories;
using Surprise_Test.ViewModels;

public class EmployeeService : IEmployeeService
{
    public readonly IEmployeeRepository _repository;
    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public List<Job_Posting> GetAll()
    {
        return _repository.GetAll();
    }
    public void AddJobPosting(AddJobPostingViewModel model)
    {
        var JobPost = new Job_Posting
        {
            CName = model.CompanyName,
            JobDescription = model.Jobrole,
        };
        _repository.AddJobPosting(JobPost);
    }
    public void UpdateJobPosting(EditJobPostingViewModel viewModel)
    {
        _repository.UpdateJobPosting(viewModel);
    }
    public void DeleteJobPosting(int id)
    {
        _repository.DeleteJobPosting(id);
    }
    public User? ValidateUserLogin(string username, string password)
    {
        return _repository.GetUserByCredentials(username, password);
    }
    public void AddJobApplication(AddJobApplicationViewModel model)
    {
        var JobApplication = new Job_Application
        {
            JobAppliedId = model.JobAppliedId,
            Email = model.Email,
            PhoneNo = model.PhoneNo,
            Status = model.Status,
            ApplicantName = model.ApplicantName,
        };
        _repository.AddJobApplication(JobApplication);
    }
    public void UpdateJobApplicationStatus(UpdateJobApplicationViewModel model)
    {
    _repository.UpdateJobApplicationStatus(model);
    }

    public List<JobApplicationViewModel> GetAllJobApplications(string userType, int userId)
    {
        return _repository.GetAllJobApplications(userType, userId);
    }
}