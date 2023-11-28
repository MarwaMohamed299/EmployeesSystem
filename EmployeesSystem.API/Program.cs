
using EmployeeSystem.BL.Managers;
using EmployeeSystem.DAL.Data.Context;
using EmployeeSystem.DAL.Repos;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region ConnecteionString
            var ConnectionString = builder.Configuration.GetConnectionString("EmployeeConnectionString"); /* ConnectionString in appSettings.Json*/
            builder.Services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(ConnectionString));

            #endregion

            #region DefaultServices
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region CORS Policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllDomains", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            #endregion

            #region Employee Services
            builder.Services.AddScoped<IEmployeesRepo, EmployeesRepo>();
            builder.Services.AddScoped<IEmployeesManager, EmployeesManager>();


            #endregion

            var app = builder.Build();


           #region MiddleWares
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion
            app.Run();
        }
    }
}