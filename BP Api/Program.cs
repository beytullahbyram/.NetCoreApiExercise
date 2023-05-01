using BP_Api.Extension;
using BP_Api.Service;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BP_Api
{
    public class Program
    {
        private static IConfiguration Configuration
        {
            get
            {
            String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")??"Production";

                return new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            //Depencedy injecktion
            builder.Services.ConfigureMapping();
            builder.Services.AddScoped<IContactService,ContactService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

             
            app.UseCustomHealthCheck();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}