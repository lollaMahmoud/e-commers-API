using E_Comers_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Comers_API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categorie> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
