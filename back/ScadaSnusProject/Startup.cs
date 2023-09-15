using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScadaSnusProject.DbContext;
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

            services.AddDbContext<AppDbContext>(options =>
             {
                 options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"));
             });
            
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();

            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IAlarmService, AlarmService>();
            
            //Controllers
            services.AddControllers();
            
            //RTU
            services.AddHostedService<RealTimeUnit>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}