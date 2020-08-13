using System.Collections.Generic;
using System.Threading.Tasks;
using VEGA.Models;
using VEGA.Models.Dtos;

namespace VEGA.IRepository
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehicles(Filter filter);
        Task<Vehicle> GetVehicle(int id, bool includRelated = true);
        void AddVehicle(Vehicle vehicle);
        void Delete(Vehicle vehicle);
    }
}