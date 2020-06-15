using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListWeekSix.Data.IInjection;
using ToDoListWeekSix.Models.DTOs;
using ToDoListWeekSix.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ToDoListWeekSix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : Controller
    {
        private readonly IListRepository listRepository;

        public ListController(IListRepository listRepository)
        {
            this.listRepository = listRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ListDTO>> GetList()
        {
            return Ok(await listRepository.GetEntireList());
        }

        [Authorize]
        [HttpGet("MyList")]
        public async Task<IEnumerable<ListDTO>> GetMyList()
        {
            return await listRepository.GetMyList(GetUserId());
        }

        // Route constraint to define difference in end point between authorized get route
        [HttpGet("{id}")]
        public async Task<ListDTO> GetListItem(int id)
        {
            return await listRepository.GetOneListItem(id);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] List list)
        {
            await listRepository.UpdateList(list, id);
            return Ok("Complete");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task Delete(int id)
        {
            await listRepository.DeleteListItem(id);
        }

        [HttpPost]
        [Authorize(Policy = "lists.create")]
        public async Task<IActionResult> CreateListItem([FromBody] List list)
        {
            list.CreatedByUserID = GetUserId();
            await listRepository.CreateListItem(list);
            return Ok("Complete");
        }

        private string GetUserId()
        {
            return ((ClaimsIdentity)User.Identity).FindFirst("UserId")?.Value;
        }



    }
}