using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_clicks
    {
        public string tconst { get; set; }
        public int amount { get; set; }

        public movie_title titles { get; set; }

    }
}
