using BootcampProjectWS.Classes;
using BootcampProjectWS.DBModels;
using BootcampProjectWS.Helpers;
using BootcampProjectWS.Models;
using BootcampProjectWS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

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
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            // Need LoginResponse object to generate token
            LoginResponse loginResponse = new LoginResponse(_configuration);

            var token = String.Empty;

            try
            {
                UserRepository userRep = new UserRepository();
                User userFound = userRep.SelectUserByUsername(_context, loginRequestModel.userName);

                if (userFound != null) // if a user was found
                {
                    // verify user status is ACTIVE - statusId = 1
                    if (userFound.Statusid == 1)
                    {
                        // verify passwords match
                        string passFindDecrypted = (new MethodsEncryptHelper().DecryptPassword(userFound.Password));

                        if (passFindDecrypted == loginRequestModel.password)
                        {
                            //login was successful
                            token = loginResponse.GenerateToken(userFound.Userid.ToString(), userFound.Username);

                            var cookieOptions = new CookieOptions
                            {
                                //HttpOnly = false,
                                Secure = true,
                                Domain = "localhost",
                                Path = "/",
                                Expires = DateTime.UtcNow.AddHours(cookieExpirationHours),
                                //IsEssential = true,
                                SameSite = SameSiteMode.None,
                            };
                            Response.Cookies.Append("token", token, cookieOptions);

                            // This is how you set text in the body of the HttpResponse
                            //await Response.WriteAsync("Hello, this is the HttpResponse body");
                            //return Ok();

                            // This is how you set an object in the body of the HttpResponse
                            //var persona = new
                            //{
                            //    Name = "Juan",
                            //    Age = 30
                            //};
                            //await Response.WriteAsJsonAsync(persona);
                            //return Ok();

                            // This is how you set an object as an action result
                            //var persona = new
                            //{
                            //    Name = "Juan",
                            //    Age = 30
                            //};
                            //return Ok(persona);

                            return Ok(new { authenticated = true });
                        }
                        else
                        {
                            return Unauthorized();
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }

        // Verify token
        [HttpGet("authenticated")]
        public IActionResult Authenticated()
        {
            // var token = Request.Cookies["token"]; // this is another way of doing the following line
            var token = HttpContext.Request.Cookies["token"];

            if(token == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "MyISP-WS", //check this
                ValidAudience = "my-isp-web-app", //check this
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("H7YVZWs1TnxVF8tCOCLF2/RJRy0FK3Hk")) //check this
            };

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

                if(securityToken is JwtSecurityToken jwtSecurityToken)
                {
                    var expirationDate = jwtSecurityToken.ValidTo;

                    if(expirationDate < DateTime.UtcNow)
                    {
                        // Token has expired
                        return Unauthorized();
                    }

                    return Ok(new {authenticated = true});
                }
                else
                {
                    // Token is not JWT
                    return Unauthorized();
                }
            }
            catch(SecurityTokenException ex)
            {
                // Token is invalid
                return Unauthorized();
            }
        }
    }
}
