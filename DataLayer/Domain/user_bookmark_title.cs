namespace DataLayer.Domain
{
    public class user_bookmark_title
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public virtual movie_title titles { get; set; }

        public virtual user User { get; set; }
    }
}
