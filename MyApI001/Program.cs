using MyApI001.Repository.Interfaces;
using MyApI001.Repository.Repo;
using MyApI001.Services.Interfaces;
using MyApI001.Services.Service;
using NLog.Web;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IEmployeesRepo,EmployeesRepo>();


var app = builder.Build();
var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
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
