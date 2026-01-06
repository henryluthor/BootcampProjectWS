using BootcampProjectWS.DBModels;
using Microsoft.AspNetCore.Mvc;
using BootcampProjectWS.Classes;

namespace BootcampProjectWS.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private int cookieExpirationHours = 24;
        private readonly BootcampprojectContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(BootcampprojectContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // Generate token and create cookie to store token
        [HttpPost("login")]
        public void Login([FromBody] LoginRequest loginRequest)
        {
            // Need LoginResponse object to generate token
        }
    }
}
