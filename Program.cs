using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoftGnet.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SoftGnet.Repository.Repositories;
using System.Configuration;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "http://localhost:4200")
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                               .WithMethods("login");
                      });
});

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json");
var key = builder.Configuration.GetSection("JwtConfig").GetSection("Key").ToString();
var keyBytes = Encoding.UTF8.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        AudienceValidator = (audiences, securityToken, validationParameters) => true,
        RequireAudience = false,
    };
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorios
builder.Services.AddScoped<UserRepository, UserRepository>();
builder.Services.AddScoped<DriversRepository, DriversRepository>();
builder.Services.AddScoped<VehiclesRepository, VehiclesRepository>();
builder.Services.AddScoped<RoutesRepository, RoutesRepository>();
builder.Services.AddScoped<SchedulesRepository, SchedulesRepository>();

builder.Services.AddAuthorization();



// Configuración de la base de datos PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
// Se deben colocar UseAuthentication y UseAuthorization antes de MapControllers
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();