using DataLayer;
using DataLayer.Domain;
using DataLayer.Models;

namespace TestProjekt
{
    public class DataLayerTest
    {
        //todo lave test til vores domains og modeler

        //herunder tester vi vores classes movie title samt person og ser på at de vigtigste værdier opføre sig som de skal
        [Fact]
        public void TestMovie_titleClass()
        {
            movie_titles movie = new movie_titles();
            Assert.Null(movie.tconst);
            Assert.Null(movie.primarytitle);
            Assert.Null(movie.title);
        }

        [Fact]
        public void TestPersonClass()
        {
            person person = new person();
            Assert.Null(person.nconst);
            Assert.Null(person.primaryname);
            Assert.Null(person.birthyear);
        }


        [Fact]
        public void TestGetMovieTitle()
        {
            var service = new MovieDataService();
            movie_title? movie = service.GetMovieTitle("tt7856872");
            Assert.Equal("Apocalypse", movie.primarytitle);
            Assert.Equal("Drama", movie.genres);
        }

        [Fact]
        public void Testbest_match()
        {
            var service = new MovieDataService();
            List<string> input = new List<string>();
            input.Add("mads");
            var result = service.best_match(input);
            Assert.Equal(42, result.Count);
            Assert.Equal("tt19877276", result.First().tconst);
            input.Add("world");
            result = service.best_match(input);
            Assert.Equal(5906, result.Count);
            Assert.Equal("tt13243898", result.First().tconst);
        }

        [Fact]
        public void Testword_word_match()
        {
            var service = new MovieDataService();
            List<string> input = new List<string>();
            input.Add("mads");
            var result = service.word_word_match(input);
            Assert.Equal(1623, result.Count);
            Assert.Equal(49, result.First().weight);
            input.Add("world");
            result = service.word_word_match(input);
            Assert.Equal(65016, result.Count);
            Assert.Equal(6030, result.First().weight);
        }
    }
}