using DataLayer;
using DataLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using WebServer.Models;
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
            _configuration = configuration;


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

            _userdataService.user_signup(model.Username, hashResult.hash, hashResult.salt);

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
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { user.userid, token = jwt });

        }

        [HttpGet]
        [Authorize]
        [Route("{userid}")]
        public IActionResult get_user([FromRoute]string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();
            }
            var data = _userdataService.GetUser(userid);


            return Ok(data);

        }

        [HttpPost("create_title_bookmark")]
        [Authorize]
        public IActionResult createtitlebookmark(titleBookmark model)
        {
            if (string.IsNullOrEmpty(model.userid) && string.IsNullOrEmpty(model.tconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.create_title_bookmark(model.userid, model.tconst);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpPost("create_name_bookmark")]
        [Authorize]
        public IActionResult create_name_bookmark(titleBookmark model)
        {
            if (string.IsNullOrEmpty(model.userid) && string.IsNullOrEmpty(model.tconst))
            {
                return BadRequest();
            }
            try
            {
                _userdataService.create_name_bookmark(model.userid, model.tconst);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }
        [HttpPost("create_rating")]
        [Authorize]
        public IActionResult create_rating(movieRating model)
        {
            if (string.IsNullOrEmpty(model.userid) && string.IsNullOrEmpty(model.tconst) && model.rating == null)
            {
                return BadRequest();
            }
            try
            {
                _userdataService.create_rating(model.userid, model.tconst, model.rating);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpPost("create_title_search")]
        [Authorize]
        public IActionResult create_title_search(titleBookmark model)
        {
            if (string.IsNullOrEmpty(model.userid) && string.IsNullOrEmpty(model.tconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.search_title(model.userid, model.tconst);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpPost]
        [Authorize]
        public IActionResult create_person_search(string userid, string nconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(nconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.search_name(userid, nconst);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpPost("create_search_word")]
        [Authorize]
        public IActionResult create_search_word(titleBookmark model)
        {//ikke rigtige model men virker tconst er input i dette tilfælde
            if (string.IsNullOrEmpty(model.userid) && string.IsNullOrEmpty(model.tconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.search_word(model.userid, model.tconst);
            }
            catch
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

        [HttpDelete]
        [Authorize]
        public IActionResult delete_title_bookmark(string userid, string tconst)
        {
            if (string.IsNullOrEmpty(userid) && string.IsNullOrEmpty(tconst))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_name_bookmark(userid, tconst);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_title_search(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_search_title(userid);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_name_search(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_search_name(userid);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_search(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();

            }
            try
            {
                _userdataService.delete_search(userid);
            }
            catch
            {
                return BadRequest();

            }

            return Ok();

        }

        [HttpDelete]
        [Authorize]
        public IActionResult delete_user(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return BadRequest();

            }

            try
            {
                _userdataService.delete_user(userid);
            }
            catch 
            { 
                return BadRequest();
            }


            return Ok();

        }
    }
}
