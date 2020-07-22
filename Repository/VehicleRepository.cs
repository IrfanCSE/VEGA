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
        
        public void AddVehicle(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            context.Remove(vehicle);
        }

        public async Task<Vehicle> GetVehicle(int id, bool includRelated = true)
        {
            if(!includRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles.Include(x => x.Features)
                        .ThenInclude(x=>x.Feature)
                        .Include(x=>x.Model)
                        .ThenInclude(x=>x.Make)
                        .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}