namespace DataLayer.Domain
{
    public class user
    {
        public string userid { get; set; }

        public string password { get; set; }

        public string salt { get; set; }

        public bool admin { get; set; } = false;

        public virtual List<user_rating> user_Ratings { get; set; }

        public virtual List<user_bookmark_title> users_bookmark_titles { get;set; }

        public virtual List<user_bookmark_name> users_bookmark_names { get; set; }

        public virtual List<title_search> title_Searches { get; set; }

        public virtual List<search_history> search_historys { get; set; }

        public virtual List<name_search> person_historys { get; set; }

    }
}
