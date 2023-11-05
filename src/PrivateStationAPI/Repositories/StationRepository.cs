using Microsoft.EntityFrameworkCore;

namespace PrivateStationAPI.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly StationContext _context;

        public StationRepository(StationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StationDAO>> GetAllStationsAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Stations.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<StationDAO> GetStationByIdAsync(int id)
        {
            return await _context.Stations.FindAsync(id);
        }

        public async Task AddStationAsync(StationDAO station)
        {
            await _context.Stations.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStationAsync(StationDAO station)
        {
            _context.Entry(station).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStationAsync(int id)
        {
            var station = await _context.Stations.FindAsync(id);
            _context.Stations.Remove(station);
            await _context.SaveChangesAsync();
        }
    }
}
