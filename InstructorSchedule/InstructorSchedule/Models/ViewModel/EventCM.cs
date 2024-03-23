using InstructorSchedule.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstructorSchedule.Models.ViewModel
{
    public class EventCM 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Start { get; set; }
        public string? End { get; set; }
        public string? ThemeColor { get; set; }
        public string? SubjectId { get; set; }
        public string? UserId { get; set; }
        public int Status { get; set; }
    }
}
