using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer
{
    public class MovieDataService : IMovieDataService
    {
        public movie_title? GetMovieTitle(string id)
        {
            IMDBContext db = new IMDBContext();
            movie_title? movie = db.movie_titles
                .Include(x => x.movie_Ratings)
                .Include(x => x.OMDB_Datasets)
                .Include(x => x.movie_Partofs)
                .Include(x => x.movie_Akas)
                .Include(x => x.movie_Clicks)
                .Include(x => x.movie_Episode)
                .Include(x => x.movie_parents)
                .Include(x => x.wis)
                .FirstOrDefault(x => x.tconst == id);
            return movie;
        }

        public List<person> GetPersonList()
        {
            IMDBContext db = new IMDBContext();
            return db.persons
                .ToList();
        }

        public List<person> GetPersonList(int page = 0, int pagesize = 25)
        {
            IMDBContext db = new IMDBContext();
            if (pagesize > 100)
            {
                pagesize = 100;
            } else if (pagesize<1)
            {
                pagesize = 1;
            }
            if(page < 0)
            {
                page = 0;
            }


            return db.persons
                .Skip(page*pagesize).Take(pagesize).ToList();
        }

        public List<movie_title> GetMovieTitleList()
        {
            IMDBContext db = new IMDBContext();
            return db.movie_titles
                .ToList();
        }

        public List<movie_title> GetMovieTitleList(int page = 0, int pagesize = 25)
        {
            IMDBContext db = new IMDBContext();
            if (pagesize > 100)
            {
                pagesize = 100;
            }
            else if (pagesize < 1)
            {
                pagesize = 1;
            }
            if (page < 0)
            {
                page = 0;
            }

            return db.movie_titles
                .Include(x => x.OMDB_Datasets)
                .Skip(page * pagesize).Take(pagesize).ToList();
        }

        public movie_title? SetMovie(movie_title input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_titles.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_title? DeleteMovie(movie_title input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_titles.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_partof? SetMovie_partof(movie_partof input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_partof.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_partof? DeleteMovie_partof(movie_partof input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_partof.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_rating? SetMovie_rating(movie_rating input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_rating.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_rating? DeleteMovie_rating(movie_rating input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_rating.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_akas? SetMovie_akas(movie_akas input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_akas.Add(input);
            db.SaveChanges();
            return input;
        }
        public OMDB_dataset? DeleteOMDB_dataset(OMDB_dataset input)
        {
            IMDBContext db = new IMDBContext();
            db.omdb_dataset.Remove(input);
            db.SaveChanges();
            return input;
        }
        public wi? SetWi(wi input)
        {
            IMDBContext db = new IMDBContext();
            db.wis.Add(input);
            db.SaveChanges();
            return input;
        }
        public wi? DeleteWi(wi input)
        {
            IMDBContext db = new IMDBContext();
            db.wis.Remove(input);
            db.SaveChanges();
            return input;
        }
        public movie_episode? SetMovie_episode(movie_episode input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_episodes.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_episode? DeleteMovie_episode(movie_episode input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_episodes.Remove(input);
            db.SaveChanges();
            return input;
        }
        public OMDB_dataset? SetOMDB_dataset(OMDB_dataset input)
        {
            IMDBContext db = new IMDBContext();
            db.omdb_dataset.Add(input);
            db.SaveChanges();
            return input;
        }

        public movie_akas? DeleteMovie_akas(movie_akas input)
        {
            IMDBContext db = new IMDBContext();
            db.movie_akas.Remove(input);
            db.SaveChanges();
            return input;
        }

        public person? GetPerson(string id)
        {
            IMDBContext db = new IMDBContext();
            person? person = db.persons
                .Include(x => x.partof)
                .FirstOrDefault(x => x.nconst == id);
            return person;
        }

        public person? SetPerson(person input)
        {
            IMDBContext db = new IMDBContext();
            db.persons.Add(input);
            db.SaveChanges();
            return input;
        }

        public person? DeletePerson(person input)
        {
            IMDBContext db = new IMDBContext();
            db.persons.Remove(input);
            db.SaveChanges();
            return input;
        }


        public List<BestMatchOut> best_match(List<string> input)
        {

            IMDBContext db = new IMDBContext();
            string ConcatInput = "SELECT * from best_match('";
            if (input.Count < 1) {
                ConcatInput = ConcatInput + "')";
            }
            foreach (string element in input)
            {
                if (input.Last().Equals(element))
                {
                    ConcatInput = ConcatInput + element;
                    ConcatInput = ConcatInput + "')";
                    break;
                }
                ConcatInput = ConcatInput + element;
                ConcatInput = ConcatInput + "', '";
            }
            
            var result = db.bestmatchouts.FromSqlRaw(ConcatInput);
            return result.ToList();
        }

        
        //todo tjek om dette skal med i pogrammet
        /*public exact_match(string input)
        {

        }

        public exact_match(string userid string input)
        {

        }*/

        public List<CoPlayersOut> find_coplayers(string nconst)
        {
            IMDBContext db = new IMDBContext();
            var result = db.coPlayersOuts.FromSqlInterpolated($"select * from find_coplayers({nconst})");
            return result.ToList();
        }

        public List<MovieActorOut> movie_actors_by_rating(string tconst)
        {
            IMDBContext db = new IMDBContext();
            var result = db.movieactorout.FromSqlInterpolated($"select * from movie_actors_by_rating({tconst})");
            return result.ToList();
        }

        public void movie_visited(string tconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select movie_visited({tconst})");
            db.SaveChanges();
        }

        public void name_rating_setter()
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select movie_visited()");
            db.SaveChanges();
        }

        public List<MovieActorOut> similar_movies(string tconst)
        {
            IMDBContext db = new IMDBContext();
            var result = db.movieactorout.FromSqlInterpolated($"select * similar_movies({tconst})");
            return result.ToList();
        }

        public List<WordOut> word_word_match(List<string> input)
        {
            IMDBContext db = new IMDBContext();
            string ConcatInput = "SELECT * from word_word_match('";
            foreach (string element in input)
            {
                if (input.Last().Equals(element))
                {
                    ConcatInput = ConcatInput + element;
                    ConcatInput = ConcatInput + "')";
                    break;
                }
                ConcatInput = ConcatInput + element;
                ConcatInput = ConcatInput + "', '";
            }

            var result = db.wordout.FromSqlRaw(ConcatInput);
            return result.ToList();
        }
    }
    }
