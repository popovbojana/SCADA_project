using Microsoft.EntityFrameworkCore;
using ScadaSnusProject.DbContext;
using ScadaSnusProject.Model;
using ScadaSnusProject.Repositories.Interfaces;

namespace ScadaSnusProject
{
    public class Program
    {
        private readonly ITagRepository _tagRepository;

        public Program(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
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

                    // InsertAlarmsIntoDatabase(dbContext);
                    
                    // InsertDataIntoDatabase(dbContext);

                    // RetrieveAllDataFromDatabase(dbContext);
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
        //     var newUser = new User("name", "surname", "username", "password");
        //
        //     var newTag = new Tag
        //     {
        //         Name = "ime",
        //         Description = "opis",
        //         IOAddress = "1",
        //         Value = 12.2
        //     };
        //
        //     var newDigitalInput = new DigitalInput
        //     {
        //         Name = "ime",
        //         Description = "opis",
        //         IOAddress = "1",
        //         Value = 12.2,
        //         ScanTime = "2023-09-14T22:12:56",
        //         IsScanOn = true
        //     };
        //
        //     dbContext.Users.Add(newUser);
        //     dbContext.Tags.Add(newTag);
        //     dbContext.DigitalInputs.Add(newDigitalInput);

        /*Tag tag = _tagRepository.GetTagById(1);
        Console.WriteLine("NAMEEEEE" + tag.Name);*/
        
        /*var alarm1 = new Alarm
        {
            Value = 900.00,
            TagId = 1,
            Type = AlarmType.Higher,
            Priority = AlarmPriority.High
        };
        
        Console.WriteLine("NAMEEEEEEEEEEEEEEEEEEEEEEEE " + alarm1.Tag.Name);

        dbContext.Alarms.Add(alarm1);
        dbContext.SaveChanges();*/

        /*var alarmActivation1 = new AlarmActivation(new DateTime(2023, 9, 17, 19, 15, 24), 1);
        var alarmActivation2 = new AlarmActivation(new DateTime(2023, 9, 17, 19, 16, 24), 2);
        var alarmActivation3 = new AlarmActivation(new DateTime(2023, 9, 17, 19, 17, 24), 3);
        var alarmActivation4 = new AlarmActivation(new DateTime(2023, 9, 17, 19, 18, 24), 1);
        var alarmActivation5 = new AlarmActivation(new DateTime(2023, 9, 17, 19, 19, 24), 4);
        dbContext.AlarmActivations.Add(alarmActivation1);
        dbContext.AlarmActivations.Add(alarmActivation2);
        dbContext.AlarmActivations.Add(alarmActivation3);
        dbContext.AlarmActivations.Add(alarmActivation4);
        dbContext.AlarmActivations.Add(alarmActivation5);
        dbContext.SaveChanges();*/
        }
        //
        // private static void RetrieveAllDataFromDatabase(AppDbContext dbContext)
        // {
        //     var allUsers = dbContext.Users.ToList();
        //     Console.WriteLine("All Users in the Database:");
        //     foreach (var user in allUsers)
        //     {
        //         Console.WriteLine($"User Id: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Username: {user.Username}, Password: {user.Password}");
        //     }
        //     
        //     var allTags = dbContext.Tags.ToList();
        //     Console.WriteLine("All Tags in the Database:");
        //     foreach (var tag in allTags)
        //     {
        //         Console.WriteLine($"Tag - Id: {tag.Id}, Name: {tag.Name}, Description: {tag.Description}, IOAddress: {tag.IOAddress}, Value: {tag.Value}");
        //     }
        //     
        //     var allDigitalInputs = dbContext.DigitalInputs.ToList();
        //     Console.WriteLine("All DigitalInputs in the Database:");
        //     foreach (var digitalInput in allDigitalInputs)
        //     {
        //         Console.WriteLine($"DigitalInputs - Id: {digitalInput.Id}, Name: {digitalInput.Name}, Description: {digitalInput.Description}, IOAddress: {digitalInput.IOAddress}, Value: {digitalInput.Value}, ScanTime: {digitalInput.ScanTime}, IsOn: {digitalInput.IsScanOn}");
        //     }
        // }


        private static void InsertAlarmsIntoDatabase(AppDbContext dbContext)
        {
            var densityAlarmLowerLow = new Alarm
            {
                Value = 900.00,
                TagId = 1,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Low
            };
            
            var densityAlarmLowerMedium = new Alarm
            {
                Value = 800.00,
                TagId = 1,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Medium
            };
            
            var densityAlarmLowerHigh = new Alarm
            {
                Value = 700.00,
                TagId = 1,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.High
            };
            
            var densityAlarmHigherLow = new Alarm
            {
                Value = 1100.00,
                TagId = 1,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Low
            };
            
            var densityAlarmHigherMedium = new Alarm
            {
                Value = 1200.00,
                TagId = 1,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Medium
            };
            
            var densityAlarmHigherHigh = new Alarm
            {
                Value = 1300.00,
                TagId = 1,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.High
            };
            
            var depthAlarmLowerLow = new Alarm
            {
                Value = 20.00,
                TagId = 2,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Low
            };
            
            var depthAlarmLowerMedium = new Alarm
            {
                Value = 10.00,
                TagId = 2,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Medium
            };
            
            var depthAlarmLowerHigh = new Alarm
            {
                Value = 0.00,
                TagId = 2,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.High
            };
            
            var depthAlarmHigherLow = new Alarm
            {
                Value = 50.00,
                TagId = 2,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Low
            };
            
            var depthAlarmHigherMedium = new Alarm
            {
                Value = 60.00,
                TagId = 2,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Medium
            };
            
            var depthAlarmHigherHigh = new Alarm
            {
                Value = 70.00,
                TagId = 2,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.High
            };
            
            var temperatureAlarmLowerLow = new Alarm
            {
                Value = 0.00,
                TagId = 3,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Low
            };
            
            var temperatureAlarmLowerMedium = new Alarm
            {
                Value = -10.00,
                TagId = 3,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.Medium
            };
            
            var temperatureAlarmLowerHigh = new Alarm
            {
                Value = -20.00,
                TagId = 3,
                Type = AlarmType.Lower,
                Priority = AlarmPriority.High
            };
            
            var temperatureAlarmHigherLow = new Alarm
            {
                Value = 100.00,
                TagId = 3,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Low
            };
            
            var temperatureAlarmHigherMedium = new Alarm
            {
                Value = 110.00,
                TagId = 3,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.Medium
            };
            
            var temperatureAlarmHigherHigh = new Alarm
            {
                Value = 120.00,
                TagId = 3,
                Type = AlarmType.Higher,
                Priority = AlarmPriority.High
            };

            dbContext.Alarms.Add(densityAlarmLowerLow);
            dbContext.Alarms.Add(densityAlarmLowerMedium);
            dbContext.Alarms.Add(densityAlarmLowerHigh);
            dbContext.Alarms.Add(densityAlarmHigherLow);
            dbContext.Alarms.Add(densityAlarmHigherMedium);
            dbContext.Alarms.Add(densityAlarmHigherHigh);

            dbContext.Alarms.Add(depthAlarmLowerLow);
            dbContext.Alarms.Add(depthAlarmLowerMedium);
            dbContext.Alarms.Add(depthAlarmLowerHigh);
            dbContext.Alarms.Add(depthAlarmHigherLow);
            dbContext.Alarms.Add(depthAlarmHigherMedium);
            dbContext.Alarms.Add(depthAlarmHigherHigh);

            dbContext.Alarms.Add(temperatureAlarmLowerLow);
            dbContext.Alarms.Add(temperatureAlarmLowerMedium);
            dbContext.Alarms.Add(temperatureAlarmLowerHigh);
            dbContext.Alarms.Add(temperatureAlarmHigherLow);
            dbContext.Alarms.Add(temperatureAlarmHigherMedium);
            dbContext.Alarms.Add(temperatureAlarmHigherHigh);

            dbContext.SaveChanges();
        }

    }
    
}
