using DataLayer;
using DataLayer.Domain;
using DataLayer.Models;

namespace TestProjekt
{
    public class DataLayerTest
    {
        //todo lave test til vores domains og modeler


        [Fact]
        public void TestGetMovieTitle()
        {
            var service = new MovieDataService();
            movie_titles? movie = service.GetMovieTitle("tt7856872");
            Assert.Equal("Apocalypse", movie.primarytitle);
            Assert.Equal("Drama", movie.genres);
        }

        [Fact]
        public void Testbest_match()
        {
            var service = new MovieDataService();
            var result = service.best_match("mads");
            Assert.Equal(42, result.Count);
            Assert.Equal("tt19877276", result.First().tconst);
            //result = service.best_match("world, mads");
            Assert.Equal(5906, result.Count);
            Assert.Equal("tt13243898", result.First().tconst);
        }

        //todo test funktioner og hvad de retunere
    }
}