using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VEGA.Models.Dtos;
using VEGA.Repository;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VEGA.Models;
using VEGA.Data;
using VEGA.IRepository;

namespace VEGA.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext context;
        public VehicleRepository(VegaDbContext context)
        {
            this.context = context;
        }
        
        public void Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }

        public async Task<Vehicle> GetDetails(int id)
        {
            return await context.Vehicles.Include(x => x.Features)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vehicle> Get(int id)
        {
            return await context.Vehicles.Where(x=>x.Id==id).FirstOrDefaultAsync();
        }
    }
}