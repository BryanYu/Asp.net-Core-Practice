using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/test
        [HttpGet]
        [Route("Map1")]
        public ActionResult<string> Get()
        {
            return "value1";
        }

        // GET api/test/5
        [HttpGet("{id}")]
        [Route(("Map2"))]
        public ActionResult<string> Get(int id)
        {
            return "value2";
        }

       
    }
}
