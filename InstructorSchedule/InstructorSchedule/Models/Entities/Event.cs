using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstructorSchedule.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? ThemeColor { get; set; }
        public Guid? SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject? Subject { get; set; }
        public Guid? UserId {  get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int Status { get; set; }
    }
}
