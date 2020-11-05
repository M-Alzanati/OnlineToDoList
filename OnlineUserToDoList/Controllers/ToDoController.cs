using System.Collections.Generic;
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
        [HttpPost]
        public ActionResult Edit(ToDoBindingModel model)
        {
            var ctx = ApplicationDbContext.Create();
            var userId = User.Identity.GetUserId();

            var newTodoModel = AutoMapping.Mapper.Map<ToDoBindingModel, ToDoModel>(model);
            newTodoModel.UserId = userId;

            var oldTodo = ctx.ToDoList.FirstOrDefault(t => t.Id == newTodoModel.Id && t.UserId == userId);
            if (oldTodo != null)
            {
                oldTodo.DueDate = newTodoModel.DueDate;
                oldTodo.Title = newTodoModel.Title;
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(ToDoBindingModel model)
        {
            var ctx = ApplicationDbContext.Create();
            var userId = User.Identity.GetUserId();

            var oldTodo = ctx.ToDoList.FirstOrDefault(t => t.Id == model.Id && t.UserId == userId);
            if (oldTodo != null)
            {
                ctx.ToDoList.Remove(oldTodo);
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Done(ToDoBindingModel model)
        {
            var ctx = ApplicationDbContext.Create();
            var userId = User.Identity.GetUserId();

            var oldTodo = ctx.ToDoList.FirstOrDefault(t => t.Id == model.Id && t.UserId == userId);
            if (oldTodo != null)
            {
                oldTodo.Status = model.Status;
            }

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
                var toDoList = context.ToDoList.Where(r => r.UserId == user.Id).ToList();
                var toDosBindingModels = new List<ToDoBindingModel>();

                foreach (var toDo in toDoList)
                {
                    toDosBindingModels.Add(AutoMapping.Mapper.Map<ToDoModel, ToDoBindingModel>(toDo));
                }

                return Json(new
                {
                    draw = 1,
                    recordsTotal = toDosBindingModels.Count,
                    recordsFiltered = toDosBindingModels.Count,
                    data = toDosBindingModels
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}