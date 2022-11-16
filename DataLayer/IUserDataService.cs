using DataLayer.Domain;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IUserDataService
    {
        public user? GetUser(string id);
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
        List<LoginOut> login_user(string userid, string password);
        void search_name(string userid, string nconst);
        void search_title(string userid, string tconst);
        void search_word(string userid, string word);
        void user_signup(string userid, string password, string hash, string salt);
        void user_signup(string userid, string password, bool admin, string hash, string salt);
    }
}
