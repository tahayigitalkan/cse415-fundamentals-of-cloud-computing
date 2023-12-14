using Microsoft.Azure.Cosmos;
using TodoItemsApi;

var builder = WebApplication.CreateBuilder(args);

// Configure Azure Cosmos DB connection
builder.Services.AddSingleton<ITodoItemService>(options=>{
    string url = builder.Configuration["AzureCosmosDBSettings:Url"];
    string primaryKey = builder.Configuration["AzureCosmosDBSettings:PrimaryKey"];
    string databaseName = builder.Configuration["AzureCosmosDBSettings:DatabaseName"];
    string containerName = builder.Configuration["AzureCosmosDBSettings:ContainerName"];

    CosmosClient cosmosClient = new CosmosClient(url, primaryKey);
    return new TodoItemService(cosmosClient, databaseName, containerName);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
