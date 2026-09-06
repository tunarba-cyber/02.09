using Microsoft.AspNetCore.Identity;
using ProniaModular.Modules.Users.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Users.Domain.Entities
{
    public sealed class AppUser:IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public UserGender UserGender { get; set; }
    }
}
