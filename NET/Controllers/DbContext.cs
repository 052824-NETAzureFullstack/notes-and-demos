using Microsoft.EntityFrameworkCore;
using Controllers.Models;

namespace Controllers.Data
{
    public class DataContext : DbContext
    {
        // Fields
        public DbSet<Pet> Pets => Set<Pet>();

        // Constructors
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}