using Microsoft.AspNetCore.Mvc;

namespace EFCoreExtensions.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string[] Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}
