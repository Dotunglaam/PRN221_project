using System.ComponentModel.DataAnnotations;

namespace InstructorSchedule.Models.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
