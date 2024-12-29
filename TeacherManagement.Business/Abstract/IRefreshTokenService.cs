using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.Business.Abstract
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> TGetByTokenAsync(string token);
        Task TAddAsync(RefreshToken refreshToken);
        Task TRevokeTokenAsync(string token);
        Task<string> TGenerateRefreshTokenAsync(AppUser user);
	}
}
