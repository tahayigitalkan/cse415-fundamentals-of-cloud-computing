# Lab Exercise: Deploying a .NET 8 Web Application to Azure App Service Using VS Code

In this lab exercise, you will learn how to create a free Azure App Service and deploy a .NET 8 web application using Visual Studio Code (VS Code). By the end of this tutorial, you'll have a live web application running on Azure.

---

## Prerequisites

Before you begin, ensure you have the following:

1. **Azure Account**:
   - If you don't have an Azure account, [sign up for a free Azure account](https://azure.microsoft.com/free/).

2. **Visual Studio Code (VS Code)**:
   - Download and install [VS Code](https://code.visualstudio.com/).

3. **.NET 8 SDK**:
   - Download and install the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

4. **Azure CLI**:
   - Install the [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli) for command-line management.

5. **Azure App Service Extension for VS Code**:
   - Open VS Code, go to the Extensions view (`Ctrl+Shift+X`), and install the **Azure App Service** extension.

6. **Git**:
   - Install [Git](https://git-scm.com/downloads).

---

## Step 1: Sign In to Azure

1. **Open Azure Portal**:
   - Navigate to [https://portal.azure.com/](https://portal.azure.com/) in your web browser.
   
2. **Sign In**:
   - Enter your Azure credentials to log in. If you’re using a free account, ensure you have access to create resources.

---

## Step 2: Create an Azure App Service

Azure App Service is a fully managed platform for building, deploying, and scaling web apps.

1. **Navigate to App Services**:
   - In the Azure Portal, click on **"Create a resource"** in the top-left corner.
   - Search for **"App Service"** and select it from the results.

2. **Create App Service**:
   - Click the **"Create"** button and select **"Web App"**

3. **Configure the App Service**:

   - **Subscription**: Select your Azure subscription.
   
   - **Resource Group**:
     - Click **"Create new"** and enter a name (e.g., `MyResourceGroup`).
     - Resource groups help organize related resources.
   
   - **Name**:
     - Enter a unique name for your App Service (e.g., `my-dotnet8-app`).
     - This name will be part of your app’s URL (`https://my-dotnet8-app.azurewebsites.net`).
   
   - **Publish**: Select **Code**.
   
   - **Runtime Stack**:
     - Choose **.NET 8 (LTS)** from the dropdown.
   
   - **Operating System**: Select **Windows**.
   
   - **Region**: Choose a region closest to you for better performance.
   
   - **App Service Plan**:
     - Click **"Create new"**.
     - Enter a name (e.g., `MyAppServicePlan`).
     - **Pricing Tier**: Select the **Free F1** tier to avoid costs. Click **"Select"**.
   
4. **Review and Create**:
   - Review your configurations and click **"Create"**.
   - Wait for the deployment to complete. You can monitor the progress in the **Notifications** area.

---

## Step 3: Deploy the .NET 8 Web Application to Azure App Service

In this step, you will deploy your .NET 8 web application to the Azure App Service. This deployment will make your application accessible over the internet.

### 1. Sign In to Azure in VS Code

Before deploying, ensure that you are signed into your Azure account within VS Code.

1. **Open VS Code**:
   - Launch Visual Studio Code on your computer.

2. **Open the Azure Extension**:
   - Click on the **Azure** icon in the Activity Bar on the left side of VS Code. If you don't see it, you can install the **Azure Tools** extension from the Extensions Marketplace.

3. **Sign In**:
   - In the Azure pane, click on **"Sign in to Azure..."**.
   - A browser window will open prompting you to enter your Azure credentials. Complete the sign-in process.
   - Once signed in, you should see your Azure subscriptions listed in the Azure pane.

### 2. Prepare Your Application for Deployment

Ensure your .NET 8 web application is ready for deployment.

1. **Build the Application**:
   - In the VS Code terminal, navigate to your project directory if you aren't already there:
     ```bash
     cd net8-api
     ```
   - Generate the deployment package locally:
     ```bash
     dotnet publish -c Release -o ./bin/Publish
     ```

### 3. Deploy to Azure App Service

Now, deploy your application to the Azure App Service you created.

**Right click the bin\Publish folder and select Deploy to Web App... and follow the prompts.**

1. Select the subscription where the Azure Web App resource is located.
2. Select the Azure Web App resource to which you will publish.
3. Select Deploy when prompted with a confirmation dialog.

**Once the deployment is finished, click Browse Website with /swagger path to validate the deployment.**

## Conclusion

In this step, you successfully deployed your .NET 8 web application to Azure App Service using Visual Studio Code. You:

1. **Signed into Azure** within VS Code.
2. **Prepared your application** by building and optionally running it locally.
3. **Deployed the application** to Azure App Service through the Azure extension in VS Code.
4. **Verified the deployment** by accessing the live application.

Your .NET 8 web application is now live on Azure, accessible via the internet, and set up for ongoing development and deployment.

---

## Additional Resources

- [Azure App Service Documentation](https://docs.microsoft.com/azure/app-service/)
- [.NET 8 Documentation](https://docs.microsoft.com/dotnet/core/dotnet-eight)
- [VS Code Azure Extensions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azureappservice)
- [Deploy a .NET App to Azure App Service](https://learn.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vscode?view=aspnetcore-8.0)

---



