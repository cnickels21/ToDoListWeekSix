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

        public Task<IEnumerable<ListDTO>> GetEntireList()
        {
            throw new NotImplementedException();
        }
    }
}
