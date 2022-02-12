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
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ToDo = new ToDoRepository(_db);
            Login = new LoginRepository(_db);
            ToDoAudit = new ToDoAuditRepository(_db);
        }
        public IToDoRepository ToDo { get; private set; }

        public ILoginRepository Login { get; private set; }

        public IToDoAuditRepository ToDoAudit { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
