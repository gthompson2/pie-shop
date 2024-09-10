using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieShopDbContext: DbContext
    {
        //bringing in a constructor
        public PieShopDbContext(DbContextOptions<PieShopDbContext> options) : base(options) 
        { 
            // expose the pie and category entities inside the DbContext as a DbSet - will be mapped to Db tables later on

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }    

    }
}
