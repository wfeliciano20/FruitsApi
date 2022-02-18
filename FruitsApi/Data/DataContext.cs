using Microsoft.EntityFrameworkCore;

namespace FruitsApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Fruit> Fruits { get; set; }
    }
}
