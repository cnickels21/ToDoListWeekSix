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

        }

        DbSet<List> Lists { get; set; }
    }
}
