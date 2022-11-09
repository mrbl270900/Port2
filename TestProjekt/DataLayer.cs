using DataLayer;
using DataLayer.Domain;
using DataLayer.Models;

namespace TestProjekt
{
    public class DataLayer
    {
        [Fact]
        public void TestContext()
        {
            var service = new MovieDataService();
            movie_titles? movie = service.GetMovieTitle("tt7856872");
            Assert.Equal("Apocalypse", movie.primarytitle);
            Assert.Equal("Drama", movie.genres);
        }
    }
}