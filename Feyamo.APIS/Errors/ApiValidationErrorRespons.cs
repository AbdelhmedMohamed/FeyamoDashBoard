namespace Feyamo.APIS.Errors
{
    public class ApiValidationErrorRespons : ApiRespons
    {
        public IEnumerable<String> Errors { get; set; }

        public ApiValidationErrorRespons():base(400)
        {
            Errors = new List<String>();
        }




    }
}
