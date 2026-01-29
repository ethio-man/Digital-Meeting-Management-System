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
- Generate formatted “Minutes of Meeting (ቃለ ጉባኤ)” documents
- Preview and print final reports
- Insert digital signature placeholders
---

## Demo / Screenshots

- Landing / Dashboard  
  ![Dashboard screenshot](docs/screenshots/dashboard.png)

- Create meeting / Agenda editor  
  ![Create meeting screenshot](docs/screenshots/create-meeting.png)

- Meeting details / Minutes  
  ![Meeting details screenshot](docs/screenshots/meeting-details.png)

Notes:
- Replace the placeholder images above with real screenshots.
- Prefer PNG or JPG images sized appropriately (e.g., 1280×720).
- If you want to include animated demos, add GIFs or short MP4s to `docs/screenshots/` and link them here.

---

## Tech stack

- Frontend: TODO (e.g., React, Vue, Angular)  
- Backend: TODO (e.g., Node.js + Express, Django, Flask, .NET Core)  
- Database: TODO (e.g., PostgreSQL, MySQL, SQLite)  
- Authentication: TODO (JWT, OAuth2, session-based)  

Update the items above with the technologies your project uses.

---

## Prerequisites

- Node.js vXX (if using Node) and npm / yarn  
- Python 3.X (if using Python) and pip  
- Database server (PostgreSQL / MySQL) if not using SQLite  

Replace the placeholders above and list any other tools (Docker, make, etc.) your project needs.

---

## Installation

1. Clone the repository
   ```bash
   git clone https://github.com/ethio-man/Digital-Meeting-Management-System.git
   cd Digital-Meeting-Management-System
   ```

2. Install dependencies
   - For Node projects:
     ```bash
     npm install
     # or
     yarn install
     ```
   - For Python projects:
     ```bash
     python -m venv venv
     source venv/bin/activate   # macOS / Linux
     venv\Scripts\activate      # Windows
     pip install -r requirements.txt
     ```

Replace the commands above with the exact commands used by your project.

---

## Configuration

Create a `.env` file (or edit the config) with required environment variables:

Example `.env` (update with real keys)
```
DATABASE_URL=postgres://user:password@localhost:5432/dbname
SECRET_KEY=your-secret-key
PORT=3000
```

Describe any other environment or configuration steps required (API keys, OAuth client IDs, etc.).

---

## Running locally

- For Node/Express + React style apps:
  ```bash
  # start backend
  npm run start:server

  # start frontend (if separate)
  npm run start:client
  ```

- For Python/Django:
  ```bash
  python manage.py migrate
  python manage.py runserver
  ```

Replace the commands above with exact project scripts.

---

## Database & Migrations

If your project uses migrations:
```bash
# Example (Django)
python manage.py migrate

# Example (Node + Sequelize)
npx sequelize db:migrate
```

Document seeding and how to create an initial admin user:
```bash
# Example
python manage.py createsuperuser
```

---

## Running tests

Run the test suite:
```bash
# Node
npm test

# Python
pytest
```

Describe any integration tests, end-to-end tests, or CI configuration.

---

## Deployment

Suggested options:
- Deploy backend to: Heroku, DigitalOcean, AWS Elastic Beanstalk, Docker/Kubernetes
- Deploy frontend to: Vercel, Netlify, GitHub Pages

Example Docker steps:
```bash
docker build -t digital-meeting .
docker run -p 3000:3000 --env-file .env digital-meeting
```

Add project-specific deployment instructions and recommended environment variables.

---

## Contributing

Thank you for considering contributing! Please:

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m "Add my feature"`
4. Push to your branch: `git push origin feature/my-feature`
5. Open a Pull Request describing your changes.

Include coding style, linting, and testing requirements (e.g., run linters and tests before submitting PR).

---

## Roadmap

Planned features:
- Recurring meetings
- Calendar integrations (Google Calendar, Outlook)
- Advanced permissions and organizational hierarchy
- Notifications and email reminders

Add or remove items to reflect your project's roadmap.

---

## License

This project is licensed under the [MIT License](LICENSE) — change if another license applies.

---

## Contact

Project maintainer: ethio-man  
Email: TODO (add contact email)  
Repository: https://github.com/ethio-man/Digital-Meeting-Management-System
