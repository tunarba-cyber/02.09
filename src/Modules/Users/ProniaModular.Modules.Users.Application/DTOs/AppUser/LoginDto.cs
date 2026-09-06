using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Users.Application.DTOs.AppUser
{
    public record LoginDto(string UserName,
        string Password
    )
    {

    }
}
