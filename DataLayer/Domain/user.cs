namespace DataLayer.Domain
{
    public class user
    {
        public string userid { get; set; }

        public string password { get; set; }

        public string salt { get; set; }

        public bool admin { get; set; } = false;

        public List<user_rating> user_Ratings { get; set; }

        public List<user_bookmark_title> users_bookmark_titles { get;set; }

        public List<user_bookmark_name> users_bookmark_names { get; set; }

        public List<title_search> title_Searches { get; set; }

        public List<search_history> search_historys { get; set; }

    }
}
