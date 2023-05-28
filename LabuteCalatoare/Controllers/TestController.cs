using System;
using Microsoft.AspNetCore.Mvc;

namespace LabuteFericite.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController()
        {
        }

        [HttpGet("[action]")]
        public int Test()
        {
            return 1;
        }
    }
}
