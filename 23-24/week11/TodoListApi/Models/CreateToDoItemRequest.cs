namespace TodoListApi.Models
{
    public class CreateToDoItemRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DueDate { get; set; }
    }
}
