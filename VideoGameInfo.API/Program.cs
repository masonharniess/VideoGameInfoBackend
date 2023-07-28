using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using VideoGameInfo.API.DbContexts;
using VideoGameInfo.API.Services;

namespace VideoGameInfo.API {

    public class Program {

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson().AddXmlSerializerFormatters();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<VideoGameInfoContext>(DbContextOptions => DbContextOptions.UseSqlite(
                builder.Configuration["ConnectionStrings:VideoGameInfoDBConnectionString"]));
            builder.Services.AddScoped<IDeveloperInfoRepository, DeveloperInfoRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}