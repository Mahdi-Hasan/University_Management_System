using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
        public virtual ICollection<Result> Results { get; set; }


    }
}
