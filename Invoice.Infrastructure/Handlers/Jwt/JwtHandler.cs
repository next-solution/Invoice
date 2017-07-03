using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Invoice.Infrastructure.DTO;
using Invoice.Infrastructure.Extensions;
using Invoice.Infrastructure.Settings;
using Microsoft.IdentityModel.Tokens;

namespace Invoice.Infrastructure.Handlers.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtsettings;
        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtsettings = jwtSettings;
        }
        public JwtDto CreateToken(string username, string role)
        {
            var currentDate = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, currentDate.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = currentDate.AddMinutes(_jwtsettings.ExpiryTimeInMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key)),
                SecurityAlgorithms.HmacSha512);
            var jwt = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                claims: claims,
                notBefore: currentDate,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}