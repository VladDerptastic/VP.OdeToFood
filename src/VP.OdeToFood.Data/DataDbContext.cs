using Microsoft.EntityFrameworkCore;
using VP.OdeToFood.Definition;

namespace VP.OdeToFood.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
