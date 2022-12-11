using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebServer.Models;
using WebServiceToken.Models;

namespace WebServiceSimple.Controllers
{
    [Route("api/movies")]
    [ApiController]

    public class MoviesController : ControllerBase
    {
        private readonly IMovieDataService _moviedataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        private readonly int MaxPageSize;

        public MoviesController(IMovieDataService moviedataService, LinkGenerator generator, IMapper mapper)
        {
            _moviedataService = moviedataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet( Name = nameof(GetMovies))]
        [Route("{page}/{pagesize}")]
        public IActionResult GetMovies([FromRoute] int page = 0, [FromRoute] int pagesize = 25)
        {
            var data = _moviedataService.GetMovieTitleList(page, pagesize).Select(x => CreateMovieModel(x));
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet ("{id}", Name = nameof(GetMovieTitle))]
        public IActionResult GetMovieTitle([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            
            var data = _moviedataService.GetMovieTitle(id);
            if(data != null)
            {
                var model = CreateMovieModel(data);
                return Ok(model);
            }
            
            return BadRequest();
           
        }

        [HttpPost]
        [Route("bestmatch")]
        public IActionResult best_match_search(List<string> input)
        {

            if (input == null && !input.Any())
            {
                return BadRequest();
            }

            var bestmatch = _moviedataService.best_match(input);
            return Ok(bestmatch);

        }

        [HttpGet]
        [Route("{tconst}/visited")]
        public IActionResult movie_visited([FromRoute]string tconst)
        {
            if (string.IsNullOrEmpty(tconst)) 
            {
                return BadRequest();
            }

            return Ok();

        }

        [HttpGet]
        [Route("{tconst}/similarmovies")]
        public IActionResult similar_movies([FromRoute]string tconst)
        {

            if (string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }

            return Ok();
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
                HttpContext,
                nameof(GetMovies), new { page, pageSize });
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

        private movieModel CreateMovieModel(movie_title movie)
        {
            var model = _mapper.Map<movieModel>(movie);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovies), new { movie.tconst });
            return model;
        }


    }
}