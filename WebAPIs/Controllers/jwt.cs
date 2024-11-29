using Business.Abstract;
using WebAPI.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class jwt : ControllerBase
    {
        
        private readonly IConfiguration _configuration;

        public jwt( IConfiguration configuration)
        {
            
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var token = TokenHandler.CreateToken( _configuration); // Token oluşturuluyor
            return Ok(token);
        }
    }
}
