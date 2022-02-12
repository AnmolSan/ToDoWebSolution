using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name ="Due Date")]
        public DateTime DueDate { get; set; }
        public bool isDone { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public UserModel UserModel { get; set; }

    }
}
