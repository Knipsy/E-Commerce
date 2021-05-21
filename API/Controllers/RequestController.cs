using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet("request")]
        [Authorize]
        public IActionResult Request()
        {
            return Ok();
        }
    }
}
