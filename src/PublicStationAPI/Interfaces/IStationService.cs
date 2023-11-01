namespace PublicStationAPI.Interfaces
{
    public interface IStationService
    {
        Task<List<Station>> GetStationAsync();
    }
}