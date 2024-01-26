using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Contract_interfaces;
using RepositoryLayer.Implementation;
using System.Collections.Generic;


namespace WaterFatoura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AppDbContext>(con => con.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<I_DSValuesRepository,DSValuesRepository>();
            //builder.Services.AddScoped<I_InvoicesRepository,InvoicesRepository>();
            builder.Services.AddScoped<I_RE_TypesRepository,RE_TypesRepository>();
            builder.Services.AddScoped<I_SubscriberRepository,SubscriberRepository>();
            //builder.Services.AddScoped<I_SubscriptionRepository,SubscriptionRepository>();
            builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WaterFatoura Api v1");
            });

            app.UseCors(builder =>
            {

                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.MapControllers();

            app.Run();


        }
    }
}