using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWeekSix.Models;

namespace ToDoListWeekSix.Data
{
    public class UsersDbContext : IdentityDbContext<ToDoUser>
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole { Id = "admin", Name = "administrator" };
            var user = new IdentityRole { Id = "user", Name = "user" };

            builder.Entity<IdentityRole>()
                .HasData(admin, user);
        }
    }
}
