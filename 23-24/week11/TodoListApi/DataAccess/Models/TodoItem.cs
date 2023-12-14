using Newtonsoft.Json;

namespace TodoItemsApi;
public class TodoItem
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("dueDate")]
    public DateTime DueDate { get; set; }

    [JsonProperty("isDone")]
    public bool IsDone { get; set; }
}