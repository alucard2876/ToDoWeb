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
            return View();
        }

       
    }
}
