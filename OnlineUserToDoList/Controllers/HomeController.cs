using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineUserToDoList.Models;

namespace OnlineUserToDoList.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var context = ApplicationDbContext.Create();
            var user = context.Users.FirstOrDefault(r => r.UserName == User.Identity.Name);
            if (user != null)
            {
                var toDos = context.ToDoList.Where(r => r.UserId == user.Id).ToList();
                return View(toDos);
            }
            return View();
        }
    }
}