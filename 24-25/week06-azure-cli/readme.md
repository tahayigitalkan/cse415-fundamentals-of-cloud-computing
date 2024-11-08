# Exercise: Create an Azure Storage Account Using Azure CLI

This repository contains an exercise for creating an Azure Storage account using the Azure Command-Line Interface (CLI). Follow the steps below to complete the exercise.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Steps](#steps)
  - [1. Open Your Terminal](#1-open-your-terminal)
  - [2. Log In to Azure](#2-log-in-to-azure)
  - [3. Set the Default Subscription (If Applicable)](#3-set-the-default-subscription-if-applicable)
  - [4. Create a Resource Group](#4-create-a-resource-group)
  - [5. Create a Storage Account](#5-create-a-storage-account)
  - [6. Verify the Storage Account Creation](#6-verify-the-storage-account-creation)
  - [7. Retrieve Storage Account Keys (Optional)](#7-retrieve-storage-account-keys-optional)


## Prerequisites

Before you begin, ensure you have the following:

- **Azure CLI Installed**: [Install Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli).

## Steps

### 1. Open Your Terminal

- **Windows**: Command Prompt or PowerShell
- **macOS/Linux**: Terminal

### 2. Log In to Azure

Log in to your Azure account using the Azure CLI:

```bash
az login
```

A browser window will open for you to authenticate.
If it doesn't open automatically, follow the CLI instructions provided in the terminal.

### 3. Set the Default Subscription (If Applicable)
If you have multiple subscriptions, set the desired one:

```bash
az account set --subscription "Your Subscription Name"
```


### 4. Create a Resource Group
Replace <resource-group-name> and <location> with your desired values:

```bash
az group create --name <resource-group-name> --location <location>
```

Example:

```bash
az group create --name MyResourceGroup --location eastus
```


### 5. Create a Storage Account
The storage account name must be unique across Azure. Replace <storage-account-name>:

```bash
az storage account create \
  --name <storage-account-name> \
  --resource-group <resource-group-name> \
  --location <location> \
  --sku Standard_LRS \
  --kind StorageV2
```

Example:

```bash
az storage account create \
  --name mystorageaccount12345 \
  --resource-group MyResourceGroup \
  --location eastus \
  --sku Standard_LRS \
  --kind StorageV2
```

### 6. Verify the Storage Account Creation
List storage accounts in your resource group:

```bash
az storage account list --resource-group <resource-group-name> --output table
```


Example:

```bash
az storage account list --resource-group MyResourceGroup --output table
```

Expected Output:

Name                  ResourceGroup    Location    SKU             Kind        AccessTier    ProvisioningState
--------------------  ---------------  ----------  --------------  ----------  ------------  -------------------
mystorageaccount12345 MyResourceGroup  eastus      Standard_LRS    StorageV2   Hot           Succeeded


### 7. Retrieve Storage Account Keys (Optional)
To access your storage account programmatically:

```bash
az storage account keys list \
  --account-name <storage-account-name> \
  --resource-group <resource-group-name> \
  --output table
```



## Conclusion
Congratulations! You've successfully created an Azure Storage account using the Azure CLI.