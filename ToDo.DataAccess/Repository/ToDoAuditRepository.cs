using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Data;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;

namespace ToDoApp.DataAccess.Repository
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private ApplicationDbContext _db;
        public ToDoRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        
        public void Update(ToDo obj)
        {
            _db.ToDos.Update(obj);
        }
    }
}
