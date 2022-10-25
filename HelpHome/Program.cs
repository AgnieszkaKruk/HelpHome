using HelpHome.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HelpHomeDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("HelpHomeConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
