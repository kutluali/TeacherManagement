using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.Entity.Entites
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
