using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebPart.Infrastructure;
using ToDoWebPart.Models;
using ToDoWebPart.Models.Reposittorys;

namespace ToDoWebPart.Controllers
{
    public class AppController : Controller
    {
        private IUserRepository repo;
        public AppController(IUserRepository repository)
        {
            repo = repository;
        }
        public IActionResult Index(User user)
        {
            var currUser = repo.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            HttpContext.Session.SetJson("Id",currUser.Id);
            HttpContext.Session.SetJson("User", currUser);
            return View(currUser);
        }

        public IActionResult AddTask()
        {
            var id = HttpContext.Session.GetJson<int>("Id");
            
            return View(id);
        }

        [HttpPost]
        public RedirectToActionResult AddTask(int Id, string Header, DateTime Start, DateTime End, string ToDo)
        {
            var task = new ToDo { Header = Header, StartDate = Start, EndDate = End, Task = ToDo, UserId = Id };
            repo.AddToDo(task);
            var user = HttpContext.Session.GetJson<User>("User");
            return RedirectToAction("Index","App",user);
        }

        [HttpPost]
        public IActionResult UpdateTask(int Id, string Header, DateTime Start, DateTime End, string ToDo,int userId)
        {

            var task = new ToDo {Id = Id, Header = Header, StartDate = Start, EndDate = End, Task = ToDo, UserId = userId };
            repo.UpdateToDo(task);
            
            var user = HttpContext.Session.GetJson<User>("User");
            return View("Index",user);
        }

        public IActionResult UpdateTask(int id)
        {
            var task = repo.ToDos.Where(t => t.Id == id).FirstOrDefault();
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteTask(int id)
        {
            var user = repo.Users.Where(u => u.Id == HttpContext.Session.GetJson<int>("Id")).FirstOrDefault();
            repo.DeleteToDo(id);

            return View("Index", user);
        }
    }
}

