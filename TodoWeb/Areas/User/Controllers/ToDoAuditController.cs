using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;
using ToDoApp.Utility;

namespace ToDoWeb.Areas.User.Controllers
{
    public class ToDoAuditController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoAuditController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: ToDoAuditController
        public ActionResult Index(ToDoAudit? toDoAudit)
        {
            var userSession = HttpContext.Session.Get<UserModel>("userSession");
            if (userSession != null)
            {
                IEnumerable<ToDoAudit> ObjToDoList = _unitOfWork.ToDoAudit.GetAll(a => a.UserId == userSession.Id);
                return View(ObjToDoList);
            }

            TempData["error"] = "Login To Access To-do Audit List";
            return RedirectToAction("Login", "Home");
        }

        
    }
}
