using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models.Reposittorys
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        public void AddUser(User user);

        public void AddToDo(int userId, ToDo todo);

        public void DeleteToDo(int userId, int taskId);
    }
}
