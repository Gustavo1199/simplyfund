using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.GeneralConfiguration.Autentication
{
    public static class TokenService
    {
        private static readonly string? _secretKey = "secretKeyapi";
        private static readonly string? _issuer = "_issuerapi";
        private static readonly string? _audience = "audienceapi";

        //public TokenService(string secretKey, string issuer, string audience)
        //{
        //    _secretKey = secretKey;
        //    _issuer = issuer;
        //    _audience = audience;
        //}

        public static string GenerateToken(string userId, string userName, string role)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role),
        };

            var token = new JwtSecurityToken(
                _issuer,
                _audience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static bool ValidateToken(string token, out ClaimsPrincipal principal)
        {
            principal = null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            try
            {
                SecurityToken validatedToken;
                principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                return true;
            }
            catch (Exception)
            {
                // La validación del token falló
                // Puedes manejar la excepción según tus necesidades (por ejemplo, registrarla)
                return false;
            }
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey))
            };
        }
    }
}
