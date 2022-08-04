using System.ComponentModel.DataAnnotations;

namespace UMS.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
