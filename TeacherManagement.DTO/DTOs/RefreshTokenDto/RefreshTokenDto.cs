using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherManagement.DTO.DTOs.RefreshTokenDto
{
	namespace TeacherManagement.Dto
	{
		public class RefreshTokenDto
		{
			public string Token { get; set; } // Mevcut refresh token
			public string RefreshToken { get; set; } // Yeni refresh token (gerektiğinde)
		}
	}

}
