using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;


using ProjectDicksonBackEnd.Repository;

namespace ProjectDicksonBackEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.secure.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services
                .Configure<SqlConnectionModel>(Configuration.GetSection("SqlConnection"))
                .AddTransient(cfg => cfg.GetService<IOptions<SqlConnectionModel>>().Value);

            services.AddTransient<IBarQueries, BarQueries>();
            services.AddTransient<IDrinkQueries, DrinkQueries>();
            services.AddTransient<IPriceQueries, PriceQueries>();
            services.AddTransient<IConnectionString, ConnectionString>();
            services.AddTransient<ISpecialQueries, SpecialQueries>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
