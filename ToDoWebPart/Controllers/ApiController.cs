using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoWebPart.Models;
using ToDoWebPart.Models.Reposittorys;

namespace ToDoWebPart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private IUserRepository repo;

        public ApiController(IUserRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public IEnumerable<ToDo> GetToDos(int userId)
        {
            return repo.ToDos.Where(t => t.UserId == userId);
        }

        [HttpGet]
        public User GetUser(string name, string password)
        {
            return repo.Users.Where(u => u.UserName == name && u.Password == Hash.GetHash(password)).FirstOrDefault();
        }

        [HttpPut]
        public void PutToDo([FromBody] ToDo task)
        {
            repo.AddToDo(task);
        }

        [HttpPost]
        public bool AddUser([FromBody] User user)
        {
            if (!repo.Users.Contains(user))
            {
                repo.AddUser(user);
                return true;
            }
            return false;
        }
    }
}