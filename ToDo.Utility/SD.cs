using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;

namespace ToDoApp.Utility
{
    public class SD
    {
        //private IUnitOfWork _unitOfWork;
        //public SD(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
        //public JsonResult GetData()
        //{
        //    var userSessionData = HttpContext.Session.Get<ToDo>("userSession");
        //    var data = _unitOfWork.ToDo.GetAll(a => a.Id == userSessionData.Id);
        //    return Json(data, JsonRequestBehavior.AllowGet);

        //}
    }
}
