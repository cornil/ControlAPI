using Microsoft.EntityFrameworkCore;

namespace PrivateStationAPI
{
    public class StationContext : DbContext
    {
        public StationContext(DbContextOptions<StationContext> options)
            : base(options)
        {
        }

        public DbSet<StationDAO> Stations { get; set; }
    }
}
