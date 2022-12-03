
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog;
using HelpHomeApi;
using HelpHomeApi.Middleware;
using Data.Services;
using Microsoft.AspNetCore.Identity;
using HelpHome.Entities;
using FluentValidation;
using Domain.Models;
using Data.Validators;
using FluentValidation.AspNetCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);
    var authenticationSettings = new AuthenticationSettings();

    builder.Host.UseNLog();
    ConfigurationManager configuration = builder.Configuration;
    configuration.GetSection("Authentication").Bind(authenticationSettings);

    builder.Services.AddControllers().AddFluentValidation();
    builder.Services.AddDbContext<Data.HelpHomeDbContext>(
        option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
        );
    builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = "Bearer";
        option.DefaultScheme = "Bearer";
        option.DefaultChallengeScheme = "Bearer";
    })
        .AddJwtBearer(option =>
        {
            option.RequireHttpsMetadata = false;
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
            };

        });
    builder.Services.AddSingleton(authenticationSettings);
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
    builder.Services.AddScoped<IValidator<RegisterSeekerDto>, RegisterSeekerDtoValidator>();
    builder.Services.AddScoped<IValidator<RegisterOfferentDto>, RegisterOfferentDtoValidator>();
    builder.Services.AddSwaggerGen();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseAuthentication();
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
