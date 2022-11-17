using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet(Name = nameof(GetPersons))]
        [Route("{page}/{pagesize}")]
        public IActionResult GetPersons([FromRoute] int page = 0, [FromRoute] int pagesize = 25)
        {
            var data = _moviedataservice.GetPersonList();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("{nconst}", Name = nameof(GetPerson))]
        public IActionResult GetPerson([FromRoute] string nconst)
        {
            if (string.IsNullOrEmpty(nconst))
            {
                BadRequest();
            }
                var data = _moviedataservice.GetPerson(nconst);
            if (data != null)
            {
                return Ok(data);
            }
                return NotFound();
        }

        [HttpGet]
        [Route("{nconst}/findcoplayers")]
        public IActionResult find_coplayers([FromRoute] string nconst)
        {
            if (string.IsNullOrEmpty(nconst))

            {
                return BadRequest();
            }
            
                var data = _moviedataservice.find_coplayers(nconst);
                return Ok(data);
            
        }
        [HttpGet]
        [Route("{tconst}/movieactorsbyrating")]
        public IActionResult movie_actors_by_rating([FromRoute] string tconst)
        {
            if (string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }

            var data = _moviedataservice.movie_actors_by_rating(tconst);
            if (data != null)
            {
                return Ok(data);
            }
                return NotFound();

        }


        [HttpGet]
        [Route("nameratingsetter")]
        [Authorize]
        public IActionResult name_rating_setter()
        {

            _moviedataservice.name_rating_setter();
 
            return Ok();

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
