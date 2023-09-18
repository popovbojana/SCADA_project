using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaSnusProject.DbContext;
using ScadaSnusProject.Hubs;
using ScadaSnusProject.Repositories;
using ScadaSnusProject.Repositories.Interfaces;
using ScadaSnusProject.RTU;
using ScadaSnusProject.Services;
using ScadaSnusProject.Services.Interfaces;

namespace ScadaSnusProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddSingleton<AppDbContext>(provider => {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(Configuration.GetConnectionString("SqliteConnection"))
                    .Options;
                return new AppDbContext(options);
            });

            
            //Repositories
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITagRepository, TagRepository>();
            services.AddSingleton<IAlarmRepository, AlarmRepository>();

            //Services
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<IAlarmService, AlarmService>();
            services.AddSingleton<IReportService, ReportService>();
            
            //Controllers
            services.AddControllers();
            
            //RTU
            services.AddHostedService<RealTimeUnit>();
            
            //Hub
            services.AddSignalR();
            
            // Inside the ConfigureServices method of Startup.cs
            services.AddSignalR(options =>
                {
                    options.EnableDetailedErrors = true; // Enable detailed error messages (optional)
                })
                .AddHubOptions<AlarmHub>(options =>
                {
                    options.EnableDetailedErrors = true; // Enable detailed error messages for your specific hub (optional)
                });


            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AlarmHub>("/alarmHub");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");

            });
        }
    }
}