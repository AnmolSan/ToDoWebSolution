using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoAudit
    {
        [Key] 
        public int Id { get; set; }
        
        public string Field { get; set; }
        [Display(Name ="Old Value")]
        public string OldValue { get; set; }
        [Display(Name = "New Value")]
        public string NewValue { get; set; }
        [Display(Name = "User Id")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public UserModel User { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Display(Name = "To-Do Id")]
        public int ToDoId { get; set; }
        
        [ForeignKey("ToDoId")]
        [ValidateNever]
        public ToDo toDo { get; set; }
    }
}
