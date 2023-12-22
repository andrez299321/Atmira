using Contracts.Business;
using Business;
using Dto.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Atmira.Controllers
{
    [Produces("application/json")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginBusiness _bLogin;
        public LoginController(ILoginBusiness bLogin)
        {
            _bLogin = bLogin;

        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginRequest userData)
        {
            var result = await _bLogin.Login(userData);
            return Ok(result);
        }
    }
}
