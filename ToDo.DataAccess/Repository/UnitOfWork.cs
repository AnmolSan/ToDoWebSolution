using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Data;
using ToDoApp.DataAccess.Repository.IRepository;

namespace ToDoApp.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ToDo = new ToDoRepository(_db);
        }
        public IToDoRepository ToDo { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
