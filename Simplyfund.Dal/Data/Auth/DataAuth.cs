using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Auth;
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

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _rolesManager;
        private readonly IConfiguration _configuration;


        public DataAuth(UserManager<User> userManager, RoleManager<Role> rolesManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _rolesManager = rolesManager;
            _configuration = configuration;
        }




        public async Task<LoginResponses> Login(LoginModel model)
        {
            try
            {
                LoginResponses login = new LoginResponses();

                User? user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (checkPassword)
                    {

                        var userRoles = await _userManager.GetRolesAsync(user);


                        if (user.UserId != null && user.UserName != null)
                        {

                            var token = await GenerateTokenAsync(user.UserId.Value.ToString(), user.UserName, userRoles.ToList());

                            login.token = token;
                            login.Expire = DateTime.Now.AddDays(1);
                            login.Roles = userRoles.ToList();
                            login.userId = user.UserId.ToString();
                            login.UserName = user.UserName;
                            return login;

                        }
                        else
                        {
                            throw new Exception("Usuario o contrasena invalida, el usuario no existe, chequea a ver");
                        }
                    }
                    else
                    {
                        throw new Exception("Usuario o contrasena invalida, el usuario no existe, chequea a ver");
                    }
                  
                }
                else
                {
                    throw new Exception("Usuario o contrasena invalida, el usuario no existe, chequea a ver");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<bool> AssignUserRole(string userId, string roleName)
        {
            var usuario = await _userManager.FindByIdAsync(userId);

            if (usuario != null)
            {
                var result = await _userManager.AddToRoleAsync(usuario, roleName);

                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new Exception($"Usuario con ID {userId} no encontrado.");
            }
        }







        public async Task<string> GenerateTokenAsync(string userId, string userName, List<string> roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey.PadRight(128)));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName),
                };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

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
