using BackgroundService;
using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ISeparateNotification, SeparateNotificationService>();
builder.Services.AddTransient(typeof(IGenericService<EmailNotification>), typeof(EmailNotificationService));
builder.Services.AddTransient(typeof(IGenericService<PdfNotification>), typeof(PdfNotificationService));
builder.Services.AddTransient(typeof(IGenericService<SMSNotification>), typeof(SmsNotificationService));
builder.Services.AddScoped<IGenerateNotification, GenerateNotificationService>();
builder.Services.AddTransient<JobFactory>();
builder.Services.AddScoped<DataJob>();
builder.Services.AddScoped<IFilesCollector, FilesCollector>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
});
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        DataScheduler.Start(serviceProvider);
    }
    catch (Exception)
    {
        throw;
    }
}

app.MapGet("/", () => "Hello World!");

app.Run();
