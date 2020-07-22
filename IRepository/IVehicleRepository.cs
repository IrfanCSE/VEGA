using System.Threading.Tasks;
using VEGA.Models;
using VEGA.Models.Dtos;

namespace VEGA.IRepository
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetDetails(int id);
        void Add(Vehicle vehicle);
        Task<Vehicle> Get(int id);
        void Delete(Vehicle vehicle);
    }
}