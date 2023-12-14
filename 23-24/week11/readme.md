# Lab 11 Exercise 
In this lab exercise, you'll deploy a very basic Todo App. To do that, you'll create a Cosmos DB instance that will keep app data, a Web API that interacts with the DB, and a function that listens to the DB events and sends e-mail notifications.

## Create a new Resource Group
In the Azure Portal, search Research Groups and select + Create.

<img width="1436" alt="Screenshot 2023-12-14 at 00 16 11" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/b28de300-e767-4f5f-ab75-ccb3a6f775c4">

## Create a Cosmos DB Instance

Navigate through Azure Portal and Search "Azure Cosmos DB":
<img width="1436" alt="Screenshot 2023-12-14 at 00 16 52" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/6ce41885-49f6-4aab-b207-65b5b0196ed8">


Create Azure Cosmos Db For NoSQL:
<img width="1438" alt="Screenshot 2023-12-14 at 00 17 07" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/705ea24a-8781-472c-b2b4-fbe701d4b612">


Configure Basic properties:
<img width="1439" alt="Screenshot 2023-12-14 at 00 21 01" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/f1643d36-f3b4-4e8a-a5a2-ad347624a4fe">


In the network section, set public access enabled:
<img width="1440" alt="Screenshot 2023-12-14 at 00 22 12" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/487ca97a-ebcd-4333-8d6c-9cfb54b79352">


Set backup policy:
<img width="1439" alt="Screenshot 2023-12-14 at 00 23 00" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/223220ab-df81-4f02-9d09-06f9ffd7d21c">


Set data encryption:
<img width="1439" alt="Screenshot 2023-12-14 at 00 23 11" src="https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/ab23203a-29d1-46ee-8730-278598e86880">

Wait for the deployment and go to the resource that have been created.


Navigate "Data Explorer" on the left menu and create new container.

Database id : TodoItemsDb.

Container id: TodoItems.

Partition key: /id.
![Screenshot 2023-12-14 100001](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/5bb711f2-2bfc-4cff-8684-d5a28d401db7)

Navigate "Keys" on the left menu, copy and keep URI, Primary key, and primary connection string. You'll use these properties to configure Web API and Function. 
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/032ac27e-5b68-4946-8050-a154371b6ad8)


## Create a Web App
On the Azure Portal, search Web App and select "+Create"
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/8a6270b4-9c66-46b4-ab2c-e6cb55edef84)

Wait for the deployment and go to the resource that have been created.
Select "Configuration" on the left menu and set Application Settings (+New Application Setting):

>AzureCosmosDBSettings:Url - Azure Cosmos DB Url you've saved before

>AzureCosmosDBSettings:PrimaryKey - Azure Cosmos DB Primary Key you've saved before

>AzureCosmosDBSettings:DatabaseName - TodoItemsDb

>AzureCosmosDBSettings:ContainerName -  TodoItems

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/ffc58850-7dc0-4147-9c12-5312112e355b)

## Create a Communication Service
On the Azure Portal, search "Communication Services" and select "+Create"
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/6b1518a5-cf81-4600-bd4d-c462305dc509)


Wait for the deployment and go to the resource that have been created.
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/512ca327-4440-4af5-a54f-51ac0a38c201)


Select "Try Email" on the left menu" and "Set up a free Azure subdomain"
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/aae7345a-65df-407b-8cb0-57ff99c71227)

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/e31b1394-2ed0-4a4f-8081-4c19943efb4a)


Please note your domain (In the example "c79b408b-eb53-4ef5-81d5-0d63422db97a.azurecomm.net")
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/15ad9cdd-713d-4827-bf07-fc3019378937)


Navigate "Keys" on the left menu and note your "Connection String"
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/4463da7f-fe15-42ac-9639-f4100673fbf5)


## Create a Function App
On the Azure Portal, search Function App and select "+Create"
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/8a5dc53e-fe5c-4e0b-a2e6-5c2c4aec8213)

Set basic properties as follows:
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/23a12788-591d-441d-ac56-f80e8194c692)


Select "Configuration" on the left menu and set Application Settings:

>CommunicationServiceConnectionString - Communication Service connection string you've saved before

>CosmosDbConnectionString - Azure Cosmos DB connection string you've saved before

>SenderMailAddress - noreply@your-email-tenant 

>RecipientMailAddress - your mail address

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/8a880db1-cddf-4c58-986f-8f6b21622c39)

## Deploy your source code
You've created all the resources that you'll use. You need the deploy your Web API and Azure Function

Open projects in your IDE. (Visual Studio or VS Code) and deploy to azure Resources.

VsCode:

Function App:
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/192ada88-8d67-48fc-a569-da717bc85d2b)

>Detailed information: https://learn.microsoft.com/en-us/azure/azure-functions/functions-develop-vs-code?tabs=node-v3%2Cpython-v2%2Cisolated-process&pivots=programming-language-csharp

Web App:
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/3f0714e8-84bf-487f-bae2-2d51eb106d6d)

> Detailed information: https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/tutorials/publish-to-azure-webapp-using-vscode.md 

Visual Studio:
Click Publish - Azure and follow the instructions.
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/0aaf34f1-5d0b-427e-a4d2-e4839bb6dbe7)
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/cc6afac0-3fc3-4a03-9578-5685ee8c51e3)


## Test your deployment

Go to your web app URL using /swagger suffix and try POST endpoint. 
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/dfb98b2f-a80a-49b1-b739-667d6ea3b18e)

Check your email
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/3f71cd19-3cd3-42c0-86b8-541217b058e4)









