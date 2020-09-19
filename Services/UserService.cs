using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stud_bud_back.Entities;
using stud_bud_back.Helpers;

namespace stud_bud_back.Services
{
	public interface IUserService : IService<User>
	{
		User Authenticate(string username, string password);
		Task<User> Create(User user, string password);
		Task<User> Update(User user, string password = null);

	}

	public class UserService : Service<User>, IUserService
	{
		private DataContext _context;

		public UserService(DataContext context) : base(context)
		{
			
		}

		public User Authenticate(string email, string password)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
				return null;

			var user = _context.Users.SingleOrDefault(x => x.Email == email);

			if (user == null)
				return null;

			if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
				return null;

			return user;
		}

		public async Task<User> Create(User user, string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new AppException("Password is required");

			if (_context.Users.Any(x => x.Email == user.Email))
				throw new AppException("Email \"" + user.Email + "\" is already taken");

			byte[] passwordHash, passwordSalt;
			CreatePasswordHash(password, out passwordHash, out passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();

			return user;
		}

		public async Task<User> Update(User userParam, string password = null)
		{
			var user = _context.Users.Find(userParam.Id);

			if (user == null)
				throw new AppException("User not found");

			if (!string.IsNullOrWhiteSpace(userParam.Email) && userParam.Email != user.Email)
			{
				if (_context.Users.Any(x => x.Email == userParam.Email))
					throw new AppException("Username " + userParam.Email + " is already taken");

				user.Email = userParam.Email;
			}

			user.FirstName = userParam.FirstName;
			user.LastName = userParam.LastName;

			byte[] passwordHash, passwordSalt;
			CreatePasswordHash(password, out passwordHash, out passwordSalt);
			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			_context.Users.Update(user);
			await _context.SaveChangesAsync();

			return user;
		}

		private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			if (password == null) throw new ArgumentNullException("password");
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

			using (var hmac = new System.Security.Cryptography.HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
		{
			if (password == null) throw new ArgumentNullException("password");
			if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
			if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
			if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

			using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				for (int i = 0; i < computedHash.Length; i++)
				{
					if (computedHash[i] != storedHash[i]) return false;
				}
			}

			return true;
		}
	}
}
