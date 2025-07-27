
namespace Feyamo.APIS.Errors
{
    public class ApiRespons
    {

        public int StatusCode { get; set; }

        public string? Message { get; set; }


        public ApiRespons(int statuscode,string? message = null)
        {
             StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }

        private string? GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch
            {
                400 => "Bad Request",
                401 => "UnAuthorized",
                404 => "Not Found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}
