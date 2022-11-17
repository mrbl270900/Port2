namespace DataLayer.Domain
{
    public class person
    {
        public string nconst { get; set; }

        public string primaryname { get; set; }

        public string? birthyear { get; set; }

        public string? deathyear { get; set; }

        public string? primaryprofession { get; set; }

        public float? name_rating { get; set; }

        public List<movie_partof> partof { get; set; }

        public List<user_bookmark_name> user_bookmarks { get; set; }

    }
}
