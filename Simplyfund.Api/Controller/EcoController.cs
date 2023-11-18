using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Simplyfund.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EcoController : ControllerBase
    {
        [HttpGet(Name = "EcoGet")]
        public  ActionResult Eco()
        {

            return CreatedAtAction(nameof(Eco), "Online");
        }
    }
}
