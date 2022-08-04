namespace UMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Gender { get; set; }
        public int Year { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistration { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
