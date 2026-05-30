# TaskTrackerAPI with JWT Auth

## Entities

- USERs
  - userId(`PK`)
  - Email
  - Password

- TASKs
  - TaskId(`PK`)
  - userId(`FK`)
  - TaskName
  - IsCompleted
  - CreatedAt
  - UpdatedAt

---
## System Architecture

---
## API Endpoints
### Auth(`Signup` `Signin`)

### USER
**GET** <br/>
- `/api/users/me`

**POST**<br/>
- `/api/users/tasks`
<br/>
**PUT**<br/>

**DELETE**<br/>

