using System.ComponentModel.DataAnnotations;

namespace InstructorSchedule.Models.Entities
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code {  get; set; }
        public DateTime DateCreate { get; set; }
    }
}
