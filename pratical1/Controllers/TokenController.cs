using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pratical1.Data;
using pratical1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pratical1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtTokenService _tokenService;

        public TokenController(IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult GenerateToken([FromBody] DisplayPersonModel vm)
        {
            var token = _tokenService.BuildToken(vm.EmailAddreess);

            return Ok(new { token });
        }

    }
}
