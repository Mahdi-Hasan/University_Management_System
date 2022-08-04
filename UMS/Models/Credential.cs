using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Credential
    {
        [Key]
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? AdminId { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}
