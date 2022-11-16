using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class user_bookmark_title
    {
        public string userid { get; set; }

        public string tconst { get; set; }

        public movie_title titles { get; set; }
    }
}
