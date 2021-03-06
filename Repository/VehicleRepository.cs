using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            if (!includRelated)
                return await context.Vehicles.FindAsync(id);

            return await context.Vehicles.Include(x => x.Features)
                        .ThenInclude(x => x.Feature)
                        .Include(x => x.Model)
                        .ThenInclude(x => x.Make)
                        .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<QueryResult<Vehicle>> GetVehicles(Filter filter)
        {
            var result = new QueryResult<Vehicle>();

            var vehicles = context.Vehicles
                .Include(x => x.Model).ThenInclude(x => x.Make)
                .Include(x => x.Features).ThenInclude(x => x.Feature)
                .AsQueryable();

            if (filter.MakeId.HasValue)
            {
                vehicles = vehicles.Where(x => x.Model.MakeId == filter.MakeId);
            }

            if (filter.ModelId.HasValue)
            {
                vehicles = vehicles.Where(x => x.ModelId == filter.ModelId);
            }

            var SortObj = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = x => x.Model.MakeId,
                ["id"] = x => x.Id,
                ["model"] = x => x.ModelId,
                ["contactName"] = x => x.ModelId
            };
            if (filter.SortBy != null)
            {
                if (filter.IsAscending)
                {
                    vehicles = vehicles.OrderBy(SortObj[filter.SortBy]);
                }
                else
                {
                    vehicles = vehicles.OrderByDescending(SortObj[filter.SortBy]);
                }
            }

            if(filter.PageSize <= 0)
                filter.PageSize=10;
            
            if(filter.Page <= 0)
                filter.Page=1;
            
            result.TotalItems = await vehicles.CountAsync();
            
            vehicles = vehicles.Skip((filter.Page-1)*filter.PageSize).Take(filter.PageSize);

            result.Items = await vehicles.ToListAsync();
            return result;

        }

    }
}