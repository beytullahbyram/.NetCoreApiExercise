using BP_Api.Extension;
using BP_Api.Models;
using BP_Api.Service;
using BP_Api.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
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

            
            builder.Services.AddControllers()
                .AddFluentValidation();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHealthChecks();
            builder.Services.AddHttpClient("garantiapi", config =>
            {
                //yukarýdaki banka apisi çaðrýldýðýnda baseadress set edilecek
                config.BaseAddress=new Uri("https://www.garanti.com");
                config.DefaultRequestHeaders.Add("Authorization","Value 123123");
            });
            //Depencedy injecktion
            builder.Services.ConfigureMapping();
            builder.Services.AddScoped<IContactService,ContactService>();
            //AddTransient => bir request içerisinde bir den fazla modelde ayný iþlem
            //yapýlýyorsa bütün hepsi için kontrol edilmesi gerekir

            builder.Services.AddTransient<IValidator<ContactDVO>,ContactValidator>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseResponseCaching();   
            app.UseCustomHealthCheck();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}