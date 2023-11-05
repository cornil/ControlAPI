

namespace PrivateStationAPI.Interfaces
{
    public interface IStationService
    {
        Task<IEnumerable<StationDTO>> GetAll();
    }
}