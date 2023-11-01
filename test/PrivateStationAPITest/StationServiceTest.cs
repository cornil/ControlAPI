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
            _stationRepositoryMock.GetAll().Returns(new List<Station> { new Station { Id = 1, Name = "Station 1" } });
            SUT = new StationService(_stationRepositoryMock);
        }

        [Fact(DisplayName = "GetAll Should Return Stations")]
        public void GetAll_ShouldReturnStations()
        {
            // Arrange
            // Act
            var result = SUT.GetAll();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }

    }
}