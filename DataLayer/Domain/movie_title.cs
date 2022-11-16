using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_title
    {
        public string tconst { get; set; }

        public string title { get; set; }

        public string primarytitle { get; set; }

        public string? originaltitle { get; set; }

        public bool? isadult { get; set; }

        public string? startyear { get; set; }

        public string? endyear { get; set; }

        public int? runtimeminutes { get; set; }

        public string? genres { get; set; }

        public List<movie_akas> movie_Akas  { get; set; }

        public List<movie_clicks> movie_Clicks { get; set; }

        public movie_episode movie_Episode { get; set; }

        public List<movie_episode> movie_parents { get; set; }

        public List<movie_partof> movie_Partofs { get; set; }

        public List<movie_rating> movie_Ratings { get; set;}

        public List<OMDB_dataset> OMDB_Datasets { get; set; }

        public List<title_search> title_search { get; set; }

        public List<user_bookmark_title> users_bookmark_title { get;}

        public List<user_rating> user_Ratings { get; set; }

        public List<wi> wis { get; set; }
    }
}
