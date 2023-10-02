using Demo.AuthService.Interfaces;
using Demo.AuthService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<SMSoptions>(builder.Configuration.GetSection("SMSClientSettings"));
builder.Services.Configure<SMSConfiguration>(builder.Configuration.GetSection("SMSConfiguration"));
builder.Services.AddTransient<ISmsService, SmsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();