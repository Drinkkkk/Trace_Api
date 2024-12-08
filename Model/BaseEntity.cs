using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Newtonsoft.Json;
using Trace_Api.Converter;

namespace Trace_Api.Model
{
    public class BaseEntity
    {

        [JsonConverter(typeof(ChinaTimeZoneConverter))]
        public DateTime? CreateDataTime { get; set; }
        [JsonConverter(typeof(ChinaTimeZoneConverter))]
        public DateTime? UpdateDataTime { get; set; }
    }
}
