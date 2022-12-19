using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataLayer
{
    public class UserDataService : IUserDataService
    {
        public user? GetUser(string id)
        {
            IMDBContext db = new IMDBContext();
            user? user = db.users
                .Include(x => x.title_Searches)
                .Include(x => x.user_Ratings)
                .Include(x => x.person_historys)
                .Include(x => x.users_bookmark_titles)
                .Include(x => x.search_historys)
                .Include(x => x.users_bookmark_names)
                .FirstOrDefault(x => x.userid == id);
            return user;
        }
        public void create_name_bookmark(string userid, string nconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from create_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public void create_rating(string userid, string tconst, int rating)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from create_rating({userid},{tconst},{rating})");
            db.SaveChanges();
        }

        public void create_title_bookmark(string userid, string tconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from create_title_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public void delete_name_bookmark(string userid, string nconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public void delete_rating(string userid, string tconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_rating({userid},{tconst})");
            db.SaveChanges();
        }

        public void delete_search(string userid)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_search({userid})");
            db.SaveChanges();
        }

        public void delete_search_name(string userid)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_search_name({userid})");
            db.SaveChanges();
        }

        public void delete_search_title(string userid)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_search_title({userid})");
            db.SaveChanges();
        }

        public void delete_title_bookmark(string userid, string tconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_title_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public void delete_user(string userid)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from delete_user({userid})");
            db.SaveChanges();
        }

        public List<LoginOut> login_user(string userid, string password)
        {
            IMDBContext db = new IMDBContext();
            var result = db.loginout.FromSqlInterpolated($"select * login_user({userid},{password})");
            return result.ToList();
        }

        public void search_name(string userid, string nconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from search_name({userid},{nconst})");
            db.SaveChanges();
        }

        public void search_title(string userid, string tconst)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from search_title({userid},{tconst})");
            db.SaveChanges();
        }

        public void search_word(string userid, string word)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from search_word({userid},{word})");
            db.SaveChanges();
        }

        public void user_signup(string userid, string password, string salt)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from user_signup({userid},{password},{salt})");
            db.SaveChanges();
        }

        public void user_signup(string userid, string password, bool admin, string hash, string salt)
        {
            IMDBContext db = new IMDBContext();
            db.Database.ExecuteSqlInterpolated($"select * from user_signup({userid},{password}, {admin})");
            db.SaveChanges();
        }

    }
}
