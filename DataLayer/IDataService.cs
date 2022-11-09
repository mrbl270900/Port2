using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IDataService
    {
        movie_titles? GetMovieTitle(string id);
        List<BestMatchOut> best_match(string input);

        //todo tjek om dette skal med i pogrammet
        /*public exact_match(string input)
        public exact_match(string userid string input)*/
        List<MovieActorOut> find_coplayers(string nconst);
        List<MovieActorOut> movie_actors_by_rating(string tconst);
        List<MovieActorOut> similar_movies(string tconst);
        List<WordOut> word_word_match(string input);
        void movie_visited(string tconst);
        void name_rating_setter();
    }
}