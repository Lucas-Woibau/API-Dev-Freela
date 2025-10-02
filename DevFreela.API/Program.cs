using DevFreela.API.ExceptionHandler;
using DevFreela.Application.Models;
using DevFreela.Application;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FreelanceTotalCostConfig>(
    builder.Configuration.GetSection("FreelancerTotalCostConfig"));

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");

builder.Services.AddDbContext<DevFreelaDbContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddApplication();

builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
