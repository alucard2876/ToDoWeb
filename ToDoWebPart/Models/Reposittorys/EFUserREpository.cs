using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models.Reposittorys
{
    public class EFUserREpository : IUserRepository
    {
        private ToDoContext context;
        public EFUserREpository(ToDoContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<User> Users => context.Users.Include(u => u.toDos);

        public IEnumerable<ToDo> ToDos => context.ToDos;

        public void AddUser(User user)
        {
            if(user != null)
            {
                context.Users.Add(user);
                context.SaveChangesAsync();
            }
        }

        public void AddToDo(ToDo todo)
        {
            if(todo != null)
            {
                
                context.ToDos.Add(todo);
                context.SaveChanges();
            }
        }

        public void UpdateToDo(ToDo todo)
        {
            var task = context.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();
            task.Header = todo.Header;
            task.StartDate = todo.StartDate;
            task.EndDate = todo.EndDate;
            task.Task = todo.Task;
            
            context.SaveChanges();
        }

        public void DeleteToDo(int todoId)
        {
           
            var currToDo = context.ToDos.Where(t=> t.Id == todoId).FirstOrDefault();
            context.Remove(currToDo);
            context.SaveChanges();
            
        }
    }
}
