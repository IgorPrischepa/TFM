using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NpgsqlTypes;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;
using Serilog.Sinks.PostgreSQL.ColumnWriters;
using System.Text;
using tfm.api.bll.Services.Contract;
using tfm.api.bll.Services.Contracts;
using tfm.api.bll.Services.Implementations;
using tfm.api.bll.Services.Implemetation;
using tfm.api.dal.Db;
using tfm.api.dal.Repos.Contracts;
using tfm.api.dal.Repos.Implemetations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Logger config

var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

string tableName = "logs";

IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
{
    { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
    { "message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
    { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
    { "raise_date", new TimestampColumnWriter(NpgsqlDbType.TimestampTz) },
    { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
    { "properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
    { "props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
    { "machine_name", new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l") }
};


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("Default connections string can't be null.");

Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.PostgreSQL(connectionString, tableName, columnWriters, needAutoCreateSchema: true, needAutoCreateTable: true)
        .ReadFrom.Configuration(configuration)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .CreateLogger();
builder.Host.UseSerilog();

// Connect to PostgreSQL Database

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:secret"]!))
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
builder.Services.AddScoped<IStyleRepo, StyleRepo>();
builder.Services.AddScoped<IStylePriceRepo, StylePriceRepo>();
builder.Services.AddScoped<IExamplesRepo, ExamplesRepo>();
builder.Services.AddScoped<IMasterRepo, MasterRepo>();

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJWTAuthService, JWTAuthService>();
builder.Services.AddScoped<IStyleService, StyleService>();
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