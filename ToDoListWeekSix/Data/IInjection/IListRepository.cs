using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListWeekSix.Models;
using ToDoListWeekSix.Models.DTOs;

namespace ToDoListWeekSix.Data.IInjection
{
    public interface IListRepository
    {
        Task<IEnumerable<ListDTO>> GetEntireList();
        Task<ListDTO> GetOneListItem(int id);
        Task<List> UpdateList(List list, int id);
        Task DeleteListItem(int id);
        Task CreateListItem(List list);
    }
}
