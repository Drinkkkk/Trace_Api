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

        public DateTime? TripStartTime { get; set; }

        public DateTime? TripEndTime { get; set; }
        [MaxLength(50)]
        public string? TripStatus { get; set; }


        //导航属性
        [ForeignKey("TruckID")]
        public virtual Truck? Truck { get; set; }

        public virtual ICollection<Coordinate>? Coordinates { get; set; }
    }
}
