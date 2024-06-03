using Gov_ListedCompany_API.Dao;
using Gov_ListedCompany_API.Dao.Interface;
using Gov_ListedCompany_API.Service;
using Gov_ListedCompany_API.Service.Interface;
using Microsoft.AspNetCore.Hosting;

namespace Gov_ListedCompany_API
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
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            #region Service
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            #endregion

            #region Dao
            builder.Services.AddScoped<ICompanyDao, CompanyDao>();
            #endregion

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin() 
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("AllowAnyOrigin");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
