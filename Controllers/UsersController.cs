using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using stud_bud_back.Entities;
using stud_bud_back.Helpers;

using stud_bud_back.Models.Users;
using stud_bud_back.Services;


namespace stud_bud_back.Controllers
{
	[Authorize]
	[Route("[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IUserService _userService;
		private ITokenService _tokenService;
		private IMapper _mapper;
		private readonly AppSettings _appSettings;

		public UsersController(ITokenService tokenService, IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
		{
			_tokenService = tokenService;
			_userService = userService;
			_mapper = mapper;
			_appSettings = appSettings.Value;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody]AuthenticateModel model)
		{
			var user = _userService.Authenticate(model.Email, model.Password);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			string tokenString = _tokenService.CreateJWTokenForUser(user);

			return Ok(new
			{
				Id = user.Id,
				Username = user.Email,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Token = tokenString,
			});
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public IActionResult Register([FromBody]RegisterModel model)
		{
			var user = _mapper.Map<User>(model);

			try
			{
				_userService.Create(user, model.Password);
				return Ok();
			}
			catch (AppException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var users = _userService.GetAll();
			var model = _mapper.Map<IList<UserModel>>(users);
			return Ok(model);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var user = _userService.GetById(id);
			var model = _mapper.Map<UserModel>(user);
			return Ok(model);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody]UpdateModel model)
		{
			if (int.Parse(User.Identity.Name) == id)
			{
				var user = _mapper.Map<User>(model);
				user.Id = id;

				_userService.Update(user, model.Password);
				return Ok();
			}
			else
				return BadRequest(new { message = "Something went wrong" });
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{

			if (int.Parse(User.Identity.Name) == id)
			{
				_userService.Delete(id);
				return Ok();
			}
			else
				return BadRequest(new { message = "Something went wrong" });
		}
	}
}



