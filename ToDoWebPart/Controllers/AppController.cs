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
            repo.AddToDo(Id,task);
            var user = repo.Users.Where(u => u.Id == Id).FirstOrDefault();
            return RedirectToAction("Index","App",user);
        }
    }
}

