using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDo { get; }
        ILoginRepository Login { get; }
        IToDoAuditRepository ToDoAudit { get; }
        void Save();
    }
}
