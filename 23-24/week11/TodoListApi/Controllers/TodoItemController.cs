using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;

namespace TodoItemsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase
{
    private readonly ITodoItemService _TodoItemService;

    public TodoItemController(ITodoItemService TodoItemService)
    {
        _TodoItemService = TodoItemService;
    }

    [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlQuery = "SELECT * FROM c";
            var result = await _TodoItemService.Get(sqlQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateToDoItemRequest request)
        {
            var result = await _TodoItemService.Add(new TodoItem
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Content = request.Content,
                DueDate = request.DueDate,
                IsDone = false
            });
           
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(TodoItem TodoItem)
        {
            var result = await _TodoItemService.Update(TodoItem);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id, string
        partition)
        {
            await _TodoItemService.Delete(id, partition);
            return Ok();
        }
}
