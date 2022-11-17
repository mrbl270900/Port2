namespace DataLayer.Domain
{
    public class user_rating
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public int rating { get; set; }

        public user users { get; set; }

        public movie_title titles { get; set; }
    }
}
