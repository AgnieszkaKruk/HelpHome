
using Data.Services;
using Domain.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//klasa ze wsp�lnymi warto�ciami, s�ownik ze wszystkimi dodatkowymi w�a�ciwo�ciami ???
// s�ownik ze jesli mam do czynienia z kategori� X to mog� tylko to i to..

builder.Services.AddControllers();
builder.Services.AddDbContext<Data.HelpHomeDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("HelpHomeConnectionString"))
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IOfferentServices, OfferentServices>();
builder.Services.AddScoped<ISeekerServices, SeekerServices>();
builder.Services.AddScoped<ICarpetWashingServices, CarpetWashingServices>();
builder.Services.AddScoped<ICleaningServices, CleaningServices>(); 
builder.Services.AddScoped<IWindowsCleaningServices, WindowsCleaningServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
