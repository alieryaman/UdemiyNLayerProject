using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UdemiyNLayerProject.API.Extension;
using UdemiyNLayerProject.API.Filters;
using UdemiyNLayerProject.Core.Repostories;
using UdemiyNLayerProject.Core.Services;
using UdemiyNLayerProject.Core.UnitOfWorks;
using UdemiyNLayerProject.Data;
using UdemiyNLayerProject.Data.Repostories;
using UdemiyNLayerProject.Data.UnitOfWorks;
using UdemiyNLayerProject.Service.Services;

namespace UdemiyNLayerProject.API
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
            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"].ToString(),o=> {


                    o.MigrationsAssembly("UdemiyNLayerProject.Data");
                
                });
            
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepostory<>), typeof(Repostory<>));
            services.AddScoped(typeof(IService<>),typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWorks>();

           
            
            services.AddControllers(o=> {

                o.Filters.Add(new ValidationFilters());
            
            
            });

            

            services.Configure<ApiBehaviorOptions>( options => 
            
            {
                options.SuppressModelStateInvalidFilter = true;
                
                
                });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomException();
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
