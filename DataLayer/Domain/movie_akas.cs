using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Domain
{
    public class movie_akas
    {
        public string titleid { get; set; }
        public int ordering { get; set; }
        public string title { get; set; }
        public string region { get; set; }
        public string? language { get; set; }
        public string? types { get; set; }
        public string? attributes { get; set; }
        public bool isoriginaltitle { get; set; }

        public movie_title movie_titles { get; set; }

    }
}
