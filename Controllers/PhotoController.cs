using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VEGA.Data;
using VEGA.IRepository;
using VEGA.Models;
using VEGA.Models.Dtos;
using VEGA.Repository;

namespace VEGA.Controllers
{
    [Route("api/vehicle/{vehicleId}/photo")]
    public class PhotoController : ControllerBase
    {
        private readonly IWebHostEnvironment host;
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;
        public PhotoController(IWebHostEnvironment host, IVehicleRepository repository, IUnitOfWork unitOfWork, IMapper mapper, VegaDbContext context)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.context = context;
            this.mapper = mapper;
            this.host = host;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId,[FromForm] IFormFile file)
        {
            var vehicle = await repository.GetVehicle(vehicleId, includRelated: false);

            if(vehicle == null)
                return NotFound();
            
            var UploadFolderPath = Path.Combine(host.WebRootPath, "Uploads");

            if (!Directory.Exists(UploadFolderPath))
                Directory.CreateDirectory(UploadFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var FilePath = Path.Combine(UploadFolderPath, fileName);

            using (var stream = new FileStream(FilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo()
            {
                FileName = fileName
            };

            vehicle.Photos.Add(photo);
            await unitOfWork.SaveAsync();

            return Ok(mapper.Map<Photo, PhotoDto>(photo));
        }
    }
}