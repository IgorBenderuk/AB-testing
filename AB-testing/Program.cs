
using AB_testing.Data;
using AB_testing.Repos;
using AB_testing.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_testing
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

            
            // injecting the automapper for mapping purpuse
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //injecting the interfaces and their implementation
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            //injecting db context
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            //ensuring creating database
            /*using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetService<AppDbContext>();
              //  context.Database.EnsureDeleted();
            }*/

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
