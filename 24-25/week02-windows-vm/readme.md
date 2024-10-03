## Learning Objectives

In this lab exercise, you will learn the following concepts:

1. **IIS Installation and Configuration**:
   - Installing IIS on Windows Server 2019.
   - Setting up and configuring a web server to host websites.

2. **Website Deployment**:
   - Deploying a basic `index.html` file as a website using IIS.

3. **Domain Binding**:
   - Configuring a custom local domain by editing the `hosts` file.
   - Binding a domain to a website in IIS.

4. **Basic Networking**:
   - Understanding local DNS resolution and domain name bindings.

5. **Server Roles and Web Hosting**:
   - Hosting websites on a Windows Server environment and accessing them via a browser.

This lab exercise provides hands-on experience with fundamental web hosting, server management, and user administration tasks.


# Windows Server 2019: Install IIS and Deploy a Basic Website

This guide walks through the steps to install IIS,  deploy a basic website (`index.html`), and assign a domain name to the IIS website on a VM.

Login to the VM using your credentials (IP address, username and password)


## Step 1: Install IIS (Internet Information Services) (This step will be done by Student1 for each group)

1. Open **Server Manager** from the Start Menu.
2. Click **Manage** > **Add Roles and Features**.
3. Click **Next** until you reach the **Server Roles** page.
4. Check the box for **Web Server (IIS)**.
5. Click **Next** and then **Install**.
6. Wait for the installation to complete, then close the wizard.

---

## Step 2: Deploy a Basic Website

### Create a Web Directory

1. Open **File Explorer** and create a folder under `C:\inetpub\wwwroot\Student1Site`.
2. Inside the folder, create a new file named `index.html`.
3. Open `index.html` in **Notepad** and add the following content:

    ```html
    <!DOCTYPE html>
    <html>
    <head>
        <title>Student Website</title>
    </head>
    <body>
        <h1>Welcome to the Website! Student X</h1>
    </body>
    </html>
    ```

4. Save the file and close Notepad.

### Configure IIS to Use the Website

1. Open **IIS Manager**.
2. Expand the **server node** and then expand **Sites**.
3. Right-click **Sites** and select **Add Website**.
4. Set the following configurations:
   - **Site Name**: `Student1Website`
   - **Physical Path**: `C:\inetpub\wwwroot\Student1Site`
   - **Binding**: Leave the default HTTP on port 80.
5. Click **OK**.
6. Verify the website by opening a browser and navigating to `http://localhost`. You should see the content from `index.html`.

---

## Step 4: Assign a Domain Name to the IIS Website

### Update IIS to Bind the Domain

1. In **IIS Manager**, select the **StudentWebsite**.
2. Click **Bindings** in the right-hand pane.
3. Click **Add**.
4. In the **Hostname** field, enter `{{yourdomainname}}.com`.
5. Leave other fields as default (HTTP, port 80), then click **OK**.


### Modify the Hosts File
1. Go back **your computer**
2. Open **Notepad** as Administrator.
3. Navigate to `C:\Windows\System32\drivers\etc`.
4. Open the `hosts` file and add the following entry at the end of the file:

    ```
    {{machine_ip_address}}  {{yourdomainname}}.com
    ```

    example:
   ```
    10.47.5.2  tahayigitalkan.com
    ```

6. Save the file.

### Access the Website Using the Domain Name

1. Open a browser and go to `{{yourdomainname}}.com`.
2. You should see the `index.html` content displayed.

---

