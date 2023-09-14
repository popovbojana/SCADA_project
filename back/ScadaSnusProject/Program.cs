using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;
using System;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
var configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Database seeding and initialization
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply pending migrations
    dbContext.Database.Migrate();

    // Seed data if the Users and Tags tables are empty
    if (!dbContext.Users.Any())
    {
        dbContext.Users.Add(new User
        {
            Name = "John",
            Surname = "Doe",
            Username = "johndoe",
            Password = "password123"
        });

        dbContext.SaveChanges();
    }

    

    /*
    if (!dbContext.Alarms.Any())
    {
        dbContext.Alarms.Add(new Alarm
        {
            Value = 10.00,
            TagId = 1,
            Type = 0,
            Priority = 0,
            IsActive = true
        });

        dbContext.SaveChanges();
    }*/

    // Display user and tag information
    var users = dbContext.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"User - Id: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Username: {user.Username}");
    }

    /*var alarms = dbContext.Alarms.ToList();
    foreach (var alarm in alarms)
    {
        Console.WriteLine($"Alarm - Id: {alarm.Id}, Value: {alarm.Value}, Type: {alarm.Type}, Priority: {alarm.Priority}, IsActive: {alarm.IsActive}");
    }*/
}

app.Run();
