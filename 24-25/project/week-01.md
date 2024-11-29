# Week 1 Lab Exercise: Setting Up Azure Cosmos DB, Key Vault, and App Configuration

Welcome to **Week 1** of your Azure environment setup lab! This week, you will:

1. **Create and Configure Azure Cosmos DB**
2. **Create and Configure Azure Key Vault**
3. **Create and Configure Azure App Configuration**
4. **Securely Store Cosmos DB Connection Strings**

By the end of this week, you will have a foundational Azure environment with a fully configured Cosmos DB, secure storage for secrets, and centralized application configurations.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Introduction to Azure Services](#introduction-to-azure-services)
3. [Step 1: Create an Azure Cosmos DB Account](#step-1-create-an-azure-cosmos-db-account)
4. [Step 2: Configure and Test Azure Cosmos DB](#step-2-configure-and-test-azure-cosmos-db)
5. [Step 3: Create an Azure Key Vault](#step-3-create-an-azure-key-vault)
6. [Step 4: Create an Azure App Configuration](#step-4-create-an-azure-app-configuration)
7. [Step 5: Securely Store Cosmos DB Connection String](#step-5-securely-store-cosmos-db-connection-string)
8. [Conclusion](#conclusion)
9. [Additional Resources](#additional-resources)

---

## Prerequisites

Before you begin, ensure you have the following:

1. **Azure Account**:
   - An active Azure subscription. If you don't have one, [sign up for a free Azure account](https://azure.microsoft.com/free/).

2. **Azure CLI (Optional but Recommended)**:
   - Install the [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli) for command-line management.

3. **Basic Understanding of Azure Portal**:
   - Familiarity with navigating the Azure Portal will be beneficial.

4. **Visual Studio Code (Optional)**:
   - Install [Visual Studio Code](https://code.visualstudio.com/) if you prefer using it for any coding or script editing.

---

## Introduction to Azure Services

### **Azure Cosmos DB**
Azure Cosmos DB is a globally distributed, multi-model database service designed for high availability and low latency. It supports various data models, including document, key-value, graph, and column-family.

### **Azure Key Vault**
Azure Key Vault helps safeguard cryptographic keys and secrets used by cloud applications and services. It provides secure storage and management of sensitive information like connection strings, API keys, and certificates.

### **Azure App Configuration**
Azure App Configuration is a centralized service for managing application settings and feature flags. It allows developers to separate configuration settings from code, enabling easier management and deployment of applications.

---

## Step 1: Create an Azure Cosmos DB Account

1. **Log in to Azure Portal**:
   - Navigate to [https://portal.azure.com/](https://portal.azure.com/) and sign in with your Azure credentials.

2. **Create a New Cosmos DB Account**:
   - Click on **"Create a resource"** in the top-left corner.
   - In the search bar, type **"Azure Cosmos DB"** and select it from the dropdown.
   - Click **"Create"**.

3. **Configure the Cosmos DB Account**:
   
   - **Subscription**: Select your Azure subscription.
   
   - **Resource Group**: 
     - Click **"Create new"**.
     - Enter a name for your resource group (e.g., `LabProjectResourceGroup`).
     - Click **"OK"**.
   
   - **Account Name**: 
     - Enter a unique name for your Cosmos DB account (e.g., `tahayigitalkanhedehodo`).
     - The name must be globally unique and can contain only lowercase letters and numbers.
   
   - **API**: 
     - Select **"Core (SQL)"** for a document-oriented database.
   
   - **Location**: 
     - Choose a region  (e.g., `East US`).
   
   - **Capacity Mode**:
     - Select **"Provisioned throughput"** for this lab exercise.
   
   - **Apply Free Tier**:
     - Ensure the **"Enable free tier"** option is checked to take advantage of free usage limits.
   
   - **Tags** (Optional):
     - Add any tags if needed for resource organization.
   
4. **Review and Create**:
   - Click **"Review + create"**.
   - After validation passes, click **"Create"**.
   - Wait for the deployment to complete. You can monitor the progress in the **Notifications** area.

---

## Step 2: Configure and Test Azure Cosmos DB

1. **Navigate to Your Cosmos DB Account**:
   - Once deployment is complete, go to **"Go to resource"** or find your Cosmos DB account under **"All resources"**.

2. **Create a Database and Container**:

   - **Create Database**:
     - In the Cosmos DB overview, click on **"Data Explorer"** in the left-hand menu.
     - Click **"New Database"**.
     - Enter a database ID (`TaskManagementDB`).
     - Check **"Provision throughput"** and set it to the desired RU/s (Request Units per second). For free tier, keep it low (e.g., 400 RU/s).
     - Click **"OK"**.

   - **Create Container**:
     - Within the newly created database, click **"New Container"**.
     - **Container ID**: Enter a name for your container (e.g., `Tasks`).
     - **Partition Key**: Enter `/taskId`.
     - Click **"OK"**.

3. **Test the Cosmos DB Setup**:

   - **Insert Sample Data**:
     - In **Data Explorer**, navigate to `TaskManagementDB` > `Tasks`.
     - Click **"New Item"**.
     - Enter a JSON document. Example:
       ```json
       {
         "id": "1",
         "taskId": "task1",
         "title": "Set Up Azure Services",
         "description": "Configure Cosmos DB, Key Vault, and App Configuration.",
         "status": "In Progress",
         "assignedTo": "student1",
         "dueDate": "2024-05-10T00:00:00Z",
         "projectId": "project1",
         "createdAt": "2024-04-01T12:00:00Z",
         "updatedAt": "2024-04-05T15:30:00Z"
       }
       ```
     - Click **"Save"**.

   - **Query the Data**:
     - In **Data Explorer**, select your container (`Tasks`).
     - Click **"New SQL Query"**.
     - Enter the following query:
       ```sql
       SELECT * FROM c WHERE c.taskId = "task1"
       ```
     - Click **"Execute Query"**.
     - Verify that the inserted document appears in the results.

---

## Step 3: Create an Azure Key Vault

1. **Navigate to Azure Key Vault**:
   - In the Azure Portal, click on **"Create a resource"**.
   - Search for **"Key Vault"** and select it.
   - Click **"Create"**.

2. **Configure the Key Vault**:

   - **Subscription**: Select your Azure subscription.
   
   - **Resource Group**: Choose the existing resource group (`LabResourceGroup`).
   
   - **Key Vault Name**: Enter a unique name (e.g., `LabKeyVault123`).
   
   - **Region**: Select the same region as your Cosmos DB (`East US`).
   
   - **Pricing Tier**: Choose **Standard**.
   
   - **Access Policies**: 
     - Click **"Add Access Policy"**.
     - **Configure from template**: Select **"Secret Management"**.
     - **Select principal**: Click **"None selected"** and choose your user account.
     - Click **"Add"**.
   
   - **Review and Create**:
     - Click **"Review + create"**.
     - After validation, click **"Create"**.
     - Wait for the deployment to complete.

3. **Access the Key Vault**:
   - Once created, navigate to your Key Vault by clicking **"Go to resource"** or finding it under **"All resources"**.

---

## Step 4: Create an Azure App Configuration

1. **Navigate to Azure App Configuration**:
   - In the Azure Portal, click on **"Create a resource"**.
   - Search for **"App Configuration"** and select it.
   - Click **"Create"**.

2. **Configure the App Configuration**:

   - **Subscription**: Select your Azure subscription.
   
   - **Resource Group**: Choose the existing resource group (`LabResourceGroup`).
   
   - **Name**: Enter a unique name (e.g., `LabAppConfig123`).
   
   - **Location**: Select the same region as your other resources (`East US`).
   
   - **SKU**: Choose **Standard** for this lab.
   
   - **Tags** (Optional):
     - Add any tags if necessary for resource organization.
   
   - **Review and Create**:
     - Click **"Review + create"**.
     - After validation, click **"Create"**.
     - Wait for the deployment to complete.

3. **Access the App Configuration**:
   - Once created, navigate to your App Configuration by clicking **"Go to resource"** or finding it under **"All resources"**.

---

## Step 5: Securely Store Cosmos DB Connection String

Now that you have both **Azure Cosmos DB** and **Azure Key Vault** set up, it's time to securely store your Cosmos DB connection string in **Key Vault** and manage it via **App Configuration**.

### **A. Retrieve Cosmos DB Connection String**

1. **Navigate to Cosmos DB Account**:
   - In the Azure Portal, go to your Cosmos DB account (`tahayigitalkanhedehodo`).

2. **Access Keys**:
   - In the left-hand menu, under **"Settings"**, click on **"Keys"**.

3. **Copy Primary Connection String**:
   - Under **"Primary Connection String"**, click **"Copy"** to copy the connection string to your clipboard.

### **B. Store Connection String in Azure Key Vault**

1. **Navigate to Key Vault**:
   - Go to your Key Vault (`LabKeyVault123`).

2. **Add a Secret**:
   - In the left-hand menu, click on **"Secrets"**.
   - Click **"+ Generate/Import"**.

3. **Configure Secret**:
   - **Upload Options**: Select **"Manual"**.
   - **Name**: Enter a name for the secret (e.g., `CosmosDBConnectionString`).
   - **Value**: Paste the copied Cosmos DB connection string.
   - Click **"Create"**.

4. **Verify Secret Creation**:
   - You should see the newly created secret in the **Secrets** list.

### **C. Add Connection String to Azure App Configuration**

1. **Navigate to App Configuration**:
   - Go to your App Configuration instance (`LabAppConfig123`).

2. **Create a New Key-Value Pair**:
   - In the left-hand menu, click on **"Configuration Explorer"**.
   - Click **"+ Create"**.

3. **Configure Key-Value Pair**:
   - **Key**: Enter a key name (e.g., `CosmosDB:ConnectionString`).
   - **Value**: Enter a placeholder or reference (e.g., `@Microsoft.KeyVault(VaultName=LabKeyVault123;SecretName=CosmosDBConnectionString)`).
   - **Label**: You can leave it blank or specify a label if needed.
   - Click **"Apply"**.

4. **Link App Configuration with Key Vault**:
   - Azure App Configuration supports Key Vault references, allowing you to securely retrieve secrets.
   - Ensure that **App Configuration** has access to **Key Vault**:
     - In Key Vault, under **"Access policies"**, ensure that the App Configuration has **"Get"** permissions for secrets.
     - If not, add an access policy:
       - Click **"Add Access Policy"**.
       - **Configure from template**: Select **"Secret Management"**.
       - **Select principal**: Click **"None selected"** and choose your App Configuration's managed identity.
       - Click **"Add"** and then **"Save"**.

5. **Test the Configuration**:
   - Use Azure Portal or your application to fetch the connection string from App Configuration.
   - The connection string should be securely retrieved from Key Vault without exposing it directly in App Configuration.

---

## Conclusion

In **Week 1**, you successfully:

1. **Created and Configured Azure Cosmos DB**:
   - Set up a Cosmos DB account, created a database and container, and inserted sample data to test the setup.

2. **Created and Configured Azure Key Vault**:
   - Established a Key Vault to securely store secrets like the Cosmos DB connection string.

3. **Created and Configured Azure App Configuration**:
   - Set up App Configuration to manage application settings and integrated it with Key Vault for secure secret management.

4. **Secured Cosmos DB Connection String**:
   - Retrieved the Cosmos DB connection string and stored it securely in Key Vault.
   - Linked the connection string in App Configuration using Key Vault references.

These foundational steps ensure that your Azure environment is secure, well-organized, and ready for the upcoming weeks where you will integrate additional services like databases, app configurations, and more.

---

## Additional Resources

- [Azure Cosmos DB Documentation](https://docs.microsoft.com/azure/cosmos-db/)
- [Azure Key Vault Documentation](https://docs.microsoft.com/azure/key-vault/)
- [Azure App Configuration Documentation](https://docs.microsoft.com/azure/azure-app-configuration/)
- [Azure CLI Documentation](https://docs.microsoft.com/cli/azure/)
- [Managing Access to Azure Key Vault](https://docs.microsoft.com/azure/key-vault/general/assign-access-policy-portal)
- [Using Azure App Configuration with Azure Key Vault](https://docs.microsoft.com/azure/azure-app-configuration/use-azure-key-vault-references)

---
