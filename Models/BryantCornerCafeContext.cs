using Microsoft.EntityFrameworkCore;

namespace BryantCornerCafe.Models
{
    public class BryantCornerCafeContext : DbContext
    {
        public BryantCornerCafeContext(DbContextOptions options) : base(options) { }

        // for every model that is part of the db
        // the names of these properties = the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<UDRel> UDRels { get; set; }

    }
}



