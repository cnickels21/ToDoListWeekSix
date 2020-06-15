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

            var admin = new IdentityRole { 
                Id = "admin", 
                Name = "administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "f7d11de5-b398-4434-a6b9-c117781c2985",
            };
            var user = new IdentityRole { 
                Id = "user", 
                Name = "user", 
                NormalizedName = "USER",
                ConcurrencyStamp = "6f454848-0477-4dd3-848c-72f51f6f2ab9",
            };

            builder.Entity<IdentityRole>()
                .HasData(admin, user);

            builder.Entity<IdentityRoleClaim<string>>()
                .HasData(
                    new IdentityRoleClaim<string> { Id = 1, RoleId = "admin", ClaimType = "Permissions", ClaimValue = "create" },
                    new IdentityRoleClaim<string> { Id = 2, RoleId = "admin", ClaimType = "Permissions", ClaimValue = "delete" },
                    new IdentityRoleClaim<string> { Id = 4, RoleId = "user", ClaimType = "Permissions", ClaimValue = "create" }
                );
        }
    }
}
