using System.Threading.Tasks;
using VEGA.IRepository;
using VEGA.Data;

namespace VEGA.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly VegaDbContext context;
        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}