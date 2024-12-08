using Microsoft.EntityFrameworkCore;
using Trace_Api.Context;
using Trace_Api.Model;
using Trace_Api.UnitOfWork;

namespace Trace_Api.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(TraceContext dbContext) : base(dbContext)
        {
        }
    }
}
