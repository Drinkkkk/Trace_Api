using Newtonsoft.Json;

namespace Trace_Api.Converter
{
    public class ChinaTimeZoneConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime)
            {
                var dateTime = (DateTime)value;
                var chinaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
                var chinaDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), chinaTimeZone);
                writer.WriteValue(chinaDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                throw new JsonSerializationException("Unexpected value type: " + value.GetType());
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}
