namespace PrivateStationAPI.Interfaces
{
    public interface IStationRepository
    {
        Task<IEnumerable<StationDAO>> GetAllStationsAsync(int pageNumber = 1, int pageSize = 20);
    }
}