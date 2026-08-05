using BaseProject.Api.EndPoints;
using BaseProject.Application;
using BaseProject.Domain.Options;
using BaseProject.Infrastructure.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionStringsOptions>(builder.Configuration.GetSection(ConnectionStringsOptions.SectionName));

builder.Services.AddControllers();
builder.Services.AddApplicationRepository();
builder.Services.AddInfrastructureRepository();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapMasterEndPoints();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
