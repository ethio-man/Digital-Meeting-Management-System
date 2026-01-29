# Digital Meeting Management System

A WinForms-based meeting management and transcription system that supports recording, agenda tracking, role-based workflows, and official minutes generation.

---

## Table of contents

- [Features](#features)
- [Demo / Screenshots](#demo--screenshots)
- [Tech stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Running locally](#running-locally)
- [Database & Migrations](#database--migrations)
- [Running tests](#running-tests)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [Roadmap](#roadmap)
- [License](#license)
- [Contact](#contact)

---

## Features

### User & Security

- Role-based login and authentication (Admin, Operator, Transcriber, Editor, Approver)
- Secure database connection and session handling
- User management (create, edit, activate/deactivate users)
  
### Meeting Management
- Create, update, and delete meeting records
- Manage meeting details (meeting number, date, location, chairperson)
- View and search historical meetings
- Sort meetings using DataGridView headers
  
### Agenda Management
- Create and manage multiple agenda items per meeting
- Attach reference documents to agendas
- Edit and remove agenda items
- Assign agenda items to recordings and transcriptions

### Audio Recording & Playback

- Record live meeting audio segments
- Automatic time-based audio segmentation
- Store and manage audio file paths
- Integrated audio playback for transcribers
- Play, pause, stop, and seek audio recordings
  Transcription Management

### Assign audio recordings to transcribers

- Text-based transcription editor
- Track transcription progress and completion status
- Save draft and submit completed transcriptions
  
### Editorial Review & Approval

- Editor review of submitted transcriptions
- Make corrections and finalize text
- Approver validation and final approval
-  Track editorial and approval status

### Minutes of Meeting Generation

- Automatic compilation of approved transcriptions
- Generate formatted “Minutes of Meeting ” documents
- Preview and print final reports
- Insert digital signature placeholders
---

## Demo / Screenshots
- Login page
  ![Login screeshot](docs/screenshots/login.png)
- Admin Dashboard  
  ![Dashboard screenshot](docs/screenshots/dashboard.png)
- Activity Logs
- ![Activities log](docs/screenshots/activity-log.png)
- User Managment Form
- ![Manage users](docs/screenshots/user-Managment.png)
- Manage meeting 
- ![Meeting management](docs/screenshots/meeting.png)
- Manage Agenda
- ![Managing Agendas](docs/screenshots/agenda.png)
- Transcriber Page
- ![Meeting Transcription page](docs/screenshots/transcriber.png)
- Editor Page
- ![Editting Transcriptions](docs/screenshots/editor.png)
- Meeting details / Minutes  
  ![Meeting details screenshot](docs/screenshots/meeting-details.png)

---

## Tech stack

- Frontend(Desktop UI): C# WinForms (.NET)
- Backend & Business Logic: C# (.NET)
- Database: Microsoft SQL Server 
- Data Access : ADO.NET (Microsoft.Data.SqlClient)
- Architecture & Patterns : MVC Architecture
---

## Prerequisites
### Software Requirements
- Microsoft Windows Operating System (Windows 10 or later)
- Microsoft Visual Studio (with .NET desktop development workload)
- Microsoft SQL Server (Express, LocalDB, or Standard Edition)
- SQL Server Management Studio (SSMS)
- .NET Runtime
- 
### Database Requirements
- Created SQL Server database (e.g., MiniDARMAS_DB)
- Required database tables (Users, Meetings, Agendas, Recordings, Transcriptions, ActivityLogs, etc.)
- Proper database permissions for the application user

### System Requirements
- Minimum 4 GB RAM (8 GB recommended)
- At least 2 GHz processor
- Sufficient disk space for:
- Database files
- Audio recordings
- Attached documents
---

## Installation

### Step 1: Install Required Software

- Install Microsoft Windows 10 or later

- Install Microsoft Visual Studio

- Select .NET desktop development workload

- Install Microsoft SQL Server (Express or LocalDB)

- Install SQL Server Management Studio (SSMS)

### Step 2: Set Up the Database

- Open SSMS
- Connect to SQL Server
- Create the database:
- CREATE DATABASE MiniDARMAS_DB;
- Run the provided SQL scripts to create all required tables:
- Users
- Meetings
- Agendas
- Recordings
- Transcriptions
- ActivityLogs
- Verify tables are created successfully

### Step 3: Configure Database Connection

- Open the project in Visual Studio
- Edit App.config
- Set the correct connection string:
```bash
<connectionStrings>
  <add name="MiniDARMAS_DB"
       connectionString="Server=(localdb)\MSSQLLocalDB;
                         Database=MiniDARMAS_DB;
                         Trusted_Connection=True;
                         TrustServerCertificate=True;" />
</connectionStrings>
```
- Save changes

### Step 4: Configure File Storage
- Create folders for file storage:
```bash
C:\MiniDARMAS\Audio
C:\MiniDARMAS\Documents
C:\MiniDARMAS\Signatures
```
- Grant read/write permissions to the application user
- Update application settings if paths are configurable

### Step 5: Build the Application

- Open solution in Visual Studio
- Restore NuGet packages (if any)
- Build the solution (Build → Build Solution)
- Fix any build errors

### Step 6: Run Initial Test

- Run the application
- Test database connection
- Log in using a test Admin account
- Create a test meeting
- Verify data appears in DataGridView

### Step 7: Configure Users and Roles
- Log in as Admin
- Create system users:
- Operator
- Transcriber
- Editor
- Approver
- Assign roles and activate accounts

### Step 8: Verify Audio & Documents

- Upload or place a test audio file in:
``` bash
  C:\MiniDARMAS\Audio
```
- Assign recording to a transcriber
- Test audio playback
- Test document attachments and previews

### Step 9: Localization Check (Optional)

- Switch UI language (Amharic / English)
- Verify correct display of all labels and buttons

### Step 10: Final Verification
- Test full workflow:
- Meeting creation
- Agenda management
- Recording
- Transcription
- Editorial review

### Final approval

- Verify activity logs
- Generate and preview final Minutes of Meeting


## Contributing

Thank you for considering contributing! Please:

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m "Add my feature"`
4. Push to your branch: `git push origin feature/my-feature`
5. Open a Pull Request describing your changes.

Include coding style, linting, and testing requirements (e.g., run linters and tests before submitting PR).

---
## License

This project is licensed under the [MIT License](LICENSE) — change if another license applies.

---

## Contact

Project maintainer: ethio-man  
Email: natymiskir@gmail.com
Repository: https://github.com/ethio-man/Digital-Meeting-Management-System
