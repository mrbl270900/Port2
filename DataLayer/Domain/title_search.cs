namespace DataLayer.Domain
{
    public class title_search
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public DateTime ts_timestamp { get; set; }

        public user users { get; set; }

        public movie_title titles { get; set;}
    }
}
