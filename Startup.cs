using Microsoft.EntityFrameworkCore;

using Sduig9suidng.Models;
using Sduig9suidng.Models.Crud;


namespace Sduig9suidng
{
    public class Startup
    {
        public string databaseEndPoint { get; set; } = @"Host=127.0.0.1;
                                                        Port=5432;
                                                        Database=default;
                                                        Username=default;
                                                        Password=default";

        public void ConfigureServices(IServiceCollection services)
        {
            databaseEndPoint = Environment
                                .GetEnvironmentVariable("POSTGRES_ENDPOINT");
            
            services.AddDbContext<_DbContext>(options =>
                options.UseNpgsql(
                    connectionString: databaseEndPoint
                )
            );

            services.AddScoped<IPet, PetRepo>();

            services.AddMvc();
            services.AddControllersWithViews(mvcOtions=>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
        }
 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseRouting();
            app.UseMvc();
        }
    }
}