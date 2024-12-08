using Microsoft.EntityFrameworkCore;
using Trace_Api.Context;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Repository
{
    public class TripRepository : Repository<Trip>, IRepository<Trip>
    {
        public TripRepository(TraceContext dbContext) : base(dbContext)
        {
        }
    }
}
