using BikeStores.API.Infrastructure.Configuration;
using BikeStores.API.Middleware;
using BikeStores.Domain.Response;
using BikeStores.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;

namespace BikeStores.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddUserData();
            builder.Services.AddServices();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddValidatorsFromAssembly(typeof(BikeStores.Services.AssemblyReference).Assembly);
            builder.Services.AddFluentValidationAutoValidation();
            builder.Configuration
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            builder.Services.AddControllers(options => 
                {
                    options.SuppressAsyncSuffixInActionNames = true;
                })
                .AddApplicationPart(typeof(BikeStores.Presentation.AssemblyReference).Assembly)
                .AddMvcOptions(config =>
                {
                    config.OutputFormatters.Clear();
                    config.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new System.Text.Json.JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
                    }));
                })
                .ConfigureApiBehaviorOptions(options=>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var firstError = context.ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .First();
                        return new BadRequestObjectResult(new ErrorResponse() { Error = firstError });
                    };
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BikeStores API", Version = "v1" });
                c.EnableAnnotations();
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BikeStores.Contracts.xml"), true);
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "BikeStores.Presentation.xml"), true);
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.RegisterMapsterConfiguration();
            builder.Services.AddTransient<ExceptionHandlingMiddleware>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var db = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
                    //db.Database.EnsureCreated();
                    db.Database.Migrate();
                } 
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"{ex.Message}\n{ex.StackTrace}");
                    Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
                }
            }

            app.UseSwagger();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1");
                    c.DefaultModelsExpandDepth(0);
                    c.DefaultModelExpandDepth(1);
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                });
            } 
            else
            {
                app.UseReDoc(c =>
                {
                    c.DocumentTitle = "BikeStores API";
                    c.SpecUrl = "/swagger/v1/swagger.json";
                    c.RoutePrefix = "docs";
                });
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            //app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}