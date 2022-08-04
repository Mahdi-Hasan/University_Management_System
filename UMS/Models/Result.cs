namespace UMS.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public  int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public decimal GPA { get; set; }
    }
}
