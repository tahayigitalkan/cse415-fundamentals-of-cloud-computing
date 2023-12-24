# Lab 12 Exercise
## Create your Azure DevOps Workspace

Open your browser and navigate [Azure DevOps](https://dev.azure.com)

If you don't have an organization create a new:

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/951b4ff6-6a92-4c0d-9eee-0a67af742e20)

![WhatsApp Image 2023-12-21 at 15 56 17_99d85ffb](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/2ce30ed6-5977-4d5c-b255-bf1cdd9cd055)

After you've successfully created your organization you'll see your organization page:

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/e5e13b91-fd0a-4e71-990c-8f14801c6360)

Click 'Organization Settings" on the bottom left and navigate to 'Users' on the left menu. 

Add new User:
* User: 20195175002@ogr.akdeniz.edu.tr
* Access Level: Basic

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/b2296170-c617-44c4-86d5-c53446a57f2b)


Go back to your organization page and create a new project in your organization:
* Visibility: Private
* Version control: Git
* Work item process: Scrum

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/cf44bbbc-bd3a-47ec-a96e-47272c76dc8b)

The system will navigate you to the Project page:

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/37ac56ef-6c66-4338-92b8-3a0e3580114f)

Click 'Project Settings" on the bottom left and navigate to 'Teams' on the left menu. 
Select the default team and add new user '20195175002@ogr.akdeniz.edu.tr' to the team.

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/cf99d954-d364-45f6-8ddf-5b87e51bfb02)

Go back to the project page and navigate Boards>Work Items on the left menu
Create a new Item and Assign it to the user '20195175002@ogr.akdeniz.edu.tr'

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/de5b8e69-ff5e-4097-ab22-e5ef01635acf)

Now, you can see it on the boards:

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/1402add0-2761-4df9-89c6-82b9de6ee042)

Navigate to the Repos and save your Url and git credentials:

![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/87937a4a-0866-4e81-ad0e-bc9d2a94b678)

Open Bash/Command Line/Terminal:
 1. Navigate to the repo cse415-fundamentals-of-cloud-computing
 1. Clear local user info in the repo (git config --local credential.helper "")
 1. Add your remote Url to the repo (git remote add azure ...your url...)
  ![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/2e6fb629-0552-4985-8b32-dcd421fd0db5)


 1. Push repo to tour remote: (git push azure)
 1. It will prompt a password. Use the password you've saved.
  ![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/da8c7c1b-ec18-492c-a4fc-1b1a017f28e1)


Now, you can see the files on your repository. 
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/aa00c597-8715-40af-b98a-26a489f92d21)



##Create App Configuration on Azure Portal

Navigate to the Azure Portal and go to the web API you created the previous week. 
Select 'Identity' on the left menu and Enable System assigned Identity. 
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/67aa37b1-4966-4c15-8320-2066471ef6b6)

Navigate to the Azure Portal, Search App Configuration and Create new.
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/cee76d68-65ad-45b1-9363-263168e56ee6)
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/3918cc31-2f7f-4b3a-b440-53a33760e4ad)

Go to the Resource you've created. 
2. Select Access control (IAM) on the left menu. Select 'Role Assignments' and 'Add role assignment'
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/1b9717b8-5c1b-4bc2-a7b0-aa53afd258bd)

2. Select 'App Configuration Date Reader' Role
  ![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/cd7741e4-f233-4bcd-9079-c0633f5ead6d)

2. Check 'Managed Identity' and 'Select Members'. Select your Web API's identity and assign it.  
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/893a07d5-a796-45fc-9b17-45fed45572fb)

You can see all assigned roles on the screen. Now, Web API has access to read keys and their contents in the 'App Configuration'
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/8c25e7e9-a03c-4c16-b132-46905cced249)

You can keep and manage your application settings on this resource. Go to the 'Configuration Explorer' and Create a new Key-Value Reference:
![image](https://github.com/tahayigitalkan/cse415-fundamentals-of-cloud-computing/assets/24842468/884a8622-ff3c-4e07-a974-4e00d1b84069)


