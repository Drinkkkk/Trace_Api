﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Hosting;

namespace Trace_Api.Model
{
    public class Truck:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TruckID { get; set; }
        [MaxLength(50)]
        public string? LicensePlate { get; set; }
        [MaxLength(50)]
        public string? VehicleModel { get; set; }
        [MaxLength(50)]
        public string? Manufacturer { get; set; }

        public int? LoadCapacity { get; set; }

        
        [MaxLength(50)]
        public string? Status { get; set; }

        //新增
        [MaxLength(100)]
        public string? Title { get; set; }

        // Truck的内容描述
        [MaxLength(100)]
        public string? Content { get; set; }

        //导航属性
        public virtual ICollection<Trip>? Trips { get; set; }

    }
}
