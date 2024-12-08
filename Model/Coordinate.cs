using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trace_Api.Model
{
    public class Coordinate:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoordinateID { get; set; }

        public int? TripID { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }
        
        public DateTime? Timestamp { get; set; }


        //导航属性
        [ForeignKey("TripID")]
        public virtual Trip? Trip { get; set; }
    }
}
