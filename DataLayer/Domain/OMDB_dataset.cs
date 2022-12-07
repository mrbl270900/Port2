namespace DataLayer.Domain
{
    public class OMDB_dataset
    {
        public string tconst { get; set; }

        public string poster { get; set; }

        public string plot { get; set; }

        public virtual movie_title? titles { get; set; }
    }
}
