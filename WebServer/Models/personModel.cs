using DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class personModel
    {
        public string? Url { get; set; }

        public string primaryname { get; set; }

        public string? birthyear { get; set; }

        public string? deathyear { get; set; }

        public string? primaryprofession { get; set; }

        public float? name_rating { get; set; }

        public List<movie_partof> partof { get; set; }

        public List<user_bookmark_name> user_bookmarks { get; set; }
    }
}