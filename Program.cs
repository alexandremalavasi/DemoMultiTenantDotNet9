using DemoMultiTenantDotNet9.Infrastructure;
using DemoMultiTenantDotNet9.Logic;
using DemoMultiTenantDotNet9.Middlewares;
using Microsoft.EntityFrameworkCore;


namespace DemoMultiTenantDotNet9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Database configuration
            builder.Services.AddScoped<IDbContextConnectionStringProvider, DbContextConnectionStringProvider>();
            builder.Services.AddDbContext<SystemContext>((serviceProvider, options) =>
            {
                var connectionStringProvider = serviceProvider.GetRequiredService<IDbContextConnectionStringProvider>();
                options.UseSqlServer(connectionStringProvider.ConnectionString);
            });

            builder.Services.AddScoped<CategoryLogic>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.UseMiddleware<TenantMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
