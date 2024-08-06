
### INFRA

#### Docker
```bash
# Below Command Run After SQL Container Runs (Keys are Case Insensitive & their alternatives are available)
# Docker Command When you don't  have a Container already running
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Asdf@1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps -a
docker start 56410d

```

### Extra
```bash
ngrok http --host-header=rewrite https://localhost:5001/
# For Creating Certificate in dotnet core
dotnet dev-certs https --trust
```

### MIGRATION
```bash
# Installing Tools When you dont have
dotnet tool list --global
dotnet tool install --global dotnet-ef -v 6.0.16
Install-Package Microsoft.EntityFrameworkCore.Tools # Power Shell

# ADD 
# NOTE: --connection is not the part of add migrations
dotnet ef migrations add Villa_Occupancy -p Lagoon.Infra -s Lagoon.Web

dotnet ef migrations add NameOfMigration 
# When you have One DBContext and One Project
dotnet ef migrations add NameOfMigration -p Lagoon.Infra -s Lagoon.Web --context DBCntx # When you have two or more Projects

# UPDATE
dotnet ef database update -p Lagoon.Infra -s Lagoon.Web --connection "Server=.;Database=Lagoon;User ID=sa;Password=Asdf@1234;Trusted_Connection=False;Encrypt=false;Integrated Security=False;"

# REMOVE
dotnet ef migrations remove  -p Lagoon.Infra -s Lagoon.Web

### PACKAGE MANAGER
UPDATE-DATABASE -Context DatabaseContext
Add-Migration NameOfMigration -Context DatabaseContextName

# Before Running the Below Command Ensure the Project is not Running Because DB In Use
dotnet ef database update -p Lagoon.Infra -s Lagoon.Web --connection "..."
dotnet run --project Lagoon.Web

```