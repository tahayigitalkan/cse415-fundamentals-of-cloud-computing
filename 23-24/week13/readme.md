# CI/CD

## Creating a service connection to the Azure subscription

To deploy your source code to the resources you need to create a service connection to the Azure Subscription.
1. Navigate to Azure DevOps
2. Select your Project
3. Go to Project settings (in the bottom left)
4. Select Pipelines -> Service Connections on the left menu
5. Create Service Connection -> Azure Resource Manager -> Workload Identity federation (automatic)
6. Select Scope Level 'Subscription' and select your subscription and resource group. In this step, it will ask you to log in to your Azure account.
7. Give a connection name and save it. You'll use it in the pipeline file.

![Screenshot 2023-12-27 223106](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/1c50acd8-4aa9-4ae6-97e6-5e9f7047b73f)
![Screenshot 2023-12-27 223120](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/a5fbe5b5-c5a0-47f2-899f-5d3e1cb99694)
![Screenshot 2023-12-27 223340](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/bdd248f3-1ffd-4810-8c60-a4c9c8117ef8)
![Screenshot 2023-12-27 223350](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/fe1ad34d-1ebd-4400-aea4-8ee0e4334d0c)
![Screenshot 2023-12-27 223702](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/ce769981-04c7-47d2-8cdf-009e32047998)
![Screenshot 2023-12-27 223749](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/26dcab95-dcf9-4f65-a0fa-ee1a47b564ae)


Now, you'll upload pipeline files to your repository. You can find the files in the repository [GitHub Repo](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/tree/main/23-24/week11/TodoListApi)
* ci-TodoListApi-master.yml
* cd-TodoListApi-release.yml
Download these files and change the content of the cd-TodoListApi-release.yml

* project: '' # Replace with the name of your Azure DevOps project
* azureSubscription: '' # Replace with the name of your Azure service connection (You've saved in the previous step)
* WebAppName: '' # Your web app name in the azure portal 

![Screenshot 2023-12-28 000912](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/56ea2dc7-1fe5-44cb-8c07-0a887790fe4a)
![Screenshot 2023-12-28 001839](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/029aced4-d8ee-472a-8564-2a403c559f52)


Commit your files to your main branch under 23/24/week11/TodoListApi
Copy and save file paths of two pipelines

![Screenshot 2023-12-27 233644](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/3f3f3002-f059-4e34-bed5-2b2e077e2b84)

1. Navigate your Azure DevOps Project and select Pipelines on the left menu
2. Select New Pipeline on the upper right
3. Select Azure Repos Git
4. Select your repo
5. Select 'Existing Azure Pipelines YAML file'
6. In the prompt, paste the ci-pipeline path you've saved in the 1st step
7. Create a pipeline

![Screenshot 2023-12-27 233434](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/f8207ba3-0359-453a-9e0d-922ecd70794c)
![Screenshot 2023-12-27 233448](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/50dfc743-fc7c-4057-96c7-8cfb7255933e)
![Screenshot 2023-12-27 233459](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/f1f70ed2-e82d-43ae-b2f6-477505edf464)
![Screenshot 2023-12-27 233700](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/a7855b4d-7f22-45a5-a573-00e13bbf08f4)
![Screenshot 2023-12-27 233725](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/b15294ed-3098-47fd-a438-c6e6fb93092d)

** !!! IMPORTANT !!! **

You need to rename your pipeline!
* ci pipeline name: ci-TodoListApi-master
* cd pipeline name: cd-TodoListApi-release
 
![Screenshot 2023-12-27 233738](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/4840e042-06e3-4d8e-b6f9-8c6acc152cc2)

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/7522a4fa-6ed9-4ffe-ad17-e0b30452d9d8)

![Screenshot 2023-12-27 233750](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/136a4c65-df84-4b92-86bc-df3f42e44266)

Apply the same steps for the CD pipelines and you'll have:
![Screenshot 2023-12-27 233929](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/ab68c777-ecf0-4c81-a715-f2952fabcf16)


## Testing your pipelines
 Add a single-line comment to the Program.cs and commit it to the main branch. 
 You can see that ci-pipeline automatically triggered

![Screenshot 2023-12-27 234040](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/04220651-a24e-4899-9f2f-06617dc4b4b6)
![Screenshot 2023-12-27 234057](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/c4d02c97-aeeb-4514-a74e-b779f76e57e7)

After the CI pipeline, the CD pipeline will be triggered automatically. You can see your build status in the pipelines menu. 

![2023-12-27_23h44_45](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/45d695f5-76b3-444b-9e6c-7def38a9b1e2)

 
