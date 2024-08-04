## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash / to ForwardSlash /
- Note: For Ubuntu You can Revert BackSlash / to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### SOLUTION COMMANDS
```bash
dotnet new sln -o Lagoon
```
### CLASS LIBRARY
```bash
# dotnet new webApi -o Lagoon.Web
dotnet new mvc -o Lagoon.Web
dotnet new classlib -o Lagoon.App
dotnet new classlib -o Lagoon.Contracts
dotnet new classlib -o Lagoon.Infra
dotnet new classlib -o Lagoon.Domain
```
### ADD / REMOVE PROJECTS
```bash
dotnet sln add ./Lagoon.Web
dotnet sln add ./Lagoon.App
dotnet sln add ./Lagoon.Contracts
dotnet sln add ./Lagoon.Infra
dotnet sln add ./Lagoon.Domain

dotnet sln add (ls -r **/*.csproj) # Powershell Command
dotnet sln remove ./Lagoon.Contacts/Lagoon.Contacts.csproj # cmd
dotnet format ./solution.sln # ??
more./SolutionName.sln # ??
```
### ADDING LOCAL PROJECTS
```bash
dotnet build
dotnet add ./Lagoon.Web/ reference ./Lagoon.Contracts/ ./Lagoon.App/ ./Lagoon.Infra/
dotnet add ./Lagoon.Infra/ reference ./Lagoon.App/ ./Lagoon.Domain/
dotnet add ./Lagoon.App/ reference ./Lagoon.Domain/
```
### RUNNING PROJECTS
```bash
dotnet run --project ./Lagoon.Web/
dotnet watch run --project ./Lagoon.Web/
```

#### USER SECRETS
```bash 
dotnet user-secrets init --project ./Lagoon.Web/
dotnet user-secrets set --project ./Lagoon.Web/ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project ./Lagoon.Web/
```
### EXTERNAL PACKAGES
- Adding Packages to Specific Project
```bash
dotnet add ./Lagoon.Web/ package AutoMapper 
dotnet add ./Lagoon.Web/ package AspNetCoreRateLimit 
dotnet add ./Lagoon.Web/ package Marvin.Cache.Headers 
dotnet add ./Lagoon.Web/ package Microsoft.AspNetCore.Mvc.Versioning 
dotnet add ./Lagoon.Web/ package Microsoft.EntityFrameworkCore.Design 
dotnet add ./Lagoon.Web/ package Microsoft.EntityFrameworkCore.Tools 
dotnet add ./Lagoon.Web/ package X.PagedList.Mvc.Core 

dotnet add ./Lagoon.App/ package OneOf # Drawback of Scalability used in App Layer
dotnet add ./Lagoon.App/ package FluentResults # It has Lack Some Ability of OneOf used in App Layer
dotnet add ./Lagoon.App/ package FluentValidation
dotnet add ./Lagoon.App/ package FluentValidation.AspNetCore
dotnet add ./Lagoon.App/ package Mapster
dotnet add ./Lagoon.App/ package MediatR
dotnet add ./Lagoon.App/ package MediatR.Extension.Microsoft.DependencyInjection
dotnet add ./Lagoon.App/ package Microsoft.Extensions.DependencyInjection.Abstractionst

dotnet add ./Lagoon.Domain/ package ErrorOr # Recommended and Final Approach

dotnet add ./Lagoon.Infra/ package DynamicExpressions.NET
dotnet add ./Lagoon.Infra/ package LinqKit.Core
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore 
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.SqlServer
# dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.Design
dotnet add ./Lagoon.Infra/ package Microsoft.EntityFrameworkCore.DynamicLinq
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add ./Lagoon.Infra/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./Lagoon.Infra/ package Microsoft.Extensions.Configuration
dotnet add ./Lagoon.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add ./Lagoon.Infra/ package X.PagedList
dotnet add ./Lagoon.Infra/ package X.PagedList.Mvc.Core
```
### GIT
```bash
start . # OPENING FOLDER EXPLORER USING CLI

dotnet new gitignore
git init
git push --set-upstream origin main
git push --set-upstream origin main
git remote set-url stream https://gitlab.com/starbazaar/admin-panel.git
git remote add stream https://gitlab.com/starbazaar/webapp.git
git remote -v
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (fetch)
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (push)
stream  https://gitlab.com/starbazaar/webapp.git (fetch)
stream  https://gitlab.com/starbazaar/webapp.git (push)
dotnet new editorconfig
```

### DOCKER
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Asdf@1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps
# Below Command Run After SQL Container Runs (Keys are Case Insensitive & their alternatives are available)
```
### MIGRATION
```bash
dotnet tool install --global dotnet-ef
dotnet tool list --global


dotnet ef database add MigrationName --project Lagoon.Infra --startup-project Lagoon.Web --connection "SERVER=127.0.0.1,1433;DATABASE=SB;USER=sa;PASSWORD=Asdf@1234;Encrypt=false"
# Run Migration
dotnet ef database update -p Lagoon.Infra -s Lagoon.Web --connection "server=localhost;Database=Lagoon;User Id=sa;password=Asdf@1234;TrustServerCertificate=true"
# This Command won't work b/c of Certificate & Swagger (Run using f5)

# ADD
dotnet ef migrations add InitialCreate -p Lagoon.Infra -s Lagoon.Web
# REMOVE
dotnet ef migrations remove  -p Lagoon.Infra -s Lagoon.Web
# UPDATE
dotnet ef database update -p Lagoon.Infra -s Lagoon.Web --connection "Server=localhost;Database=SB;User Id=sa;Password=Asdf@1234;Encrypt=false"
# RUN
dotnet run --project Lagoon.Web
```
### CURL COMMAND
- Undermentioned Commands only works with Bash
- Before Using that you have to Stop Https Middleware
- Running your app with http in Visual Studio
```bash
curl -X 'POST' 'http://localhost:5294/auth/register' -H 'accept: */*' -H 'Content-Type: App/json' -d '{   "firstName": "string", "lastName": "string", "email": "string", "password": "string" }'
curl -X 'POST' 'http://localhost:5294/auth/login' -H 'accept: */*' -H 'Content-Type: App/json' -d '{ "email": "string", "password": "string" }'
curl -X 'GET' 'http://localhost:5294/Web/Dinners' -H 'accept: */*' -H 'Authorization: Bearer token.full.goeshere'
```

30

dotnet run --launch-profile https