
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
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _service.ValidateUserLogin(username, password);

        if (user != null)
        {
            HttpContext.Session.SetString("user_id", user.UserId.ToString());
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("user_type", user.UserType);

            return RedirectToAction("Index", "Home"); // redirect to job list
        }

        ViewBag.Error = "Invalid username or password.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }

    public IActionResult Index()
    {
        var Employee = _service.GetAll();
        return View(Employee);
    }
    [HttpPost]
    public IActionResult CreateJobPost(AddJobPostingViewModel model)
    {
        if (ModelState.IsValid)
        {
            _service.AddJobPosting(model);
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult EditJobPost(int id)
    {
        var JobPost = _service.GetAll().FirstOrDefault(s => s.JobId == id);
        if (JobPost == null)
        {
            return NotFound();
        }
        var viewModel = new EditJobPostingViewModel
        {
            Id = JobPost.JobId,
            CompanyName = JobPost.CName,
            JobRole = JobPost.JobDescription,
        };
        return Json(viewModel);
    }

    // [HttpPost]
    // public IActionResult UpdateJobPost(EditJobPostingViewModel viewModel)
    // {
    // if(ModelState.IsValid)
    // {
    //  _service.UpdateJobPosting(viewModel);
    // }
    // return RedirectToAction("Index");
    // }
    [HttpPost]
    public IActionResult UpdateJobPost(EditJobPostingViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"❌ Field: {state.Key} | Error: {error.ErrorMessage}");
                }
            }
            return View(viewModel);
        }
        _service.UpdateJobPosting(viewModel);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteJobPost(int id)
    {
        Console.WriteLine($"🛑 Delete Request Received | JobId: {id}");
        _service.DeleteJobPosting(id);
        return RedirectToAction("Index");
    }
    // [HttpPost]
    // public IActionResult CreateJobApplication(AddJobApplicationViewModel model)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _service.AddJobApplication(model);
    //         TempData["Message"] = "Applied Successfully!";
    //     }
    //     return RedirectToAction("Index");
    // }
    [HttpPost]
    public IActionResult CreateJobApplication(AddJobApplicationViewModel model)
    {
    Console.WriteLine("== [CreateJobApplication] POST called ==");
    Console.WriteLine("JobAppliedId: " + model.JobAppliedId);
    Console.WriteLine("ApplicantName: " + model.ApplicantName);
    Console.WriteLine("Email: " + model.Email);
    Console.WriteLine("PhoneNo: " + model.PhoneNo);
    Console.WriteLine("Status: " + model.Status);

    if (ModelState.IsValid)
    {
        Console.WriteLine("✅ ModelState is VALID");
        _service.AddJobApplication(model);
        TempData["Message"] = "Applied Successfully!";
    }
    else
    {
        Console.WriteLine("❌ ModelState is INVALID");
    }

    return RedirectToAction("Index");
    }
    [HttpPost]
    public IActionResult UpdateJobApplicationStatus(UpdateJobApplicationViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"❌ Field: {state.Key} | Error: {error.ErrorMessage}");
                }
            }
            return View(viewModel);
        }
        _service.UpdateJobApplicationStatus(viewModel);
        return RedirectToAction("Applications");
    }

    public IActionResult Applications()
    {
        var userType = HttpContext.Session.GetString("user_type");
        var userIdString = HttpContext.Session.GetString("user_id");

        Console.WriteLine("Session - user_type: " + userType);
        Console.WriteLine("Session - user_id (string): " + userIdString);

        if (string.IsNullOrEmpty(userType) || string.IsNullOrEmpty(userIdString))
        {
            Console.WriteLine("Session is missing. Redirecting to Login.");
            return RedirectToAction("Login");
        }
        var userId = Convert.ToInt32(userIdString);
        Console.WriteLine("Converted user_id (int): " + userId);
        var applications = _service.GetAllJobApplications(userType, userId);
        Console.WriteLine("Applications count returned: " + applications.Count);
        return View(applications);
    }
}
