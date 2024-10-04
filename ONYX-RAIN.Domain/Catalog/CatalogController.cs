using Microsoft.AspNetCore.Mvc;
using Onyx.Rain.Domain.Catalog;

namespace Onyx.Rain.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
            public IActionResult GetItems()
            {
                return Ok("hello world.");
            }
    }
    
}

