using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataLayer
{
    public class MovieDataService : IMovieDataService
    {
        public IMDBContext db = new IMDBContext();

        public movie_title? GetMovieTitle(string id)
        {
            movie_title? movie = db.movie_titles
                .Include(x => x.movie_Clicks)
                .Include(x => x.movie_Akas)
                .Include(x => x.movie_Episode)
                .Include(x => x.movie_parents)
                .Include(x => x.movie_Partofs)
                .Include(x => x.movie_Ratings)
                .Include(x => x.wis)
                .Include(x => x.OMDB_Datasets)
                .Include(x => x.title_search)
                .Include(x => x.users_bookmark_title)
                .FirstOrDefault(x => x.tconst == id);
            return movie;
        }

        public List<person> GetPersonList()
        {
            return db.persons
                .Include(x => x.user_bookmarks)
                .Include(x => x.partof)
                .ToList();
        }

        public List<person> GetPersonList(int page = 0, int pagesize = 25)
        {
            return db.persons
                .Include(x => x.user_bookmarks)
                .Include(x => x.partof)
                .Skip(page*pagesize).Take(pagesize).ToList();
        }

        public List<movie_title> GetMovieTitleList()
        {
            return db.movie_titles
                .Include(x => x.movie_Clicks)
                .Include(x => x.movie_Akas)
                .Include(x => x.movie_Episode)
                .Include(x => x.movie_parents)
                .Include(x => x.movie_Partofs)
                .Include(x => x.movie_Ratings)
                .Include(x => x.wis)
                .Include(x => x.OMDB_Datasets)
                .Include(x => x.title_search)
                .Include(x => x.users_bookmark_title)
                .ToList();
        }

        public List<movie_title> GetMovieTitleList(int page = 0, int pagesize = 25)
        {
            return db.movie_titles
                .Include(x => x.movie_Clicks)
                .Include(x => x.movie_Akas)
                .Include(x => x.movie_Episode)
                .Include(x => x.movie_parents)
                .Include(x => x.movie_Partofs)
                .Include(x => x.movie_Ratings)
                .Include(x => x.wis)
                .Include(x => x.OMDB_Datasets)
                .Include(x => x.title_search)
                .Include(x => x.users_bookmark_title)
                .Skip(page * pagesize).Take(pagesize).ToList();
        }

        public movie_title? SetMovie(movie_title input)
        {
            db.movie_titles.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_title? DeleteMovie(movie_title input)
        {
            db.movie_titles.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_partof? SetMovie_partof(movie_partof input)
        {
            db.movie_partof.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_partof? DeleteMovie_partof(movie_partof input)
        {
            db.movie_partof.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_rating? SetMovie_rating(movie_rating input)
        {
            db.movie_rating.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_rating? DeleteMovie_rating(movie_rating input)
        {
            db.movie_rating.Remove(input);
            db.SaveChanges();
            return input;
        }

        public movie_akas? SetMovie_akas(movie_akas input)
        {
            db.movie_akas.Add(input);
            db.SaveChanges();
            return input;
        }
        public OMDB_dataset? DeleteOMDB_dataset(OMDB_dataset input)
        {
            db.omdb_dataset.Remove(input);
            db.SaveChanges();
            return input;
        }
        public wi? SetWi(wi input)
        {
            db.wis.Add(input);
            db.SaveChanges();
            return input;
        }
        public wi? DeleteWi(wi input)
        {
            db.wis.Remove(input);
            db.SaveChanges();
            return input;
        }
        public movie_episode? SetMovie_episode(movie_episode input)
        {
            db.movie_episodes.Add(input);
            db.SaveChanges();
            return input;
        }
        public movie_episode? DeleteMovie_episode(movie_episode input)
        {
            db.movie_episodes.Remove(input);
            db.SaveChanges();
            return input;
        }
        public OMDB_dataset? SetOMDB_dataset(OMDB_dataset input)
        {
            db.omdb_dataset.Add(input);
            db.SaveChanges();
            return input;
        }

        public movie_akas? DeleteMovie_akas(movie_akas input)
        {
            db.movie_akas.Remove(input);
            db.SaveChanges();
            return input;
        }

        public person? GetPerson(string id)
        {
            person? person = db.persons
                .Include(x => x.user_bookmarks)
                .Include(x => x.partof).FirstOrDefault(x => x.nconst == id);
            return person;
        }

        public person? SetPerson(person input)
        {
            db.persons.Add(input);
            db.SaveChanges();
            return input;
        }

        public person? DeletePerson(person input)
        {
            db.persons.Remove(input);
            db.SaveChanges();
            return input;
        }


        //todo mangler generele funktioner der kigge i vores tabeler




        public List<BestMatchOut> best_match(List<string> input)
        {
            string ConcatInput = "SELECT * from best_match('";
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
            var result = db.coPlayersOuts.FromSqlInterpolated($"select * from find_coplayers({nconst})");
            return result.ToList();
        }

        public List<MovieActorOut> movie_actors_by_rating(string tconst)
        {
            var result = db.movieactorout.FromSqlInterpolated($"select * from movie_actors_by_rating({tconst})");
            return result.ToList();
        }

        public void movie_visited(string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited({tconst})");
            db.SaveChanges();
        }

        public void name_rating_setter()
        {
            db.Database.ExecuteSqlInterpolated($"select movie_visited()");
            db.SaveChanges();
        }

        public List<MovieActorOut> similar_movies(string tconst)
        {
            var result = db.movieactorout.FromSqlInterpolated($"select * similar_movies({tconst})");
            return result.ToList();
        }

        public List<WordOut> word_word_match(List<string> input)
        {
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
