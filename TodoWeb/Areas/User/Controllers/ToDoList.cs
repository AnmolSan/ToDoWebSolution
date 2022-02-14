using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;
using ToDoApp.Utility;

namespace ToDoWeb.Areas.User.Controllers
{
    public class ToDoList : Controller
    {
        private readonly IUnitOfWork _unitOfWork; 
        public ToDoList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        // GET: ToDoList
        public ActionResult Index(ToDo? toDo)
        {
            //var userSession = HttpContext.Session.GetString("userSession");
            var userSession = HttpContext.Session.Get<UserModel>("userSession");
            if (userSession!= null)
            {
                //var convertToModel = JsonConvert.DeserializeObject<UserModel>(userSession);
                IEnumerable<ToDo> ObjToDoList = _unitOfWork.ToDo.GetAll(a=>a.UserId == userSession.Id);
                return View(ObjToDoList);
            }

            TempData["error"] = "Login To Access To-do List";
            return RedirectToAction("Login","Home");
        }
        [HttpPost]
        
        
            
        public JsonResult AjaxMethod(string id, bool isDoneInput)
        {

            //var todo = _unitOfWork.ToDo.GetFirstOrDefault(a => a.Id == Convert.ToInt16(id));
            //todo.isDone = isDoneInput;
            //_unitOfWork.Save();
            //if (todo.isDone)
            //    return Json("Complete");
            return Json("Incomplete");

        }
        public ActionResult IsDone(int? id)
        {
            var userSession = HttpContext.Session.GetString("userSession");
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var todoFirstFromDb = _unitOfWork.ToDo.GetFirstOrDefault(x => x.Id == id);
            if (todoFirstFromDb == null)
            {
                return NotFound();
            }
            if (todoFirstFromDb.isDone)
                todoFirstFromDb.isDone = false;
            else
                todoFirstFromDb.isDone = true;

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(userSession))
                {
                    return RedirectToAction("Login","Home");
                }
                _unitOfWork.ToDo.Update(todoFirstFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Record updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error ! To-do not updated successfully";
            return View();
        }

        // GET: ToDoList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToDo obj)
        {
            //SessionVM sessionVM = new()
            if (obj.Title == null)
            {
                TempData["emptyTitle"] = "Cannot save Empty Title";
            }
            //var userSession = HttpContext.Session.GetString("userSession");
            var userSession = HttpContext.Session.Get<UserModel>("userSession");
            if (userSession == null)
            {
                TempData["Error"] = "Please Login !! Your session has expire";
                return RedirectToAction("Login", "Home");
            }
            //var convertToModel = JsonConvert.DeserializeObject<UserModel>(userSession);
            obj.UserId = userSession.Id;
            var sameTitle = _unitOfWork.ToDo.GetAll(a => a.UserId == obj.UserId && a.Title ==obj.Title);
            if (sameTitle.Any())
            {
                TempData["error"] = "Cannot add dublicate Title";
                return View();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Record Saved successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Oops!! Date not saved"; 
            return View(obj);
        }

        // GET: ToDoList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0 )
            {
                return NotFound();
            }
            var todoFirstFromDb = _unitOfWork.ToDo.GetFirstOrDefault(x => x.Id == id);
            if(todoFirstFromDb == null)
            {
                return NotFound();
            }
            return View(todoFirstFromDb);
        }

        // POST: ToDoList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToDo obj)
        {
           if(obj.DueDate < DateTime.Today)
            {
                ModelState.AddModelError("Due Date", "Please enter future date for the event.");
                TempData["dueDate"] = "Please enter future date for the event.";
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Record updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Error ! To-do not updated successfully";
            return View(obj);
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var todoFirstFromDb = _unitOfWork.ToDo.GetFirstOrDefault(x => x.Id == id);
            if (todoFirstFromDb == null)
            {
                return NotFound();
            }
            return View(todoFirstFromDb);
        }

        // POST: ToDoList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var todoFirstFromDb = _unitOfWork.ToDo.GetFirstOrDefault(u=>u.Id== id);
            if(todoFirstFromDb == null)
            {
                TempData["error"] = "Record not found";
                return NotFound();
            }
            _unitOfWork.ToDo.Remove(todoFirstFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Removed sucessfully";
            return RedirectToAction("Index");
        }
    }
}
