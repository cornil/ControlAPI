namespace PublicStationAPI.Interfaces
{
    public interface IStationService
    {
        Task<List<StationDTO>> GetStationAsync();
    }
}