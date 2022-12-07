namespace DataLayer.Domain
{
    public class movie_partof
    {
        public string tconst { get; set; }
        public int ordering { get; set; }
        public string nconst { get; set; }
        public string category { get; set; }
        public string? job { get; set; }
        public string? characters { get; set; }

        public virtual movie_title Movie_Title { get; set; }

        public virtual person Person { get; set; }

    }
}
