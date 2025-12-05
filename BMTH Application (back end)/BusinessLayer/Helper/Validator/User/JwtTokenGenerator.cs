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
            if (providedUser == null)
            {
                throw new ValidationException("User cannot be null when generating a JWT token");
            }
            var jwtSettings = _config.GetSection("JwtSettings");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? 
                                       throw new InvalidOperationException("Jwt:Key is missing from configuration"))
            );

            string? issuer = jwtSettings["Issuer"];
            if (string.IsNullOrWhiteSpace(issuer))
            {
                throw new ValidationException("JwtSettings:Issuer is missing.");
            }

            string? audience = jwtSettings["Audience"];
            if (string.IsNullOrWhiteSpace(audience))
            {
                throw new ValidationException("JwtSettings:Audience is missing.");
            }

            if (!int.TryParse(jwtSettings["ExpiryMinutes"], out int expiryMinutes))
            {
                throw new ValidationException("JwtSettings:ExpiryMinutes must be a integer.");
            }

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
