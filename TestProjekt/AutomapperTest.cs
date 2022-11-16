using DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;

namespace TestProjekt
{
    public class AutomapperTest
    {
            [Fact]
            public void AutoMapperTest1()
            {
            var service = new MovieDataService();
            movie_title? movie = service.db.movie_titles.Find("tt7856872");
            List<movie_akas> akas = movie?.movie_Akas;
            Assert.NotNull(akas);
            Assert.Equal("Drama", movie?.genres);
        }
    }
}
