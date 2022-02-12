using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ToDoApp.DataAccess.Repository.IRepository;
using ToDoApp.Models;
using ToDoApp.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ToDoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(UserModel? user)
        {
            //var userSession = HttpContext.Session.GetString("userSession");
            var userSession = HttpContext.Session.Get<UserModel>("userSession");

            if (userSession==null)
            {
                return View(user);
            }
            //var convertToModel = JsonConvert.DeserializeObject<UserModel>(userSession);
            
            return View(userSession);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel credentialObj)
        {
            if (credentialObj.UserName == null || credentialObj.Password == null)
            {
                TempData["error"] = "Invalid User and Password";
                return View(credentialObj);
            }
            var user = _unitOfWork.Login.GetFirstOrDefaultUser(credentialObj);
            if (user != null)
            {
                
                 HttpContext.Session.Set<UserModel>("userSession", user);
                TempData["userSession"] = user.FullName;    
                return RedirectToAction("Index",user);



            }
            else
            {
                TempData["error"] = "User not found";
                return View(credentialObj);
            }
            return RedirectToAction("Index");

        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public JsonResult CheckSession()
        //{
        //    SessionClass session = new();
        //    if (HttpContext.Session.IsAvailable)
        //    {

        //    }
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}