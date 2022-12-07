namespace DataLayer.Domain
{
    public class title_search
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public DateTime ts_timestamp { get; set; }

        public virtual user users { get; set; }

        public virtual movie_title titles { get; set;}
    }
}
