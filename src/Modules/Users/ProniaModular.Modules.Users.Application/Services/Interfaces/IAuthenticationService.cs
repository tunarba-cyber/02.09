using ProniaModular.Modules.Users.Application.DTOs.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Users.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(RegisterDto user);
    }
}
