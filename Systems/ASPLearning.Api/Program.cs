using ASPLearning.Api.Configuration;
using ASPLearning.Context;
using ASPLearning.Context.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddControllers();
services.AddAppUsersDb();
services.AddAppVersioning();
services.AddAppSwagger();
services.AddAppHealthCheck();
services.AddAppAutomapper();

var app = builder.Build();

app.UseAppSwagger();
app.UseAppHealthChecks();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

DbInitializer.Execute(app.Services);
DbSeeder.AddDemoData(app.Services);

app.Run();
