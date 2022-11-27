
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog;
using HelpHomeApi;
using HelpHomeApi.Middleware;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using HelpHome.Entities;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();

    builder.Services.AddControllers();
    builder.Services.AddDbContext<Data.HelpHomeDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddScoped<IOfferentServices, OfferentServices>();
    builder.Services.AddScoped<ISeekerServices, SeekerServices>();
    builder.Services.AddScoped<ICarpetWashingServices, CarpetWashingServices>();
    builder.Services.AddScoped<ICleaningServices, CleaningServices>();
    builder.Services.AddScoped<IWindowsCleaningServices, WindowsCleaningServices>();
    builder.Services.AddScoped<IAccountServices, AccountServices>();
    builder.Services.AddSingleton<ILog, Log>();
    builder.Services.AddScoped<ErrorHandlingMiddleware>();
    builder.Services.AddScoped<IPasswordHasher<Seeker>, PasswordHasher<Seeker>>();
    builder.Services.AddScoped<IPasswordHasher<Offerent>, PasswordHasher<Offerent>>();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpHome Api");
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
}
catch (Exception exception)
{
    
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    
    LogManager.Shutdown();
}
