using Microsoft.EntityFrameworkCore;
using Trace_Api.Model;

namespace Trace_Api.Context
{
    public class TraceContext:DbContext
    {
        public TraceContext(DbContextOptions<TraceContext> options):base(options) 
        {
                
        }

        public DbSet<Truck>? Trucks { get; set; }
        public DbSet<Trip>? Trips { get; set; }
        public DbSet<Coordinate>? Coordinates { get; set; }
        public DbSet<User>? Users { get; set; }


    }
}
