using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
