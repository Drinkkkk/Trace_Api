using Microsoft.EntityFrameworkCore;
using Trace_Api.Context;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Repository
{
    public class TruckRepository : Repository<Truck>, IRepository<Truck>
    {
        public TruckRepository(TraceContext dbContext) : base(dbContext)
        {
        }
    }
}
