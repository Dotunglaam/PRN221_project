using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstructorSchedule.Models.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isActive {  get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
