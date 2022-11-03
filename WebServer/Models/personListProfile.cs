using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class personListModel
    {
        public string? Url { get; set; }

        public string? primaryname { get; set; }

        public int? birthyear { get; set; }

        public int? deathyear { get; set; }

        public string? primaryprofession { get; set; }

        public float? name_rating { get; set; }
    }
}