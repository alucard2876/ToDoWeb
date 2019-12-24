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

        public void AddUser(User user)
        {
            if(user != null)
            {
                context.Users.Add(user);
                context.SaveChangesAsync();
            }
        }

        public void AddToDo(int userId,ToDo todo)
        {
            if(todo != null)
            {
                context.Users.ElementAt(userId).toDos.Add(todo);
                context.SaveChangesAsync();
            }
        }

        public void DeleteToDo(int userId, int taskId)
        {
            var user = context.Users.ElementAt(userId);
            if(user != null)
            {
                context.Users.ElementAt(userId).toDos.RemoveAt(taskId);
                context.SaveChangesAsync();
            }
        }
    }
}
