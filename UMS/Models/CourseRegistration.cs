namespace UMS.Models
{
    public class CourseRegistration
    {
        public Guid Id { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }         
        public DateTime RegDate { get; set; }
        public byte IsApproved { get; set; }
    }
}
