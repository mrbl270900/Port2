using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_partof
    {
        public string tconst { get; set; }
        public int ordering { get; set; }
        public string nconst { get; set; }
        public string category { get; set; }
        public string? job { get; set; }
        public string? characters { get; set; }

        public movie_title titles { get; set; }

        public person persons { get; set; }

    }
}
