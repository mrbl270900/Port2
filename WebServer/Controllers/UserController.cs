using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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
    }
}
