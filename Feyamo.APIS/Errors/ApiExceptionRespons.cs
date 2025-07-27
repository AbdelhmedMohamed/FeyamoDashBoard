namespace Feyamo.APIS.Errors
{
    public class ApiExceptionRespons : ApiRespons
    {
        public string? Details { get; set; }

        public ApiExceptionRespons(int statuscode, string? message = null ,string? detalis =null) :base(statuscode,message)
        {
            Details = detalis;
        }




    }
}
