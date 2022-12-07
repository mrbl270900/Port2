namespace DataLayer.Domain
{
    public class movie_episode
    {
        public string tconst { get; set; }
        public string parenttconst { get; set; }

        public int seseasonnumber { get; set; }

        public int episodenumber { get; set; }

        public virtual movie_title titles { get; set; }
        public virtual movie_title parenttitles { get; set; }

    }
}
