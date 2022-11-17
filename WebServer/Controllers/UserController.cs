using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using WebServiceToken.Models;


namespace WebServiceToken.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDataService _userdataService;
        private readonly Hashing _hashing;
        private readonly IConfiguration _configuration;

        public UserController(IUserDataService userdataService, Hashing hashing, IConfiguration configuration)
        {
            _userdataService = userdataService;
            _hashing = hashing;


        }
        [HttpPost("register")]
        public IActionResult Register(UserCreateModel model)
        {
            if (_userdataService.GetUser(model.Username) != null)
            {
                return BadRequest();

            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return BadRequest();

            }
            var hashResult = _hashing.hash(model.Password);

            _userdataService.user_signup(model.Name, model.Username, hashResult.hash, hashResult.salt);

            return Ok();

        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginModel model)
        {
            var user = _userdataService.GetUser(model.Username);
            if (user == null)
            {
                return BadRequest();

            }

            if (!_hashing.Verify(model.Password, user.password, user.salt))
            {
                return BadRequest();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userid)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Auth:secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { user.userid, token = jwt });

        }

        [HttpGet]
        [Authorize]
        public IActionResult create_title_bookmark(string userid, string tconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(tconst))
            {
                return BadRequest();

            }

          
            return Ok();

        }

        [HttpGet]
        [Authorize]
        public IActionResult create_name_bookmark(string userid, string nconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(nconst))
            {
                return BadRequest();

            }


            return Ok();

        }
        [HttpGet]
        [Authorize]
        public IActionResult create_rating(string userid, string tconst, int rating)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(tconst) && rating == null)
            {
                return BadRequest();

            }


            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_name_bookmark(string userid, string nconst) 
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(nconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_name_bookmark(userid, nconst);
            }
            catch 
            {
                return BadRequest();
            
            }

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_rating(string userid, string tconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(tconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_rating(userid, tconst);

            }
            catch 
            { 
                return BadRequest();
            
            }
            

            return Ok();

        }
        [HttpGet]
        [Authorize]
        public IActionResult delete_title_bookmark(string userid, string tconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(tconst))
            {
                return BadRequest();

            }


            return Ok();

        }
        [HttpGet]
        [Authorize]
        public IActionResult delete_user(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();

            }


            return Ok();

        }
    }
}
