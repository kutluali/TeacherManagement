using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Abstract
{
    public interface IRefreshTokenDal : IGenericDal<RefreshToken>
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken> GetByTokenAsync(string token);
        Task RevokeTokenAsync(string token);
		Task<string> GenerateRefreshTokenAsync(AppUser user);
	}
}
