using ASPLearning.Api.Configuration;
using ASPLearning.Api.Settings;
using ASPLearning.Context;
using ASPLearning.Context.Setup;
using ASPLearning.Services;
using ASPLearning.Services.UserAccount;
using ASPLearning.Settings;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();


var services = builder.Services;
var identitySettings = Settings.Load<IdentitySettings>("Identity");
services.AddSingleton(identitySettings);

services.AddHttpContextAccessor();

services.AddAppAuth(identitySettings);
services.AddControllers().AddValidator();
services.AddAppDbContext();
services.AddAppVersioning();
services.AddAppSwagger(identitySettings);
services.AddAppHealthCheck();
services.AddAppAutomapper();
services.AddAppUserAccountService();

services.AddTextService();

var app = builder.Build();

app.UseAppAuth();
app.UseAppSwagger();
app.UseAppHealthChecks();

app.UseHttpsRedirection();
app.MapControllers();

DbInitializer.Execute(app.Services);
DbSeeder.AddDemoData(app.Services);

app.Run();
