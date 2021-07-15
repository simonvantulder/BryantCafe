using Microsoft.EntityFrameworkCore;

namespace BryantCornerCafe.Models
{
    public class BryantCornerCafeContext : DbContext
    {
        public BryantCornerCafeContext(DbContextOptions options) : base(options) { }

        // for every model that is part of the db
        // the names of these properties = the tables in the db
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<CSubRel> CSubRels { get; set; }
        public DbSet<SubDRel> SubDRels { get; set; }

    }
}



