using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class SessionClass
    {
        public bool IsActiveSession { get; set; }
        public UserModel userModel { get; set; }
        public ToDo toDo { get; set; }  

    }
}
