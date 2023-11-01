namespace PrivateStationAPI.Repositories
{
    public class StationRepository : IStationRepository
    {
        List<Station> _stations = new List<Station>();

        public StationRepository()
        {
            _stations.Add(new Station { Id = 1, Name = "Station 1" });
            _stations.Add(new Station { Id = 2, Name = "Station 2" });
            _stations.Add(new Station { Id = 3, Name = "Station 3" });
        }

        public List<Station> GetAll()
        {
            return _stations;
        }
    }
}
