using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class search_history
    {
        public string userid { get; set; }

        public string searchword { get; set; }

        public DateTime sh_timestamp { get; set; }

        public user users { get; set; }

    }
}
