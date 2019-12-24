using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Password { get; set; }
        public int ToDoId { get; set; }

        public List<ToDo> toDos { get; set; }
    }
}
