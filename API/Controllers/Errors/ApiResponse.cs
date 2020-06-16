using System;

namespace API.Controllers.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statuCode, string message=null)
        {
            StatusCode = statuCode;
            Message = message ?? GetDefaultMessageForStatusCode(StatusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Error are the path to the dark side.Errors lead to anger. Anger leads to Hate. Hate leads to career change",
                _ => null
            };
        }

    }
}