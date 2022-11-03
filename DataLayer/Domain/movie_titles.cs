using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class movie_titles
    {
        public string tcontst { get; set; }

        public string title { get; set; }

        public string primarytitle { get; set; }

        public string? originaltitle { get; set; }

        public bool? isadult { get; set; }

        public int? startyear { get; set; }

        public int? endyear { get; set; }

        public int? runtimeminutes { get; set; }

        public string? genres { get; set; }
    }
}
