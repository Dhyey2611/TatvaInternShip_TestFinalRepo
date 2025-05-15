
using Microsoft.AspNetCore.Mvc;
using Surprise_Test.ViewModels;

namespace Surprise_Test.Controllers;

public class HomeController : Controller
{
    private readonly IEmployeeService _service;

    public HomeController(IEmployeeService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var Employee = _service.GetAll();
        return View(Employee);
    }
    [HttpPost]
    public IActionResult CreateJobPost(AddJobPostingViewModel model)
    {
    if(ModelState.IsValid)
    {
        _service.AddJobPosting(model);
    }
    return RedirectToAction("Student");
    }

    [HttpGet]
    public IActionResult EditJobPost(int id)
    {
    var JobPost = _service.GetAll().FirstOrDefault(s => s.JobId == id);
    if(JobPost == null)
    {
    return NotFound();
    }
    var viewModel = new EditJobPostingViewModel
    {
    CompanyName = JobPost.CName,
    JobRole = JobPost.JobDescription,
    };
    return Json(viewModel);
    }

    [HttpPost]
    public IActionResult UpdateJobPost(EditJobPostingViewModel viewModel)
    {
    if(ModelState.IsValid)
    {
     _service.UpdateJobPosting(viewModel);
    }
    return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteJobPost(int id)
    {
    _service.DeleteJobPosting(id);
    return RedirectToAction("Index");
    }
}
