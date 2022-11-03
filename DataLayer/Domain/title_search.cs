using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class title_search
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public DateTime ts_timestamp { get; set; }

        public users users { get; set; }

        public movie_titles titles { get; set;}
    }
}
