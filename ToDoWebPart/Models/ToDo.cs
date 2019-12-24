using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoWebPart.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Task { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
