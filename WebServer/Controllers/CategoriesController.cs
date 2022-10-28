using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from controller";
        }
    }
}
