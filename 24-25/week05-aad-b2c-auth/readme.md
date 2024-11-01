# Azure AD B2C Authentication and Authorization in ASP.NET Core MVC (.NET 8)

This project demonstrates how to implement authentication and authorization in an ASP.NET Core MVC application using Azure Active Directory B2C (Azure AD B2C). Follow the steps below to set up and run the application.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Setup Instructions](#setup-instructions)
  - [1. Create an Azure AD B2C Tenant](#1-create-an-azure-ad-b2c-tenant)
  - [2. Register the MVC Application](#2-register-the-mvc-application)
  - [3. Create User Flows](#3-create-user-flows)
  - [4. Update Application Configuration](#4-update-application-configuration)
  - [5. Run the Application](#6-run-the-application)
- [Additional Resources](#additional-resources)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An [Azure subscription](https://azure.microsoft.com/free/)
- An [Azure AD B2C tenant](https://learn.microsoft.com/azure/active-directory-b2c/tutorial-create-tenant)

## Setup Instructions

### 1. Create an Azure AD B2C Tenant

If you don't have an Azure AD B2C tenant, follow these steps:

1. **Sign in to the Azure Portal**:
   - Go to the [Azure Portal](https://portal.azure.com) and sign in with your Azure account.

2. **Create a New Azure AD B2C Tenant**:
   - In the Azure Portal, click on **Create a resource**.
   - Search for **Azure Active Directory B2C** and select it.
   - Click **Create**.
   - Fill in the required information:
     - **Organization name**: A unique name for your tenant.
     - **Initial domain name**: A unique domain (e.g., `yourtenant.onmicrosoft.com`).
     - **Country or region**: Select your country or region.
   - Click **Create**.

### 2. Register the MVC Application

Register your MVC application in the Azure AD B2C tenant:

1. **Navigate to App Registrations**:
   - In your B2C tenant, go to **Azure AD B2C** > **App registrations**.
   - Click **New registration**.

2. **Register the Application**:
   - **Name**: `AzureAD-B2C-MVC-Demo`
   - **Supported account types**: `Accounts in any identity provider or organizational directory`
   - **Redirect URI**:
     - **Type**: `Web`
     - **URI**: `https://localhost:7017/signin-oidc`
   - Click **Register**.

3. **Configure Authentication**:
   - In the app registration, select **Authentication** from the left menu.
   - Under **Implicit grant and hybrid flows**, ensure **ID tokens** is checked.
   - Under **Front-channel logout URL**, enter `https://localhost:7017/signout-callback-oidc`.
   - Click **Save**.

### 3. Create User Flows

User flows define how users interact with your application during sign-up and sign-in:

1. **Navigate to User Flows**:
   - Go to **Azure AD B2C** > **User flows**.
   - Click **+ New user flow**.

2. **Create Sign Up and Sign In Flow**:
   - **Recommended user flow version**: Select **Recommended**.
   - **Flow type**: Choose **Sign up and sign in**.
   - **Name**: `B2C_1_SignUpSignIn`
   - **Identity providers**: Choose **Email signup** or any other providers you prefer.
   - **User attributes and claims**: Select attributes like **Display Name**, **Email Addresses**, etc.
   - Click **Create**.

### 4. Update Application Configuration

Configure your application to use Azure AD B2C settings:

1. **Modify appsettings.json**:

   ```json
   {
     "AzureAdB2C": {
       "Instance": "https://<your-tenant-name>.b2clogin.com/",
       "Domain": "<your-tenant-name>.onmicrosoft.com",
       "ClientId": "<your-application-id>",
       "SignUpSignInPolicyId": "B2C_1_SignUpSignIn",
       "CallbackPath": "/signin-oidc"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "AllowedHosts": "*"
   }

### 5. Run Application

Open terminal. Navigate to the project folder. src/AADExample/AADExample


RUN: dotnet run --launch-profile https
