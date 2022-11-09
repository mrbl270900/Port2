using DataLayer;
using DataLayer.Domain;
using DataLayer.Models;

namespace TestProjekt
{
    public class UnitTest1
    {
        [Fact]
        public void TestContext()
        {
            var service = new DataService();
            movie_titles? movie = service.GetMovieTitle("tt7856872");
            Assert.Equal("Apocalypse", movie.primarytitle);
            Assert.Equal("Drama", movie.genres);
        }
    }
}