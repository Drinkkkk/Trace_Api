using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Trace_Api.Model
{
    public class Coordinate:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoordinateID { get; set; }

        public int? TripID { get; set; }

        [Precision(9, 6)]
        public decimal? Longitude { get; set; }
        [Precision(9, 6)]
        public decimal? Latitude { get; set; }
        
        public DateTime? Timestamp { get; set; }


        //导航属性
        [ForeignKey("TripID")]
        public virtual Trip? Trip { get; set; }
    }
}
