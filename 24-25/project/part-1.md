# Part 1: Setting Up Azure Cosmos DB, Key Vault, and App Configuration

1. **Create and Configure Azure Cosmos DB**
2. **Create and Configure Azure Key Vault**
3. **Create and Configure Azure App Configuration**
4. **Securely Store Cosmos DB Connection Strings**

By the end of this part, you will have a foundational Azure environment with a fully configured Cosmos DB, secure storage for secrets, and centralized application configurations.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Introduction to Azure Services](#introduction-to-azure-services)
3. [Step 1: Create a Resource Group](#step-1-create-a-resource-group)
4. [Step 2: Create an Azure Cosmos DB Account](#step-2-create-an-azure-cosmos-db-account)
5. [Step 3: Configure and Test Azure Cosmos DB](#step-3-configure-and-test-azure-cosmos-db)
6. [Step 4: Create an Azure Key Vault](#step-4-create-an-azure-key-vault)
7. [Step 5: Create an Azure App Configuration](#step-5-create-an-azure-app-configuration)
8. [Step 6: Securely Store Cosmos DB Connection String](#step-6-securely-store-cosmos-db-connection-string)
9. [Conclusion](#conclusion)
10. [Additional Resources](#additional-resources)

---

## Prerequisites

- **Azure Account**: If you don’t have one, [sign up for a free Azure account](https://azure.microsoft.com/free/).
- **Azure CLI (Optional)**: [Install the Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli).
- Familiarity with the Azure Portal is beneficial.
- **Visual Studio Code (Optional)**: [Download VS Code](https://code.visualstudio.com/) for editing code or scripts if needed.

---

## Introduction to Azure Services

### Azure Cosmos DB
A globally distributed, multi-model database service designed for low latency and high availability. Supports various APIs, including Core (SQL).

### Azure Key Vault
A secure service for storing secrets, keys, and certificates. It helps prevent sensitive information from being exposed in application code or configuration.

### Azure App Configuration
A centralized service for managing application settings and feature flags, allowing you to decouple configuration from code.

---

## Step 1: Create a Resource Group

1. **Log in to the Azure Portal**:
   - Go to [https://portal.azure.com/](https://portal.azure.com/) and sign in with your Azure credentials.

2. **Navigate to Resource Groups**:
   - From the Portal dashboard, click **"Resource groups"** in the left-hand menu.  
     If not visible, click **"All services"** and search for "Resource groups".

3. **Create a New Resource Group**:
   - Click **"+ Create"** at the top.
   - **Subscription**: Select your Azure subscription.
   - **Resource group name**: Provide a unique name (e.g. `Cse415FinalProject`).
   - **Region**: Select a region (e.g., `East US`).
   - Click **"Review + create"**, then **"Create"**.

---

## Step 2: Create an Azure Cosmos DB Account

1. **Create Cosmos DB Resource**:
   - Click **"Create a resource"** on the Portal dashboard.
   - Search for **"Azure Cosmos DB"** and select **"Azure Cosmos DB for NoSQL"**.
   - Click **"Create"**.

2. **Configure Cosmos DB Account**:
   - **Subscription**: Choose your subscription.
   - **Resource Group**: Select `Cse415FinalProject`.
   - **Account Name**: Enter a globally unique name (e.g. `cse415projectdb`).
   - **API**: Select **"Core (SQL)"**.
   - **Location**: Choose your region (e.g. `East US`).
   - **Capacity Mode**: Select **"Provisioned throughput"**.
   - **Free Tier**: Enable to take advantage of free usage.
   - Click **"Review + create"** and then **"Create"**.

3. **Wait for Deployment**:
   - Once complete, click **"Go to resource"** to access your Cosmos DB account.

---

## Step 3: Configure and Test Azure Cosmos DB

1. **Create Database and Container**:
   - In your Cosmos DB account, select **"Data Explorer"**.
   - Click **"New Database"**, name it `TaskManagementDB`, enable throughput if prompted, then click **"OK"**.
   - Within `TaskManagementDB`, click **"New Container"**.
   - **Container ID**: `Tasks`
   - **Partition Key**: `/taskId`
   - Click **"OK"**.

2. **Insert Sample Data**:
   - Select the `Tasks` container, click **"New Item"**.
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

3. **Query Data**:
   - Click **"New SQL Query"** and run:
     ```sql
     SELECT * FROM c WHERE c.taskId = "task1"
     ```
   - Confirm the inserted document appears in the results.

---

## Step 4: Create an Azure Key Vault

1. **Create Key Vault**:
   - Click **"Create a resource"**, search for "Key Vault" and select it.
   - **Subscription**: Select yours.
   - **Resource Group**: `Cse415FinalProject`.
   - **Name**: `Cse415FinalProjectKeyVault` (unique name).
   - **Region**: Same as Cosmos DB.
   - **Pricing Tier**: Standard.
   - Add an access policy for your account (Secret Management template).
   - Click **"Review + create"** and then **"Create"**.

2. **Go to Key Vault**:
   - Once deployed, click **"Go to resource"** to open Key Vault.

---

## Step 5: Create an Azure App Configuration

1. **Create App Configuration**:
   - Click **"Create a resource"**, search for "App Configuration".
   - **Subscription**: Select yours.
   - **Resource Group**: `Cse415FinalProject`.
   - **Name**: `Cse415FinalProjectAppConfig` (unique).
   - **Location**: Same region.
   - **SKU**: Standard.
   - Click **"Review + create"** and then **"Create"**.

2. **Go to App Configuration**:
   - Once deployed, click **"Go to resource"** to open the App Configuration instance.

3. **Enable System-Assigned Managed Identity on App Configuration**:
   - In the App Configuration instance, click **"Identity"** under the **"Settings"** section.
   - Switch the **System assigned** status to **On**, and then click **"Save"**.
   - Wait for a few moments while the managed identity is enabled. A principal ID will be assigned to App Configuration.
     *You will use this identity in RBAC in the next section.*

---

## Step 6: Securely Store Cosmos DB Connection String

### A. Retrieve Cosmos DB Connection String

1. **Get Connection String**:
   - In Cosmos DB account, under **"Settings"**, select **"Keys"**.
   - Copy the **Primary Connection String**.

### B. Add the Secret to Key Vault

1. **Go to Key Vault**:
   - In the Key Vault, select **"Secrets"** and **"+ Generate/Import"**.
   - **Name**: `CosmosDBConnectionString`.
   - **Value**: Paste the Cosmos DB connection string.
   - Click **"Create"**.

### C. Add a Key-Value in App Configuration Using Key Vault Reference

1. **Go to App Configuration**:
   - In the App Configuration instance, click **"Configuration Explorer"**.
   - Click **"+ Create"** to add a new key-value.

2. **Enter Key and Add Key Vault Reference**:
   - **Key**: `CosmosDBConnectionString`
   - **Value**: Instead of typing the reference string, click on the **"Add key vault reference"** button.
   - In the "Add key vault reference" pane:
     - Select your Key Vault (`Cse415FinalProjectKeyVault`).
     - Choose the secret `CosmosDBConnectionString`.
     - Click **"Apply"** or **"OK"** (depending on the interface).
    
    *If you get any error you need to grant RBAC (Role Based Access Control) for your user*
    - In the left-hand menu, select **"Access control (IAM)"**.
   - Click **"+ Add"** and then **"Add role assignment"**.
   - In the **Role** dropdown, select **"Key Vault Administrator"**.  
     *(This role allows full access to secrets in the Key Vault via RBAC.)*
   - Click **"Next"** to go to the **Members** tab.
   - Select **"Managed Identity"**, then **"Select members"**.
   - Search for and select the system-assigned managed identity corresponding to your App Configuration resource.
   - Click **"Review + assign"** to finalize.
       

4. **Save the Key-Value Pair**:
   - Confirm the Key and Value (now showing as a Key Vault reference).
   - Click **"Apply"** to save.

5.  **Grant App Configuration Access to Key Vault using RBAC**:
   - In the left-hand menu, select **"Access control (IAM)"**.
   - Click **"+ Add"** and then **"Add role assignment"**.
   - In the **Role** dropdown, select **"Key Vault Secrets User"**.  
     *(This role allows read (get/list) access to secrets in the Key Vault via RBAC.)*
   - Click **"Next"** to go to the **Members** tab.
   - Select **"User, group, or service principal"**, then **"Select members"**.
   - Search for and select the user.
   - Click **"Review + assign"** to finalize.

5. **Verify the Setup**:
   - Your application (or test code) should now retrieve the Cosmos DB connection string from App Configuration, which securely references Key Vault without exposing secrets directly.

---

## Conclusion

You have:

1. **Set up Azure Cosmos DB**: Created a database and container, tested data insertion and querying.
2. **Configured Azure Key Vault**: Stored the Cosmos DB connection string as a secret.
3. **Created Azure App Configuration**: Centralized configuration and integrated Key Vault references.
4. **Secured the Connection String**: Ensured sensitive information is retrieved securely via Key Vault references in App Configuration.

This foundational setup prepares your environment for further integration with applications and additional Azure services.

---

## Additional Resources

- [Azure Cosmos DB Documentation](https://docs.microsoft.com/azure/cosmos-db/)
- [Azure Key Vault Documentation](https://docs.microsoft.com/azure/key-vault/)
- [Azure App Configuration Documentation](https://docs.microsoft.com/azure/azure-app-configuration/)
- [Managing Access to Azure Key Vault](https://docs.microsoft.com/azure/key-vault/general/assign-access-policy-portal)
- [Use Key Vault references in App Configuration](https://docs.microsoft.com/azure/azure-app-configuration/use-azure-key-vault-references)

---

