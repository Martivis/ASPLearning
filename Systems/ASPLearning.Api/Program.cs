using ASPLearning.Api.Configuration;
using ASPLearning.Services.Settings;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddSwaggerSettings();

services.AddAppSwagger();

var app = builder.Build();

app.UseAppSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
