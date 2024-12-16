using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFunctionApp
{
   
        public class TaskItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("taskId")]
            public string TaskId { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("assignedTo")]
            public string AssignedTo { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("dueDate")]
            public DateTime DueDate { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }
    
}
