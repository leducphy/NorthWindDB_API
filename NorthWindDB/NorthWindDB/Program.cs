using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using NorthWindDB.Formatter;
using NorthWindDB.Mapper;
using NorthWindDB.Models;

namespace NorthWindDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers(options =>
                {
                    //options.OutputFormatters.Add(new CsvOutputFormatter());
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                    //options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
                    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                    options.InputFormatters.Add(new CsvInputFormatter());
                }
            ).AddOData(
                opt => opt.Select() 
                    .Filter()
                    .OrderBy()
                    .SetMaxTop(20)
                    .Count()
                    .Expand()
            );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<NorthWindContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(policy =>
            {
                policy.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}