# appinsights

# Clean Architecture

This project based on the Clean Architecture framework with ASP.NET Core. [Clean Architecture](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#clean-architecture) and solution tempalte is created based on the [ardalis/cleanarchitecture](https://github.com/ardalis/cleanarchitecture) GitHub repository.


## Using the GitHub Repository

To get started based on this repository, you need to get a copy locally. You have three options: fork, clone, or download. Most of the time, you probably just want to download.

You should **download the repository**, unblock the zip file, and extract it to a new folder if you just want to play with the project or you wish to use it as the starting point for an application.

You should **fork this repository** only if you plan on submitting a pull request. Or if you'd like to keep a copy of a snapshot of the repository in your own GitHub account.

You should **clone this repository** if you're one of the contributors and you have commit access to it. Otherwise you probably want one of the other options.

## Technology Stack

.NET 5.0
SQLLite - Database ( initial seed will create a database table and insert the mock data)
EF Core 5.0.4 
Swagger API Doc


##Build and Release

Azure dev ops build and relesae pipelines are configured to build and deploy the latest code from main brachn to azure app services

https://dev.azure.com/kannappankalisamy0761/AppInsights/



##API
/api/AppInsights?clientId=xyz-0001" 

##DTO
ActivityLogDTO
ActivityDateTimeUTC - DateTime
ServerName - HostName string
isOnline - Bool ( True/False)



## Azure Web APP/ APIM Url

