using BlazorServerCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<Person> Persons { get; set; }
    }

    
}
