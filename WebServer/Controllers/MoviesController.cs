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

        [HttpGet ("{tconst}", Name = nameof(GetMovie))]
        public IActionResult GetMovie([FromRoute] string tconst)
        {
            if (string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }
            
            var data = _moviedataService.GetMovieTitle(tconst);
            if(data != null)
            {
                var model = CreateMovieModel(data);
                return Ok(model);
            }
            
            return NotFound();
           
        }

        [HttpPost]
        [Route("bestmatch")]
        public IActionResult best_match_search(List<string> input)
        {

            if (input == null && !input.Any())
            {
                return BadRequest();
            }

            var data = _moviedataService.best_match(input);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();

        }

        [HttpGet]
        [Route("{tconst}/visited")]
        public IActionResult movie_visited([FromRoute]string tconst)
        {
            if (string.IsNullOrEmpty(tconst)) 
            {
                return BadRequest();
            }

            _moviedataService.movie_visited(tconst);

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

            var data = _moviedataService.similar_movies(tconst);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
                HttpContext,
                nameof(GetMovies), new { page, pageSize });
        }


        private movieModel CreateMovieModel(movie_title movie)
        {
            var model = _mapper.Map<movieModel>(movie);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovie), new { movie.tconst });
            return model;
        }


    }
}