using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineUserToDoList.App_Start;
using OnlineUserToDoList.Models;

namespace OnlineUserToDoList.Controllers
{
    public class ToDoController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult Create(ToDoBindingModel model)
        {
            var ctx = ApplicationDbContext.Create();
            var userId = User.Identity.GetUserId();

            var todoModel = AutoMapping.Mapper.Map<ToDoBindingModel, ToDoModel>(model);
            todoModel.UserId = userId;

            var lastRecord = ctx.ToDoList.Where(r => r.UserId == userId).OrderByDescending(r => r.RecordNumber).FirstOrDefault();
            if (lastRecord != null)
            {
                todoModel.RecordNumber = lastRecord.RecordNumber + 1;
            }
            else
            {
                todoModel.RecordNumber++;
            }

            ctx.ToDoList.Add(todoModel);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetToDos()
        {
            var context = ApplicationDbContext.Create();
            var user = context.Users.FirstOrDefault(r => r.UserName == User.Identity.Name);
            if (user != null)
            {
                var toDos = context.ToDoList.Where(r => r.UserId == user.Id).ToList();
                return Json(new
                {
                    draw = 1,
                    recordsTotal = toDos.Count,
                    recordsFiltered = toDos.Count,
                    data = toDos
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}