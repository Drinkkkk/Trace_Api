using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Trace_Api.Model
{
    public class BaseEntity
    {
        public DateTime CreateDataTime { get; set; }
        public DateTime UpdateDataTime { get; set; }
    }
}
