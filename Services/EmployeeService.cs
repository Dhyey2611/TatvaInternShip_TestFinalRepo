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
}