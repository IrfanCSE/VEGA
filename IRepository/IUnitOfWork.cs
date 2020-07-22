using System.Threading.Tasks;

namespace VEGA.IRepository
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}