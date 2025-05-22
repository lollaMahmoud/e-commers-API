
using E_Comers_API;
using E_Comers_API.Repo.CategoreRepo;
using E_Comers_API.Repo.ProductsRepo;
using Microsoft.EntityFrameworkCore;

namespace E_commers_API
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
            builder.Services.AddDbContext<AppDbContext>(b=>b.UseSqlServer(builder.Configuration.GetConnectionString("con")));
            builder.Services.AddScoped<IProductRepo,ProductsRepo>();
            builder.Services.AddScoped<IcategoreRepo,categoreRepo>();
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
