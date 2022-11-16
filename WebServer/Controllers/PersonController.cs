using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebServer.Controllers

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
        // todo lav search for person


        [HttpGet(Name = nameof(GetPersons))]
        public IActionResult GetPerson(int page = 0, int pageSize = 10, string? search = ?)
        {
            if (string.IsNullOrEmpty(search))

            {

                var person =
                _MovieDataService.GetPerson(page, pageSize).Select(x => CreatePersonModel(x));

                return Ok(Paging(page, pageSize));
            }
            else

            {
                var data = _MovieDataService.GetPerson(search)
                return Ok(data);
            }
        }
        
}
}
