using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWeekSix.Models;

namespace ToDoListWeekSix.Data
{
    public class ListDbContext : DbContext
    {
        public ListDbContext(DbContextOptions<ListDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed list data to check Get routes
            modelBuilder.Entity<List>()
                .HasData(
                new { Id = 1, Task = "Start up injection", DueDate = DateTime.Now, Assignee = "Chase" },
                new { Id = 2, Task = "Routing", DueDate = DateTime.Now, Assignee = "Chase" }
                );
        }

        DbSet<List> Lists { get; set; }
    }
}
