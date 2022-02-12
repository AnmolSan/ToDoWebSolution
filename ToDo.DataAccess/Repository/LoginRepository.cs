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
    public class LoginRepository : ILoginRepository
    {
        private ApplicationDbContext _db;
        public LoginRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public UserModel GetFirstOrDefaultUser(UserModel obj)
        {
            var retriveUserFromDb = _db.UsersModel.Where(a=>a.UserName == obj.UserName && a.Password==obj.Password).FirstOrDefault();
            return retriveUserFromDb;
        }
    }
}
