using InstructorSchedule.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace InstructorSchedule.Models.ViewModel
{
    public class SubjectVM : Subject
    {

    }

    public class SubjectCM
    {
        public String Name { get; set; }    
        public String Description { get; set; } 
        public String Code {  get; set; }
        public String? DateCreate { get; set; }
    }
}
