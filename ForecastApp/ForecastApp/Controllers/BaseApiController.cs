using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
