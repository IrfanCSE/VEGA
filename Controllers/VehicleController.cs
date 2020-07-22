using Microsoft.AspNetCore.Mvc;
using VEGA.Models;
using System.Threading.Tasks;
using VEGA.Models.Dtos;
using AutoMapper;
using VEGA.IRepository;

namespace VEGA.Controllers
{
    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehicleController(IVehicleRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto);

            repository.AddVehicle(vehicle);
            await unitOfWork.SaveAsync();

            var VehicleDetails = await repository.GetVehicle(vehicle.Id);
            var dto = mapper.Map<Vehicle, VehicleDetailsDto>(VehicleDetails);

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var updateVehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto, vehicle);
            await unitOfWork.SaveAsync();

            var VehicleDetails = await repository.GetVehicle(id);
            var dto = mapper.Map<Vehicle, VehicleDetailsDto>(VehicleDetails);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await repository.GetVehicle(id, includRelated: false);

            if (vehicle == null)
                return NotFound();

            repository.Delete(vehicle);
            await unitOfWork.SaveAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();

            var vehicleDto = mapper.Map<Vehicle, VehicleDetailsDto>(vehicle);

            return Ok(vehicleDto);
        }

    }
}