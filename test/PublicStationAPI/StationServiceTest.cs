using PublicStationAPI.Entities;
using PublicStationAPI.Services;

namespace PublicStationAPI
{
    public class StationServiceTest
    {
        private StationService SUT;

        public StationServiceTest()
        {
            SUT = new StationService(new HttpClient());
        }

        [Fact]
        public async Task GetStationAsync_WhenCalled_ReturnsStation()
        {
            var result = await SUT.GetStationAsync();
            Assert.IsType<Station>(result);
        }
    }
}