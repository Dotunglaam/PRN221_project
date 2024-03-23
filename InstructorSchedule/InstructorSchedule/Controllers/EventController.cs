using Infrasctructrue.DAL;
using InstructorSchedule.Models.Entities;
using InstructorSchedule.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorSchedule.Controllers
{

    public class EventController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAsscessor;
        public EventController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAsscessor)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _httpContextAsscessor = httpContextAsscessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSchedule()
        {
            var userIdString = _httpContextAsscessor.HttpContext.Session.GetString("UserId");
            var _userId = Guid.Parse(userIdString);
            var schedules = _unitOfWork.EventRepository.Get(_ => _.Status == 1 && _.UserId.Equals(_userId), _ => _.Subject).ToList();
            return Json(new { data = schedules });
        }

        public IActionResult RegisterSchedule()
        {
            var userIdString = _httpContextAsscessor.HttpContext.Session.GetString("UserId");
            var _userId = Guid.Parse(userIdString);
            var schedules = _unitOfWork.EventRepository.Get(_ => _.Status == 0 && _.UserId.Equals(_userId), _ => _.Subject).ToList();
            return Json(new { data = schedules });
        }

        [HttpPost]
        public async Task<IActionResult> SaveSchedule([FromBody] EventCM _eventCM)
        {

            var userIdString = _httpContextAsscessor.HttpContext.Session.GetString("UserId");
            var _userId = Guid.Parse(userIdString);
            var status = false;
            if (_eventCM.Id.Equals("0"))
            {
                Event __event = new Event();
                __event.Id = Guid.NewGuid();
                __event.Description = _eventCM.Description;
                __event.Name = _eventCM.Name;
                __event.SubjectId = Guid.Parse(_eventCM.SubjectId);
                __event.Start = DateTime.Parse(_eventCM.Start);
                __event.End = DateTime.Parse(_eventCM.End);
                __event.ThemeColor = _eventCM.ThemeColor;
                __event.Status = _eventCM.Status;
                __event.UserId = _userId;
                await _unitOfWork.EventRepository.AddAsync(__event);
         
            }
            else
            {
                Guid _eventGuiId = Guid.Parse(_eventCM.Id);
                var _event = _unitOfWork.EventRepository.Get(_ => _.Id.Equals(_eventGuiId)).FirstOrDefault();
                if (_event != null)
                {
                    _event.SubjectId = Guid.Parse(_eventCM.SubjectId);
                    _event.Description = _eventCM.Description;
                    _event.Name = _eventCM.Name;
                    _event.Start = DateTime.Parse(_eventCM.Start);
                    _event.End = DateTime.Parse(_eventCM.End);
                    _event.ThemeColor = _eventCM.ThemeColor;
                    _unitOfWork.EventRepository.Update(_event);
                }
            }
            int result = await _unitOfWork.SaveChangeAsync();
            if (result > 0) status = true;

            return new JsonResult(new { status });
        }

        [HttpPut]
        public async Task<IActionResult> DeleteSchedule(Guid eventId)
        {
            if (eventId != null)
            {
                var status = false;
                var _event = _unitOfWork.EventRepository.Get(_ => _.Id.Equals(eventId)).FirstOrDefault();
                _unitOfWork.EventRepository.Remove(_event);
                int result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return new JsonResult(new { data = _event });
                }
            }
            return new JsonResult(new { status = false });

        }

    }
}
