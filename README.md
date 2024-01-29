# Nombre del Proyecto
Rest Api developed with .NET, using repository design pattern and postgres sql database. It has migrations included.
run port:5152
## Requisitos

Make sure you have the following installed before running the app:

- .NET SDK
- postgres sql
- 
## Configuración

1. Clone repository:
git clone https://github.com/RobinsonHortaBeltran/softGnetBack.git
cd sofGnetBack
  
2. Create database:
https://www.postgresql.org/download/windows/
Database configuration
Host=localhost;Port=5432;Database=apiPg;Username=postgres;Password=0000;

3. execute migration
 ```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --context SoftGnet.Models.ApplicationDbContext
dotnet ef database update --context SoftGnet.Models.ApplicationDbContext
```
4. execute project 
```bash
dotnet run
```

5. Register User
Open postman and enter the following url
http://localhost:5152/api/Auth/register
example request
```bash
{
  "name": "Robinson Horta",
  "email": "hortarobinson@gmail.com",
  "password": "admin",
  "rol": "User"
}
```
example response 
```bash
{
    "id": 2,
    "name": "Robinson Horta",
    "email": "hortarobinson@gmail.com",
    "password": "$2a$11$ABZAIgJZwWrGjhf7lqxxnOVBPlDDEEaQRY1cuwbLXfdSJ7kpoDymS",
    "rol": "User"
}
```
open swagger for more information 
http://localhost:5152/swagger/index.html
