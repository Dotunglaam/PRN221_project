using Infrasctructrue.DAL;
using InstructorSchedule.Models.Entities;
using InstructorSchedule.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InstructorSchedule.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAsscessor;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; // Set your page size
        public int PageCount { get; set; }
        public AdminController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAsscessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAsscessor = httpContextAsscessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Subject(int? pageNumber)
        {
            var subjects = _unitOfWork.SubjectRepository.GetAll().ToList();
            var TotalPage = subjects.Count();
            PageCount = TotalPage / 10;
            if (TotalPage % 10 != 0) PageCount++;
            PageNumber = pageNumber ?? 1;
            subjects = subjects.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            ViewData["TotalPage"] = PageCount;
            return View(subjects);
        }

        [HttpPost]
        public async Task<IActionResult> Subject([FromForm] SubjectCM subjectCM)
        {
            if(ModelState.IsValid)
            {
                Subject _subject = new Subject();
                _subject.Id = Guid.NewGuid();
                _subject.Name = subjectCM.Name;
                _subject.Code = subjectCM.Code;
                _subject.Description = subjectCM.Description;
                _subject.DateCreate = DateTime.Now; 
                await  _unitOfWork.SubjectRepository.AddAsync(_subject);
                await _unitOfWork.SaveChangeAsync();
            }
            return RedirectToAction("Subject");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Approval(int? pageNumber)
        {
            var listEvent = _unitOfWork.EventRepository.Get(_ => _.Status == 0, _ => _.User, _ => _.Subject).ToList();
            var TotalPage = listEvent.Count();
            PageCount = TotalPage / 10;
            if (TotalPage % 10 != 0) PageCount++;
            PageNumber = pageNumber ?? 1;
            listEvent = listEvent.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            ViewData["TotalPage"] = PageCount;
            return View(listEvent);
        }

        public async Task<IActionResult> ApprovalSubject(Guid eventId)
        {
            if (eventId != null)
            {
                var status = false;
                var _event = _unitOfWork.EventRepository.Get(_ => _.Id.Equals(eventId)).FirstOrDefault();
                if(_event != null)
                {
                    _event.Status = 1;
                    _unitOfWork.EventRepository.Update(_event);
                }
               await _unitOfWork.SaveChangeAsync();
            }
            return RedirectToAction("Approval");
        }





    }
}
