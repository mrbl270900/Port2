using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class users
    {
        public string userid { get; set; }

        public string password { get; set; }

        public bool admin { get; set; } = false;

    }
}
