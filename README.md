
# DeerDiary
## Concept and Planning
### Idea
DeerDiary is an application which helps you Journal. Each day you visit the site, where you may write down a simple entry about your day. DeerDiary asks a random question each day, to help you engage and express your emotions. Not only that, it mentors you specifically to your journal entries, by reading the journal and asking specific questions to help you see what is not clear. The goal is to help you express.
#### Originality
DeerDiary seeks to improve QoL when journaling and most importantly support you with your expression, by asking questions specifically to your journal entries.  
### Technologies
#### Frontend
We will employ Blazor as our frontend, where it is independent from the backend and communicates through the API to the backend.
#### Backend
We will employ ASP.NET as our backend, where it connects to the DB and offers an API. Entity framework will be used as an ORM.
#### Database
We will employ a MySQL database which will be running inside a container.

## Starting the project
### Docker setup
- Make sure no MySQL processes are running so that our Database system works.
- `docker compose up` inside of the repository to start up all the containers needed for the Website.

### Opening the Website
- Open the solution in VisualStudio and right-click thes solution file, then select "Configure Startup Projects...", choose "Multiple startup projects:" and finally select "Start" for both Frontend and Backend.
- Open the PMC (Packet Manager Console) by clicking on View > Other Windows > Packet Manager Console
- Inside the PMC type `update-update` and wait for it to say "Done."
- Now you can press Start or F5 to startup the website and make sure to navigate to `localhost:7201`.
