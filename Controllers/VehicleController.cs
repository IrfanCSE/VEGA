using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using VEGA.Data;
using VEGA.Models;
using System.Threading.Tasks;
using VEGA.Models.Dtos;
using AutoMapper;
using System.Collections.Generic;
using VEGA.IRepository;

namespace VEGA.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly VegaDbContext context;

        public VehicleController(IVehicleRepository repository, IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleDto vehicleDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleDto,Vehicle>(vehicleDto);

            repository.Add(vehicle);
            await context.SaveChangesAsync();

            var dto = mapper.Map<Vehicle,VehicleDto>(vehicle);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleDto vehicleDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetDetails(id);

            if (vehicle == null)
                return NotFound();

            var updateVehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto, vehicle);

            await context.SaveChangesAsync();

            var dto = mapper.Map<Vehicle, VehicleDto>(updateVehicle);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = repository.GetDetails(id);

            if(vehicle == null)
                return NotFound();

            await repository.Delete(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await repository.GetDetails(id);

            if (vehicle == null)
                return NotFound();

            var vehicleDto = mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(vehicleDto);
        }

    }
}