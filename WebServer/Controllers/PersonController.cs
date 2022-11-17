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
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMovieDataService _moviedataservice;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        private readonly int MaxPageSize;


        public PersonController(IMovieDataService dataService, LinkGenerator generator, IMapper mapper)
        {
        _moviedataservice = dataService;
        _generator = generator;
        _mapper = mapper;
        }
        // todo lav search for person


        [HttpGet(Name = nameof(GetPerson))]
        public IActionResult GetPerson(string? search, int page = 0, int pageSize = 10)
        {
            if (string.IsNullOrEmpty(search))

            {

                var person =
                _moviedataservice.GetPersonList();

                return Ok(Paging(page, pageSize, person.Count, person));
            }
            else

            {
                var data = _moviedataservice.GetPerson(search);
                return Ok(data);
            }
        }


        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
                HttpContext,
                nameof(GetPerson), new { page, pageSize });
        }
       
        private object Paging<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
                pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

                //if (pageSize > MaxPageSize)
                //{
                //    pageSize = MaxPageSize;
                //}

                var pages = (int)Math.Ceiling((double)total / (double)pageSize)
                    ;

                var first = total > 0
                    ? CreateLink(0, pageSize)
                    : null;

                var prev = page > 0
                    ? CreateLink(page - 1, pageSize)
                    : null;

                var current = CreateLink(page, pageSize);

                var next = page < pages - 1
                    ? CreateLink(page + 1, pageSize)
                    : null;

                var result = new
                {
                    first,
                    prev,
                    next,
                    current,
                    total,
                    pages,
                    items
                };
                return result;
        }


    }
}
