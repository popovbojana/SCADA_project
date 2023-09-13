using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.Migrate();

    var newUser = new User
    {
        Name = "John",
        Surname = "Doe",
        Username = "johndoe",
        Password = "password123" 
    };

    dbContext.Users.Add(newUser);
    dbContext.SaveChanges();

    var users = dbContext.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Username: {user.Username}, Password: {user.Password}");
    }
}

