using Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;
using Repository.Contracts;
using Repository.Repositories;
using Service.Contracts;
using Service.Services;

namespace CurupiraCarAPI
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
            services.AddDbContext<MySqlContext>(
                options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            // Adiciona as DIs
            services.AddSingleton(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IApoliceSeguroService,ApoliceSeguroService>();
            services.AddScoped<IApoliceSeguroRepository, ApoliceSeguroRepository>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MySqlContext>();
                context.Database.EnsureCreated();
            }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
