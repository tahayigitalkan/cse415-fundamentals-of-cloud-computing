using Azure.Communication.Email;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TaskFunctionApp;
public class TaskChangedFunction
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TaskChangedFunction> _logger;

    public TaskChangedFunction(IConfiguration configuration, ILogger<TaskChangedFunction> logger)
    {
 
        _configuration = configuration;
      
        _logger = logger;
    }

    [Function("TaskChangedFunction")]
    public async Task Run(
        [CosmosDBTrigger(
                databaseName: "TaskManagementDB",
                containerName: "Tasks",
                Connection = "CosmosDBConnectionString", 
                LeaseContainerName = "leases",
                CreateLeaseContainerIfNotExists = true)] IReadOnlyList<TaskItem> input)
    {
        if (input != null && input.Count > 0)
        {
            string acsConnection = _configuration["ACS:ConnectionString"];
            var emailClient = new EmailClient(acsConnection);

            foreach (var task in input)
            {
                var emailContent = new EmailContent($"Task '{task.Title}' was created. Status: {task.Status}")
                {
                    PlainText = $"Task '{task.Title}' was created. Status: {task.Status}"
                };

                // Construct the email message
                var message = new EmailMessage(_configuration["FromEmail"],
                  _configuration["ToEmail"],
                   emailContent);

                try
                {
                    var response = await emailClient.SendAsync(Azure.WaitUntil.Completed, message);
                    _logger.LogInformation($"Email sent for task {task.Id}. Message ID: {response.Id}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to send email.");
                }
            }
        }
    }
}

