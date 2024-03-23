using InstructorSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Infrasctructrue.DAL;
using InstructorSchedule.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using InstructorSchedule.Models.Entities;

namespace InstructorSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAsscessor;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _httpContextAsscessor = httpContextAccessor;
        }

        public IActionResult Index()
        {

            var listSubject = _unitOfWork.SubjectRepository.GetAll().ToList();
            return View(listSubject);
        }

        public IActionResult Register()
        {
            var listSubject = _unitOfWork.SubjectRepository.GetAll().ToList();
            return View(listSubject);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            _httpContextAsscessor.HttpContext.Session.Remove("UserId");
            _httpContextAsscessor.HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserCM userCM)
        {
            var user = _unitOfWork.UserRepository.Get(_ => _.Email.Equals(userCM.Email) && _.Password.Equals(userCM.Password), _ => _.Role).FirstOrDefault();
            if (user != null)
            {
                _httpContextAsscessor.HttpContext.Session.SetString("UserId", user.Id.ToString());
                _httpContextAsscessor.HttpContext.Session.SetString("UserName", user.Name);
                if (user.Role.Name.Equals("Admin"))
                {
                    // Redirect to admin page.
                    return RedirectToAction("Subject", "Admin", new { pageNumber = 1 });
                } else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewData["Message"] = "Wrong email or password";
            return View();
        }


        [HttpGet]
        public IActionResult RegisterAccount()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterAccount([FromForm] UserCM userCM)
        { 
            if(userCM.Password.Equals(userCM.PasswordConfirm))
            {
                User user = new User
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    Email = userCM.Email,
                    Password = userCM.Password,
                    Name = userCM.Name,
                    isActive = true,
                    RoleId = Guid.Parse("73c53820-e78c-4a52-94fa-4e20b5b23a12"),
                };
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.SaveChangeAsync();
            } else
            {
            ViewData["Message"] = "Password not match";
            }
            return RedirectToAction("Login");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
