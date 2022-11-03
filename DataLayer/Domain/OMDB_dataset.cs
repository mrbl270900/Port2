using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class OMDB_dataset
    {
        public string tconst { get; set; }

        public string poster { get; set; }

        public string plot { get; set; }

        public movie_titles titles { get; set; }
    }
}
