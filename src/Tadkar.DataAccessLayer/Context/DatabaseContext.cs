using Microsoft.EntityFrameworkCore;
using Tadkar.Core.Aggregates.Cities;
using Tadkar.Core.Aggregates.Personnels;
using Tadkar.Core.Aggregates.Province;

namespace Tadkar.DataAccessLayer.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        }

        public DbSet<Personnel> Personnel { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Province> Province { get; set; }
    }
}
