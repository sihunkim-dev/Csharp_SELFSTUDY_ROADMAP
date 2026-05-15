using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using To_Do_ListAPI.Models;
using To_Do_ListAPI.Services;

namespace To_Do_ListAPI.Controllers
{
    [ApiController]
    [Route("api/Todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        //GET : [HttpGet]
        [HttpGet]
        public async Task<IActionResult> GetAllTodoAsync()
        {
            var todos = await _todoService.GetAllTodoAsync();
            return Ok(todos);
        }
        //GET by Id : [HttpGet("{id}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoByIdAsync(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }
        //POST

        [HttpPost]
        public async Task<ActionResult<Todos>> CreateTodoAsync(Todos todos)
        {
            var createdTodo = await _todoService.CreateTodoAsync(todos);
            if (createdTodo == null)
                return BadRequest();

            return CreatedAtAction("GetTodoById", new { id = createdTodo.Id }, createdTodo);
        }


        //PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoAsync(int id, Todos todos)
        {
            var updatedTodo = await _todoService.UpdateTodoAsync(id, todos);
            if (updatedTodo == null)
            {
                return NotFound();
            }
            
            return NoContent();

        }
        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoAsync(int id)
        {
            var isDeleted = await _todoService.GetTodoByIdAsync(id);
            if (isDeleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}