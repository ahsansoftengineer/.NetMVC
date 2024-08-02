Microsoft recommends using APT over Snap for installing .NET on Ubuntu due to several reasons:

### Install .NET SDK 8.0 using APT

1. **Add the Microsoft package signing key to your list of trusted keys and add the package repository**:
```sh
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```
2. **Install the .NET SDK**:
```sh
sudo apt update
sudo apt install dotnet-sdk-8.0
```

### Verify the installation
After installation, verify it by running:
```sh
dotnet --version
```
To configure .NET SDK with Visual Studio Code (VS Code) on Ubuntu, follow these steps:

### 1. Install Visual Studio Code
If you haven't installed VS Code yet, you can install it using APT:

```sh
sudo apt update
sudo apt install wget gpg
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > packages.microsoft.gpg
sudo install -o root -g root -m 644 packages.microsoft.gpg /usr/share/keyrings/
sudo sh -c 'echo "deb [arch=amd64 signed-by=/usr/share/keyrings/packages.microsoft.gpg] https://packages.microsoft.com/repos/vscode stable main" > /etc/apt/sources.list.d/vscode.list'
sudo apt update
sudo apt install code
```

### 2. Install .NET SDK
Make sure you have the .NET SDK installed, as described in the previous message:
```sh
sudo apt update
sudo apt install dotnet-sdk-8.0
```

### 3. Install C# Extension for VS Code
Open VS Code and install the C# extension, which provides language support for C# and .NET development.

1. **Open VS Code**.
2. **Go to the Extensions view** by clicking on the Extensions icon in the Activity Bar on the side of the window or by pressing `Ctrl+Shift+X`.
3. **Search for "C# for Visual Studio Code"**.
4. **Click Install**.

### 4. Create a New .NET Project
1. Open a terminal in VS Code by pressing `Ctrl+`` (backtick).
2. Navigate to the directory where you want to create your new project.
3. Create a new .NET project using the following command:
```sh
dotnet new console -n MyConsoleApp
```
4. Navigate into your project directory:
```sh
cd MyConsoleApp
```

### 5. Open the Project in VS Code
1. Open the project folder in VS Code by using the `code` command or by selecting `File > Open Folder` in the menu.
```sh
code .
```

### 6. Enable OmniSharp and IntelliSense
The C# extension uses OmniSharp to provide IntelliSense and other advanced language features. By default, it should be enabled, but you can check and configure it:

1. Go to `File > Preferences > Settings` or press `Ctrl+,`.
2. Search for `OmniSharp: Enable` and make sure it is checked.

### 7. Build and Run Your Project
To build and run your project:

1. Open the terminal in VS Code.
2. Use the following command to build your project:
```sh
dotnet build
```
3. Run your project using:
```sh
dotnet run
```