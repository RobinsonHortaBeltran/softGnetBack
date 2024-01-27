Comandos para readme 
creacion de proyecto 
dotnet new webapi --use-controllers -o softGNet

certificado de desarrollo de HTTPS
dotnet dev-certs https --trust

comando para iniciar la aplicación en el perfil https
dotnet run --launch-profile https

Ruta para la verificacion de swagger
/swagger/index.html

Comando para instalar paquete de postgres
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

Agregan los paquetes NuGet necesarios para realizar scaffolding.
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool uninstall -g dotnet-aspnet-codegenerator
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator

Comando para agregar un controlador
dotnet aspnet-codegenerator controller -name VehiclesController -async -api -m Vehicles -dc SoftGnet.Models.ApplicationDbContext -outDir Controllers


Comando para agregar el Jwt 
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer


comando para migraciones 
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --context SoftGnet.Models.ApplicationDbContext
dotnet ef database update --context SoftGnet.Models.ApplicationDbContext
