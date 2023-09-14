using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaSnusProject.DbContext;
using System;
using System.Linq;
using ScadaSnusProject.Model;

namespace ScadaSnusProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<AppDbContext>();
                
                try
                {
                    dbContext.Database.Migrate();

                    InsertDataIntoDatabase(dbContext);

                    RetrieveAllDataFromDatabase(dbContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while migrating the database or performing data operations.");
                    Console.WriteLine(ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void InsertDataIntoDatabase(AppDbContext dbContext)
        {
            var newUser = new User
            {
                Name = "Name",
                Surname = "Surname",
                Username = "Username",
                Password = "Password"
            };
            
            var newTag = new Tag
            {
                Name = "ime",
                Description = "opis",
                IOAddress = "1",
                Value = 12.2
            };

            var newDigitalInput = new DigitalInput
            {
                Name = "ime",
                Description = "opis",
                IOAddress = "1",
                Value = 12.2,
                ScanTime = "1.5.2001",
                IsScanOn = true
            };

            dbContext.Users.Add(newUser); // Add the new entity to the DbSet
            dbContext.Tags.Add(newTag);
            dbContext.DigitalInputs.Add(newDigitalInput);
            dbContext.SaveChanges(); // Save changes to the database
        }

        private static void RetrieveAllDataFromDatabase(AppDbContext dbContext)
        {
            var allUsers = dbContext.Users.ToList();
            Console.WriteLine("All Users in the Database:");
            foreach (var user in allUsers)
            {
                Console.WriteLine($"User Id: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Username: {user.Username}, Password: {user.Password}");
            }
            
            var allTags = dbContext.Tags.ToList();
            Console.WriteLine("All Tags in the Database:");
            foreach (var tag in allTags)
            {
                Console.WriteLine($"Tag - Id: {tag.Id}, Name: {tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}");
            }
            
            var allDigitalInputs = dbContext.DigitalInputs.ToList();
            Console.WriteLine("All DigitalInputs in the Database:");
            foreach (var digitalInput in allDigitalInputs)
            {
                Console.WriteLine($"DigitalInputs - Id: {digitalInput.Id}, Name: {digitalInput.Name}, Description: {digitalInput.Description}, IOAddress: {digitalInput.IOAddress}, Value: {digitalInput.Value}, ScanTime: {digitalInput.ScanTime}, IsOn: {digitalInput.IsScanOn}");
            }
        }
    }
}
