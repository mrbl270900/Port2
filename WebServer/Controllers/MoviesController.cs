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
    [ApiController]
    [Route("api/movies")]

    public class MoviesController : ControllerBase
    {
        private readonly IMovieDataService _moviedataService;
        private readonly LinkGenerator _generator;
        private readonly autoMapper _mapper;

        public MoviesController(IMovieDataService moviedataService, LinkGenerator generator, autoMapper _mapper)
        {
            _moviedataService = moviedataService;
            _generator = generator;
        }

        [HttpGet ("{id}", Name = nameof(GetMovieTitle))]
        public IActionResult GetMovieTitle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            
            }
            
            var movies = _moviedataService.GetMovieTitle(id);
            
            return Ok(movies);
           
        }

        [HttpGet]
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
        public IActionResult movie_visited(string tconst)
        {
            if (string.IsNullOrEmpty(tconst)) 
            {
                return BadRequest();
            }

            return Ok();

        }

        [HttpGet]
        public IActionResult similar_movies(string tconst)
        {

            if (string.IsNullOrEmpty(tconst))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}