using System.Globalization;

namespace PrivateStationAPI.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<IEnumerable<StationDTO>> GetAll()
        {
            var dbStation = await _stationRepository.GetAllStationsAsync();
            var station = dbStation.Select(MapStationDAOToDTO);
            return station;
        }

        public StationDTO MapStationDAOToDTO(StationDAO stationDAO)
        {
            var stationDTO = new StationDTO
            {
                Id = stationDAO.id.Value,
                Name = stationDAO.nom_station ?? "",
                Description = stationDAO.implantation_station ?? "",
                Address = stationDAO.adresse_station ?? "",
                City = stationDAO.consolidated_commune ?? "",
                Power = stationDAO.puissance_nominale ?? 0,
                Free = stationDAO.gratuit?.ToUpper() == "TRUE" || stationDAO.gratuit == "1",
                AccessCondition = stationDAO.condition_acces ?? "",
                OpeningHours = stationDAO.horaires ?? ""
            };

            return stationDTO;
        }
    }
}
