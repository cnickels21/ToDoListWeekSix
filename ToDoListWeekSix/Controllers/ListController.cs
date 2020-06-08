using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListWeekSix.Data.IInjection;
using ToDoListWeekSix.Models.DTOs;

namespace ToDoListWeekSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : Controller
    {
        IListRepository listRepository;

        public ListController(IListRepository listRepository)
        {
            this.listRepository = listRepository;
        }

        public async Task<ActionResult<ListDTO>> Index()
        {
            var list = await listRepository.GetEntireList();
            // return list;
            return View(list);
        }
    }
}