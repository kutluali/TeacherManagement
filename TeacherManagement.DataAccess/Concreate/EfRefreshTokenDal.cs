using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Context;
using TeacherManagement.DataAccess.Respository;
using TeacherManagement.Entity.Entites;

namespace TeacherManagement.DataAccess.Concreate
{
    public class EfRefreshTokenDal : GenericRepository<RefreshToken>, IRefreshTokenDal
    {
        private readonly TeacherManagementContext _context;

        public EfRefreshTokenDal(TeacherManagementContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken)
        {
            if (refreshToken == null)
            {
                throw new ArgumentNullException(nameof(refreshToken), "Refresh token cannot be null.");
            }

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }
        public async Task<RefreshToken> GetByTokenAsync(string token)
        {
            return await _context.Set<RefreshToken>().FirstOrDefaultAsync(rt => rt.Token == token);
        }

        public async Task RevokeTokenAsync(string token)
        {
            var refreshToken = await GetByTokenAsync(token);
            if (refreshToken != null)
            {
                refreshToken.IsRevoked = true;
                _context.Update(refreshToken);
                await _context.SaveChangesAsync();
            }
        }
		public async Task<string> GenerateRefreshTokenAsync(AppUser user)
		{
			var refreshToken = new RefreshToken
			{
				UserId = user.Id,
				Token = Guid.NewGuid().ToString(), // Yeni token
				Expiration = DateTime.UtcNow.AddDays(7), // Token geçerlilik süresi
				IsRevoked = false
			};

			await AddAsync(refreshToken);

			return refreshToken.Token; // Yeni refresh token döndürülür
		}
	}
}
