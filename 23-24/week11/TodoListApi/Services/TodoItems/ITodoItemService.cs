namespace TodoItemsApi;
public interface ITodoItemService
{
    Task<TodoItem> Add(TodoItem TodoItem);
    Task Delete(string id, string partition);
    Task<List<TodoItem>> Get(string cosmosQuery);
    Task<TodoItem> Update(TodoItem task);
}
