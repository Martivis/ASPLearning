using ASPLearning.Identity.Configuration;
using ASPLearning.Context;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppDbContext();
services.AddAppHealthCheck();


var app = builder.Build();

app.UseAppHealthChecks();

app.Run();

