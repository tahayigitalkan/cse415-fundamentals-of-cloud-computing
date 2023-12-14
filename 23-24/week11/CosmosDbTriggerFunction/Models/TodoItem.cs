using System;

namespace CosmosDbTriggerFunction.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
      
        public string Title { get; set; }
   
        public string Content { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }
    }
}
