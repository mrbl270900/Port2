using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataService : IDataService
    {
        public IMDBContext db = new IMDBContext();

        public GetMovieTitle(string id)
        {
            movie_titles movie = db.movie_titles.FirstOrDefault(x => x.Id == id);
        }

        public List<BestMatchOut> best_match(string input)
        {
            var result = db.bestmatchouts.FromSqlInterpolated($"select * best_match({input})");
            return result.ToList;
        }

        public create_name_bookmark(string userid string nconst)
        {
            db.Database.ExecuteSqlInterpolated($"select create_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public create_rating(string userid string tconst int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select create_rating({userid},{tconst},{rating})");
            db.SaveChanges();
        }

        public create_title_bookmark(string userid string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select create_name_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public delete_name_bookmark(string userid string nconst)
        {

        }

        public delete_rating(string userid string tconst int rating)
        {

        }
        
        public delete_search(string userid)
        {

        }

        public delete_search_name(string userid)
        {

        }

        public delete_search_title(string userid)
        {

        }

        public delete_title_bookmark(string userid string tconst)
        {

        }

        public delete_user(string userid)
        {

        }

        /*public exact_match(string input)
        {

        }

        public exact_match(string userid string input)
        {

        }*/

        public find_coplayers(string nconst)
        {

        }

        public login_user(string userid string password)
        {

        }

        public movie_actors_by_rating(string tconst)
        {

        }

        public movie_visited(string tconst)
        {

        }

        public name_rating_setter()
        {

        }

        public search_name(string userid string nconst)
        {

        }

        public search_title(string userid string tconst)
        {

        }

        public search_word(string userid, string word)
        {

        }

        public similar_movies(string tconst)
        {

        }

        public user_signup(string userid string password)
        {

        }

        public user_signup(string userid string password bool admin)
        {

        }

        word_word_match(string input)
        {

        }
    }
    }
