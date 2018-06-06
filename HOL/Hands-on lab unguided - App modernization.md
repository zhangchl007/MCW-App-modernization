![](images/HeaderPic.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
App modernization
</div>

<div class="MCWHeader2">
Hands-on lab unguided
</div>

<div class="MCWHeader3">
February 2018
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.
© 2018 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at https://www.microsoft.com/en-us/legal/intellectualproperty/Trademarks/Usage/General.aspx are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Abstract and learning objectives](#abstract-and-learning-objectives)
- [Overview](#overview)
- [Solution architecture](#solution-architecture)
- [Requirements](#requirements)
- [Exercise 1: Azure data, storage, and app environment setup](#exercise-1-azure-data-storage-and-app-environment-setup)
    - [Help references](#help-references)
    - [Task 1: Create web app, SQL database, and storage instances and migrate SQL](#task-1-create-web-app-sql-database-and-storage-instances-and-migrate-sql)
        - [Tasks to complete](#tasks-to-complete)
        - [Exit criteria](#exit-criteria)
- [Exercise 2: Identity and security](#exercise-2-identity-and-security)
    - [Help references](#help-references-1)
    - [Task 1: Create a new Contoso user](#task-1-create-a-new-contoso-user)
        - [Tasks to complete](#tasks-to-complete-1)
        - [Exit criteria](#exit-criteria-1)
    - [Task 2: Add the Web API application](#task-2-add-the-web-api-application)
        - [Tasks to complete](#tasks-to-complete-2)
        - [Exit criteria](#exit-criteria-2)
    - [Task 3: Expose Web API to other applications](#task-3-expose-web-api-to-other-applications)
        - [Tasks to complete](#tasks-to-complete-3)
        - [Exit criteria](#exit-criteria-3)
    - [Task 4: Add the ContosoInsurance desktop (WinForms) application](#task-4-add-the-contosoinsurance-desktop-winforms-application)
        - [Tasks to complete](#tasks-to-complete-4)
        - [Exit criteria](#exit-criteria-4)
    - [Task 5: Add the mobile application](#task-5-add-the-mobile-application)
        - [Tasks to complete](#tasks-to-complete-5)
        - [Exit criteria](#exit-criteria-5)
    - [Task 6: Configure access control for the PolicyConnect web application](#task-6-configure-access-control-for-the-policyconnect-web-application)
        - [Tasks to complete](#tasks-to-complete-6)
        - [Exit criteria](#exit-criteria-6)
    - [Task 7: Grant the ContosoInsurance Web app permissions to the Web API app](#task-7-grant-the-contosoinsurance-web-app-permissions-to-the-web-api-app)
        - [Tasks to complete](#tasks-to-complete-7)
        - [Exit criteria](#exit-criteria-7)
- [Exercise 3: Configure blob storage and search indexing](#exercise-3-configure-blob-storage-and-search-indexing)
    - [Help references](#help-references-2)
    - [Task 1: Bulk upload PDFs to blob storage](#task-1-bulk-upload-pdfs-to-blob-storage)
        - [Tasks to complete](#tasks-to-complete-8)
    - [Task 2: Create an Azure search service](#task-2-create-an-azure-search-service)
        - [Tasks to complete](#tasks-to-complete-9)
    - [Task 3: Configure full-text search indexing](#task-3-configure-full-text-search-indexing)
        - [Tasks to complete](#tasks-to-complete-10)
        - [Exit criteria](#exit-criteria-8)
- [Exercise 4: Configure Key Vault](#exercise-4-configure-key-vault)
    - [Help references](#help-references-3)
    - [Task 1: Create a new Key Vault](#task-1-create-a-new-key-vault)
        - [Tasks to complete](#tasks-to-complete-11)
    - [Task 2: Create a new secret to store the SQL connection string](#task-2-create-a-new-secret-to-store-the-sql-connection-string)
        - [Tasks to complete](#tasks-to-complete-12)
    - [Task 3: Add Client Id, Client Secret, and Secret URL to Web API's app settings](#task-3-add-client-id-client-secret-and-secret-url-to-web-apis-app-settings)
        - [Tasks to complete](#tasks-to-complete-13)
- [Exercise 5: Configure and deploy the Contoso Insurance apps](#exercise-5-configure-and-deploy-the-contoso-insurance-apps)
    - [Task 1: Deploy the Web API](#task-1-deploy-the-web-api)
        - [Tasks to complete](#tasks-to-complete-14)
        - [Exit criteria](#exit-criteria-9)
    - [Task 2: Deploy the Contoso Insurance web app](#task-2-deploy-the-contoso-insurance-web-app)
        - [Tasks to complete](#tasks-to-complete-15)
        - [Exit criteria](#exit-criteria-10)
    - [Task 3: Configure and run the legacy desktop (Windows Forms) application](#task-3-configure-and-run-the-legacy-desktop-windows-forms-application)
        - [Tasks to complete](#tasks-to-complete-16)
        - [Exit criteria](#exit-criteria-11)
    - [Task 4: Configure and run the mobile application](#task-4-configure-and-run-the-mobile-application)
        - [Tasks to complete](#tasks-to-complete-17)
        - [Exit criteria](#exit-criteria-12)
- [Exercise 6: Create a Flow app that sends push notifications when important emails arrive](#exercise-6-create-a-flow-app-that-sends-push-notifications-when-important-emails-arrive)
    - [Task 1: Sign up for a Flow account](#task-1-sign-up-for-a-flow-account)
        - [Tasks to complete](#tasks-to-complete-18)
    - [Task 2: Create new flow](#task-2-create-new-flow)
        - [Tasks to complete](#tasks-to-complete-19)
    - [Task 3: Test your flow](#task-3-test-your-flow)
        - [Tasks to complete](#tasks-to-complete-20)
        - [Exit criteria](#exit-criteria-13)
- [Exercise 7: Create an app in PowerApps](#exercise-7-create-an-app-in-powerapps)
    - [Help references](#help-references-4)
    - [Task 1: Sign up for a PowerApps account](#task-1-sign-up-for-a-powerapps-account)
        - [Tasks to complete](#tasks-to-complete-21)
    - [Task 2: Create a new SQL connection](#task-2-create-a-new-sql-connection)
        - [Tasks to complete](#tasks-to-complete-22)
    - [Task 3: Create a new app](#task-3-create-a-new-app)
        - [Tasks to complete](#tasks-to-complete-23)
    - [Task 4: Design app](#task-4-design-app)
        - [Tasks to complete](#tasks-to-complete-24)
    - [Task 5: Edit the app settings and run the app](#task-5-edit-the-app-settings-and-run-the-app)
        - [Tasks to complete](#tasks-to-complete-25)
        - [Exit criteria](#exit-criteria-14)
- [After the hands-on lab](#after-the-hands-on-lab)
    - [Task 1: Delete the Resource Group in which you placed your Azure resources.](#task-1-delete-the-resource-group-in-which-you-placed-your-azure-resources)
    - [Task 2: Delete the Azure Active Directory app registrations for Desktop and Mobile](#task-2-delete-the-azure-active-directory-app-registrations-for-desktop-and-mobile)

<!-- /TOC -->

## Abstract and learning objectives 

Modernize legacy on-premise applications and infrastructure by leveraging several cloud services, while adding a mix of web and mobile services, all secured using AAD.

Learning Objectives:

-   Use Azure App Services

-   Protect app secrets using Key Vault

-   Empower business users to create ad-hoc CRUD mobile apps with PowerApps

-   Centralize authorization across Azure services using AAD

-   Orchestrate between services such as Office 365 email and mobile using Flow

-   Use Search to make files full text searchable

## Overview

The App Modernization hands-on lab is an exercise that will challenge you to implement an end-to-end scenario using a supplied sample that is based on Microsoft Azure App Services and related services. The scenario will include implementing compute, storage, security, and search, using various components of Microsoft Azure. The hands-on lab can be implemented on your own, but it is highly recommended to pair up with other members at the lab to model a real-world experience and to allow each member to share their expertise for the overall solution.

## Solution architecture

After lawyers affirmed that Contoso Ltd. could legally store customer data in the cloud, Contoso created a strategy that capitalized on the capabilities of Microsoft Azure.

![The Solution architecture is described in the following text.](images/Hands-onlabstep-by-step-Appmodernizationimages/media/image2.png "Solution architecture")

The solution begins with mobile apps (built for Android and iOS using **Xamarin**) and a website, both of which provide access to PolicyConnect. The website, hosted in a **Web App**, provides the user interface for browser-based clients, whereas the Xamarin Forms-based apps provide the UI to mobile devices. Both mobile app and website rely on web services hosted in an **API App**. Sensitive configuration data like connection strings are stored in **Key Vault** and accessed from the API App or Web App on demand so that these settings never live in their file system. Full-text search of policy documents is enabled by the Indexer for **Blob Storage** (which indexes text in the Word and PDF documents) and stores the results in an **Azure Search** index. **PowerApps** enable authorized business users to build mobile and web create, read, update, delete (CRUD) applications that interact with **SQL Database** and Azure Storage, while **Microsoft Flow** enables them to orchestrations between services such as Office 365 email and services for sending mobile notifications. These orchestrations can be used independently of PowerApps or invoked by PowerApps to provide additional logic. The solution uses user and application identities maintained in **Azure Active Directory**.

## Requirements

-   Microsoft Azure subscription (non-Microsoft subscription)

-   **Global Administrator role** for Azure AD within your subscription

-   Local machine or a virtual machine configured with (**complete the day before the lab!**):

    -   Visual Studio Community 2017 or greater

        -   (<https://www.visualstudio.com/downloads/>)

    -   Xamarin tools, specifically Xamarin.Android

        -   Install instructions <https://developer.xamarin.com/guides/android/getting_started/installation/windows/#download>

        -   Download and run the Xamarin Unified Installer

            <http://www.xamarin.com/Download>

    -   Azure development workload for Visual Studio 2017

        -   [https://docs.microsoft.com/azure/azure-functions/functions-develop-vs\#prerequisites](https://docs.microsoft.com/azure/azure-functions/functions-develop-vs%23prerequisites)

    -   SQL Server 2016 Express or greater

        -   <https://www.microsoft.com/en-us/download/details.aspx?id=54284>

    -   SQL Server Management Studio (SSMS)

        -   <https://msdn.microsoft.com/library/mt238290.aspx>

    -   (optional) Self-signed certificate for debugging the legacy app environment

    -   PowerShell 1.1.0 or higher


## Exercise 1: Azure data, storage, and app environment setup

Duration: 45 minutes

Contoso Insurance has asked you to provision the Web API, storage, and data services to Microsoft Azure, and then migrate their on-premises SQL database to Azure SQL Database. Ensure all resources use the same resource group that was created for the App Service Environment.

### Help references
|    |            |       
|----------|:-------------:|
| **Description** | **Links** |
| SQL firewall | <https://azure.microsoft.com/en-us/documentation/articles/sql-database-configure-firewall-settings/> |


### Task 1: Create web app, SQL database, and storage instances and migrate SQL

In this exercise, you will provision a website via the Azure Web App template using the Microsoft Azure Portal. You will then provision storage instances for storing the PDF files. Next, you will migrate the on-premises SQL database to new Azure SQL instance you created.

#### Tasks to complete

1.  Create web, API app, storage, and SQL Server instances from within Azure

2.  Migrate the on-premises SQL database to Azure

#### Exit criteria

-   Azure App Service instances should be created for the web application and the Web API

-   Note the URLs of the provisioned web and API app services for future reference

-   Save the new database connection string for later

-   The database and all of its data should be hosted in Azure and accessible through SQL Server Management Services (SSMS)  

## Exercise 2: Identity and security

Duration: 30 minutes

Azure Active Directory will be used to allow users to authenticate to the web app, PolicyConnect desktop app, mobile apps, and PowerApps solutions. Azure AD will also be used to manage application access to Key Vault secrets. You have been asked to create a new Azure AD Tenant and secure the application so only users from the tenant can log on.

### Help references
|    |            |       
|----------|:-------------:|
| **Description** | **Links** |
| What is Azure AD? | <https://azure.microsoft.com/en-us/documentation/articles/active-directory-whatis/> |
| Azure Web Apps authentication | <http://azure.microsoft.com/blog/2014/11/13/azure-websites-authentication-authorization/> |
| View your access and usage reports | <https://msdn.microsoft.com/en-us/library/azure/dn283934.aspx/> |


**Note**: Tasks 1 and 2 require global admin permissions on the Azure AD Tenant. Task 3 requires the permission to create an app in the Azure AD tenant. Task 1 and 2 cannot be completed if you use Microsoft's Azure AD tenant.

### Task 1: Create a new Contoso user

#### Tasks to complete

1.  Create a new Contoso user named **Contoso User** in your Azure AD tenant and set the password to **demo\@pass123**

#### Exit criteria

-   You have made note of the full user name for later use. The user name will be in the following format: contosouser@\[your tenant\].onmicrosoft.com

-   You have saved the temporary password for later

### Task 2: Add the Web API application

#### Tasks to complete

1.  Add the Web API application to your AAD tenant

2.  Set the sign-on URL: http://\<your web api name\>.azurewebsites.net

3.  Create a new key named webapikey, then copy the generated value for later reference

4.  Add a new Reply URL, making it the same as the other one, but using https

#### Exit criteria

-   You have saved the new key value for later

-   You have copied and saved the Reply URLs for later

-   You have copied and saved the Application ID and App ID URI values for later

### Task 3: Expose Web API to other applications 

In order to make the Web API accessible to other applications added to Azure Active Directory, we must define the appropriate permissions. We will modify the manifest for the Web API to configure these settings, since, as of now, the Azure management portal does not provide an interface for this.

#### Tasks to complete

1.  Expose the Web API to other applications by updating the manifest to enable **oauth2AllowImplicitFlow** and adding an **oauth2Permissions** entry that allows applications to read-write the Contoso Web API on behalf of the signed-in user

#### Exit criteria

-   Your Web API manifest has been updated to enable oauth2AllowImplicitFlow

-   You have an oauth2Permissions entry with the following information (replace the id value with a new GUID):
    ```
    {

    "adminConsentDescription": "Allow read-write access to the Contoso Insurance Web API on behalf of the signed-in user",

    "adminConsentDisplayName": "Read-Write access to Contoso Insurance Web API",

    "id": "**494581dd-4bf5-451d-9bf8-487f4a43a09c**",

    "isEnabled": true,

    "type": "User",

    "userConsentDescription": "Allow read-write access to the Contoso Insurance Web API on your behalf",

    "userConsentDisplayName": "Read-Write access to Contoso Insurance Web API",

    "value": "Read_Write_ContosoInsurance_WebAPI"

    }
    ```

### Task 4: Add the ContosoInsurance desktop (WinForms) application 

#### Tasks to complete

1.  Add the Contoso Insurance Desktop app to your AAD tenant and grant permissions to the Web API application

#### Exit criteria

-   You have copied the Redirect URI for later

-   The "Read-write access to Contoso Insurance Web API" permission that you added through the manifest has been selected when adding API access to the app's required permissions

-   You have copied the Application ID for later

### Task 5: Add the mobile application 

#### Tasks to complete

1.  Add the Contoso Insurance mobile app to your AAD tenant and grant permissions to the Web API application

#### Exit criteria

-   You have copied the Redirect URI for later

-   The "Read-write access to Contoso Insurance Web API" permission that you added through the manifest has been selected when adding API access to the app's required permissions

-   You have copied the Application ID for later

### Task 6: Configure access control for the PolicyConnect web application

#### Tasks to complete

1.  Modify the PolicyConnect website authentication settings to use AAD

#### Exit criteria

-   The Azure Active Directory authentication provider has been added to the web application, using Express management mode

### Task 7: Grant the ContosoInsurance Web app permissions to the Web API app 

#### Tasks to complete

1.  Grant permissions for the website to the Web API within AAD and update the manifest to enable **oauth2AllowImplicitFlow**

#### Exit criteria

-   You have added two new Reply URIs and copied their values for later:

    -   Enter "https://\<your web app name\>.azurewebsites.net/"

    -   Enter "https://\<your web app name\>.azurewebsites.net/static"

-   The "Read-write access to Contoso Insurance Web API" permission that you added through the manifest has been selected when adding API access to the app's required permissions

-   You have copied the Application ID for later

## Exercise 3: Configure blob storage and search indexing

Duration: 30 minutes

Contoso Insurance is currently storing all of their scanned PDF documents on a local network share. They have asked to enable full-text searching on the documents, and to be able to store them automatically from a workflow. We have already provisioned a storage instance that we will use to store the files in a blob container. First, we need a way to bulk upload their existing PDFs, then configure search indexing on that container.

### Help references
|    |            |       
|----------|:-------------:|
| **Description** | **Links** |
| Transfer data with the AzCopy command-line utility | <https://azure.microsoft.com/en-us/documentation/articles/storage-use-azcopy/%23blob-upload/> |
| Download AzCopy | <http://aka.ms/downloadazcopy/> |
| Create an Azure Search service using the Azure Portal | <https://azure.microsoft.com/en-us/documentation/articles/search-create-service-portal/> |
| Indexing Documents in Blob Storage | https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/> |
| Portal support for Azure Search blob and table indexers | <https://azure.microsoft.com/en-us/blog/portal-support-for-azure-search-blob-and-table-indexers-now-in-preview/> |


### Task 1: Bulk upload PDFs to blob storage 

#### Tasks to complete

1.  Download and use the AzCopy command line utility to bulk upload the PDFs to a new blob container named **policies**

2.  Verify that all of the PDFs have been uploaded to the container

### Task 2: Create an Azure search service

#### Tasks to complete

1.  Provision a new search service, making sure to add it to the **ContosoInsuranceHackathon** resource group. Select the Basic tier when provisioning.

### Task 3: Configure full-text search indexing

#### Tasks to complete

1.  Use the import data feature of the newly provisioned search service to connect to your blob storage container (policies) which contain the PDF files

2.  Name the new index **policies**, using the detected metadata\_storage\_path as the key

3.  Make most of the fields retrievable, and the **content** field both filterable and searchable

4.  Create an indexer for the new index that has a 5-minute interval (for testing only)

5.  Configure CORS to allow all origins

#### Exit criteria

-   All 650 PDFs should be indexed

-   Use the Search explorer to validate functionality. You should be able to search by full policy number, or partial file content matches.

## Exercise 4: Configure Key Vault

Duration: 15 minutes

Key Vault will be used to protect sensitive information, such as database connection strings and storage account keys. Our application services that we have registered within Azure Active Directory will be granted access to the Key Vault secrets we create in this section. We have selected to use secrets instead of keys, due to the small size of the strings we are storing, as well as how often we need to retrieve the values. Retrieving secrets from Key Vault is a lower latency operation than retrieving keys, due to the real-time encryption and decryption involved.

### Help references
|    |            |       
|----------|:-------------:|
| **Description** | **Links** |
| What is Key Vault? | <https://azure.microsoft.com/en-us/documentation/articles/key-vault-whatis/> |
| About Keys and Secrets | <https://msdn.microsoft.com/library/dn903623.aspx/> |
| Get Started with Azure Key Vault | <https://azure.microsoft.com/en-us/documentation/articles/key-vault-get-started/> |
| Use Azure Key Vault from a Web Application | <https://azure.microsoft.com/en-us/documentation/articles/key-vault-use-from-web-application/> |


### Task 1: Create a new Key Vault

#### Tasks to complete

1.  Use the New-AzureRmKeyVault PowerShell cmdlet to create the Key Vault within the ContosoInsuranceHackathon resource group

2.  Make note of the Vault URI for later reference

### Task 2: Create a new secret to store the SQL connection string

#### Tasks to complete

1.  Save the full (including username and password) SQL connection string as a new secret named SQLConnectionString by using the Set-AzureKeyVaultSecret cmdlet

2.  Obtain the URI to the secret for later reference

3.  Use the Set-AzureRmKeyVaultAccessPolicy cmdlet to grant the Web API application Get access to the secret

### Task 3: Add Client Id, Client Secret, and Secret URL to Web API's app settings 

#### Tasks to complete

1.  Modify the Web API app service Application settings to add the following keys and values:

    -   Key: **ClientId** Value: \<AAD web app Client Id for Web API\>

    -   Key: **ClientSecret** Value: \<AAD web app Key for Web API\>

    -   Key: **SecretUri** Value \<Key Vault Uri for the SQLConnectionString secret\>

## Exercise 5: Configure and deploy the Contoso Insurance apps

Duration: 40 minutes

The developers at Contoso Insurance have been working toward migrating their apps to the cloud. As such, most of the pieces are already in place to deploy the apps to Azure, as well as configure them to communicate with the new app services, such as Web API. Since the required services have already been provisioned on Azure up to this point, what remains is applying application-level configuration settings, and then deploying any hosted apps and services from the Visual Studio Starter Project solution.

### Task 1: Deploy the Web API

In this exercise, the attendee will apply application settings using the Microsoft Azure Portal. The attendee will then deploy the Web API from the Starter Project.

#### Tasks to complete

1.  Apply application settings using the Microsoft Azure Portal:

    -   Key: **ida:Tenant** Value: \<AAD tenant name\>

    -   Key: **ida:Audience** Value: \<App ID URI within AAD application settings\>

2.  Deploy the Web API from the **Contoso.Apps.Insurance.WebAPI** Starter Project in Visual Studio

#### Exit criteria

-   Validate the Web API by typing in /swagger to the end of its URL in your browser (e.g. http://contosoinsurancewebapi.azurewebsites.net/swagger). You should see a list of the available REST APIs. However, you will not be able to execute them from here, as they are protected by AAD application permissions, accepting only token-based calls from registered apps.
    
    ![In the Swagger window, information displays for Contoso.Apps.Insurance.WebAPI.](images/Hands-onlabunguided-Appmodernizationimages/media/image27.png "Swagger window")

### Task 2: Deploy the Contoso Insurance web app

#### Tasks to complete

1.  Apply application settings using the Microsoft Azure Portal:

    -   Key: **RootWebApiPath** Value: \<URL to published Web API\>

    -   Key: **Tenant** Value: \<AAD tenant name\>

    -   Key: **WebClientId** Value: \<App's AAD Client Id\>

    -   Key: **WebApiAppId** Value: \<Web API's APP ID URI from AAD\>

2.  Modify the **app.js file** in the Scripts \> app folder the file where you see the line (126) that begins with **var endpoints = {**. Change the URL in quotes to the same URL you entered for the RootWebApiPath application variable, which is the root location of your Web API, (e.g. https://contosoinsurancewebapi.azurewebsites.net)

3.  Deploy the web app from the **Contoso.Apps.Insurance.Web** Starter Project in Visual Studio.

#### Exit criteria

-   Validate the website by browsing to it, if it did not automatically launch after publishing\
    ![Screenshot of the Contoso Insurance PolicyConnect website with the message that PolicyConnect is now on the web.](images/Hands-onlabunguided-Appmodernizationimages/media/image28.png "Contoso Insurance PolicyConnect website")

-   Click on the **Policies** link. You will likely be prompted to log in to AAD if you do not already have a cached authentication token. When you log in, do so with the **Contoso User** account you created earlier. Username is **contosouser@\<your tenant\>.onmicrosoft.com** and the password is **demo\@pass123**. After authentication is complete, you should see a list of policies, and you should have a Logout link on the upper-left.\
    ![A list of Policy types displays in the Manage Policy Holders webpage.](images/Hands-onlabunguided-Appmodernizationimages/media/image29.png "Manage Policy Holders webpage")

### Task 3: Configure and run the legacy desktop (Windows Forms) application

#### Tasks to complete

1.  Modify the application settings within the App.config file of the **PolicyConnectDesktop** Starter Project in Visual Studio

2.  Make sure to set the **UseWebApi** value to **true** in order to have it pull data from the newly published Web API instead of the legacy WCF services. This also tells the application to authenticate via AAD instead of the legacy SQL authentication method.

#### Exit criteria

-   Successfully run the desktop application by debugging it in Visual Studio

-   Click the **Log in** button to begin

-   You will be presented with an AAD login window. Enter the login credentials for the Contoso User account you created in your AAD directory. Username is **contosouser@\<your tenant\>.onmicrosoft.com** and the password is **demo\@pass123**. After authentication is complete, you should see a list of policyholders, and you should see a label on the upper-right saying you are logged in as your Contoso User account. Feel free to explore the different capabilities of the application. Some functionality is intentionally left out. To open a policyholder record, simply double-click on any of the rows.
    
    ![On the Contoso Insurance PolicyConnect webpage, Policy numbers and their information displays. In the Update Policy Holders dialog box, under Edit Existing Policy information, policy information for a person displays.](images/Hands-onlabunguided-Appmodernizationimages/media/image30.png "Contoso Insurance PolicyConnect webpage, and Update Policy Holders dialog box")

### Task 4: Configure and run the mobile application

#### Tasks to complete

1.  Modify the properties within the **ApplicationSettings.cs** file of the **PolicyConnectDesktop** Starter Project in Visual Studio

2.  Debug the **CIMobile.Droid** project within the Android emulator\
    ![In the Microsoft Visual Studio window, the debug button is selected.](images/Hands-onlabunguided-Appmodernizationimages/media/image31.png "Microsoft Visual Studio")

#### Exit criteria

-   The Android emulator should appear, and then launch the PolicyConnect app within\
    ![Screenshot of the Contoso Insurance PolicyConnect sign-in page.](images/Hands-onlabunguided-Appmodernizationimages/media/image32.png "Contoso Insurance PolicyConnect sign-in page")

-   Click the **Sign In** button to begin

-   You will be presented with an AAD login window. Enter the login credentials for the Contoso User account you created in your AAD directory. Username is **contosouser@\<your tenant\>.onmicrosoft.com** and the password is **demo\@pass123**. After authentication is complete, you should see a list of policyholders. You cannot interact with the records in any way for this demo.

-   Click on the menu button on the upper-left to explore other parts of the app.
    
    ![Screenshot of the Policy Holders list.](images/Hands-onlabunguided-Appmodernizationimages/media/image33.png "Policy Holders list")

-   Click on the menu and choose **Search Policy #**.
    
    ![Search Policy number is selected in the Policy Holders menu.](images/Hands-onlabunguided-Appmodernizationimages/media/image34.png "Policy Holders menu")

-   You can either enter a full policy \#, or perform a partial search of all content and metadata fields within the search field. Type in at least 3 characters to activate the search button. Try searching with the letters **MON**. The most relevant search results will appear first. Now try searching by an exact policy number, such as **DOW586IJCG493F**. You should see a single result matching that policy number.
    
    ![Mon is typed in the Policy number search field.](images/Hands-onlabunguided-Appmodernizationimages/media/image35.png "Policy number search field")

-   Click on a search result to view the content that was extracted by the Azure Search indexer. There is a link to download the actual PDF at the bottom of the result page. This will display the file that is stored in blob storage.

    ![Search results display for a particular policy holder.](images/Hands-onlabunguided-Appmodernizationimages/media/image36.png "Search results")\
    ![A .pdf of the Search results displays.](images/Hands-onlabunguided-Appmodernizationimages/media/image37.png "Search results PDF")

## Exercise 6: Create a Flow app that sends push notifications when important emails arrive

Duration: 10 minutes

Contoso wants to receive push notifications when important emails arrive, since any newly scanned policies that are emailed to the data entry employees are marked as important. Since they use Office 365 for their email services, you can easily meet this requirement with Flow.

### Task 1: Sign up for a Flow account

#### Tasks to complete

1.  Visit <https://flow.microsoft.com> to create an account if you do not already have one

2.  Download the Flow mobile app

### Task 2: Create new flow

#### Tasks to complete

1.  Create a new trigger that connects to Office 365 Outlook, watching for any that is of high importance and have an attachment

2.  Execute a push notification if an email with the preferred criteria arrives in the user's inbox. Make sure that the subject is part of the notification title

### Task 3: Test your flow

#### Tasks to complete

1.  Send a new email to the linked email account that will trigger the notification

#### Exit criteria

-   If you have installed the Flow mobile app that supports push notifications, you should have received one after the message has been sent

-   Alternatively, check the status of your flow by going to **My flows**, then clicking on the name of the flow. The resulting page will display a log of each time it was executed. When you click on the log entry, you will see which of the steps, the email trigger or the push notification, were successful.
    
    ![On the My flows tab, the option to send a mobile notification when a new email arrives is set to On.](images/Hands-onlabunguided-Appmodernizationimages/media/image38.png "My flows tab")

## Exercise 7: Create an app in PowerApps

Duration: 15 minutes

Since creating mobile apps is a long development cycle, Contoso is interested in using PowerApps to create mobile applications in order to add functionality not currently offered by their app rapidly. In this scenario, they want to be able to edit the Policy lookup values (Silver, Gold, Platinum, etc.), which they are unable to do in the current app.

Get them up and running with a new app created in PowerApps, which connects to the ContosoInsurance database and performs basic CRUD (Create, Read, Update, and Delete) operations against the Policies table.

### Help references
|    |            |       
|----------|:-------------:|
| **Description** | **Links** |
| PowerApps | <https://powerapps.microsoft.com/en-us/tutorials/getting-started/> |


### Task 1: Sign up for a PowerApps account

#### Tasks to complete

1.  Go to <https://web.powerapps.com> and sign up for a new account, or sign in with an existing one

2.  Download and install the PowerApps Studio application from the Microsoft store:

    <https://www.microsoft.com/en-us/store/p/powerapps/9nblggh5z8f3>

### Task 2: Create a new SQL connection

#### Tasks to complete

1.  From the <https://web.powerapps.com> website, create a new SQL connection, entering the server name, database name, username, and password for the ContosoInsurance database hosted in Azure

### Task 3: Create a new app

#### Tasks to complete

1.  Launch the PowerApps desktop application and create a new app, using the SQL connection, pointing to the Policies table

### Task 4: Design app

#### Tasks to complete

1.  After the app has been generated, change the titles on each of the three screens to remove the database table name

2.  Remove any unneeded labels from the list view screen

3.  Rearrange the order of the fields within the details and the edit form screens

4.  Fix up the labels for the field names to make them more human readable

### Task 5: Edit the app settings and run the app

#### Tasks to complete

1.  Change the name of the app

2.  Save the app to the cloud

3.  Run the app to test the app's ability to display and edit the list of Policies

#### Exit criteria

-   The PowerApps Studio application comes with a powerful app simulator in which you can test the app against your data source in real time. You should be able to view all of the Policies, edit them, create new ones, and delete the newly created ones. You will be unable to delete existing Policies since they are being referenced by other table records.

    ![All of the Policy options display.](images/Hands-onlabunguided-Appmodernizationimages/media/image39.png "Policies section")

## After the hands-on lab 

Duration: 10 minutes

In this exercise, attendees will deprovision any Azure resources that were created in support of the lab.

### Task 1: Delete the Resource Group in which you placed your Azure resources.

1.  From the Portal, navigate to the blade of your Resource Group and click Delete in the command bar at the top

2.  Confirm the deletion by re-typing the resource group name and clicking Delete

### Task 2: Delete the Azure Active Directory app registrations for Desktop and Mobile

1.  Open the manifest for each app registration and change the following setting to false:

    -   "availableToOtherTenants": false

2.  Save the manifest, then delete the app registrations

You should follow all steps provided *after* attending the hands-on lab.

