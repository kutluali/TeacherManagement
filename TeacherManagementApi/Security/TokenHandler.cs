using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TeacherManagement.Entity.Entites;

namespace TeacherManagementApi.Security
{
    public static class TokenHandler
    {
        public static Token CreateToken(IConfiguration configuration, AppUser user, IList<string> roles)
        {
            Token token = new Token();

            // Anahtar uzunluğunu kontrol edin
            var key = configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key) || Encoding.UTF8.GetBytes(key).Length < 32)
            {
                throw new ArgumentException("JWT Key must be at least 32 characters long.");
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Claims ekleyin
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Kullanıcı ID
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Benzersiz token ID
            };

            // Rolleri ekleyin
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            token.Expiration = DateTime.Now.AddMinutes(Convert.ToInt16(configuration["Jwt:Expiration"]));

            JwtSecurityToken jwtSecurityToken = new(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);

            byte[] numbers = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(numbers);
            token.RefreshToken = Convert.ToBase64String(numbers);

            return token;
        }

    }
}
