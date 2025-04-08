using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReimbursementApp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 23))));

builder.Services.AddControllers();

// CORS configuration for allowing requests from your Angular app
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
        builder.WithOrigins("http://localhost:4200")  // Allow Angular app's URL
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Add logging services
builder.Services.AddLogging();

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Enable static file serving (for uploads)
app.UseStaticFiles();

// Enable CORS
app.UseCors("AllowAngularApp"); // Apply CORS policy

app.UseRouting();
app.UseAuthorization();
app.MapControllers();  // Ensure this is added so that controllers are mapped

app.Run();
