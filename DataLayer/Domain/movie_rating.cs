using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_rating
    {
        public string tconst { get; set; }

        public float averagerating { get; set; }

        public int numvotes { get; set; }

        public movie_title titles { get; set; }
    }
}
