using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeerDiary_Backend.Security
{
    public class JWTManager
    {
        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;

        private readonly string _issuer;
        private readonly string _audience;

        public JWTManager(IConfiguration config){
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);
            _issuer = config["JWT:ValidAudience"];
            _audience = config["JWT:ValidIssuer"];
        }
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: _credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
