using Microsoft.EntityFrameworkCore;

namespace MusicAPI.Data
{
    public class DataContext : DbContext
    {
        // Fields


        //Constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        // Methods

    }
}