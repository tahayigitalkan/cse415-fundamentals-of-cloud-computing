# Introduction to Azure

In this tutorial, you will learn the basics of using Azure by logging into your Azure account, creating a subscription, setting up a resource group, deploying a virtual machine (VM), and connecting to the VM via Remote Desktop.

---

## Prerequisites

- An active Azure account (Your student account or personal account).
- Remote Desktop Connection (RDP) client installed on your local machine.

---

## Step 1: Logging into Your Azure Account

1. Open your browser and go to [Azure Portal](https://portal.azure.com/).
2. Log in with your Azure credentials.

---

## Step 2: Create a Subscription

1. In the Azure Portal, click on the **Subscriptions** tab in the left-hand menu.
2. Click **+ Add** to create a new subscription if you don't already have one.
3. Select the type of subscription you want to create (**Pay-As-You-Go**).
4. Fill in the required details and click **Create**.

---

## Step 3: Create a Resource Group

A resource group in Azure is a container that holds related resources for an Azure solution.

1. In the Azure Portal, search for **Resource Groups** in the top search bar and select it from the results.
2. Click **+ Create** to create a new resource group.
3. Choose the following settings:
   - **Subscription**: Select the subscription you created.
   - **Resource group name**: Enter a name for your resource group (e.g., `MyResourceGroup`).
   - **Region**: Select a region closest to you or your users.
4. Click **Review + Create** and then **Create** to create the resource group.

---

## Step 4: Create a Virtual Machine (VM)

1. In the Azure Portal, search for **Virtual Machines** in the top search bar.
2. Click **+ Create** and select **Azure Virtual Machine**.
3. In the **Basics** tab, fill out the following information:
   - **Subscription**: Select the subscription you created.
   - **Resource group**: Choose the resource group you just created (`MyResourceGroup`).
   - **Virtual machine name**: Give your VM a name (e.g., `MyVM`).
   - **Region**: Ensure the region matches the one selected for the resource group.
   - **Image**: Select a VM image (e.g., **Windows Server 2019**).
   - **Size**: Select the size of the VM (the default is usually fine for this tutorial).
   - **Administrator account**: Create a username and password for logging into the VM.
4. Click **Review + Create** and then **Create** to deploy the VM.

---

## Step 5: Connect to the Virtual Machine via Remote Desktop

1. Once the virtual machine has been created, navigate to the **Virtual Machines** section in the Azure Portal.
2. Select your VM (`MyVM`) from the list.
3. On the VM overview page, click **Connect** at the top, then select **RDP** (Remote Desktop Protocol).
4. A `.rdp` file will be downloaded to your computer.
5. Open the `.rdp` file with your Remote Desktop client.
6. When prompted, enter the **username** and **password** you set during VM creation.
7. Click **Connect** to establish a connection to your Azure VM.

---

## Conclusion

In this tutorial, you learned how to:
1. Log in to your Azure account.
2. Create a subscription.
3. Set up a resource group.
4. Deploy a virtual machine.
5. Connect to the virtual machine using Remote Desktop.

This basic introduction gives you a foundational understanding of using Azure to deploy and manage resources. You can now explore additional features and services available on the Azure platform.
