using CallForPapers.Application.Repositories;
using CallForPapers.Core.Behavior;
using CallForPapers.Core.Middlewares;
using CallForPapers.Infrastructure.Database;
using CallForPapers.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var assemblies = AppDomain.CurrentDomain.GetAssemblies();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddTransient<IStatementRepository, StatementRepository>();
builder.Services.AddTransient<IStatementActivityRepository, StatementActivityRepository>();

builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(assemblies);

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseNpgsql(config["ConnectionStrings:URI"])
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
