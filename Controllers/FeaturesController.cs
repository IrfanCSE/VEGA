using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VEGA.Data;
using System.Threading.Tasks;

namespace VEGA.Controllers
{
    [ApiController]
    [Route("api/feature")]
    public class FeaturesController : ControllerBase
    {
        private readonly VegaDbContext context;
        public FeaturesController(VegaDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var features = await context.Features.ToListAsync();
            return Ok(features);
        }
    }
}