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
        public Task<IEnumerable<ListDTO>> GetEntireList()
        {
            throw new NotImplementedException();
        }
    }
}
