using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoWebPart.Models;
using ToDoWebPart.Models.Reposittorys;

namespace ToDoWebPart.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repo;

        public HomeController(IUserRepository repository)
        {
            repo = repository;
        }

        public IActionResult Index()
        { 
            return View(null);
        }
        
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult SignIn(string UserName, string Password)
        {
            var user = repo.Users.Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Hash.GetHash(Password))).FirstOrDefault();

            return RedirectToAction("Index","App",user);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult SignUp(string UserName, string Password, string ConfirmPassword)
        {
            if(Password.Equals(ConfirmPassword))
            {
                var userCheck = repo.Users.Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Hash.GetHash(Password))).FirstOrDefault();
                if(userCheck == null)
                {
                    var user = new User { UserName = UserName, Password = Hash.GetHash(Password)};
                    repo.AddUser(user);
                    return RedirectToAction("Index", "App", user);
                }
                
            }
            return RedirectToAction("Error","Home", null);
            
        }
       
    }
}
