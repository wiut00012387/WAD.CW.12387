using Backend._12387.DAL;
using Backend._12387.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Backend._12387
{
    public class Startup
    {
        private const string DataDirectory = "|DataDirectory|";
        private string _appPath;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FootballContext>(o => o.UseSqlServer(Configuration.GetConnectionString
            ("FootballDb").Replace(DataDirectory, _appPath)));
            services.AddControllers();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<ILeagueTableRepository, LeagueTableRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _appPath = Path.Combine(env.ContentRootPath, "AppData");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
