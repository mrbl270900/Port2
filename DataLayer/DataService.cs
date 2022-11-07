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
            db.Database.ExecuteSqlInterpolated($"select delete_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public delete_rating(string userid string tconst int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_rating({userid},{tconst},{rating})");
            db.SaveChanges();
        }
        
        public delete_search(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search({userid})");
            db.SaveChanges();
        }

        public delete_search_name(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search_name({userid})");
            db.SaveChanges();
        }

        public delete_search_title(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search_title({userid})");
            db.SaveChanges();
        }

        public delete_title_bookmark(string userid string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_title_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public delete_user(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_user({userid})");
            db.SaveChanges();
        }

        /*public exact_match(string input)
        {

        }

        public exact_match(string userid string input)
        {

        }*/

        public find_coplayers(string nconst)
        {//todo lav en model med find coplayers
            var result = db.bestmatchouts.FromSqlInterpolated($"select * best_match({input})");
            return result.ToList;
        }

        public login_user(string userid string password)
        {
            db.Database.ExecuteSqlInterpolated($"select login_user({userid},{password})");
            db.SaveChanges();
        }

        public movie_actors_by_rating(string tconst)
        {//todo lav en model med movieactors by rating
            var result = db.bestmatchouts.FromSqlInterpolated($"select * best_match({input})");
            return result.ToList;
        }

        public movie_visited(string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited({tconst})");
            db.SaveChanges();
        }

        public name_rating_setter()
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited()");
            db.SaveChanges();
        }

        public search_name(string userid string nconst)
        {
            db.Database.ExecuteSqlInterpolated($"select search_name({userid},{nconst})");
            db.SaveChanges();
        }

        public search_title(string userid string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select search_title({userid},{tconst})");
            db.SaveChanges();
        }

        public search_word(string userid, string word)
        {
            db.Database.ExecuteSqlInterpolated($"select search_word({userid},{word})");
            db.SaveChanges();
        }

        public similar_movies(string tconst)
        {//todo lav relsultat similar movies
            var result = db.bestmatchouts.FromSqlInterpolated($"select * best_match({input})");
            return result.ToList;
        }

        public user_signup(string userid string password)
        {
            db.Database.ExecuteSqlInterpolated($"select user_signup({userid},{password})");
            db.SaveChanges();
        }

        public user_signup(string userid string password bool admin)
        {
            db.Database.ExecuteSqlInterpolated($"select user_signup({userid},{password}, {admin})");
            db.SaveChanges();
        }

        word_word_match(string input)
        {//todo lav word_word_mathc
            var result = db.bestmatchouts.FromSqlInterpolated($"select * best_match({input})");
            return result.ToList;
        }
    }
    }
