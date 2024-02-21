using MatchManagementApiDemo.Converters;
using MatchManagementApiDemo.Data;
using MatchManagementApiDemo.Interfaces.BaseService;
using MatchManagementApiDemo.Interfaces.Services;
using MatchManagementApiDemo.Mappings;
using MatchManagementApiDemo.Services;
using MatchManagementApiDemo.Services.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace MatchManagementApiDemo
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
            services.AddControllers()
                                    .AddJsonOptions(options =>
                                    {
                                        options.JsonSerializerOptions.Converters.Add(new TimeSpanConverter());
                                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                                    });
            services.AddDbContext<ApplicationDbContext>(options =>
                                                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Match Management Api Demo", Version = "v1" });
            });
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMatchOddsService, MatchOddsService>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Match Management Api Demo V1");
                // Customize Swagger UI settings if needed
            });

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
