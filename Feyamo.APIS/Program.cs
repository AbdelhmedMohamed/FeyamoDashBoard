
using DashBoard.PL.Helpers;
using Feyamo.APIS.Errors;
using Feyamo.APIS.Helpers;
using Feyamo.APIS.MiddleWare;
using Feyamo.BLL.ApiRepositories;
using Feyamo.BLL.Interfacies;
using Feyamo.BLL.Repositories;
using Feyamo.DAL.Data;
using Feyamo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Feyamo.APIS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DI
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

           

            builder.Services.AddAutoMapper(typeof(MappingProfileDto));

            builder.Services.AddScoped(typeof(IGenericRepoAPI<>),typeof(GenericRepoAPI<>));

            builder.Services.AddScoped(typeof(IReservationHotelRepoAPI),typeof(ReservationHotelRepoAPI));

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                         .Select(E => E.ErrorMessage)
                                                         .ToList();

                    var response = new ApiValidationErrorRespons()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });




            var app = builder.Build();

            //Ask CLR Explcitly For Creating object from AppDbContext
            
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _dbcontext =services.GetRequiredService<AppDbContext>();


            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbcontext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occrred duiring migartion");
            }

            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseStatusCodePagesWithReExecute("/Errors/{0}");


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
