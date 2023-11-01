namespace PrivateStationAPI.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public List<Station> GetAll()
        {
            return _stationRepository.GetAll();
        }
    }
}
