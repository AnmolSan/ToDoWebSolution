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
        void Save();
    }
}
