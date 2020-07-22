using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VEGA.Data;
using VEGA.Models;
using VEGA.Models.Dtos;

namespace VEGA.Controllers
{
    [ApiController]
    [Route("api/model")]
    public class ModelController : ControllerBase
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public ModelController(VegaDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mod = await context.Models.Where(x => x.MakeId == id).ToListAsync();
            var mode=mapper.Map<List<Model>,List<ModelDto>>(mod);
            return Ok(mode);
        }

    }
}