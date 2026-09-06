using Microsoft.AspNetCore.Identity;
using ProniaModular.Modules.Users.Application.DTOs.AppUser;
using ProniaModular.Modules.Users.Application.Services.Interfaces;
using ProniaModular.Modules.Users.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Users.Application.Services.Implementations
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> LoginAsync(LoginDto userdto)
        {
            AppUser? user = await _userManager.FindByNameAsync(userdto.UserName);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            bool result = await _userManager.CheckPasswordAsync(user, userdto.Password);
            if (!result)
            {
                await _userManager.AccessFailedAsync(user);
                throw new Exception("Invalid password");
            }

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "your-issuer",
                audience: "your-audience",

                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                },
                expires: DateTime.UtcNow.AddHours(1),
                notBefore: DateTime.UtcNow,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key")),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256
                )
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }

        public async Task RegisterAsync(RegisterDto userDto)
        {
            AppUser user = new()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                UserName = userDto.Username,
                Email = userDto.Email,
                UserGender = userDto.UserGender
            };
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}