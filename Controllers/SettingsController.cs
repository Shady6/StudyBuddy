using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stud_bud_back.Models;

namespace stud_bud_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SettingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("auth")]
        public ActionResult<PublicAuthSettings> GetPublicAuthSettings()
        {
            try
            {
                var dto = new PublicAuthSettings()
                {
                    Audience = _configuration.GetValue<string>("Auth:Audience"),
                    Domain = _configuration.GetValue<string>("Auth:Domain"),
                    ClientId = _configuration.GetValue<string>("Auth:ClientId")
                };
                return dto;
            }
            catch (Exception)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}