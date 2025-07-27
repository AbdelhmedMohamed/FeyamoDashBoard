using Feyamo.APIS.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Feyamo.APIS.Controllers
{
    [Route("Errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Errors(int code)
        {
            if (code == 401)
            {
                return Unauthorized(new ApiRespons(401));
            }
            else if (code == 404)
            {
                return NotFound(new ApiRespons(404));
            }
            else 
                return StatusCode(code);


            
        }



    }
}
