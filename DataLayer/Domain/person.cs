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

        public virtual List<movie_partof> partof { get; set; }

        public virtual List<user_bookmark_name> user_bookmarks { get; set; }

        public virtual List<name_search> Name_Searches { get; set; }

    }
}
