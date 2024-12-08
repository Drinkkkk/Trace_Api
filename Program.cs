using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trace_Api.Context;
using Trace_Api.IService;
using Trace_Api.Mapper;
using Trace_Api.Model;
using Trace_Api.Repository;
using Trace_Api.Service;
using Trace_Api.UnitOfWork;

namespace Trace_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<TraceContext>(options=>
            {
                //option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")
                var connect= builder.Configuration.GetConnectionString("SqlServer");
                options.UseSqlServer(connect);
            
            }).AddUnitOfWork<TraceContext>()
            .AddCustomRepository<User,UserRepository>()
            .AddCustomRepository<Truck,TruckRepository>()
            .AddCustomRepository<Trip,TripRepository>()
            .AddCustomRepository<Coordinate,CoordinateRepository>();

          
            builder.Services.AddTransient<IUserService, UserService>();

            //Ìí¼ÓAutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TraceProfile());
            });

            builder.Services.AddSingleton(config.CreateMapper());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
