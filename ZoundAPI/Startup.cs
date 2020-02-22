using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using ZoundAPI.Data;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Data.Repositories;
using ZoundAPI.Models.Domain;

namespace ZoundAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ZoundContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredLength = 2;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;

                o.User.RequireUniqueEmail = true;
            }
            )
                .AddEntityFrameworkStores<ZoundContext>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
                options.AddPolicy("Customer", policy => policy.RequireClaim(ClaimTypes.Role, "customer"));
            });
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddSession();
            services.AddScoped<ZoundDataInit>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IMusicRoomRepository, MusicRoomRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ZoundDataInit dataInit)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            dataInit.InitAsync();
        }
    }
}
