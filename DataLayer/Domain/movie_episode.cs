using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_episode
    {
        public string tconst { get; set; }
        public string parenttconst { get; set; }

        public int seseasonnumber { get; set; }

        public int episodenumber { get; set; }

        public movie_titles titles { get; set; }
        public movie_titles parenttitles { get; set; }

    }
}
