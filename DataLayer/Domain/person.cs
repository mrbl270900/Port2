using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class person
    {
        public string nconst { get; set; }

        public string primaryname { get; set; }

        public int? birthyear { get; set; }

        public int? deathyear { get; set; }

        public string? primaryprofession { get; set; }

        public float? name_rating { get; set; }

    }
}
