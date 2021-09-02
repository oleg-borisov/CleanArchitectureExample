using Equipment.ApplicationServices.Implementation;
using Equipment.ApplicationServices.Interfaces;
using Equipment.DataAccess.Implementation.MSSQL;
using Equipment.DataAccess.Interfaces;
using Equipment.UseCases.Buildings.Commands.CreateBuilding;
using Equipment.UseCases.Buildings.Utils;
using Equipment.UseCases.Utils.Behaviours;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApplication.Middleware;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace WebApplication
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
            // Domain
            services.AddScoped<IEquipmentExistenceIndicatorApplicationService, EquipmentExistenceIndicatorApplicationService>();

            // Infrastructure
            services.AddDbContext<IDBContext, ApplicationDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Database")));


            // Frameworks
            services.AddControllers();
            services.AddAutoMapper(typeof(BuildingMapperProfile));
            services.AddMediatR(typeof(CreateBuildingCommandHandler));
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CreateBuildingCommandHandler>());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));

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
