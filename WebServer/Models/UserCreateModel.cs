using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceToken.Models
{

    public class UserCreateModel
    {

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
