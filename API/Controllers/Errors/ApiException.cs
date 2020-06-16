namespace API.Controllers.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statuCode, string message = null, string details = null) : base(statuCode, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}