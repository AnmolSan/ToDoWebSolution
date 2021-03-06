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
    public class ToDoAuditRepository : Repository<ToDoAudit>, IToDoAuditRepository
    {
        private ApplicationDbContext _db;
        public ToDoAuditRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
    }
}
