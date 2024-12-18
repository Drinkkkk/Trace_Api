using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trace_Api.Model
{
    public class Trip:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripID { get; set; }

        public int? TruckID { get; set; }

        //实际开始时间
        public DateTime? TripStartTime { get; set; }

        //实际结束时间
        public DateTime? TripEndTime { get; set; }
       
        // 预计开始时间
        public DateTime? ExpectedStartTime { get; set; }

        // 预计结束时间
        public DateTime? ExpectedEndTime { get; set; }
        //Trip的标题
        [MaxLength(100)]
        public string? Title { get; set; }

        // Trip的内容描述
        [MaxLength(100)]
        public string? Content { get; set; }
        [MaxLength(50)]
        public string? TripStatus { get; set; }
        //导航属性
        [ForeignKey("TruckID")]
        public virtual Truck? Truck { get; set; }

        public virtual ICollection<Coordinate>? Coordinates { get; set; }
    }
}
