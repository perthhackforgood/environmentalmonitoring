# Local Dev Environment
- Sign up at GitHub.com

- Request Collaborator invite at https://github.com/perthhackforgood/environmentalmonitoring

- Install Git (for Windows)

- GUI for Git = Atlassian SourceTree or Fork: https://git-fork.com/

- Visual Studio Professional / Community Edition
Install Azure SDK components

- Create an Empty Azure Functions project phfg.api

- Install AzCopy Storage tool

- Install CosmosDB emulator: https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator-release-notes
Installs a web-based UI to https://localhost:8081/_explorer/index.

# Get Az Functions Publish Profile
- Go to the PHFG API: https://portal.azure.com/#blade/WebsitesExtension/FunctionsIFrameBlade/id/%2Fsubscriptions%2F09e2c0b1-3480-446f-8f33-81f7f510c865%2Fresourcegroups%2Frg-ae-sponsorship-hack%2Fproviders%2FMicrosoft.Web%2Fsites%2Fphfg-api 

- Download publish profile

- Clone the repo into a local dev folder:
```
cd c:\Development\phfg
git clone https://github.com/perthhackforgood/environmentalmonitoring.git
```

- Open "C:\Development\phfg\environmentalmonitoring\api\phfg.api\phfg.api.sln"

- Right-click the `phfg-api` C# project, Publish
Import the downloaded publish profile

Now you're ready to go!


# Reference
## Use Portal to create Function App
https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function

# Azure
Storage account keys => inject as environment variables into Azure Functions
