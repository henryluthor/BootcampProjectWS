using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BootcampProjectWS.Classes
{
    public class LoginResponse
    {
        private readonly IConfiguration _configuration;

        public LoginResponse(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string userId, string username)
        {
            string mySecretKey;
            mySecretKey = _configuration.GetValue<string>("JwtBearerData:SecretKey");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JwtBearerData:Issuer"),
                audience: _configuration.GetValue<string>("JwtBearerData:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
