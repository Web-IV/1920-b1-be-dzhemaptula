using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZoundAPI.Data;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Data.Repositories;

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
            services.AddControllers();
            services.AddSession();
            services.AddMemoryCache();

            services.AddScoped<ZoundDataInit>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IMusicRoomService, MusicRoomService>();
            services.AddScoped<IUserFriendService, UserFriendService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
