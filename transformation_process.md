# From Code to Product: The MiniDARMAS Transformation Journey

This document details the step-by-step process used to transform the **MiniDARMAS** source code into fully functional, distributable application software.

## Phase 1: Application Readiness (Preparing the Source)
Before creating an installer, the "raw" source code needed to be polished into a proper software identity.

### 1.1 Defining Identity
We moved beyond default settings to give the application a professional profile in `MiniDARMAS.csproj`:
*   **Metadata**: Assigned Version (`1.0.0`), Publisher (`ethio-man`), and Copyright.
*   **Branding**: Replaced the default executable icon with a custom **Nationally Themed Icon**. We automated the conversion of a high-res PNG to the required `.ico` format using a custom PowerShell script.

### 1.2 Build Configuration
We configured the application to be **Self-Contained**.
*   **What this means**: The .NET Runtime is bundled *inside* the application.
*   **Benefit**: The end user does **not** need to install .NET separately. It just works.
*   **Architecture**: Targeted `win-x64` for modern Windows systems.

---

## Phase 2: The Packaging Strategy (WiX Toolset)
We chose **WiX Toolset v4** to create an industry-standard Windows Installer (`.msi`).

### 2.1 Project Structure
We created a separate project `MiniDARMAS.Installer` to keep the packaging logic clean and separate from the application code.

### 2.2 Automated File Harvesting ("Heat")
Instead of manually listing every DLL and file (which is error-prone), we used **HeatWave** (`HarvestDirectory`).
*   **Mechanism**: The build process automatically "harvests" every file in the `publish` directory.
*   **Result**: If you add a new library to the app, the installer automatically includes it in the next build without manual updates.

### 2.3 Installation Experience
We defined the user experience in `Package.wxs`:
*   **Directory Layout**: Installs to `%ProgramFiles%\MiniDARMAS`.
*   **Shortcuts**: Automatically creates shortcuts on the **Desktop** and in the **Start Menu**.
*   **Upgradability**: Configured `MajorUpgrade` logic so installing version 1.1.0 will automatically remove 1.0.0.

---

## Phase 3: The Build Pipeline (The "Transformation")
The transformation happens in a specific sequence of commands. This is the "recipe" for the software.

### Step 1: Clean & Refresh
We start fresh to ensure no old files cause conflicts.
```powershell
dotnet clean
```

### Step 2: Publish (Compile Application)
We compile the C# code into machine code and gather all dependencies.
```powershell
dotnet publish "..\MiniDARMAS\MiniDARMAS.csproj" -c Release -r win-x64 --self-contained true -o "..\publish"
```
*   *Output*: A folder full of DLLs and the `MiniDARMAS.exe`.

### Step 3: Build Installer (Package Application)
We compile the WiX project. This step:
1.  Reads the `publish` folder.
2.  Compresses the files into `.cab` archives.
3.  Embeds the icon and metadata.
4.  Generates the database tables for the Windows Installer.
```powershell
dotnet build "MiniDARMAS.Installer\MiniDARMAS.Installer.wixproj" -c Release
```

### Challenges Overcome
*   **Path Resolution**: We fixed build errors where the installer couldn't find the files by implementing a robust `DeployDir` pathing strategy.
*   **Icon Management**: We ensured the icon appears not just on the `.exe`, but also in the Windows "Add/Remove Programs" list.

---

## Phase 4: The Final Product
The result is a single file: **`MiniDARMAS.Installer.msi`**.

*   **Professional**: Signed (self-signed), versioned, and branded.
*   **Distributable**: Can be shared via USB, Cloud, or Network.
*   **Managed**: Windows can track it, repair it, and uninstall it cleanly.
