# Appendix A: Lab environment setup

This appendix provides the steps to manually provision and configure the resources created by the ARM template used before the hands-on lab guide.

**Contents**:

- [Appendix A: Lab environment setup](#Appendix-A-Lab-environment-setup)
  - [Task 1: Create an Azure Storage account](#Task-1-Create-an-Azure-Storage-account)
  - [Task 2: Create the LabVM](#Task-2-Create-the-LabVM)
  - [Task 3: Create SQL Server 2008 R2 virtual machine](#Task-3-Create-SQL-Server-2008-R2-virtual-machine)
  - [Task 4: Provision an Azure SQL Database](#Task-4-Provision-an-Azure-SQL-Database)
  - [Task 5: Create Azure Database Migration Service](#Task-5-Create-Azure-Database-Migration-Service)
  - [Task 6: Provision a Web App](#Task-6-Provision-a-Web-App)
  - [Task 7: Provision an API App](#Task-7-Provision-an-API-App)
  - [Task 8: Provision a Function App](#Task-8-Provision-a-Function-App)
  - [Task 9: Provision API Management](#Task-9-Provision-API-Management)
  - [Task 10: Create Cognitive Services account](#Task-10-Create-Cognitive-Services-account)
  - [Task 11: Create an Azure Key Vault](#Task-11-Create-an-Azure-Key-Vault)
  - [Task 12: Connect to the Lab VM](#Task-12-Connect-to-the-Lab-VM)
  - [Task 13: Install required software on the LabVM](#Task-13-Install-required-software-on-the-LabVM)
  - [Task 14: Open port 1433 on SqlServer2008 VM network security group](#Task-14-Open-port-1433-on-SqlServer2008-VM-network-security-group)
  - [Task 15: Connect to SqlServer2008 VM](#Task-15-Connect-to-SqlServer2008-VM)

> **IMPORTANT**: Many Azure resources require globally unique names. Throughout these steps you will see the word "SUFFIX" as part of resource names. You should replace this with your Microsoft alias, initials, or another value to ensure resources are uniquely named.

## Task 1: Create an Azure Storage account

In this task, you will provision an Azure Storage account, which will be used for storing policy documents, as well as vulnerability assessments performed using SQL Advanced Data Security.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "storage account" into the Search the Marketplace box and select **Storage account** from the results, and then select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "storage account" is entered into the Search the Marketplace box. Storage account is selected in the results.](./media/create-resource-storage-account.png "Create Storage account")

2. On the Create storage account **Basics** tab, enter the following:

    - Project Details:

        - **Subscription**: Select the subscription you are using for this hands-on lab.
        - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

    - Instance Details:

        - **Storage account name**: Enter contosostoreSUFFIX.
        - **Location**: Select the location you are using for resources in this hands-on lab.
        - **Performance**: Choose **Standard**.
        - **Account kind**: Select **StorageV2 (general purpose v2)**.
        - **Replication**: Select **Locally-redundant storage (LRS)**.
        - **Access tier**: Choose **Hot**.

    ![On the Create storage account blade, the values specified above are entered into the appropriate fields.](media/storage-create-account.png "Create storage account")

3. Select **Review + create**.

4. On the **Review + create** blade, ensure the Validation passed message is displayed and then select **Create**.

## Task 2: Create the LabVM

In this task, you will provision a virtual machine (VM) in Azure. The VM image used will have Visual Studio Community 2019 installed.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "visual studio 2019" into the Search the Marketplace box, expand the **Visual Studio 2019 Latest** group, and then select **Visual Studio 2019 Community (latest release) on Windows Server 2016 (x64)** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "visual studio 2019" is entered into the Search the Marketplace box. Visual Studio Community 2019 on Windows Server 2016 (x64) is selected in the results.](./media/create-resource-visual-studio-on-windows-server-2016.png "Create Windows Server 2016 with Visual Studio Community 2019")

2. Select **Create** on the Visual Studio 2019 Latest blade.

    ![The Create button is highlighted on the Create Visual Studio VM blade.](media/visual-studio-create.png "Create Visual Studio VM")

3. On the Create a virtual machine **Basics** tab, set the following configuration:

    - Project Details:

        - **Subscription**: Select the subscription you are using for this hands-on lab.
        - **Resource Group**: Select the **hands-on-lab-SUFFIX** resource group from the list of existing resource groups.

    - Instance Details:

        - **Virtual machine name**: Enter LabVM.
        - **Region**: Select the region you are using for resources in this hands-on lab.
        - **Availability options**: Select no infrastructure redundancy required.
        - **Image**: Leave Visual Studio 2019 Community (latest release) on Windows Server 2016 (x64) selected.
        - **Size**: Select **Change size**, and select Standard D2s v3 from the list and then select **Accept**.

    - Administrator Account:

        - **Username**: Enter **demouser**
        - **Password**: Enter **Password.1!!**

    - Inbound Port Rules:

        - **Public inbound ports**: Choose Allow selected ports.
        - **Select inbound ports**: Select RDP (3389) in the list.

    ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/lab-virtual-machine-basics-tab.png "Create a virtual machine Basics tab")

    > **Note**: The remaining tabs can be skipped, and default values will be used.

4. Select **Review + create** to validate the configuration.

5. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

    ![The Review + create tab is displayed, with a Validation passed message.](media/lab-virtual-machine-review-create-tab.png "Create a virtual machine Review + create tab")

6. It will take approximately 10 minutes for the VM to finish provisioning. You can move on to the next task while you wait.

## Task 3: Create SQL Server 2008 R2 virtual machine

In this task, you will provision another virtual machine (VM) in Azure which will host your "on-premises" instance of SQL Server 2008 R2. The VM will use the SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2 image.

> **Note**: An older version of Windows Server is being used because SQL Server 2008 R2 is not supported on Windows Server 2016.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, and enter "SQL Server 2008R2SP3 on Windows Server 2008R2" into the Search the Marketplace box.

2. On the **SQL Server 2008 R2 SP3 on Windows Server 2008 R2** blade, select **SQL Server R2 SP3 Standard on Windows Server 2008 R2** for the software plan and then select **Create**.

    ![The SQL Server 2008 R2 SP3 on Windows Server 2008 R2 blade is displayed with the standard edition selected for the software plan. The Create button highlighted.](media/create-resource-sql-server-2008-r2.png "Create SQL Server 2008 R2 Resource")

3. On the Create a virtual machine **Basics** tab, set the following configuration:

    - Project Details:

        - **Subscription**: Select the subscription you are using for this hands-on lab.
        - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

    - Instance Details:

        - **Virtual machine name**: Enter SqlServer2008.
        - **Region**: Select the region you are using for resources in this hands-on lab.
        - **Availability options**: Select no infrastructure redundancy required.
        - **Image**: Leave SQL Server 2008 R2 SP3 Standard on Windows Server 2008 R2 selected.
        - **Size**: Select **Change size**, and select Standard D2s v3 from the list and then select **Accept**.

    - Administrator Account:

        - **Username**: Enter **demouser**
        - **Password**: Enter **Password.1!!**

    - Inbound Port Rules:

        - **Public inbound ports**: Choose Allow selected ports.
        - **Select inbound ports**: Select RDP (3389) in the list.

    ![Screenshot of the Basics tab, with fields set to the previously mentioned settings.](media/sql-server-2008-r2-vm-basics-tab.png "Create a virtual machine Basics tab")

    > **Note**: The remaining tabs can be skipped, and default values will be used.

4. Select **Review + create** to validate the configuration.

5. On the **Review + create** tab, ensure the Validation passed message is displayed, and then select **Create** to provision the virtual machine.

6. It will take approximately 10 minutes for the SQL VM to finish provisioning. You can move on to the next task while you wait.

## Task 4: Provision an Azure SQL Database

In this task, you will provision an Azure SQL Database (Azure SQL DB).

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "sql database" into the Search the Marketplace box, select **SQL Database** from the results, and then select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "sql database" is entered into the Search the Marketplace box. SQL Database is selected in the results.](media/create-resource-azure-sql-database.png "Create Azure SQL Database")

2. On the Create SQL Database **Basics** tab, enter the following:

    - Project Details:

        - **Subscription**: Select the subscription you are using for this hands-on lab.
        - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

    - Database Details:

        - **Database name**: Enter ContosoInsurance.
        - **Server**: Select **Create new**, and on the New server blade enter the following:
          - **Server name**: Enter contosoinsuranceSUFFIX.
          - **Server admin login**: Enter demouser.
          - **Password**: Enter Password.1!!
          - **Location**: Select the region you are using for resources in this hands-on lab.
          - **Allow Azure services to access server**: Check this box.
          - Select **Select**.
        - **Want to use SQL elastic pool**: Choose No.
        - **Compute + storage**: Accept the default, SO with 10 DTUs and 250 GB storage.

    ![The Create SQL Database Basics tab is displayed, with the values specified above entered into the appropriate fields.](media/create-sql-database-basics-tab.png "Create SQL Database")

3. Select **Next: Additional settings**.

4. On the **Additional settings** tab, **Enable Advanced Data Security** by selecting **Start free trial**.

    ![On the Additional settings tab, Enable Advanced Data Security is highlighted and Start free trial is selected.](media/create-sql-database-additional-settings-tab.png "Create SQL Database")

5. Select **Review + create**

6. On the **Review + create** tab, select **Create** to provision the SQL Database.

## Task 5: Create Azure Database Migration Service

In this task, you will provision an instance of the Azure Database Migration Service (DMS).

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "database migration" into the Search the Marketplace box, select **Azure Database Migration Service** from the results, and select **Create**.

    ![+Create a resource is selected in the Azure navigation pane, and "database migration" is entered into the Search the Marketplace box. Azure Database Migration Service is selected in the results.](media/create-resource-azure-database-migration-service.png "Create Azure Database Migration Service")

2. On the Create Migration Service blade, enter the following:

    - **Service Name**: Enter contoso-dms.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - **Location**: Select the location you are using for resources in this hands-on lab.
    - **Virtual network**: Select the **hands-on-lab-SUFFIX-vnet/default** virtual network, and then select **OK**. This will place the DMS instance into the same VNet as your LabVM and SqlServer2008 virtual machines.
    - **Pricing tier**: Select Premium: 4 vCores.

    ![The Create Migration Service blade is displayed, with the values specified above entered into the appropriate fields.](media/create-migration-service.png "Create Migration Service")

    > **Note**: If you see the message `Your subscription doesn't have proper access to Microsoft.DataMigration`, refresh the browser window before proceeding. If the message persists, verify you successfully registered the resource provider, and then you can safely ignore this message.

3. Select **Create**.

4. It can take 15 minutes to deploy the Azure Data Migration Service. You can move on to the next task while you wait.

## Task 6: Provision a Web App

In this task, you will provision an App Service (Web app), which will be used for hosting the Contoso Insurance web application.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "web app" into the Search the Marketplace box, select **Web App** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "web app" is entered into the Search the Marketplace box. Web App is selected in the results.](media/create-resource-web-app.png "Create Web App")

2. On the Web App blade, select **Create**.

    ![On the Web App blade, the Create button is highlighted.](media/create-web-app.png "Create Web App")

3. On the Create Web App **Basics** tab, set the following configuration:

    - Project Details:

        - **Subscription**: Select the subscription you are using for this hands-on lab.
        - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.

    - Instance Details:

        - **Name**: Enter contosoinswebSUFFIX.
        - **Publish**: Select Code.
        - **Runtime stack**: Select .NET Core 2.2.
        - **Operating System**: Select Windows.
        - **Location**: Select the location you are using for resources in this hands-on lab.

    - App Service Plan:

        - **Plan**: Select **Create new** and enter **hands-on-lab-asp** for the name.
        - **Sku and size**: Accept the default value of Standard S1.

    ![The values specified above are entered into the appropriate fields in the Create Web App Basics tab.](media/create-web-app-basics-tab.png "Create Web App")

4. Select **Next: Monitoring**.

5. On the **Monitoring** tab, select **No** next to Enable Application Insights.

    ![No is selected next to Enable Application Insights on the Monitoring tab.](media/create-web-app-monitoring-tab.png "Create Web App")

6. Select **Review and create**.

7. On the **Review and create** tab, select **Create**.

8. It will take a few minutes for the Wep App creation to complete. You can move on to the next task while you wait.

## Task 7: Provision an API App

In this task, you will provision an App Service (API App), which will be used for hosting the Contoso Insurance APIs.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "api app" into the Search the Marketplace box, select **API App** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "api app" is entered into the Search the Marketplace box. API App is selected in the results.](media/create-resource-api-app.png "Create Web App")

2. On the API App blade, select **Create**.

3. On the API App Create blade, enter the following:

    - **App name**: Enter contosoinsapiSUFFIX.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource Group**: Choose Use exiting and select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - **App Service plan/Location**: Select the hands-on-lab-asp App Service plan.
    - **Application Insights**: Select **Disabled**.

    ![On the API App Create blade, the values specified above are entered into the appropriate fields.](media/create-api-app-basics-tab.png "Create API App")

4. Select **Create**.

## Task 8: Provision a Function App

In this task, you will provision Function App, which will be used for retrieving PDF documents from Azure Storage.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "function app" into the Search the Marketplace box, select **Function App** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "function app" is entered into the Search the Marketplace box. Function App is selected in the results.](media/create-resource-function-app.png "Create Web App")

2. On the Function App blade, select **Create**.

3. On the Function App Create blade, enter the following:

    - **App name**: Enter contosoinsfuncSUFFIX.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource Group**: Choose Use exiting and select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - **OS**: Select Windows.
    - **Hosting Plan**: Select Consumption Plan.
    - **Location**: Select the location you are using for resources in this hands-on lab.
    - **Runtime Stack**: Select .NET.
    - **Storage**: Choose Create new and accept the default name.
    - **Application Insights**: Select **Disabled**.

    ![On the Function App Create blade, the values specified above are entered into the associated fields.](media/function-app-create.png "Create Function App")

4. Select **Create**.

## Task 9: Provision API Management

In this task, you will provision API Management, which will be used for managing the Contoso APIs.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "api management" into the Search the Marketplace box, select **API Management** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "api management" is entered into the Search the Marketplace box. API Management is selected in the results.](media/create-resource-api-management.png "Create Web App")

2. On the API Management blade, select **Create**.

3. On the API Management service blade, enter the following:

    - **Name**: Enter contosoinsapimSUFFIX.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - **Location**: Select the location you are using for resources in this hands-on lab.
    - **Organization name**: Enter Contoso Insurance.
    - **Administrator email**: Enter an email add that can receive API Management admin notifications.
    - **Pricing tier**: Select Developer (No SLA).
    - **Enable Application Insights**: Uncheck this box.

    ![The values specified above are entered into the API Management service blade.](media/api-management-service-create.png "Create API Management service")

4. Select **Create**.

5. It will take around 30 minutes for API Management to finish provisioning. You can move on to the next task while you wait.

## Task 10: Create Cognitive Services account

In this task, you will create a Cognitive Services account.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "cognitive services" into the Search the Marketplace box, select **Cognitive Services** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "cognitive services" is entered into the Search the Marketplace box. Cognitive Services is selected in the results.](media/create-resource-cognitive-services.png "Create Cognitive Services account")

2. On the Cognitive Services blade, select **Create**.

3. On the Cognitive Services Create blade, enter the following:

    - **Name**: Enter contoso-cog-services.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Location**: Select the region you are using for resources in this hands-on lab.
    - **Pricing tier**: Select S0.
    - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - Check the box to confirm you have read and understood the notice.

    ![The values specified above are entered into the Create blade.](media/cognitive-services-create.png "Create Cognitive Services")

4. Select **Create**.

## Task 11: Create an Azure Key Vault

In this task, you will provision an Azure Key Vault, which will be used for securing application secrets.

1. In the [Azure portal](https://portal.azure.com/), select **+Create a resource**, enter "key vault" into the Search the Marketplace box, select **Key Vault** from the results.

    ![+Create a resource is selected in the Azure navigation pane, and "key vault" is entered into the Search the Marketplace box. Key Vault is selected in the results.](media/create-resource-key-vault.png "Create Key Vault")

2. On the Key Vault blade, select **Create**.

3. On the Create Key Vault blade, enter the following:

    - **Name**: Enter contosoinskv.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource Group**: Select the hands-on-lab-SUFFIX resource group from the list of existing resource groups.
    - **Location**: Select the location you are using for resources in this hands-on lab.
    - **Pricing tier**: Select Standard.
    - **Access policies**: Accept the default value, 1 principal selected. You will configure this later as part of the hands-on lab exercises.
    - **Virtual networks**: Accept the default value, All networks can access.

    ![The values specified above are entered into the Create Key Vault blade.](media/key-vault-create.png "Create Key Vault")

4. Select **Create**.

## Task 12: Connect to the Lab VM

In this task, you will create an RDP connection to your Lab virtual machine (VM), and disable Internet Explorer Enhanced Security Configuration.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, and select the hands-on-lab-SUFFIX resource group from the list.

    ![Resource groups is selected in the Azure navigation pane and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

2. In the list of resources for your resource group, select LabVM.

    ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and LabVM is highlighted.](./media/resource-group-resources-LabVM.png "LabVM in resource group list")

3. On your LabVM blade, select **Connect** from the top menu.

    ![The LabVM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-LabVM.png "Connect to Lab VM")

4. On the Connect to virtual machine blade, select **Download RDP File**, then open the downloaded RDP file.

    ![The Connect to virtual machine blade is displayed, and the Download RDP File button is highlighted.](./media/connect-to-virtual-machine.png "Connect to virtual machine")

5. Select **Connect** on the Remote Desktop Connection dialog.

    ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png "Remote Desktop Connection dialog")

6. Enter the following credentials when prompted, and then select **OK**:

    - **User name**: demouser
    - **Password**: Password.1!!

    ![The credentials specified above are entered into the Enter your credentials dialog.](media/rdc-credentials.png "Enter your credentials")

7. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

    ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-LabVM.png "Remote Desktop Connection dialog")

8. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not.

9. Select **Local Server**, then select **On** next to **IE Enhanced Security Configuration**.

    ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-manager-ie-enhanced-security-configuration.png "Server Manager")

10. In the Internet Explorer Enhanced Security Configuration dialog, select **Off** under both Administrators and Users, and then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/internet-explorer-enhanced-security-configuration-dialog.png "Internet Explorer Enhanced Security Configuration dialog box")

11. Close the Server Manager, but leave the connection to the LabVM open for the next task.

## Task 13: Install required software on the LabVM

In this task, you will install SQL Server Management Studio (SSMS) on the LabVM.

1. First, you will install SSMS on the LabVM. Open a web browser on your LabVM, navigate to <https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms> and then select the **Download SQL Server Management Studio 18.x** link to download the latest version of SSMS.

    ![The Download SQL Server Management Studio 18.x link is highlighted on the page specified above.](media/download-ssms.png "Download SSMS")

    > **Note**: Versions change frequently, so if the version number you see does not match the screenshot, just download and install the most recent version.

2. Run the downloaded installer.

3. On the Welcome screen, select **Install** to begin the installation.

    ![The Install button is highlighted on the SSMS installation welcome screen.](media/ssms-install.png "Install SSMS")

4. Select **Close** when the installation completes.

    ![The Close button is highlighted on the SSMS Setup Completed dialog.](media/ssms-install-close.png "Setup completed")

## Task 14: Open port 1433 on SqlServer2008 VM network security group

In this task, you will open port 1433 on the network security group associated with the SqlServer2008 VM to allow external communication with SQL Server.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** in the Azure navigation pane, enter your resource group name (hands-on-lab-SUFFIX) into the filter box, and select it from the list.

    ![Resource groups is selected in the Azure navigation pane, "hands" is entered into the filter box, and the "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

2. In the list of resources for your resource group, select the SqlServer2008 VM.

    ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and SqlServer2008 is highlighted.](media/resource-group-resources-sqlserver2008.png "SqlServer2008 VM in resource group list")

3. On the SqlServer2008 blade, select **Networking** under Settings in the left-hand menu, and then select **Add inbound port rule**.

    ![Add inbound port rule is highlighted on the SqlServer2008 - Networking blade.](media/sql-virtual-machine-add-inbound-port-rule.png "SqlServer2008 - Networking blade")

4. On the **Add inbound security rule blade**, enter the following:

    - Select **Basic** on the toolbar to switch to the basic view.
    - **Service**: Select MS SQL.
    - **Port ranges**: Value will be set to 1433.
    - **Priority**: Accept the default priority value.
    - **Name**: Enter SqlServer.

    ![On the Add inbound security rule dialog, MS SQL is selected for Service, port 1433 is selected, and the SqlServer is entered as the name.](media/sql-virtual-machine-add-inbound-security-rule-1433.png "Add MS SQL inbound security rule")

5. Select **Add**. Remain on the SqlServer2008 VM blade for the next step.

## Task 15: Connect to SqlServer2008 VM

In this task, you will open an RDP connection to the SqlServer2008 VM, disable Internet Explorer Enhanced Security Configuration, and add a firewall rule to open port 1433 to inbound TCP traffic. You will also install Data Migration Assistant (DMA).

1. As you did for the LabVM, navigate to the SqlServer2008 VM blade in the Azure portal, select **Overview** from the left-hand menu, and then select **Connect** on the top menu.

    ![The SqlServer2008 VM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-sqlserver2008.png "Connect to SqlServer2008 VM")

2. On the Connect to virtual machine blade, select **Download RDP File**, then open the downloaded RDP file.

3. Select **Connect** on the Remote Desktop Connection dialog.

    ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection-sql-2008.png "Remote Desktop Connection dialog")

4. Enter the following credentials when prompted, and then select **OK**:

    - **User name**: demouser
    - **Password**: Password.1!!

    ![The credentials specified above are entered into the Enter your credentials dialog.](media/rdc-credentials-sql-2008.png "Enter your credentials")

5. Select **Yes** to connect, if prompted that the identity of the remote computer cannot be verified.

    ![In the Remote Desktop Connection dialog box, a warning states that the identity of the remote computer cannot be verified, and asks if you want to continue anyway. At the bottom, the Yes button is circled.](./media/remote-desktop-connection-identity-verification-sqlserver2008.png "Remote Desktop Connection dialog")

6. Once logged in, launch the **Server Manager**. This should start automatically, but you can access it via the Start menu if it does not.

7. On the **Server Manager** view, select **Configure IE ESC** under Security Information.

    ![Screenshot of the Server Manager. In the left pane, Local Server is selected. In the right, Properties (For LabVM) pane, the IE Enhanced Security Configuration, which is set to On, is highlighted.](./media/windows-server-2008-manager-ie-enhanced-security-configuration.png "Server Manager")

8. In the Internet Explorer Enhanced Security Configuration dialog, select **Off** under both Administrators and Users, and then select **OK**.

    ![Screenshot of the Internet Explorer Enhanced Security Configuration dialog box, with Administrators set to Off.](./media/2008-internet-explorer-enhanced-security-configuration-dialog.png "Internet Explorer Enhanced Security Configuration dialog box")

9. Back in the Server Manager, expand **Configuration** and **Windows Firewall with Advanced Security**.

    ![In Server Manager, Configuration and Windows Firewall with Advanced Security are expanded, Inbound Rules is selected and highlighted.](media/windows-firewall-inbound-rules.png "Windows Firewall")

10. Right-click on **Inbound Rules** and then select **New Rule** from the context menu.

    ![Inbound Rules is selected and New Rule is highlighted in the context menu.](media/windows-firewall-with-advanced-security-new-inbound-rule.png "New Rule")

11. In the New Inbound Rule Wizard, under Rule Type, select **Port**, then select **Next**.

    ![Rule Type is selected and highlighted on the left side of the New Inbound Rule Wizard, and Port is selected and highlighted on the right.](media/windows-2008-new-inbound-rule-wizard-rule-type.png "Select Port")

12. In the Protocol and Ports dialog, use the default **TCP**, and enter **1433** in the Specific local ports text box, and then select **Next**.

    ![Protocol and Ports is selected on the left side of the New Inbound Rule Wizard, and 1433 is in the Specific local ports box, which is selected on the right.](media/windows-2008-new-inbound-rule-wizard-protocol-and-ports.png "Select a specific local port")

13. In the Action dialog, select **Allow the connection**, and then select **Next**.

    ![Action is selected on the left side of the New Inbound Rule Wizard, and Allow the connection is selected on the right.](media/windows-2008-new-inbound-rule-wizard-action.png "Specify the action")

14. In the Profile step, check **Domain**, **Private**, and **Public**, then select **Next**.

    ![Profile is selected on the left side of the New Inbound Rule Wizard, and Domain, Private, and Public are selected on the right.](media/windows-2008-new-inbound-rule-wizard-profile.png "Select Domain, Private, and Public")

15. On the Name screen, enter **SqlServer** for the name, and select **Finish**.

    ![Profile is selected on the left side of the New Inbound Rule Wizard, and sqlserver is in the Name box on the right.](media/windows-2008-new-inbound-rule-wizard-name.png "Specify the name")

16. Close the Server Manager.

17. Next, you will install DMA by navigating to <https://www.microsoft.com/en-us/download/details.aspx?id=53595> in a web browser on the SqlServer2008 VM, and then selecting the **Download** button.

    ![The Download button is highlighted on the Data Migration Assistant download page.](media/dma-download.png "Download Data Migration Assistant")

18. Run the downloaded installer.

19. Select **Next** on each of the screens, accepting to the license terms and privacy policy in the process.

20. Select **Install** on the Privacy Policy screen to begin the installation.

21. On the final screen, select **Finish** to close the installer.

    ![The Finish button is selected on the Microsoft Data Migration Assistant Setup dialog.](./media/data-migration-assistant-setup-finish.png "Run the Microsoft Data Migration Assistant")
