using DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class SimilarMoviesOut
    {
        public string tconst { get; set; }

        public string primarytitle { get; set; }
        public int movie_rating { get; set; }
    }
}
