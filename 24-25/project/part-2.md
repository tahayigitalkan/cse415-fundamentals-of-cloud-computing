# Part 2: Building an MVC Application for CRUD Operations on Azure Cosmos DB

In this part, you will:

1. **Develop an ASP.NET Core MVC (.NET 8) Application** that performs Create, Read, Update, and Delete (CRUD) operations on tasks stored in Cosmos DB.
2. **Integrate App Configuration and Key Vault** to securely retrieve the Cosmos DB connection string.
3. **Test the Application Locally** and **Deploy to Azure App Service**.

By the end of this part, you will have a functioning MVC application that connects to your Cosmos DB via App Configuration and Key Vault references, demonstrating best practices in secure configuration management and cloud-native development.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Introduction](#introduction)
3. [Step 1: Set Up the Development Environment](#step-1-set-up-the-development-environment)
4. [Step 2: Create a Basic MVC Web Application](#step-2-create-a-basic-mvc-web-application)
5. [Step 3: Implement CRUD Operations for Tasks](#step-3-implement-crud-operations-for-tasks)
6. [Step 4: Deploy Your Applications](#step-4-deploy-your-application)
7. [Step 5. Enabling System-Assigned Identity and Configuring RBAC for App Configuration and Key Vault](#step-5-system-assigned-identity)

---

## Prerequisites

- **Completed Part 1**: You should have Cosmos DB, Key Vault, and App Configuration set up, with your Cosmos DB connection string secured in Key Vault and referenced in App Configuration.
- **.NET 8 SDK**: [Download .NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- **Visual Studio Code (VS Code)**: [Download VS Code](https://code.visualstudio.com/).
- **Azure CLI**: [Install Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli).
- **Git** (optional for version control): [Download Git](https://git-scm.com/downloads).

---

## Introduction

In this part, you will create an ASP.NET Core MVC application to manage tasks stored in the Cosmos DB database configured in Part 1. You will use the Cosmos DB Core (SQL) API with the `.NET SDK` for CRUD operations. Application settings, including the Cosmos DB connection string, will be retrieved from App Configuration and Key Vault, ensuring secrets are never exposed directly in code.

---

## Step 1: Set Up the Development Environment

1. **Open VS Code**:
   - Launch Visual Studio Code.

2. **Install C# Extensions (if not installed)**:
   - Click on **Extensions** (Ctrl+Shift+X) in VS Code.
   - Search for **"C#"** and install the **C# extension by Microsoft** for improved IntelliSense and debugging.

3. **Check .NET SDK Installation**:
```bash
   dotnet --version
```

## Step 2: Create a Basic MVC Web Application

1. **Create a Project Directory**:
```bash
    mkdir Cse415FinalProject
    cd Cse415FinalProject
```

2. **Create a New MVC Project**:
```bash
    dotnet new mvc -n TaskManagementApp
    cd TaskManagementApp
```

3. **Restore and build**:
``` bash
    dotnet restore
    dotnet build
```

4. **Run the Application locally**:
``` bash
    dotnet run
```
 
    - Open link in your browser.
    - You should see the default MVC template running.


## Step 3:  Implement CRUD Operations for Tasks

1. **Install required packages**
``` bash
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.Azure.Cosmos
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration
dotnet add package Azure.Identity
```

2. **Create TaskItem Model**:

Create Models/TaskItem.cs

``` csharp
using Newtonsoft.Json;

namespace TaskManagementApp.Models
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
```

3. **Create a TaskController**

Create Controllers/TaskController.cs

``` csharp
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using Microsoft.Azure.Cosmos;
namespace TaskManagementApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public TaskController(IConfiguration configuration, CosmosClient cosmosClient)
        {
            _configuration = configuration;
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("TaskManagementDB", "Tasks");
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var query = "SELECT * FROM c";
            var iterator = _container.GetItemQueryIterator<TaskItem>(query);
            List<TaskItem> tasks = new List<TaskItem>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                tasks.AddRange(response);
            }

            return View(tasks);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem task)
        {
            var id = Guid.NewGuid().ToString();
            task.Id = id;
            task.TaskId = id;
            task.CreatedAt = DateTime.UtcNow;
            task.UpdatedAt = DateTime.UtcNow;

            await _container.CreateItemAsync(task, new PartitionKey(task.TaskId));
            return RedirectToAction(nameof(Index));
        }

    }
}


```

4. **Create Views for Task Operations**:

    - Under Views, create a Task folder.
    - Add Index.cshtml, Create.cshtml with appropriate HTML forms and tables.

Views/Task/Index.cshtml:

```html
@model IEnumerable<TaskManagementApp.Models.TaskItem>

@{
    ViewData["Title"] = "Tasks";
}

<h1>Tasks</h1>

<p>
    <a href="/Task/Create" class="btn btn-primary">Create New Task</a>
</p>

<table class="table">
    <thead>
        <tr>
            <th>Title</th>
            <th>Description</th>
            <th>Assigned To</th>
            <th>Status</th>
            <th>Due Date</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var task in Model)
        {
            <tr>
                <td>@task.Title</td>
                <td>@task.Description</td>
                <td>@task.AssignedTo</td>
                <td>@task.Status</td>
                <td>@task.DueDate.ToShortDateString()</td>
            </tr>
        }
    </tbody>
</table>


```


Views/Task/Create.cshtml:
```html
@model TaskManagementApp.Models.TaskItem

@{
    ViewData["Title"] = "Create Task";
}

<h1>Create Task</h1>

<form method="post" asp-action="Create">
    <div class="form-group">
        <label for="Title">Title</label>
        <input type="text" class="form-control" id="Title" name="Title" required />
    </div>
    <div class="form-group">
        <label for="Description">Description</label>
        <textarea class="form-control" id="Description" name="Description" required></textarea>
    </div>
    <div class="form-group">
        <label for="AssignedTo">Assigned To</label>
        <input type="text" class="form-control" id="AssignedTo" name="AssignedTo" required />
    </div>
    <div class="form-group">
        <label for="Status">Status</label>
        <input type="text" class="form-control" id="Status" name="Status" required />
    </div>
    <div class="form-group">
        <label for="DueDate">Due Date</label>
        <input type="date" class="form-control" id="DueDate" name="DueDate" required />
    </div>
    <button type="submit" class="btn btn-primary">Create</button>
    <a href="/Task/Index" class="btn btn-secondary">Cancel</a>
</form>


````


5. **Add Navigation Links**
    - Open Views/Shared/_Layout.cshtml
    - Locate the navigation bar section and add a link to the Task management section

``` html
<ul class="navbar-nav">
    <li class="nav-item">
        <a class="nav-link text-dark" href="/">Home</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark" href="/Task/Index">Tasks</a>
    </li>
</ul>
``` 

6. **Integrate App Configuration and Key Vault**
Update Program.cs

``` csharp
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Azure.Identity;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureAppConfiguration(options =>
{
    var token = new DefaultAzureCredential();
    var endpoint = builder.Configuration["AppConfig:Endpoint"];
    options.Connect(new Uri(endpoint), token);
    options.ConfigureKeyVault(kv => kv.SetCredential(token));
});


// Register CosmosClient as a Singleton
builder.Services.AddSingleton<CosmosClient>(sp =>
{
    string connectionString = sp.GetRequiredService<IConfiguration>()["CosmosDBConnectionString"];
    return new CosmosClient(connectionString);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

```

## Step 4. Deploy your application
  - Create an WebApp resource and deploy your application to the web app.
  - For detailed information look at week 04 lab exercise.
  - Go to **Environment Variables** section in the left hand menu. And add your App Config Url with key: **AppConfig:Endpoint**

## Step 5. Enabling System-Assigned Identity and Configuring RBAC for App Configuration and Key Vault

To allow your Web App (running on Azure App Service) to securely access configuration values and secrets without manual credentials, you need to:

1. **Enable a system-assigned managed identity on the Web App**.
2. **Use Role-Based Access Control (RBAC) to grant the Web App’s managed identity the necessary permissions in App Configuration and Key Vault**.

This approach eliminates the need to store secrets in code or configuration files, following best security practices.

---

### Steps to Enable System-Assigned Identity on the Web App

1. **Open the Web App in Azure Portal**:
   - Go to [https://portal.azure.com](https://portal.azure.com) and sign in.
   - In the left-hand menu, select **"App Services"**.
   - Locate and click on your Web App (e.g., `Cse415FinalProjectWeb`).

2. **Enable System-Assigned Managed Identity**:
   - In the Web App’s left-hand menu, under **"Settings"**, click **"Identity"**.
   - On the **System assigned** tab, set **Status** to **On**.
   - Click **"Save"**.
   
   After a moment, the Web App will have a system-assigned identity (a principal ID) that Azure manages.

---

### Configure RBAC for App Configuration

Your Web App will need to access settings stored in Azure App Configuration. By granting the managed identity RBAC roles, you ensure it can read configurations.

1. **Navigate to App Configuration in the Azure Portal**:
   - Search for your App Configuration resource (e.g., `Cse415FinalProjectAppConfig`) and select it.

2. **Open Access Control (IAM)**:
   - In the left-hand menu of the App Configuration resource, click **"Access control (IAM)"**.

3. **Add a Role Assignment**:
   - Click **"+ Add"** and select **"Add role assignment"**.
   - Choose a role that grants read access to App Configuration, for example:
     - **"App Configuration Data Reader"**: This role allows read access to configuration values.
   
4. **Select the Managed Identity**:
   - Under the **Members** tab, select **"User, group, or service principal"**.
   - Search for your Web App’s system-assigned identity by name.
   - Select it, then click **"Review + assign"** to apply the role assignment.

Your Web App now has permission to read configuration values from App Configuration.

---

### Configure RBAC for Key Vault

Your Web App also needs to retrieve secrets from Key Vault. Using RBAC instead of access policies is recommended for modern deployments.

1. **Navigate to Key Vault**:
   - Find your Key Vault (e.g., `Cse415FinalProjectKeyVault`) and select it in the Azure Portal.

2. **Open Access Control (IAM)** on Key Vault:
   - In the Key Vault’s left-hand menu, click **"Access control (IAM)"**.

3. **Add a Role Assignment**:
   - Click **"+ Add"** > **"Add role assignment"**.
   - Choose a role that grants read access to secrets, such as:
     - **"Key Vault Secrets User"**: Allows get/list of secrets.
   
4. **Select the Managed Identity**:
   - On the **Members** step, select **"User, group, or service principal"**.
   - Search for and select your Web App’s system-assigned identity.
   - Click **"Review + assign"** to finalize.

Your Web App can now read secrets from Key Vault at runtime using its managed identity.

---

### Verification

- **App Configuration Access**: With the `App Configuration Data Reader` role assigned, your Web App can retrieve application settings from App Configuration using the managed identity.
- **Key Vault Access**: With the `Key Vault Secrets User` role assigned, your Web App can read secrets from Key Vault without embedding keys in code.

When your application runs, it will use the managed identity for authentication. The assigned roles ensure it has the minimal permissions required to fetch configurations and secrets securely.

---

### Summary

By enabling the system-assigned managed identity on your Web App and assigning RBAC roles on App Configuration and Key Vault, you have established a secure, credential-free integration between these services. This setup follows best practices in cloud security and configuration management, reducing the risk of exposing secrets and making your application more maintainable and secure.



