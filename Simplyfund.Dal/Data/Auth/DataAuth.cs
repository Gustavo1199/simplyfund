using Microsoft.IdentityModel.Tokens;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Simplyfund.Dal.Data.Auth
{
    public class DataAuth : IDataAuth
    {
        private static readonly string? _secretKey = "secretKeyapi";
        private static readonly string? _issuer = "_issuerapi";
        private static readonly string? _audience = "audienceapi";
        public DataAuth() { }

        public async Task<string> GenerateTokenAsync(string userId, string userName, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.PadRight(128)));

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

            return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
        }


    }
}
