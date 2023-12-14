using Azure;
using Azure.Communication.Email;
using CosmosDbTriggerFunction.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CosmosDbTriggerFunction
{
    public class NotifyFunction
    {
        [FunctionName("Notify")]
        public async Task Run([CosmosDBTrigger(
            databaseName: "TodoItemsDb",
            containerName: "TodoItems",
            Connection = "CosmosDbConnectionString",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)]IReadOnlyList<TodoItem> input,
            ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                string connectionString = Environment.GetEnvironmentVariable("CommunicationServiceConnectionString");
                EmailClient emailClient = new EmailClient(connectionString);

                var subject = "New Todo Item!";
                var htmlContent = $"<html><body><h1>{input[0].Title}</h1><br/><p>{input[0].Content}</p></body></html>";
                var sender = Environment.GetEnvironmentVariable("SenderMailAddress"); ;
                var recipient = Environment.GetEnvironmentVariable("RecipientMailAddress");

                try
                {
                    log.LogInformation($"Todo Id: {input[0].Id}. Sending email notification");
                    EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                        Azure.WaitUntil.Completed,
                        sender,
                        recipient,
                        subject,
                        htmlContent);
                    EmailSendResult statusMonitor = emailSendOperation.Value;

                    log.LogInformation($"Todo Id: {input[0].Id}. Email Sent. Status = {emailSendOperation.Value.Status}");

                    /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                    string operationId = emailSendOperation.Id;

                    log.LogInformation($"Email operation id = {operationId}");
                }
                catch (RequestFailedException ex)
                {
                    /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                    log.LogError($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
                }

            }
        }
    }

}
