using DataLayer.Domain;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;


namespace DataLayer
{
    public class DummyDataService : IDataService
    {
        public List<BestMatchOut> best_match(string input)
        {
            throw new NotImplementedException();
        }

        public void create_name_bookmark(string userid, string nconst)
        {
            throw new NotImplementedException();
        }

        public void create_rating(string userid, string tconst, int rating)
        {
            throw new NotImplementedException();
        }

        public void create_title_bookmark(string userid, string tconst)
        {
            throw new NotImplementedException();
        }

        public void delete_name_bookmark(string userid, string nconst)
        {
            throw new NotImplementedException();
        }

        public void delete_rating(string userid, string tconst, int rating)
        {
            throw new NotImplementedException();
        }

        public void delete_search(string userid)
        {
            throw new NotImplementedException();
        }

        public void delete_search_name(string userid)
        {
            throw new NotImplementedException();
        }

        public void delete_search_title(string userid)
        {
            throw new NotImplementedException();
        }

        public void delete_title_bookmark(string userid, string tconst)
        {
            throw new NotImplementedException();
        }

        public void delete_user(string userid)
        {
            throw new NotImplementedException();
        }

        public List<MovieActorOut> find_coplayers(string nconst)
        {
            throw new NotImplementedException();
        }

        public movie_titles GetMovieTitle(string id)
        {
            throw new NotImplementedException();
        }

        public List<LoginOut> login_user(string userid, string password)
        {
            throw new NotImplementedException();
        }

        public List<MovieActorOut> movie_actors_by_rating(string tconst)
        {
            throw new NotImplementedException();
        }

        public void movie_visited(string tconst)
        {
            throw new NotImplementedException();
        }

        public void name_rating_setter()
        {
            throw new NotImplementedException();
        }

        public void search_name(string userid, string nconst)
        {
            throw new NotImplementedException();
        }

        public void search_title(string userid, string tconst)
        {
            throw new NotImplementedException();
        }

        public void search_word(string userid, string word)
        {
            throw new NotImplementedException();
        }

        public List<MovieActorOut> similar_movies(string tconst)
        {
            throw new NotImplementedException();
        }

        public void user_signup(string userid, string password)
        {
            throw new NotImplementedException();
        }

        public void user_signup(string userid, string password, bool admin)
        {
            throw new NotImplementedException();
        }

        public List<WordOut> word_word_match(string input)
        {
            throw new NotImplementedException();
        }
    }
}
