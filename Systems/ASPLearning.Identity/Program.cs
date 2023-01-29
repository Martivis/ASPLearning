using ASPLearning.Identity.Configuration;
using ASPLearning.Context;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppDbContext();
services.AddAppIdentityServer();
services.AddAppHealthCheck();
services.AddAppCors();

var app = builder.Build();
app.UseAppIdentityServer();
app.UseAppHealthChecks();

app.Run();

