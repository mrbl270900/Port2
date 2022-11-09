﻿using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserDataService : IUserDataService
    {
        public IMDBContext db = new IMDBContext();
        public void create_name_bookmark(string userid, string nconst)
        {
            db.Database.ExecuteSqlInterpolated($"select create_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public void create_rating(string userid, string tconst, int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select create_rating({userid},{tconst},{rating})");
            db.SaveChanges();
        }

        public void create_title_bookmark(string userid, string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select create_name_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public void delete_name_bookmark(string userid, string nconst)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_name_bookmark({userid},{nconst})");
            db.SaveChanges();
        }

        public void delete_rating(string userid, string tconst, int rating)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_rating({userid},{tconst},{rating})");
            db.SaveChanges();
        }

        public void delete_search(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search({userid})");
            db.SaveChanges();
        }

        public void delete_search_name(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search_name({userid})");
            db.SaveChanges();
        }

        public void delete_search_title(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_search_title({userid})");
            db.SaveChanges();
        }

        public void delete_title_bookmark(string userid, string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_title_bookmark({userid},{tconst})");
            db.SaveChanges();
        }

        public void delete_user(string userid)
        {
            db.Database.ExecuteSqlInterpolated($"select delete_user({userid})");
            db.SaveChanges();
        }

        public List<LoginOut> login_user(string userid, string password)
        {
            var result = db.loginout.FromSqlInterpolated($"select * login_user({userid},{password})");
            return result.ToList();
        }

        public void search_name(string userid, string nconst)
        {
            db.Database.ExecuteSqlInterpolated($"select search_name({userid},{nconst})");
            db.SaveChanges();
        }

        public void search_title(string userid, string tconst)
        {
            db.Database.ExecuteSqlInterpolated($"select search_title({userid},{tconst})");
            db.SaveChanges();
        }

        public void search_word(string userid, string word)
        {
            db.Database.ExecuteSqlInterpolated($"select search_word({userid},{word})");
            db.SaveChanges();
        }

        public void user_signup(string userid, string password)
        {
            db.Database.ExecuteSqlInterpolated($"select user_signup({userid},{password})");
            db.SaveChanges();
        }

        public void user_signup(string userid, string password, bool admin)
        {
            db.Database.ExecuteSqlInterpolated($"select user_signup({userid},{password}, {admin})");
            db.SaveChanges();
        }

    }
}