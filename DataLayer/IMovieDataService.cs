using DataLayer.Domain;
using DataLayer.Models;

namespace DataLayer
{
    public interface IMovieDataService
    {
        List<person> GetPersonList();
        List<person> GetPersonList(int page, int pagesize);
        List<movie_title> GetMovieTitleList();
        List<movie_title> GetMovieTitleList(int page, int pagesize);
        movie_title? GetMovieTitle(string id);
        List<BestMatchOut> best_match(List<string> input);

        //todo tjek om dette skal med i pogrammet
        /*public exact_match(string input)
        public exact_match(string userid string input)*/
        List<CoPlayersOut> find_coplayers(string nconst);
        List<MovieActorOut> movie_actors_by_rating(string tconst);
        List<MovieActorOut> similar_movies(string tconst);
        List<WordOut> word_word_match(List<string> input);
        void movie_visited(string tconst);
        void name_rating_setter();
        person? GetPerson(string id);
    }
}