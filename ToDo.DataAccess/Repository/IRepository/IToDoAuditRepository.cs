using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DataAccess.Repository.IRepository
{
    public interface IToDoAuditRepository : IRepository<ToDoAudit>
    {
    }
}
