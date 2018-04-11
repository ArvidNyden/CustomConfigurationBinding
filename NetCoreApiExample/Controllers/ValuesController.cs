using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetCoreApiExample.Models;

namespace NetCoreApiExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public MyConfiguration Get(IOptions<MyConfiguration> conf)
        {
            return conf.Value;
        }
    }
}
