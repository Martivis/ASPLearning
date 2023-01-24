using ASPLearning.Api.Configuration;
using ASPLearning.Context;
using ASPLearning.Context.Setup;
using ASPLearning.Services;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddHttpContextAccessor();

services.AddControllers()
	.AddValidator();

services.AddAppDbContext();
services.AddAppVersioning();
services.AddAppSwagger();
services.AddAppHealthCheck();
services.AddAppAutomapper();

services.AddTextService();

var app = builder.Build();

app.UseAppSwagger();
app.UseAppHealthChecks();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

DbInitializer.Execute(app.Services);
DbSeeder.AddDemoData(app.Services);

app.Run();
