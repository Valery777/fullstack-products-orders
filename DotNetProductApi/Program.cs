using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using DotNetProductApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------- Logging ----------
builder.Host.UseSerilog((ctx, lc) =>
    lc.ReadFrom.Configuration(ctx.Configuration));

// ---------- Database For PostgreSQL----------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------- Database For SQL Server----------
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------- CORS ----------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")   // React dev server
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
    });
}

// ---------- Use CORS ----------
app.UseCors("AllowFrontend");

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

app.Run();
