using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;

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
        public ActionResult Index()
        {
            IEnumerable<ToDo>ObjToDoList = _unitOfWork.ToDo.GetAll();
            return View(ObjToDoList);
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
            if (obj.Title == null)
            {
                TempData["emptyTitle"] = "Cannot save Empty Title";
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
            if (id == null || id == 0)
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
