using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.Entity.Entites
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public int UserId { get; set; } // AppUser ile ilişkilendirilecek 
        public AppUser User { get; set; } // Navigation property
        public DateTime Expiration { get; set; }
        public bool IsRevoked { get; set; }
    }

}
