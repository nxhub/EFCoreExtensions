using Microsoft.AspNetCore.Mvc;

namespace EFCoreExtensions.Sample.Controllers
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
