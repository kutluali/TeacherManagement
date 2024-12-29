using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.Business.Abstract;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.Business.Concrete
{
    public class RefreshTokenManager : GenericManager<RefreshToken>, IRefreshTokenService
    {
        private readonly IRefreshTokenDal _refreshTokenDal;
        public RefreshTokenManager(IGenericDal<RefreshToken> _genericDal, IRefreshTokenDal refreshTokenDal) : base(_genericDal)
        {
            _refreshTokenDal = refreshTokenDal;
        }

        public async Task TAddAsync(RefreshToken refreshToken)
        {
            await _refreshTokenDal.AddAsync(refreshToken);
        }

		public Task<string> TGenerateRefreshTokenAsync(AppUser user)
		{
			return _refreshTokenDal.GenerateRefreshTokenAsync(user);
		}

		public async Task<RefreshToken> TGetByTokenAsync(string token)
        {
            return await _refreshTokenDal.GetByTokenAsync(token);
        }

        public async Task TRevokeTokenAsync(string token)
        {
            await _refreshTokenDal.RevokeTokenAsync(token);
        }
    }
}
