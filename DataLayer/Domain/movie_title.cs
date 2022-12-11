namespace DataLayer.Domain
{
    public class movie_title
    {
        public string tconst { get; set; }

        public string? title { get; set; }

        public string? primarytitle { get; set; }

        public string? originaltitle { get; set; }

        public bool? isadult { get; set; }

        public string? startyear { get; set; }

        public string? endyear { get; set; }

        public int? runtimeminutes { get; set; }

        public string? genres { get; set; }

        public virtual List<movie_akas>? movie_Akas  { get; set; }

        public virtual movie_clicks? movie_Clicks { get; set; }

        public virtual movie_episode? movie_Episode { get; set; }

        public virtual List<movie_episode>? movie_parents { get; set; }

        public virtual List<movie_partof>? movie_Partofs { get; set; }

        public virtual movie_rating? movie_Ratings { get; set; }

        public virtual OMDB_dataset? OMDB_Datasets { get; set; }

        public virtual List<title_search>? title_search { get; set; }

        public virtual List<user_bookmark_title>? users_bookmark_title { get; set; }

        public virtual List<user_rating>? user_Ratings { get; set; }

        public virtual List<wi>? wis { get; set; }
    }
}
