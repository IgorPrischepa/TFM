using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;
using tfm.api.bll.Services.Contracts;
using tfm.api.bll.Services.Implementations;
using tfm.api.dal.Db;
using tfm.api.dal.Repos.Contracts;
using tfm.api.dal.Repos.Implemetations;
using tfm.api.Services.Contract;
using tfm.api.Services.Implemetation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Logger config

var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
        .ReadFrom.Configuration(configuration)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .CreateLogger();
builder.Host.UseSerilog();

// Connect to PostgreSQL Database


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:audience"],
        ValidIssuer = builder.Configuration["Jwt:issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:secret"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", _ => { _.RequireRole("Admin"); });
    options.AddPolicy("Manager", _ => { _.RequireRole("Manager"); });
    options.AddPolicy("Customer", _ => { _.RequireRole("Customer"); });
});

//Repos
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IRolesRepo, RoleRepo>();
builder.Services.AddScoped<IMasterRepo, MasterRepo>();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTAuthService, JWTAuthService>();
builder.Services.AddScoped<IMasterService, MasterService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("JWT Bearer", new OpenApiSecurityScheme
    {
        Description = "This is a JWT bearer authentication scheme",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{
            Reference = new OpenApiReference{
                Id = "JWT Bearer",
                Type = ReferenceType.SecurityScheme
            }
            }, new List<string>()
        }
    });
});

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();