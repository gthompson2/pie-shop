using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        //DbContext has been registered with the services collection; can get access to it via dependency injection
        private readonly PieShopDbContext _pieShopDbContext;

        // Constructor injection
        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }

        // Implement the methods of our IPieRepository interface
        public IEnumerable<Pie> AllPies
        {
            get
            {
                // Launches a query asking for all records in the pies table. Include info about the category.
                // .Include is essentially a left join using the foreign key related to c.Category (Eager Loading)

                // SELECT TOP [c].[*]
                //      FROM [Pies] AS [c]
                //      LEFT JOIN [Categories] AS [c.Category] ON [c].[CategoryId] = [c.Category].[CategoryId]
                return _pieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId) 
        {
            return _pieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
