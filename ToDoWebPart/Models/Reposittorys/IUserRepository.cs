using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models.Reposittorys
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        IEnumerable<ToDo> ToDos { get; }

        public void AddUser(User user);

        public void AddToDo(ToDo todo);

        public void UpdateToDo(ToDo todo);
        public void DeleteToDo(int taskId);
    }
}
