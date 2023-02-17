using Microsoft.EntityFrameworkCore;
using tfm.api.bll.Services.Contracts;
using tfm.api.bll.Services.Implementations;
using tfm.api.dal.Db;
using tfm.api.dal.Repos.Contracts;
using tfm.api.dal.Repos.Implemetations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

//Repos
builder.Services.AddScoped<IUserRepo, UserRepo>();

//Services
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
