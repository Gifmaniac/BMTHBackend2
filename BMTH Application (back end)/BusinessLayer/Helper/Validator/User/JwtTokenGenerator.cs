using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Domain.User;
using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Helper.Validator.User
{
    public class JwtTokenGenerator(IConfiguration config) : IJwtTokenGenerator
    {
        private readonly IConfiguration _config = config;

        public string GenerateToken(LoginUser providedUser)
        {
            var jwtSettings = _config.GetSection("JwtSettings");

            var keyValue = jwtSettings["Key"]
                           ?? Environment.GetEnvironmentVariable("JWT_SIGNING_KEY")
                           ?? throw new InvalidOperationException("JWT signing key is missing.");

            var issuer = jwtSettings["Issuer"]
                         ?? Environment.GetEnvironmentVariable("JWT_ISSUER")
                         ?? throw new ValidationException("JWT issuer is missing.");

            var audience = jwtSettings["Audience"]
                           ?? Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                           ?? throw new ValidationException("JWT audience is missing.");

            var expiryValue = jwtSettings["ExpiryMinutes"]
                              ?? Environment.GetEnvironmentVariable("JWT_EXPIRY_MINUTES")
                              ?? throw new ValidationException("JWT expiry minutes is missing.");

            if (!int.TryParse(expiryValue, out int expiryMinutes))
            {
                throw new ValidationException("JwtSettings:ExpiryMinutes must be an integer.");
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(keyValue)
            );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, providedUser.Id.ToString()),
                new Claim(ClaimTypes.Email, providedUser.Email),
                new Claim(ClaimTypes.Role, providedUser.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"] ??
                                                              throw new InvalidOperationException("Expiry time wasn't found"))),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
