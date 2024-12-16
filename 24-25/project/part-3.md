# Part 3: Integrating Azure Communication Services and Azure Functions for Email Notifications

In this part, you will:

1. **Create an Azure Communication Services (ACS) resource** to enable email sending capabilities.
2. **Implement an Azure Function triggered by the Cosmos DB change feed** to detect when tasks are created or updated.
3. **Send email notifications** via ACS whenever a new task is inserted or an existing task is updated in Cosmos DB.

By the end of this part, you will have an event-driven architecture where changes in Cosmos DB trigger a serverless function that sends real-time email notifications, enhancing the overall functionality of your Task Management solution.

---

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Introduction](#introduction)
3. [Step 1: Create an Azure Communication Services Resource](#step-1-create-an-azure-communication-services-resource)
4. [Step 2: Retrieve ACS Credentials and Store in Key Vault](#step-2-retrieve-acs-credentials-and-store-in-key-vault)
5. [Step 3: Create an Azure Function App for Cosmos DB Change Feed](#step-3-create-an-azure-function-app-for-cosmos-db-change-feed)
6. [Step 4: Implement the Function to Send Emails](#step-4-implement-the-function-to-send-emails)
7. [Step 5: Configure RBAC and App Configuration References](#step-5-configure-rbac-and-app-configuration-references)
8. [Step 6: Test the Email Notification Flow](#step-6-test-the-email-notification-flow)
9. [Conclusion](#conclusion)
10. [Additional Resources](#additional-resources)

---

## Prerequisites

- **Completed Part 1 and Part 2**: You should have:
  - A Cosmos DB database and container set up.
  - A Key Vault and App Configuration resource with connection strings and secrets securely stored.
  - An MVC web application performing CRUD operations on tasks stored in Cosmos DB.
- **Azure CLI** installed.
- **.NET SDK** (8.0 or later) installed.
- **Azure Functions Core Tools** (Optional if you want to test locally): [Install Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local).

---

## Introduction

In previous parts, you built a secure, cloud-ready web application. Now, you will introduce event-driven capabilities. When a new task is created or updated in Cosmos DB, an Azure Function will use the Cosmos DB change feed to detect the change and send an email notification using Azure Communication Services (ACS).

This event-driven approach improves user experience by providing real-time alerts and demonstrates how multiple Azure services can work together seamlessly.

---

## Step 1: Create an Azure Communication Services Resource

1. **Create ACS in Azure Portal**:
   - Go to **"Create a resource"** in the Azure Portal.
   - Search for **"Communication Services"** and select it.
   - **Subscription**: Select yours.
   - **Resource Group**: `Cse415FinalProject` (or the group you have been using).
   - **Name**: A unique name (e.g., `Cse415ACSResource`).
   - **Location**: Same region as your other resources.
   - Click **"Review + create"**, then **"Create"**.

2. **Wait for Deployment**:
   - Once complete, click **"Go to resource"**.

3. **Set Up  a Free Azure-Provided Subdomain**

1. **Access the Email Feature in ACS**:
   - In the ACS resource page, find the **"Email"** section in the left-hand navigation pane (this may be under **"Settings"** or labeled **"Email (Preview)"** depending on the portal UI).

2. **Opt for the Free Azure-Provided Subdomain**:
   - When you open the Email section, look for the option to **"Try Email"**.
   - You will be given the choice to use a free Azure-provided domain. This domain typically looks like `*.communication.azure.com`.

3. **Select the Provided Subdomain**:
   - Follow the on-screen instructions to confirm the usage of the Azure-provided subdomain.
   - No DNS configuration is required on your side since Azure manages the domain and its verification.

4. **Verified Sender Address**:
   - Once the subdomain is set up by Azure, you will have a verified sender domain automatically.
   - Create or specify a sender email address using this domain (for example: `DoNotReply@<yoursubdomain>.communication.azure.com`).
   - This sender address will be automatically verified since Azure controls the subdomain.

5. **Use the Verified Sender in Your Code**:
   - With the free azure-provided subdomain and sender configured, you can now use this email address in your Azure Function email-sending code.
   - No additional domain verification steps are needed since Azure handles this for you.

By using the free Azure-provided subdomain, you can quickly start sending emails without configuring any DNS records or verifying a custom domain, making it ideal for development, testing, or initial proof-of-concept scenarios.

4. **Get Connection String for ACS**:
   - In the ACS resource overview, you should find a **"Keys and endpoints"** section.
   - Copy the **Primary Connection String** for ACS.

---

## Step 2: Retrieve ACS Credentials and Store in Key Vault

1. **Go to Key Vault**:
   - Open your Key Vault (`Cse415FinalProjectKeyVault`).

2. **Add ACS Connection String as a Secret**:
   - Click **"Secrets"** > **"+ Generate/Import"**.
   - **Name**: `ACSConnectionString`
   - **Value**: Paste the ACS connection string.
   - Click **"Create"**.

3. **Reference in App Configuration**:
   - Go to App Configuration (`Cse415FinalProjectAppConfig`).
   - In **Configuration Explorer**, click **"+ Create"**.
   - **Key**: `ACS:ConnectionString`
   - Use the **"Add key vault reference"** option to select `ACSConnectionString` secret from Key Vault.
   - Click **"Apply"**.

---

## Step 3: Create an Azure Function App for Cosmos DB Change Feed

1. **Create a Function App**:
   - In the Azure Portal, click **"Create a resource"**, search for **"Function App"**.
   - **Subscription**: Select yours.
   - **Resource Group**: `Cse415FinalProject`.
   - **Name**: `Cse415FinalProjectFunc` (unique name).
   - **Runtime stack**: `.NET`
   - **Version**: `.NET 8` (if available, else `.NET 6/7` and upgrade later).
   - **Region**: Same region.
   - **Plan type**: Consumption is fine for this scenario.
   - Click **"Review + create"**, then **"Create"**.

2. **Enable System-Assigned Identity on the Function App**:
   - Once deployed, go to the Function App resource.
   - Click **"Identity"** under **"Settings"**.
   - Turn **"System assigned"** to **On**.
   - Click **"Save"**.

3. **Configure RBAC and App Configuration References**
   - For the Function App:
   - Enable managed identity (done in Step 3).
   - In Key Vault, assign "Key Vault Secrets User" role to the Function App’s managed identity.
   - In App Configuration, assign "App Configuration Data Reader" role to the Function App’s managed identity.
   - In Function App Set **"CosmosDBConnectionString"** Environment variable  in format *@Microsoft.KeyVault(SecretUri=)*
   - In Function App Set **AppConfig:Endpoint** Environment variable.
---

## Step 4: Deploy Azure Function App
   - Deploy the Azure Function App (TaskFunctionApp folder) to the desired Azure environment using your preferred deployment method (e.g., Visual Studio, Azure CLI, or GitHub Actions).
   - Once deployment is complete, navigate to the Azure Portal.
   - Access the deployed Function App, and verify the presence of the TaskChangedFunction on the Overview page.
   - Conduct a test to validate the email flow functionality by triggering the TaskChangedFunction and confirming that emails are successfully sent and received.

