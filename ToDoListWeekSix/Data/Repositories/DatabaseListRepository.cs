using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWeekSix.Data.IInjection;
using ToDoListWeekSix.Models;
using ToDoListWeekSix.Models.DTOs;

namespace ToDoListWeekSix.Data.Repositories
{
    public class DatabaseListRepository : IListRepository
    {
        private readonly ListDbContext _context;
        private readonly UserManager<ToDoUser> userManager;

        public DatabaseListRepository(ListDbContext context, UserManager<ToDoUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ListDTO>> GetEntireList()
        {
            var list = await _context.Lists
                .Select(list => new ListDTO
                {
                    Id = list.Id,
                    Task = list.Task,
                    DueDate = list.DueDate,
                    Assignee = list.Assignee,
                    CreatedBy = list.CreatedByUserID,
                })
                .ToListAsync();

            return list;
        }

        public async Task<ListDTO> GetOneListItem(int id)
        {
            var listItem = await _context.Lists.FindAsync(id);

            if (listItem == null)
                return null;

            var user = await userManager.FindByIdAsync(listItem.CreatedByUserID);

            return new ListDTO
            {
                Id = listItem.Id,
                Task = listItem.Task,
                CreatedBy = user == null ? null : $"{user.FirstName} {user.LastName}",
            };
        }

        public async Task<List> UpdateList(List list, int id)
        {
            if (list.Id == id)
            {
                _context.Entry(list).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return list;
        }

        public async Task DeleteListItem(int id)
        {
            var listItem = await _context.Lists.FindAsync(id);
            _context.Entry(listItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task CreateListItem(List list)
        {
            _context.Entry(list).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}
