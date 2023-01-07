using ASPLearning.Api.Configuration;
using ASPLearning.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var services = builder.Services;

services.AddControllers();
services.AddSwaggerSettings();
services.AddAppSwagger();
services.AddAppHealthCheck();

var app = builder.Build();

app.UseAppSwagger();
app.UseAppHealthChecks();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
