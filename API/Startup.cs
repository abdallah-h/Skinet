using API.Extensions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API {
    public class Startup {
        private readonly IConfiguration _configuration;

        public Startup (IConfiguration configuration) {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            services.AddControllers ();
            services.AddAutoMapper (typeof (MappingProfiles));
            // configure database context as a service
            services.AddDbContext<StoreContext> (x =>
                x.UseSqlite (_configuration.GetConnectionString ("DefaultConnection"))
            );

            services.AddApplicationServices ();
            services.AddSwaggerDocumentation ();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            // handle Exception using ExceptionMiddleware class
            app.UseMiddleware<ExceptionMiddleware> ();

            app.UseStatusCodePagesWithReExecute ("/errors/{0}");

            app.UseHttpsRedirection ();

            // Connect with the controller 
            app.UseRouting ();

            app.UseStaticFiles ();

            app.UseAuthorization ();

            app.UseSwaggerDocumentation ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}