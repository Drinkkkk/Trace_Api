namespace Trace_Api.IService
{
    public class ApiResponse
    {
        public ApiResponse(string Msg, bool status = false)
        {
            Message = Msg;
            Status = status;
        }
        public ApiResponse(bool status, object result)
        {
            Status = status;
            Result = result;
        }
        public string? Message { get; set; }
        public bool? Status { get; set; }
        public object? Result { get; set; }
    }
}
