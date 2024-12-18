namespace Trace_Api.Parameter
{
    public class QueryParameter
    {
        public int PageIndex { get; set; }
        public int PageSize {  get; set; }
        public string? Search { get; set; } = "";
    }
}
