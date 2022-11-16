using Automapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebServer.Models;

{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IMovieDataService _MovieDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public CategoriesController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
        _dataService = dataService;
        _generator = generator;
        _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetPersons))]
        public IActionResult GetPerson()
        {
        var Person =
            _dataService.GetPerson().Select(x => CreatePersonModel(x));
        return Ok(Person);
        }

}
}
