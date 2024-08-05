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
dotnet run --launch-profile https # Inside Api / Web Project
dotnet run --project ./Lagoon.Web/
dotnet watch run --project ./Lagoon.Web/

```
#### USER SECRETS
```bash 
dotnet user-secrets init --project ./Lagoon.Web/
dotnet user-secrets set --project ./Lagoon.Web/ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project ./Lagoon.Web/
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

