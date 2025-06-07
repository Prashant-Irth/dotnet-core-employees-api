using ContactBook.API.DbContexts;
using ContactBook.API.Repository;
using ContactBook.API.Services;
using ContactBook.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/contactbookapi.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Us Serilog for logging
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger generation
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddSingleton<EmployeesDataStore>();

// The connection string "Data Source=EmployeeInfo.db" tells it to use a local SQLite file named EmployeeInfo.db.
builder.Services.AddDbContext<EmployeeInfoContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:EmployeeInfoDBConnectionString"]));

builder.Services.AddScoped<IEmployeeInfoRepository, EmployeeInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Optional: Configure validation behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // These two lines are all you need for Swagger with Swashbuckle
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
