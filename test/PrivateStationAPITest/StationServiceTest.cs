using PrivateStationAPI.Interfaces;
using PrivateStationAPI.Services;
using NSubstitute;
using PrivateStationAPI.Entities;

namespace PrivateStationAPITest
{
    public class StationServiceTest
    {
        private StationService SUT;
        
        // mock station repository
        private IStationRepository _stationRepositoryMock = Substitute.For<IStationRepository>();

        public StationServiceTest()
        {
            _stationRepositoryMock.GetAllStationsAsync().Returns(new List<StationDAO> { new StationDAO { id = 1, nom_station = "Station 1" } });
            SUT = new StationService(_stationRepositoryMock);
        }

        [Fact(DisplayName = "GetAll Should Return Stations")]
        public async void GetAll_ShouldReturnStations()
        {
            // Arrange
            // Act
            var result = await SUT.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
        }

        // test MapStationDAOToDTO
        // StationDAO.gratuit can have values 'TRUE', 'false', 'FALSE', 'true', nan, 'False', '1', '0', 'True'
        [Theory(DisplayName = "MapStationDAOToDTO Should Return StationDTO")]
        [InlineData("TRUE", true)]
        [InlineData("True", true)]
        [InlineData("true", true)]
        [InlineData("1", true)]
        [InlineData("FALSE", false)]
        [InlineData("False", false)]
        [InlineData("false", false)]
        [InlineData("0", false)]
        [InlineData("nan", false)]
        public void MapStationDAOToDTO_ShouldReturnStationDTO(string gratuit, bool expected)
        {
            // Arrange
            var stationDAO = new StationDAO
            {
                id = 1,
                nom_station = "Station 1",
                gratuit = gratuit
            };
            // Act
            var result = SUT.MapStationDAOToDTO(stationDAO);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.Free);
        }

    }
}