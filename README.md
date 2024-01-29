# Nombre del Proyecto
Rest Api developed with .NET, using repository design pattern and postgres sql database. It has migrations included.

## Requisitos

Make sure you have the following installed before running the app:

- .NET SDK
- postgres sql
- 
## Configuración

1. Clone repository:
   ```bash
git clone https://github.com/RobinsonHortaBeltran/softGnetBack.git
cd sofGnetBack
  ```
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
