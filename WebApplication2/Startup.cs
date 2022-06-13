using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2
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
          
            services.AddControllersWithViews();
            services.AddSwaggerGen();
            services.AddDbContext<WebApplication2Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApplication2Context")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<WebApplication2Context>();
                //context.Database.Migrate();

                if (context.Role.ToArray().Length == 0)
                {
                    Models.Role adminRole = new Models.Role() { IsAdmin = true, Bonuses = "", Range = 0 };
                    Models.Role standardRole = new Models.Role() { IsAdmin = false, Bonuses = "", Range = 0 };
                    context.Role.Add(adminRole);
                    context.Role.Add(standardRole);
                    context.SaveChanges();
                }
                if (context.FuelAvaliability.ToArray().Length == 0)
                {
                    Models.FuelAvaliability avaliability;
                    foreach (bool b1 in new bool[2] { false, true })
                        foreach (bool b2 in new bool[2] { false, true })
                            foreach (bool b3 in new bool[2] { false, true })
                                foreach (bool b4 in new bool[2] { false, true })
                                {
                                    avaliability = new Models.FuelAvaliability() { Avaliable95 = b1, Avaliable98 = b2, AvaliableDiesel = b3, AvaliableLPG = b4 };
                                    context.FuelAvaliability.Add(avaliability);
                                }

                    context.SaveChanges();
                }
            }
            // This middleware serves generated Swagger document as a JSON endpoint
            app.UseSwagger();

            // This middleware serves the Swagger documentation UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "/Home/index");
            });
        }
    }
}
