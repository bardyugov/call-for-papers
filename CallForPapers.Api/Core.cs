using CallForPapers.Infrastructure;
using CallForPapers.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddInfrastructure(config);

var app = builder.Build();
app.UseCustomExceptionHandler();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
