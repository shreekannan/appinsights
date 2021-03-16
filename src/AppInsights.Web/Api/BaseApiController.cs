using Microsoft.AspNetCore.Mvc;

namespace AppInsights.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
