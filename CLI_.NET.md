# DOT NET CLI
### Dot New
> It will Create the Project within the Folder as of name of the Folder 
```bash
dotnet new webapi
dotnet new react
dotnet new angular
```
- 
### Dot Net Use Full Command
```bash
dotnet-
dotnet build
dotnet build-server
dotnet clean
dotnet dev-certs
dotnet format
dotnet help
dotnet migrate
dotnet msbuild
dotnet new <TEMPLATE>
dotnet new list
dotnet new search
dotnet new install
dotnet new uninstall
dotnet new update
# .NET default templates
# Custom templates
dotnet pack
dotnet publish
dotnet restore
dotnet run
dotnet sdk check
dotnet sln
dotnet store
dotnet test
dotnet vstest
dotnet watch
# Elevated access
# Enable Tab completion
# Develop libraries with the CLI
```
### Implicit restore
1. You don't have to run dotnet restore because it's run implicitly by all commands that require a restore to occur, such as dotnet new, dotnet build, dotnet run, dotnet test, dotnet publish, and dotnet pack. To disable implicit restore, use the --no-restore option.


### dotnet new 
```bash
dotnet new <TEMPLATE> 
  [--dry-run] 
  [--force] 
  [-lang|--language {"C#"|"F#"|VB}]
  [-n|--name <OUTPUT_NAME>] 
  [-f|--framework <FRAMEWORK>] 
  [--no-update-check]
  [-o|--output <OUTPUT_DIRECTORY>] 
  [--project <PROJECT_PATH>]
  [-d|--diagnostics] 
  [--verbosity <LEVEL>] [Template options]
```

### What does dotnet run under the hood?
- dotnet run 4 things
1. restore based on project.cs -> Download Dependencies
2. build -> compiled the App
3. run the project
4. Open the Default Browser and Load the page

### dotnet run
```bash
dotnet run 
    [-a|--arch <ARCHITECTURE>] 
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] // net6.0 
    [--force] 
    [--interactive]
    [--launch-profile <NAME>] 
    [--no-build]
    [--no-dependencies] 
    [--no-launch-profile] 
    [--no-restore]
    [--os <OS>] 
    [--project <PATH>] // path/where/project_created
    [-r|--runtime <RUNTIME_IDENTIFIER>]
    [-v|--verbosity <LEVEL>] 
    [[--] [App arguments]]

dotnet run -h|--help
```
### Adding Swagger to a Project?
```bash
dotnet add TodoApi.csproj package Swashbuckle.AspNetCore -v 6.2.3
```

### UBUNTU DOTNET INSTALLATION
```bash
# Add Microsoft package repository
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

# Update package list and install .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Verify .NET installation
dotnet --list-sdks
dotnet --list-runtimes
```
### Tools (EF)
```bash
# Add SDK and Tools path to the environment (for Bash)
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$DOTNET_ROOT' >> ~/.bashrc
echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> ~/.bashrc
source ~/.bashrc

# Add SDK and Tools path to the environment (for Zsh)
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.zshrc
echo 'export PATH=$PATH:$DOTNET_ROOT' >> ~/.zshrc
echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> ~/.zshrc
source ~/.zshrc

# Verify environment configuration
echo $DOTNET_ROOT
echo $PATH

# Reinstall dotnet-ef tool
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef

# Verify dotnet-ef tool installation
dotnet ef

```

### UBUNTU UNINSTALL DOTNET 
```bash
# List installed SDKs and runtimes
dotnet --list-sdks
dotnet --list-runtimes

# Remove .NET SDKs and runtimes
sudo apt-get remove --purge dotnet-sdk-8.0
sudo apt-get remove --purge dotnet-runtime-8.0
sudo apt-get remove --purge aspnetcore-runtime-8.0

# Remove global tools
dotnet tool uninstall --global dotnet-ef

# Remove remaining files and directories
sudo rm -rf /usr/share/dotnet
sudo rm -rf ~/.dotnet
sudo rm -rf ~/.nuget

# Update package list and clean up
sudo apt-get update
sudo apt-get autoremove
sudo apt-get clean

```