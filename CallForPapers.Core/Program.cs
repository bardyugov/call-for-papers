using CallForPapers.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseNpgsql(config["ConnectionStrings:URI"])
);

var app = builder.Build();

app.Run();
