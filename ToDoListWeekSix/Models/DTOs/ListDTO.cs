using System;

namespace ToDoListWeekSix.Models.DTOs
{
    public class ListDTO
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public string Assignee { get; set; }
        public string CreatedBy { get; set; }
    }
}
