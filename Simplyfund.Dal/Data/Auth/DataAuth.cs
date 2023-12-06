using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Simplyfund.Dal.Data.IBaseDatas.Auth;
using Simplyfund.Dal.DataInterface.Auth;
using SimplyFund.Domain.Dto.Login;
using SimplyFund.Domain.Dto.Responses;
using SimplyFund.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
        private readonly IDataRol dataRol;
        private readonly IConfiguration _configuration;



        public DataAuth(UserManager<User> userManager, RoleManager<Role> rolesManager, IConfiguration configuration, IDataRol dataRol)
        {
            _userManager = userManager;
            _rolesManager = rolesManager;
            _configuration = configuration;
            this.dataRol = dataRol;
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

        public async Task<object> ForgotPassword(ForgotPasswordDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null && (await _userManager.IsEmailConfirmedAsync(user)))
                {
                    throw new Exception("No es posible restablecer su contrasena.");
                }
                else
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    //Enviar Correo 
                    return new { mensaje = token/*"Se a enviado un correo con la informaciones necesarias para restablecer la contrasena."*/ };
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ResetPassword(ResetPasswordDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                throw new Exception("No es posible restablecer su contrasena.");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private async Task<string> GenerateTokenAsync(string userId, string userName, List<string> roles)
        {
            if (_secretKey != null)
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
            else
            {
                throw new Exception("No has a secrect key");
            }
        }

        public async Task<string> CreateUser(User user)
        {
            try
            {
                string password;
                if (user != null)
                {

                    if (user.UserName != null)
                    {
                        password = await GenerateTemporaryPasswordAsync(user.UserName);


                        string hashedPassword = _userManager.PasswordHasher.HashPassword(user, password);

                        user.Password = password;
                        user.PasswordHash = hashedPassword;
                        var create = await _userManager.CreateAsync(user);
                        if (user.Rol != null)
                        {
                            await dataRol.AssignUserRole(user.UserName, user.Rol);

                        }
                        return password;

                    }
                    else
                    {
                        throw new InvalidOperationException("Username no puede ser null");
                    }


                }
                else
                {
                    throw new InvalidOperationException("Usuario no puede ser null");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task<string> GenerateTemporaryPasswordAsync(string nombre)
        {
            DateTime today = DateTime.Today;

            string fechaFormateada = today.ToString("yyyyMMdd");

            string inputString = $"{nombre}{fechaFormateada}";

            string hashedPassword = await CalculateMd5HashAsync(inputString);

            string temporaryPassword = hashedPassword.Substring(0, 8);

            return temporaryPassword;
        }

        async Task<string> CalculateMd5HashAsync(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = await Task.Run(() => md5.ComputeHash(inputBytes));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }


    }
}
