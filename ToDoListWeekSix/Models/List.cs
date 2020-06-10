using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoListWeekSix.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public string Assignee { get; set; }
        public string CreatedByUserID { get; set; }
    }
}
