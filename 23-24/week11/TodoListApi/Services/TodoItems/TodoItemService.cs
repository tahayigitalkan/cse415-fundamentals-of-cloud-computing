using Microsoft.Azure.Cosmos;

namespace TodoItemsApi;
public class TodoItemService : ITodoItemService
{
    private readonly Container _container;

    public TodoItemService(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }

    public async Task<TodoItem> Add(TodoItem TodoItem)
    {
        ItemResponse<TodoItem> response = await _container.CreateItemAsync(TodoItem, new PartitionKey(TodoItem.Id));
        return response.Resource;
    }

    public async Task Delete(string id, string partition)
    {
        await _container.DeleteItemAsync<TodoItem>(id, new
        PartitionKey(partition));
    }
    public async Task<List<TodoItem>> Get(string cosmosQuery)
    {
        var query = _container.GetItemQueryIterator<TodoItem>(new QueryDefinition(cosmosQuery));
        List<TodoItem> results = new List<TodoItem>();
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            results.AddRange(response);
        }
        return results;
    }
    public async Task<TodoItem> Update(TodoItem TodoItem)
    {
        var item = await _container.UpsertItemAsync<TodoItem>(TodoItem, new PartitionKey(TodoItem.Id));
        return item;
    }
}
