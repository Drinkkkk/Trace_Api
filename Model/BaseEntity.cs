using System;
using System.Data;

namespace Trace_Api.Model
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public DateTime CreateDataTime { get; set; }
        public DateTime UpdateDataTime { get; set; }
    }
}
