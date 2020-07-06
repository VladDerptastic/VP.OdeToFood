using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using VP.OdeToFood.Data;

namespace VP.OdeToFood
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
            services.AddRazorPages();
            //register controllers if you want to use them (VP: .NET Core 3.0+ thing)
            services.AddControllers();
            //register dependency injection
            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            //AddScoped => An instance per HTTP request (as per instruction), allows the DbContext to reconsile its changes on every request
            services.AddScoped<IRestaurantData, SqlServerRetaurantData>(); 

            //register Db context
            services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
                //register db provider
                options.UseSqlServer(Configuration.GetConnectionString("LocalDb"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.Use(SayHelloMiddleware);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                //register controllers if you want to use them (VP: .NET Core 3.0+ thing)
                endpoints.MapControllers();
            });
        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate arg)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/middleware"))
                {
                    await ctx.Response.WriteAsync("Hello personal middleware!");
                }
                else
                {
                    //else pass the request allong the pipeline
                    await arg(ctx);
                }
            };
        }
    }
}
