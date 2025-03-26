using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
