using Microsoft.EntityFrameworkCore;
using MusicAPI.Models;

namespace MusicAPI.Data
{
    public class DataContext : DbContext
    {
        // Fields
        public DbSet<Song> Songs => Set<Song>();
        public DbSet<Artist> Artists => Set<Artist>();
        public DbSet<Genre> Genres => Set<Genre>();

        //Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // Methods

    }
}