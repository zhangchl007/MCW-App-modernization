# App modernization

Contoso, Ltd. (Contoso) is a new company in an old business. Founded in Auckland, NZ, in 2014, they provide a full range of long-term insurance services to help individuals who are under-insured, filling a void their founders saw in the market. From the beginning, they grew faster than anticipated and have struggled to cope with rapid growth. During their first year alone, they added over 100 new employees to keep up with the demand for their services. To manage policies and associated documentation, they use a custom developed Windows Forms application, called PolicyConnect. PolicyConnect uses an on-premises SQL Server 2008 R2 database as its data store, along with a file server on their local area network for storing policy documents. That application and its underlying processes for managing policies have become increasingly overloaded.

To allow policyholders, brokers and employees to access policy information without requiring them to VPN into the Contoso network, they recently launched projects to create new web and mobile applications. For the web application, they have created a new .NET Core 2.2 MVC web application, which accesses the PolicyConnect database using REST APIs. They eventually intend to have the REST APIs be shared across all of their applications, including the mobile application and WinForms version of PolicyConnect. They have a prototype of the web application running on-premises, and are interested in taking their modernization efforts a step further by hosting the application in the cloud. However, they don't know how to really take advantage of all the managed services of the cloud since they have no experience with it and would like to know how to take what they've created so far and make it more cloud-native.

They have not started development of a mobile app yet, and are looking for guidance on how they can take a .NET developer-friendly approach to implement the PolicyConnect mobile app on Android and iOS.

To prepare for hosting their applications in the cloud, they would like to migrate their SQL Server database to a PaaS SQL service in Azure. Contoso would like to migrate their new web application to the cloud,and optimize that application to run in the cloud, including taking advantage of serverless technologies and advanced security features available in a fully-managed SQL service in the Azure. By migrating to the cloud, they hope to improve their technological capabilities and take advantage of enhancements and services that are enabled by moving to the cloud, including adding automated document forwarding from brokers, securing access for brokers to Contoso, allowing access to policy information, and providing easy policy retrieval for a dispersed workforce. They have been clear that they will continue using the PolicyConnect WinForms application on-premises, but want to update the application to use cloud-based APIs and services. Additionally, they want to store policy documents in cloud storage for retrieval via the web and mobile applications.

## Target audience

- Application developer

## Abstract

### Workshop

In this workshop, you will gain a better understanding on the steps involved in modernizing legacy on-premises applications and infrastructure by leveraging cloud services, while adding a mix of web and mobile services, all secured using Azure Active Directory.

At the end of this workshop, you will be better able to design a modernization plan for organizations looking to move services from on-premises to the cloud.

### Whiteboard design session

In this whiteboard design session, you will work with a group to design a solution for modernizing legacy on-premises applications and infrastructure by leveraging cloud services, while adding a mix of web and mobile services, all secured using Azure Active Directory.

At the end of this whiteboard design session, you will be better able to design a modernization plan for organizations looking to move services from on-premises to the cloud.

### Hands-on lab

In this hands-on lab, you will implement the steps to modernize a legacy on-premises application, including upgrading and migrating the database to Azure and updating the application to take advantage of serverless and cloud services.

At the end of this hands-on lab, you will be better able to build solutions for modernizing legacy on-premises applications and infrastructure using cloud services.

## Azure services and related products

- API Management
- App Services
- Azure Active Directory
- Azure Cognitive Services
- Azure Database Migration Service
- Azure Key Vault
- Azure Redis
- Azure Search
- Azure SQL Database
- Azure Storage
- Flow
- PowerApps
- Visual Studio
- Xamarin

## Related references
- [MCW](https://microsoftcloudworkshop.com)
- [Reference architecture for Managed Web Applications](https://docs.microsoft.com/en-gb/azure/architecture/reference-architectures/app-service-web-app/basic-web-app)
- [Azure application architecture guide](https://docs.microsoft.com/en-us/azure/architecture/guide/)
