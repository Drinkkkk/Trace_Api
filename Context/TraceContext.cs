using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;
using Trace_Api.Model;

namespace Trace_Api.Context
{
    public class TraceContext : DbContext
    {
        public TraceContext(DbContextOptions<TraceContext> options) : base(options)
        {

        }

        public DbSet<Truck>? Trucks { get; set; }
        public DbSet<Trip>? Trips { get; set; }
        public DbSet<Coordinate>? Coordinates { get; set; }
        public DbSet<User>? Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
                        modelBuilder.Entity<Truck>()
                 .HasMany(t => t.Trips) // 指定 Truck 实体中的导航属性
                 .WithOne(t => t.Truck) // 指定 Trip 实体中的导航属性，注意这里的参数应该是 t
                 .HasForeignKey(t => t.TruckID) // 指定 Trip 实体中的外键属性
                 .OnDelete(DeleteBehavior.Cascade); // 设置级联删除行为，注意这里应该使用 OnDelete 方法
            */
            // 配置 Truck 和 Trip 之间的关系，并启用级联删除
            modelBuilder.Entity<Truck>()
         .HasMany(t => t.Trips) // 指定 Truck 实体中的导航属性
         .WithOne(t => t.Truck) // 指定 Trip 实体中的导航属性
         .HasForeignKey(t => t.TruckID) // 指定 Trip 实体中的外键属性
         .OnDelete(DeleteBehavior.Cascade); // 设置级联删除行为

            // 配置 Trip 和 Coordinate 之间的关系，并启用级联删除
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Coordinates) // Trip 有一个 Coordinates 集合
                .WithOne(c => c.Trip) // Coordinate 必须有一个 Trip
                .HasForeignKey(c => c.TripID) // Coordinate 中的外键属性是 TripID
                .OnDelete(DeleteBehavior.Cascade); // 启用级联删除
        }
    }
}
