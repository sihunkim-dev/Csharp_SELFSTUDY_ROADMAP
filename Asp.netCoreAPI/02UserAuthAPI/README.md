## User Authentication and Authorization

**This project is for self-study with asp.net core api**


**Create new dotnet webapi project**
`dotnet new webapi -o ProjectName`

### Key difference between Authentication and Authorization

- **Authentication** : The process of verifying who a user is 

- **Authorization** : The process of verifying what a user is allowed to do

### Key points in Project
- JWT-based authentication and Authorization for resources
- Handling Middleware pipeline
- Access Token must be returned to client to be stateless : Server only remembers refresh token for a while(7 days maximum : optional)
- Mapping and Fluent api with database


### Entity
- `User`
  1. userId : pk
  2. email : required
  3. password : required



### API Endpoints
**GET**
- `/user/{userId}` : receive specific user information [ADMIN]
- `/user` : receive 