using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name ="Due Date")]
        public DateTime DueDate { get; set; }

    }
}
