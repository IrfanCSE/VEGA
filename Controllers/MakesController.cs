using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VEGA.Data;
using VEGA.Models;
using VEGA.Models.Dtos;

namespace VEGA.Controllers
{
    [ApiController]
    [Route("api/make")]
    public class MakesController : ControllerBase
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Makes = await context.Makes.ToListAsync();
            mapper.Map<List<Make>,List<MakeDto>>(Makes);
            return Ok(Makes);
        }

    }
}