using Microsoft.EntityFrameworkCore;
using Trace_Api.Context;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Repository
{
    public class CoordinateRepository : Repository<Coordinate>, IRepository<Coordinate>
    {
        public CoordinateRepository(TraceContext dbContext) : base(dbContext)
        {
        }
    }
}
