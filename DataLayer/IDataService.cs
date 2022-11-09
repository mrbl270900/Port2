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
        void create_name_bookmark(string userid, string nconst);
        void create_rating(string userid, string tconst, int rating);
        void create_title_bookmark(string userid, string tconst);
        void delete_name_bookmark(string userid, string nconst);
        void delete_rating(string userid, string tconst, int rating);
        void delete_search(string userid);
        void delete_search_name(string userid);
        void delete_search_title(string userid);
        void delete_title_bookmark(string userid, string tconst);
        void delete_user(string userid);
        //todo tjek om dette skal med i pogrammet
        /*public exact_match(string input)
        public exact_match(string userid string input)*/
        List<MovieActorOut> find_coplayers(string nconst);
        List<LoginOut> login_user(string userid, string password);
        List<MovieActorOut> movie_actors_by_rating(string tconst);
        void movie_visited(string tconst);
        void name_rating_setter();
        void search_name(string userid, string nconst);
        void search_title(string userid, string tconst);
        void search_word(string userid, string word);
        List<MovieActorOut> similar_movies(string tconst);
        void user_signup(string userid, string password);
        void user_signup(string userid, string password, bool admin);
        List<WordOut> word_word_match(string input);
    }
}