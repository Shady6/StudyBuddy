using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using stud_bud_back.Entities;
using stud_bud_back.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace stud_bud_back.Services
{
	public interface ITokenService
	{
		public string CreateJWTokenForUser(User user);
	}

	public class TokenService : ITokenService
	{
		private readonly AppSettings _appSettings;

		public TokenService(IOptions<AppSettings> appSettings)
		{
			_appSettings = appSettings.Value;
		}

		public string CreateJWTokenForUser(User user)
		{

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[] {
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);

			return tokenString;
		}
	}
}
