using Surprise_Test.Data;
using Surprise_Test.Models;
using Surprise_Test.Repositories;
using Surprise_Test.ViewModels;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DatabaseContext _context;
    public EmployeeRepository(DatabaseContext context)
    {
        _context = context;
    }
    public List<Job_Posting> GetAll()
    {
        return _context.Job_Postings.ToList();
    }
     public void AddJobPosting(Job_Posting JobPosting)
    {
        _context.Job_Postings.Add(JobPosting);
        _context.SaveChanges();
    }
    public void UpdateJobPosting(EditJobPostingViewModel model)
    {
        var JobPost = _context.Job_Postings.FirstOrDefault(s => s.JobId == model.Id);
        if(JobPost != null)
        {
       _context.Job_Postings.Update(JobPost);
       _context.SaveChanges();
        }
    }
    public void DeleteJobPosting(int id)
    {
        var JobPost = _context.Job_Postings.FirstOrDefault(s => s.JobId == id);
        if(JobPost != null)
        {
        _context.Job_Postings.Remove(JobPost);
        _context.SaveChanges();
        }
    }
}
