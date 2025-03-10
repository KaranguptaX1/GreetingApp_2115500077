using BusinessLayer.Service;
using RepositoryLayer.Service;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RepositoryLayer.Context;
var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();
logger.Info("Application is starting...");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddLogging();
    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddScoped<IGreetingBL, GreetingBL>();
    builder.Services.AddScoped<IGreetingRL, GreetingRL>();
    // Connect to DataBase
    var connectionstring = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<HelloGreetingContext>(options => options.UseSqlServer(connectionstring));

    // Use Swagger for API documentation
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();
    //Karan
    // Use Swagger Middleware
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloWorld API V1");
    });

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "An unhandled exception occurred during application startup.");
    throw;
}
finally
{
    LogManager.Shutdown(); // Ensure logs are flushed and disposed
}