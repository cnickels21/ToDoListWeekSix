using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWeekSix.Data.IInjection;
using ToDoListWeekSix.Models.DTOs;

namespace ToDoListWeekSix.Data.Repositories
{
    public class DatabaseListRepository : IListRepository
    {
        private readonly ListDbContext _context;

        public DatabaseListRepository(ListDbContext context)
        {
            _context = context;
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
    }
}
