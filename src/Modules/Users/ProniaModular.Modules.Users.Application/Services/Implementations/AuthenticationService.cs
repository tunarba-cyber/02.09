using Microsoft.AspNetCore.Identity;
using ProniaModular.Modules.Users.Application.DTOs.AppUser;
using ProniaModular.Modules.Users.Application.Services.Interfaces;
using ProniaModular.Modules.Users.Domain.Entities;
using System;
using System.Collections.Generic;
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