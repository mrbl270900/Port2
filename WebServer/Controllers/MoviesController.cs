using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Authorize] //this shows where I have to get Authorization
        public IActionResult GetMovieTitle(string id)
        {
            try
            {
                var movies = _moviedataService.GetMovieTitle();
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }

    }
}