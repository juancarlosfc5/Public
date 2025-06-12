using System.Reflection;
using ApiProject.Extensions;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddCustomRateLimiter();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<PublicDBContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("ConexMySql")!;
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<PublicDBContext>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseRateLimiter();
// app.Use(async (context, next) =>
// {
//     await next();

//     if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests && !context.Response.HasStarted)
//     {
//         context.Response.ContentType = "application/json";
//         await context.Response.WriteAsync("{\"message\": \"¡Demasiadas peticiones!\"}");
//     }
// });
app.MapControllers();

app.Run();