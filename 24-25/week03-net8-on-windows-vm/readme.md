# Deploying a .NET 8 API to IIS

In this tutorial, you will configure IIS and deploy a pre-built .NET 8 API provided as publish files. Follow the steps to configure IIS, deploy the API, and ensure it runs properly.

---

## Prerequisites

1. **Published .NET 8 API files** (provided by the instructor).
2. **IIS** installed on the Server.
3. **Windows Server** with IIS enabled.
4. **Remote Desktop** access to the server.

---

## Step 1: Install IIS on the Server (If it is not installed)

If IIS is not already installed on your Windows machine, follow these steps to install it:

1. Open **Server Manager** (for Windows Server) or **Windows Features** (for Windows 10/11).
2. In **Server Manager**:
   - Click **Manage** > **Add Roles and Features**.
   - Choose **Role-based or feature-based installation**.
   - On the **Server Roles** page, select **Web Server (IIS)** and click **Next**.
   - Leave the default settings and click **Install**.

3. In **Windows Features** (for Windows 10/11):
   - Open the **Start Menu** and search for "Windows Features".
   - Check **Internet Information Services (IIS)** and click **OK**.

4. After the installation is complete, IIS should be running.

To verify, open a browser and navigate to `http://localhost`. You should see the IIS welcome page.

---

## Step 2: Configure IIS for .NET 8 API Deployment

### Enable .NET Hosting Bundle

For IIS to host .NET 8 applications, you must install the **.NET 8 Hosting Bundle**.

1. Download the **.NET Hosting Bundle** from the [official .NET website](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
2. Run the installer and follow the prompts to install the hosting bundle on your server.
   - This will configure IIS to host .NET Core/5/6/7/8 applications.

### Add the Application Pool

1. Open **IIS Manager** (Search for "IIS Manager" in the Start Menu).
2. In the **Connections** pane on the left, right-click **Application Pools** and select **Add Application Pool**.
3. Name your application pool (e.g., `MyApiAppPool`).
4. Set the **.NET CLR Version** to **No Managed Code** (since ASP.NET Core applications are self-contained).
5. Click **OK**.

### Set Up the Website

1. In **IIS Manager**, right-click **Sites** in the left pane and select **Add Website**.
2. Fill out the following:
   - **Site Name**: Choose a name for your site (e.g., `MyApiSite`).
   - **Physical Path**: Browse to the folder where you’ll place the published API files.
   - **Binding**: Leave the default settings (HTTP, Port 80) unless specified otherwise.
3. Select the **Application Pool** you created earlier (`MyApiAppPool`).
4. Click **OK**.

---

## Step 3: Deploy the .NET 8 API to IIS

1. **Copy the Published Files**:
   - You will receive a folder containing the published files for the .NET 8 API.
   - Copy these files to the physical path you specified when setting up the website in IIS (e.g., `C:\inetpub\wwwroot\MyApi`).

2. **Set Folder Permissions**:
   - Right-click on the deployment folder (e.g., `C:\inetpub\wwwroot\MyApi`) and go to **Properties** > **Security**.
   - Ensure that the **IIS_IUSRS** group has read and execute permissions for the folder.
   - Click **Apply** and **OK**.

---

## Step 4: Test the API Deployment

1. Open a browser and navigate to `http://localhost/example` or `http://<your-server-ip>/example`.
2. If the API is correctly deployed, you should see the default response or Swagger documentation (depending on how the API is set up).

If you encounter issues, check the following:
- **Application Pool Status**: Ensure the app pool is running.
- **Event Viewer**: Check for any error logs in the Event Viewer under **Windows Logs** > **Application**.

---
## Conclusion

You have successfully deployed a .NET 8 API to IIS. This tutorial covered:
1. Installing IIS and the .NET Hosting Bundle.
2. Configuring the application pool and website in IIS.
3. Deploying the published API files.
4. Testing the API to ensure it is running.

Your API is now live and ready to use on IIS.
