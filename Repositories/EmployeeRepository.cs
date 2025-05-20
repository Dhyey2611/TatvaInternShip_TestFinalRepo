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
        return _context.Job_Postings.Where(j => !j.IsDelete).ToList();
    }
    public void AddJobPosting(Job_Posting JobPosting)
    {
        _context.Job_Postings.Add(JobPosting);
        _context.SaveChanges();
    }
    public void UpdateJobPosting(EditJobPostingViewModel model)
    {
        var JobPost = _context.Job_Postings.FirstOrDefault(s => s.JobId == model.Id);
        if (JobPost != null)
        {
            JobPost.JobDescription = model.JobRole;
            JobPost.CName = model.CompanyName;
            _context.SaveChanges();
        }
    }
    public void DeleteJobPosting(int id)
    {
        var JobPost = _context.Job_Postings.FirstOrDefault(s => s.JobId == id);
        if (JobPost != null)
        {
            JobPost.IsDelete = true;
            _context.SaveChanges();
        }
    }
    public User? GetUserByCredentials(string username, string password)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsActive);
    }
    public void AddJobApplication(Job_Application application)
    {
        _context.Job_Applications.Add(application);
        _context.SaveChanges();
    }
    
    public void UpdateJobApplicationStatus(UpdateJobApplicationViewModel model)
    {
        var application = _context.Job_Applications.FirstOrDefault(x => x.ApplicantId == model.ApplicantId);
        if (application != null)
        {
            application.Status = model.Status;
            _context.SaveChanges();
        }
    }

    public List<JobApplicationViewModel> GetAllJobApplications(string userType, int userId)
    {
        if (userType == "Admin")
        {
            return (from app in _context.Job_Applications
                    join job in _context.Job_Postings
                        on app.JobAppliedId equals job.JobId
                    select new JobApplicationViewModel
                    {
                        ApplicantId = app.ApplicantId,
                        ApplicantName = app.ApplicantName,
                        Email = app.Email,
                        PhoneNo = app.PhoneNo,
                        Status = app.Status,
                        CompanyName = job.CName,
                        JobRole = job.JobDescription
                    }).ToList();
        }
        else
        {
            return (from app in _context.Job_Applications
                    where app.Id == userId
                    join job in _context.Job_Postings
                    on app.JobAppliedId equals job.JobId
                    select new JobApplicationViewModel
                    {
                        ApplicantId = app.ApplicantId,
                        ApplicantName = app.ApplicantName,
                        Email = app.Email,
                        PhoneNo = app.PhoneNo,
                        Status = app.Status,
                        CompanyName = job.CName,
                        JobRole = job.JobDescription
                    }).ToList();
        }
    }
}
